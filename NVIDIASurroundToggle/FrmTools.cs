using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using NVIDIASurroundToggle.Resources;

namespace NVIDIASurroundToggle
{
    public partial class FrmTools : Form
    {
        public FrmTools()
        {
            InitializeComponent();
        }

        private void FrmToolsKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                Close();
            }
        }

        private void CbAppProcessCheckedChanged(object sender, EventArgs e)
        {
            nud_app_timeout.ReadOnly = txt_app_process.ReadOnly = !cb_app_process.Checked;
            if (txt_app_process.ReadOnly)
            {
                if (!string.IsNullOrWhiteSpace(txt_app_executable.Text)
                    && File.Exists(txt_app_executable.Text))
                {
                    txt_app_process.Text = Path.GetFileNameWithoutExtension(txt_app_executable.Text).ToLower();
                }
                else
                {
                    txt_app_process.Text = string.Empty;
                }
                nud_app_timeout.Value = 20;
            }
        }

        private void BtnComSelectClick(object sender, EventArgs e)
        {
            var description = string.Empty;
            var args = new List<string>();
            if (rb_com_toggle.Checked)
            {
                args.Add("-aToggleMode");
                description = Language.FrmTools_Toggles_the_display_mode_between_surround_and_extended;
            }
            else if (rb_com_surround.Checked)
            {
                args.Add("-aGoSurround");
                description = Language.FrmTools_Changes_the_display_mode_to_surround;
            }
            else if (rb_com_extended.Checked)
            {
                args.Add("-aGoExtended");
                description = Language.FrmTools_Changes_the_display_mode_to_extended;
            }
            else if (rb_com_options.Checked)
            {
                args.Add("-aOpenOptions");
                description = Language.FrmTools_Opens_the_program_s_configuration_screen;
            }
            else if (rb_com_tools.Checked)
            {
                args.Add("-aOpenTools");
                description = Language.FrmTools_Opens_the_program_s_tools_screen;
            }
            var argsString = string.Join(" ", args);

            if (dialog_save.ShowDialog(this) == DialogResult.OK)
            {
                var toolname = Application.ExecutablePath;
                if (Utility.CreateShortcut(dialog_save.FileName, toolname, argsString, null, description))
                {
                    MessageBox.Show(
                        Language.FrmTools_Shortcut_created_successfully,
                        Language.FrmTools_Shortcut,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(
                        Language.FrmTools_Failed_to_create_the_shortcut__Unexpected_exception_occurred,
                        Language.FrmTools_Shortcut,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
                dialog_save.FileName = string.Empty;
            }
        }

        private void BtnAppSelectClick(object sender, EventArgs e)
        {
            while (string.IsNullOrWhiteSpace(txt_app_executable.Text) || !File.Exists(txt_app_executable.Text))
            {
                BtnAppExecutableClick(sender, e);
                if (DialogResult != DialogResult.OK)
                {
                    return;
                }
            }
            var programName = Path.GetFileNameWithoutExtension(txt_app_executable.Text);
            var icon = $"{txt_app_executable.Text},0";
            var description = string.Empty;
            var args = new List<string>();
            if (rb_app_surround.Checked)
            {
                args.Add("-aGoSurround");
                description = string.Format(Language.FrmTools_Open_in_surround_mode, programName);
            }
            else if (rb_app_extended.Checked)
            {
                args.Add("-aGoExtended");
                description = string.Format(Language.FrmTools_Open_in_extended_mode, programName);
            }
            args.Add($"-e \"{txt_app_executable.Text}\"");
            if (cb_app_args.Checked && !string.IsNullOrWhiteSpace(txt_app_args.Text))
            {
                args.Add($"--arguments=\"{txt_app_args.Text}\"");
            }
            if (cb_app_process.Checked && !string.IsNullOrWhiteSpace(txt_app_process.Text))
            {
                args.Add($"-w \"{txt_app_process.Text}\"");
                args.Add($"-t {nud_app_timeout.Value}");
            }
            var argsString = string.Join(" ", args);

            if (dialog_save.ShowDialog(this) == DialogResult.OK)
            {
                var toolname = Application.ExecutablePath;
                if (Utility.CreateShortcut(dialog_save.FileName, toolname, argsString, icon, description))
                {
                    MessageBox.Show(
                        Language.FrmTools_Shortcut_created_successfully,
                        Language.FrmTools_Shortcut,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(
                        Language.FrmTools_Failed_to_create_the_shortcut__Unexpected_exception_occurred,
                        Language.FrmTools_Shortcut,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
                dialog_save.FileName = string.Empty;
            }
        }

        private void BtnAppExecutableClick(object sender, EventArgs e)
        {
            if (dialog_open.ShowDialog(this) == DialogResult.OK)
            {
                if (File.Exists(dialog_open.FileName) && Path.GetExtension(dialog_open.FileName) == ".exe")
                {
                    txt_app_executable.Text = dialog_open.FileName;
                    txt_app_process.Text =
                        (Path.GetFileNameWithoutExtension(txt_app_executable.Text) ?? string.Empty).ToLower();
                    dialog_open.FileName = string.Empty;
                }
                else
                {
                    MessageBox.Show(
                        Language.FrmTools_Bad_file_selected__Please_select_an_executable_file,
                        Language.FrmTools_App_Select,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
            }
        }

        private void CbAppArgsCheckedChanged(object sender, EventArgs e)
        {
            txt_app_args.ReadOnly = !cb_app_args.Checked;
            if (txt_app_args.ReadOnly)
            {
                txt_app_args.Text = string.Empty;
            }
        }
    }
}