using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using NVIDIASurroundToggle.Properties;
using NVIDIASurroundToggle.Resources;

namespace NVIDIASurroundToggle
{
    public partial class FrmOptions : Form
    {
        public FrmOptions()
        {
            InitializeComponent();

            lbl_version.Text = string.Format(
                Language.FrmOptions_By_Soroush_Falahati_v,
                Assembly.GetEntryAssembly().GetName().Version.ToString(2));
            cb_lang.Items.Add(new ComboBoxItem("Windows Default") { Tag = string.Empty });
            cb_lang.Items.Add(new ComboBoxItem("English") {Tag = "en-US"});
            cb_lang.Items.Add(new ComboBoxItem("Deutsch") {Tag = "de-DE"});
            cb_lang.Items.Add(new ComboBoxItem("Dutch") {Tag = "nl-NL"});
            cb_lang.SelectedIndex = 0;
            if (!string.IsNullOrWhiteSpace(Settings.Default.ControlPanelLanguage))
            {
                var selectedLanguage = cb_lang.SelectedItem =
                    cb_lang.Items.Cast<ComboBoxItem>()
                        .FirstOrDefault(
                            item =>
                                Settings.Default.ControlPanelLanguage.Equals(item.Tag as string,
                                    StringComparison.CurrentCultureIgnoreCase));
                if (selectedLanguage == null)
                {
                    selectedLanguage = new ComboBoxItem(Settings.Default.ControlPanelLanguage)
                    {
                        Tag = Settings.Default.ControlPanelLanguage
                    };
                    cb_lang.Items.Add(selectedLanguage);
                }
                cb_lang.SelectedItem = selectedLanguage;
            }
            cb_lang.SelectedIndexChanged += cb_lang_SelectedIndexChanged;
            RefreshButtons();
        }

        private void RefreshButtons()
        {
            if (string.IsNullOrWhiteSpace(Settings.Default.DisplaySettings))
            {
                btn_extended.Enabled = false;
                btn_extended.Text =
                    Language
                        .FrmOptions_I_don_t_know_anything_about_your_monitor_arrangement_in_extended_mode__Next_time__I_will_take_a_copy_of_your_settings_before_changing_to_surround_mode;
            }
            else
            {
                btn_extended.Enabled = true;
                btn_extended.Text =
                    Language
                        .FrmOptions_I_took_a_copy_of_your_settings_last_time_you_was_in_extended_mode__So_I_may_have_an_idea_about_your_desired_configuration__Click_here_to_remove_this_data_and_to_ask_you_again_later_to_reorganize_your_setup;
            }
            if (string.IsNullOrWhiteSpace(Settings.Default.Arrangement))
            {
                btn_surround.Enabled = false;
                btn_surround.Text =
                    Language
                        .FrmOptions_I_have_no_idea_about_your_surround_settings__I_will_ask_you_about_it_the_next_time_you_tried_to_enable_the_surround_mode;
            }
            else
            {
                btn_surround.Enabled = true;
                btn_surround.Text =
                    Language
                        .FrmOptions_I_believe_that_I_have_an_idea_about_how_you_expect_your_surround_setup_to_be__If_you_think_that_I_am_wrong__click_here_and_I_will_ask_you_about_it_the_next_time_you_tried_to_enable_the_surround_mode;
            }
        }

        private void BtnExtendedClick(object sender, EventArgs e)
        {
            Settings.Default.DisplaySettings = string.Empty;
            Settings.Default.Save();
            RefreshButtons();
        }

        private void BtnSurroundClick(object sender, EventArgs e)
        {
            Settings.Default.Arrangement = string.Empty;
            Settings.Default.Save();
            RefreshButtons();
        }

        private void BtnCleanClick(object sender, EventArgs e)
        {
            Utility.ToggleTaskbar(true);
            Surround.Cleanup();
            btn_clean.Text = Language.FrmOptions_I_tried_to_solve_the_problems__you_happy_now;
            btn_clean.Enabled = false;
        }

        private void FrmOptionsKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                Close();
            }
        }

        private void LblVersionLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://falahati.net");
        }

        private void cb_lang_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = cb_lang.SelectedItem as ComboBoxItem;
            if (item != null)
            {
                Settings.Default.ControlPanelLanguage = item.Tag as string ?? Settings.Default.ControlPanelLanguage;
                Settings.Default.Save();
            }
        }
        
    }
}