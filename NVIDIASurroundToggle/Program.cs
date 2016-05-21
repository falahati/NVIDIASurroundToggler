using System;
using System.Diagnostics;
using System.Globalization;
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
                if (!string.IsNullOrWhiteSpace(CommandLineOptions.Default.Language) ||
                    !string.IsNullOrWhiteSpace(Settings.Default.ControlPanelLanguage))
                {
                    try
                    {
                        NVidiaLocalization.Culture =
                            new CultureInfo(string.IsNullOrWhiteSpace(CommandLineOptions.Default.Language)
                                ? Settings.Default.ControlPanelLanguage
                                : CommandLineOptions.Default.Language);
                    }
                    catch
                    {
                        // ignored
                    }
                }
                if (string.IsNullOrWhiteSpace(CommandLineOptions.Default.StartFilename))
                {
                    switch (CommandLineOptions.Default.Action)
                    {
                        case StartupActions.OpenOptions:
                            new OptionsForm().ShowDialog();
                            break;
                        case StartupActions.OpenTools:
                            new ToolsForm().ShowDialog();
                            break;
                        case StartupActions.GoExtended:
                            if (Helper.IsAnyProgramActive())
                            {
                                throw new Exception(
                                    Language
                                        .Program_Another_instance_of_this_program_is_in_working_state__please_try_again_later_);
                            }
                            Surround.DisableSurround(false,
                                !(CommandLineOptions.Default.NoSLI || Settings.Default.DoNotPreferSLIMode));
                            return;
                        case StartupActions.GoSurround:
                            if (Helper.IsAnyProgramActive())
                            {
                                throw new Exception(
                                    Language
                                        .Program_Another_instance_of_this_program_is_in_working_state__please_try_again_later_);
                            }
                            Surround.EnableSurround(false);
                            return;
                        case StartupActions.ToggleMode:
                            if (Helper.IsAnyProgramActive())
                            {
                                throw new Exception(
                                    Language
                                        .Program_Another_instance_of_this_program_is_in_working_state__please_try_again_later_);
                            }
                            Surround.ToggleSurround(false,
                                !(CommandLineOptions.Default.NoSLI || Settings.Default.DoNotPreferSLIMode));
                            return;
                        case StartupActions.None:
                            if (Helper.IsAnyProgramActive())
                            {
                                throw new Exception(
                                    Language
                                        .Program_Another_instance_of_this_program_is_in_working_state__please_try_again_later_);
                            }
                            Surround.ToggleSurround(true,
                                !(CommandLineOptions.Default.NoSLI || Settings.Default.DoNotPreferSLIMode));
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
                        case StartupActions.GoExtended:
                            if (!Helper.QueryStatus(InstanceStatus.WaitingForExtendedProcess))
                            {
                                if (Helper.QueryStatus(InstanceStatus.WaitingForSurroundProcess))
                                {
                                    throw new Exception(
                                        Language
                                            .Program_You_can_t_start_a_process_in_extended_mode_when_you_have_another_process_in_surround_mode__Close_the_other_program_and_try_again);
                                }
                                didWeChangedTheMode = Surround.DisableSurround(false,
                                    !(CommandLineOptions.Default.NoSLI || Settings.Default.DoNotPreferSLIMode));
                            }
                            Service.GetInstance().Status = InstanceStatus.WaitingForExtendedProcess;
                            break;
                        case StartupActions.GoSurround:
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
                            case StartupActions.GoExtended:
                                while (Helper.QueryStatus(InstanceStatus.WaitingForExtendedProcess))
                                {
                                    Thread.Sleep(500);
                                }
                                Service.GetInstance().Status = InstanceStatus.Busy;
                                Surround.EnableSurround(false);
                                break;
                            case StartupActions.GoSurround:
                                while (Helper.QueryStatus(InstanceStatus.WaitingForSurroundProcess))
                                {
                                    Thread.Sleep(500);
                                }
                                Service.GetInstance().Status = InstanceStatus.Busy;
                                Surround.DisableSurround(false,
                                    !(CommandLineOptions.Default.NoSLI || Settings.Default.DoNotPreferSLIMode));
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