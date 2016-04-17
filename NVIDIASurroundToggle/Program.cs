using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using NVIDIASurroundToggle.InterProcess;
using NVIDIASurroundToggle.Properties;
using NVIDIASurroundToggle.Resources;

namespace NVIDIASurroundToggle
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                if (!Service.StartService())
                {
                    throw new Exception(Language.Program_Can_not_open_a_named_pipe_for_IPC);
                }
                if (Settings.Default.FirstRun)
                {
                    var currentVersion = Settings.Default.Settings_Version;
                    Settings.Default.Upgrade();
                    if (Settings.Default.Settings_Version != currentVersion)
                    {
                        Settings.Default.Reset();
                    }
                    Settings.Default.FirstRun = false;
                    Settings.Default.Save();
                }
                if (string.IsNullOrWhiteSpace(CommandLineOptions.Default.StartFilename))
                {
                    switch (CommandLineOptions.Default.Action)
                    {
                        case CommandLineOptions.Actions.OpenOptions:
                            new FrmOptions().ShowDialog();
                            break;
                        case CommandLineOptions.Actions.OpenTools:
                            new FrmTools().ShowDialog();
                            break;
                        case CommandLineOptions.Actions.GoExtended:
                            if (Helper.IsAnyProgramActive())
                            {
                                throw new Exception(
                                    Language
                                        .Program_Another_instance_of_this_program_is_in_working_state__please_try_again_later_);
                            }
                            Surround.DisableSurround(false);
                            return;
                        case CommandLineOptions.Actions.GoSurround:
                            if (Helper.IsAnyProgramActive())
                            {
                                throw new Exception(
                                    Language
                                        .Program_Another_instance_of_this_program_is_in_working_state__please_try_again_later_);
                            }
                            Surround.EnableSurround(false);
                            return;
                        case CommandLineOptions.Actions.ToggleMode:
                            if (Helper.IsAnyProgramActive())
                            {
                                throw new Exception(
                                    Language
                                        .Program_Another_instance_of_this_program_is_in_working_state__please_try_again_later_);
                            }
                            Surround.ToggleSurround(false);
                            return;
                        case CommandLineOptions.Actions.None:
                            if (Helper.IsAnyProgramActive())
                            {
                                throw new Exception(
                                    Language
                                        .Program_Another_instance_of_this_program_is_in_working_state__please_try_again_later_);
                            }
                            Surround.ToggleSurround();
                            break;
                        default:
                            throw new Exception(Language.Program_Bad_Action_Specified);
                    }
                }
                else if (File.Exists(CommandLineOptions.Default.StartFilename))
                {
                    if (Helper.QueryStatus(InstanceStatus.Busy))
                    {
                        throw new Exception(
                            Language
                                .Program_Another_instance_of_this_program_is_in_working_state__please_try_again_later_);
                    }
                    var didWeChangedTheMode = false;
                    switch (CommandLineOptions.Default.Action)
                    {
                        case CommandLineOptions.Actions.GoExtended:
                            if (!Helper.QueryStatus(InstanceStatus.WaitingForExtendedProcess))
                            {
                                if (Helper.QueryStatus(InstanceStatus.WaitingForSurroundProcess))
                                {
                                    throw new Exception(
                                        Language
                                            .Program_You_can_t_start_a_process_in_extended_mode_when_you_have_another_process_in_surround_mode__Close_the_other_program_and_try_again);
                                }
                                didWeChangedTheMode = Surround.DisableSurround(false);
                            }
                            Service.GetInstance().Status = InstanceStatus.WaitingForExtendedProcess;
                            break;
                        case CommandLineOptions.Actions.GoSurround:
                            if (!Helper.QueryStatus(InstanceStatus.WaitingForSurroundProcess))
                            {
                                if (Helper.QueryStatus(InstanceStatus.WaitingForExtendedProcess))
                                {
                                    throw new Exception(
                                        Language
                                            .Program_You_can_t_start_a_process_in_surround_mode_when_you_have_another_process_in_extended_mode__Close_the_other_program_and_try_again);
                                }
                                didWeChangedTheMode = Surround.EnableSurround(false);
                            }
                            Service.GetInstance().Status = InstanceStatus.WaitingForSurroundProcess;
                            break;
                        default:
                            throw new ArgumentException(Language.Program_Bad_Action_Specified);
                    }
                    Utility.ContinueException(
                        () =>
                        {
                            var process = Process.Start(
                                CommandLineOptions.Default.StartFilename,
                                CommandLineOptions.Default.StartArguments);
                            Process[] processes = {process};
                            if (!string.IsNullOrWhiteSpace(CommandLineOptions.Default.StartProcess))
                            {
                                Utility.DoTimeout(
                                    () =>
                                    {
                                        processes =
                                            Process.GetProcessesByName(CommandLineOptions.Default.StartProcess);
                                        return processes.Length > 0;
                                    },
                                    CommandLineOptions.Default.StartProcessTimeout*1000);
                            }
                            foreach (var p in processes)
                            {
                                p.WaitForExit();
                            }
                        });
                    if (didWeChangedTheMode)
                    {
                        switch (CommandLineOptions.Default.Action)
                        {
                            case CommandLineOptions.Actions.GoExtended:
                                while (Helper.QueryStatus(InstanceStatus.WaitingForExtendedProcess))
                                {
                                    Thread.Sleep(500);
                                }
                                Service.GetInstance().Status = InstanceStatus.Busy;
                                Surround.EnableSurround(false);
                                break;
                            case CommandLineOptions.Actions.GoSurround:
                                while (Helper.QueryStatus(InstanceStatus.WaitingForSurroundProcess))
                                {
                                    Thread.Sleep(500);
                                }
                                Service.GetInstance().Status = InstanceStatus.Busy;
                                Surround.DisableSurround(false);
                                break;
                            default:
                                throw new ArgumentException(Language.Program_Bad_Action_Specified);
                        }
                    }
                    return;
                }
                else
                {
                    throw new ArgumentException(Language.Program_Bad_Filename_Specified);
                }
            }
            catch (Exception e)
            {
                Cursor.Show();
                Surround.Cleanup();
                Utility.ToggleTaskbar(true);
                MessageBox.Show(
                    string.Format(Language.Program_Fatal_Error_Message, e.Message),
                    Language.Program_Fatal_Error,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            new Thread(
                () =>
                {
                    while (true)
                    {
                        if (
                            !Utility.DefaultOnException(
                                () => Application.OpenForms.Cast<Form>().Any(form => form.Visible)))
                        {
                            Application.Exit();
                            return;
                        }
                        Thread.Sleep(100);
                    }
                }).Start();
            Application.Run();
        }
    }
}