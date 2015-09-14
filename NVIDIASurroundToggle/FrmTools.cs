namespace NVIDIASurroundToggle
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Windows.Forms;

    using NVIDIASurroundToggle.Resources;

    public partial class FrmTools : Form
    {
        public FrmTools()
        {
            this.InitializeComponent();
        }

        private void FrmToolsKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                this.Close();
            }
        }

        private void CbAppProcessCheckedChanged(object sender, EventArgs e)
        {
            this.nud_app_timeout.ReadOnly = this.txt_app_process.ReadOnly = !this.cb_app_process.Checked;
            if (this.txt_app_process.ReadOnly)
            {
                if (!string.IsNullOrWhiteSpace(this.txt_app_executable.Text)
                    && File.Exists(this.txt_app_executable.Text))
                {
                    this.txt_app_process.Text = Path.GetFileNameWithoutExtension(this.txt_app_executable.Text).ToLower();
                }
                else
                {
                    this.txt_app_process.Text = string.Empty;
                }
                this.nud_app_timeout.Value = 20;
            }
        }

        private void BtnComSelectClick(object sender, EventArgs e)
        {
            string description = string.Empty;
            List<String> args = new List<string>();
            if (this.rb_com_toggle.Checked)
            {
                args.Add("-aToggleMode");
                description = Language.FrmTools_Toggles_the_display_mode_between_surround_and_extended;
            }
            else if (this.rb_com_surround.Checked)
            {
                args.Add("-aGoSurround");
                description = Language.FrmTools_Changes_the_display_mode_to_surround;
            }
            else if (this.rb_com_extended.Checked)
            {
                args.Add("-aGoExtended");
                description = Language.FrmTools_Changes_the_display_mode_to_extended;
            }
            else if (this.rb_com_options.Checked)
            {
                args.Add("-aOpenOptions");
                description = Language.FrmTools_Opens_the_program_s_configuration_screen_;
            }
            else if (this.rb_com_tools.Checked)
            {
                args.Add("-aOpenTools");
                description = Language.FrmTools_Opens_the_program_s_tools_screen_;
                ;
            }
            string argsString = string.Join(" ", args);

            if (this.dialog_save.ShowDialog(this) == DialogResult.OK)
            {
                var toolname = Application.ExecutablePath;
                if (Utility.CreateShortcut(this.dialog_save.FileName, toolname, argsString, null, description))
                {
                    MessageBox.Show(
                        Language.FrmTools_Shortcut_created_successfully_,
                        Language.FrmTools_Shortcut,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(
                        Language.FrmTools_Failed_to_create_the_shortcut__Unexpected_exception_occurred_,
                        Language.FrmTools_Shortcut,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
                this.dialog_save.FileName = string.Empty;
            }
        }

        private void BtnAppSelectClick(object sender, EventArgs e)
        {
            while (string.IsNullOrWhiteSpace(this.txt_app_executable.Text) || !File.Exists(this.txt_app_executable.Text))
            {
                this.BtnAppExecutableClick(sender, e);
                if (this.DialogResult != DialogResult.OK)
                {
                    return;
                }
            }
            string programName = Path.GetFileNameWithoutExtension(this.txt_app_executable.Text);
            string icon = string.Format("{0},0", this.txt_app_executable.Text);
            string description = string.Empty;
            List<String> args = new List<string>();
            if (this.rb_app_surround.Checked)
            {
                args.Add("-aGoSurround");
                description = string.Format(Language.FrmTools_Open__0__in_surround_mode_, programName);
            }
            else if (this.rb_app_extended.Checked)
            {
                args.Add("-aGoExtended");
                description = string.Format(Language.FrmTools_Open__0__in_extended_mode_, programName);
            }
            args.Add(string.Format("-e \"{0}\"", this.txt_app_executable.Text));
            if (this.cb_app_args.Checked && !string.IsNullOrWhiteSpace(this.txt_app_args.Text))
            {
                args.Add(string.Format("--arguments=\"{0}\"", this.txt_app_args.Text));
            }
            if (this.cb_app_process.Checked && !string.IsNullOrWhiteSpace(this.txt_app_process.Text))
            {
                args.Add(string.Format("-w \"{0}\"", this.txt_app_process.Text));
                args.Add(string.Format("-t {0}", this.nud_app_timeout.Value));
            }
            string argsString = string.Join(" ", args);

            if (this.dialog_save.ShowDialog(this) == DialogResult.OK)
            {
                var toolname = Application.ExecutablePath;
                if (Utility.CreateShortcut(this.dialog_save.FileName, toolname, argsString, icon, description))
                {
                    MessageBox.Show(
                        Language.FrmTools_Shortcut_created_successfully_,
                        Language.FrmTools_Shortcut,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(
                        Language.FrmTools_Failed_to_create_the_shortcut__Unexpected_exception_occurred_,
                        Language.FrmTools_Shortcut,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
                this.dialog_save.FileName = string.Empty;
            }
        }

        private void BtnAppExecutableClick(object sender, EventArgs e)
        {
            if (this.dialog_open.ShowDialog(this) == DialogResult.OK)
            {
                if (File.Exists(this.dialog_open.FileName) && Path.GetExtension(this.dialog_open.FileName) == ".exe")
                {
                    this.txt_app_executable.Text = this.dialog_open.FileName;
                    this.txt_app_process.Text =
                        (Path.GetFileNameWithoutExtension(this.txt_app_executable.Text) ?? string.Empty).ToLower();
                    this.dialog_open.FileName = string.Empty;
                }
                else
                {
                    MessageBox.Show(
                        Language.FrmTools_Bad_file_selected__Please_select_an_executable_file_,
                        Language.FrmTools_App_Select,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
            }
        }

        private void CbAppArgsCheckedChanged(object sender, EventArgs e)
        {
            this.txt_app_args.ReadOnly = !this.cb_app_args.Checked;
            if (this.txt_app_args.ReadOnly)
            {
                this.txt_app_args.Text = string.Empty;
            }
        }
    }
}