namespace NVIDIASurroundToggle
{
    using NVIDIASurroundToggle.Resources;

    partial class FrmOptions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_extended = new System.Windows.Forms.Button();
            this.btn_surround = new System.Windows.Forms.Button();
            this.btn_clean = new System.Windows.Forms.Button();
            this.lbl_version = new System.Windows.Forms.LinkLabel();
            this.cb_lang = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_extended
            // 
            this.btn_extended.BackColor = System.Drawing.Color.Transparent;
            this.btn_extended.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_extended.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn_extended.Location = new System.Drawing.Point(12, 12);
            this.btn_extended.Name = "btn_extended";
            this.btn_extended.Size = new System.Drawing.Size(400, 90);
            this.btn_extended.TabIndex = 0;
            this.btn_extended.Text = global::NVIDIASurroundToggle.Resources.Language.FrmOptions_I_took_a_copy_of_your_settings_last_time_you_was_in_extended_mode__So_I_may_have_an_idea_about_your_desired_configuration__Click_here_to_remove_this_data_and_to_ask_you_again_later_to_reorganize_your_setup;
            this.btn_extended.UseVisualStyleBackColor = false;
            this.btn_extended.Click += new System.EventHandler(this.BtnExtendedClick);
            this.btn_extended.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmOptionsKeyDown);
            // 
            // btn_surround
            // 
            this.btn_surround.BackColor = System.Drawing.Color.Transparent;
            this.btn_surround.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_surround.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn_surround.Location = new System.Drawing.Point(12, 108);
            this.btn_surround.Name = "btn_surround";
            this.btn_surround.Size = new System.Drawing.Size(400, 90);
            this.btn_surround.TabIndex = 1;
            this.btn_surround.Text = global::NVIDIASurroundToggle.Resources.Language.FrmOptions_I_believe_that_I_have_an_idea_about_how_you_expect_your_surround_setup_to_be__If_you_think_that_I_am_wrong__click_here_and_I_will_ask_you_about_it_the_next_time_you_tried_to_enable_the_surround_mode;
            this.btn_surround.UseVisualStyleBackColor = false;
            this.btn_surround.Click += new System.EventHandler(this.BtnSurroundClick);
            this.btn_surround.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmOptionsKeyDown);
            // 
            // btn_clean
            // 
            this.btn_clean.BackColor = System.Drawing.Color.Transparent;
            this.btn_clean.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_clean.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn_clean.Location = new System.Drawing.Point(12, 204);
            this.btn_clean.Name = "btn_clean";
            this.btn_clean.Size = new System.Drawing.Size(400, 90);
            this.btn_clean.TabIndex = 2;
            this.btn_clean.Text = global::NVIDIASurroundToggle.Resources.Language.FrmOptions_Sometimes__and_especially_when_I_get_confused__I_may_do_things_that_I_did_not_intended_to_do__Like_messing_with_your_taskbar_and_NVIDIA_control_panel__If_something_like_that_happened_to_you__click_here_and_I_do_my_best_to_make_it_right_;
            this.btn_clean.UseVisualStyleBackColor = false;
            this.btn_clean.Click += new System.EventHandler(this.BtnCleanClick);
            this.btn_clean.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmOptionsKeyDown);
            // 
            // lbl_version
            // 
            this.lbl_version.AutoSize = true;
            this.lbl_version.Location = new System.Drawing.Point(12, 324);
            this.lbl_version.Name = "lbl_version";
            this.lbl_version.Size = new System.Drawing.Size(124, 13);
            this.lbl_version.TabIndex = 5;
            this.lbl_version.TabStop = true;
            this.lbl_version.Text = "By Soroush Falahati v{0}";
            this.lbl_version.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LblVersionLinkClicked);
            // 
            // cb_lang
            // 
            this.cb_lang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_lang.FormattingEnabled = true;
            this.cb_lang.Location = new System.Drawing.Point(157, 299);
            this.cb_lang.Name = "cb_lang";
            this.cb_lang.Size = new System.Drawing.Size(255, 21);
            this.cb_lang.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 302);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "NVidia Language";
            // 
            // FrmOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(424, 346);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_lang);
            this.Controls.Add(this.lbl_version);
            this.Controls.Add(this.btn_clean);
            this.Controls.Add(this.btn_surround);
            this.Controls.Add(this.btn_extended);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = global::NVIDIASurroundToggle.Properties.Resources.Surround;
            this.Name = "FrmOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Options";
            this.TopMost = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmOptionsKeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_extended;
        private System.Windows.Forms.Button btn_surround;
        private System.Windows.Forms.Button btn_clean;
        private System.Windows.Forms.LinkLabel lbl_version;
        private System.Windows.Forms.ComboBox cb_lang;
        private System.Windows.Forms.Label label1;
    }
}