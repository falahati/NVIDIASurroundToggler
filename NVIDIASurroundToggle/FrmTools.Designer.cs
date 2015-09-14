namespace NVIDIASurroundToggle
{
    using NVIDIASurroundToggle.Resources;

    partial class FrmTools
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTools));
            this.gb_com = new System.Windows.Forms.GroupBox();
            this.btn_com_select = new System.Windows.Forms.Button();
            this.rb_com_toggle = new System.Windows.Forms.RadioButton();
            this.rb_com_extended = new System.Windows.Forms.RadioButton();
            this.rb_com_surround = new System.Windows.Forms.RadioButton();
            this.gb_app = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_app_executable = new System.Windows.Forms.Button();
            this.txt_app_executable = new System.Windows.Forms.TextBox();
            this.lbl_app_executable = new System.Windows.Forms.Label();
            this.txt_app_args = new System.Windows.Forms.TextBox();
            this.cb_app_args = new System.Windows.Forms.CheckBox();
            this.nud_app_timeout = new System.Windows.Forms.NumericUpDown();
            this.txt_app_process = new System.Windows.Forms.TextBox();
            this.cb_app_process = new System.Windows.Forms.CheckBox();
            this.btn_app_select = new System.Windows.Forms.Button();
            this.rb_app_extended = new System.Windows.Forms.RadioButton();
            this.rb_app_surround = new System.Windows.Forms.RadioButton();
            this.dialog_open = new System.Windows.Forms.OpenFileDialog();
            this.dialog_save = new System.Windows.Forms.SaveFileDialog();
            this.rb_com_tools = new System.Windows.Forms.RadioButton();
            this.rb_com_options = new System.Windows.Forms.RadioButton();
            this.gb_com.SuspendLayout();
            this.gb_app.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_app_timeout)).BeginInit();
            this.SuspendLayout();
            // 
            // gb_com
            // 
            this.gb_com.Controls.Add(this.rb_com_tools);
            this.gb_com.Controls.Add(this.rb_com_options);
            this.gb_com.Controls.Add(this.btn_com_select);
            this.gb_com.Controls.Add(this.rb_com_toggle);
            this.gb_com.Controls.Add(this.rb_com_extended);
            this.gb_com.Controls.Add(this.rb_com_surround);
            this.gb_com.Location = new System.Drawing.Point(12, 12);
            this.gb_com.Name = "gb_com";
            this.gb_com.Size = new System.Drawing.Size(343, 71);
            this.gb_com.TabIndex = 0;
            this.gb_com.TabStop = false;
            this.gb_com.Text = Language.FrmTools_Create_Shortcut__Commands;
            // 
            // btn_com_select
            // 
            this.btn_com_select.Location = new System.Drawing.Point(244, 42);
            this.btn_com_select.Name = "btn_com_select";
            this.btn_com_select.Size = new System.Drawing.Size(93, 23);
            this.btn_com_select.TabIndex = 5;
            this.btn_com_select.Text = Language.FrmTools_Place_Shortcut;
            this.btn_com_select.UseVisualStyleBackColor = true;
            this.btn_com_select.Click += new System.EventHandler(this.BtnComSelectClick);
            this.btn_com_select.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmToolsKeyDown);
            // 
            // rb_com_toggle
            // 
            this.rb_com_toggle.AutoSize = true;
            this.rb_com_toggle.Checked = true;
            this.rb_com_toggle.Location = new System.Drawing.Point(216, 19);
            this.rb_com_toggle.Name = "rb_com_toggle";
            this.rb_com_toggle.Size = new System.Drawing.Size(58, 17);
            this.rb_com_toggle.TabIndex = 2;
            this.rb_com_toggle.TabStop = true;
            this.rb_com_toggle.Text = Language.FrmTools_Toggle;
            this.rb_com_toggle.UseVisualStyleBackColor = true;
            this.rb_com_toggle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmToolsKeyDown);
            // 
            // rb_com_extended
            // 
            this.rb_com_extended.AutoSize = true;
            this.rb_com_extended.Location = new System.Drawing.Point(110, 19);
            this.rb_com_extended.Name = "rb_com_extended";
            this.rb_com_extended.Size = new System.Drawing.Size(100, 17);
            this.rb_com_extended.TabIndex = 1;
            this.rb_com_extended.Text = Language.FrmTools_Extended_Mode;
            this.rb_com_extended.UseVisualStyleBackColor = true;
            this.rb_com_extended.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmToolsKeyDown);
            // 
            // rb_com_surround
            // 
            this.rb_com_surround.AutoSize = true;
            this.rb_com_surround.Location = new System.Drawing.Point(6, 19);
            this.rb_com_surround.Name = "rb_com_surround";
            this.rb_com_surround.Size = new System.Drawing.Size(98, 17);
            this.rb_com_surround.TabIndex = 0;
            this.rb_com_surround.Text = Language.FrmTools_Surround_Mode;
            this.rb_com_surround.UseVisualStyleBackColor = true;
            this.rb_com_surround.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmToolsKeyDown);
            // 
            // gb_app
            // 
            this.gb_app.Controls.Add(this.label1);
            this.gb_app.Controls.Add(this.btn_app_executable);
            this.gb_app.Controls.Add(this.txt_app_executable);
            this.gb_app.Controls.Add(this.lbl_app_executable);
            this.gb_app.Controls.Add(this.txt_app_args);
            this.gb_app.Controls.Add(this.cb_app_args);
            this.gb_app.Controls.Add(this.nud_app_timeout);
            this.gb_app.Controls.Add(this.txt_app_process);
            this.gb_app.Controls.Add(this.cb_app_process);
            this.gb_app.Controls.Add(this.btn_app_select);
            this.gb_app.Controls.Add(this.rb_app_extended);
            this.gb_app.Controls.Add(this.rb_app_surround);
            this.gb_app.Location = new System.Drawing.Point(12, 89);
            this.gb_app.Name = "gb_app";
            this.gb_app.Size = new System.Drawing.Size(343, 149);
            this.gb_app.TabIndex = 1;
            this.gb_app.TabStop = false;
            this.gb_app.Text = Language.FrmTools_Create_Shortcut__App_Control;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(216, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = Language.FrmTools_Timeout;
            // 
            // btn_app_executable
            // 
            this.btn_app_executable.Location = new System.Drawing.Point(313, 41);
            this.btn_app_executable.Name = "btn_app_executable";
            this.btn_app_executable.Size = new System.Drawing.Size(24, 22);
            this.btn_app_executable.TabIndex = 4;
            this.btn_app_executable.Text = "...";
            this.btn_app_executable.UseVisualStyleBackColor = true;
            this.btn_app_executable.Click += new System.EventHandler(this.BtnAppExecutableClick);
            // 
            // txt_app_executable
            // 
            this.txt_app_executable.Location = new System.Drawing.Point(110, 42);
            this.txt_app_executable.Name = "txt_app_executable";
            this.txt_app_executable.ReadOnly = true;
            this.txt_app_executable.Size = new System.Drawing.Size(197, 20);
            this.txt_app_executable.TabIndex = 3;
            // 
            // lbl_app_executable
            // 
            this.lbl_app_executable.AutoSize = true;
            this.lbl_app_executable.Location = new System.Drawing.Point(3, 45);
            this.lbl_app_executable.Name = "lbl_app_executable";
            this.lbl_app_executable.Size = new System.Drawing.Size(104, 13);
            this.lbl_app_executable.TabIndex = 2;
            this.lbl_app_executable.Text = "Executable Addrress";
            // 
            // txt_app_args
            // 
            this.txt_app_args.Location = new System.Drawing.Point(110, 68);
            this.txt_app_args.Name = "txt_app_args";
            this.txt_app_args.ReadOnly = true;
            this.txt_app_args.Size = new System.Drawing.Size(227, 20);
            this.txt_app_args.TabIndex = 6;
            // 
            // cb_app_args
            // 
            this.cb_app_args.AutoSize = true;
            this.cb_app_args.Location = new System.Drawing.Point(6, 70);
            this.cb_app_args.Name = "cb_app_args";
            this.cb_app_args.Size = new System.Drawing.Size(101, 17);
            this.cb_app_args.TabIndex = 5;
            this.cb_app_args.Text = Language.FrmTools_With_Arguments;
            this.cb_app_args.UseVisualStyleBackColor = true;
            this.cb_app_args.CheckedChanged += new System.EventHandler(this.CbAppArgsCheckedChanged);
            // 
            // nud_app_timeout
            // 
            this.nud_app_timeout.Location = new System.Drawing.Point(267, 94);
            this.nud_app_timeout.Maximum = new decimal(new int[] {
            240,
            0,
            0,
            0});
            this.nud_app_timeout.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nud_app_timeout.Name = "nud_app_timeout";
            this.nud_app_timeout.ReadOnly = true;
            this.nud_app_timeout.Size = new System.Drawing.Size(70, 20);
            this.nud_app_timeout.TabIndex = 10;
            this.nud_app_timeout.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nud_app_timeout.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmToolsKeyDown);
            // 
            // txt_app_process
            // 
            this.txt_app_process.Location = new System.Drawing.Point(110, 94);
            this.txt_app_process.Name = "txt_app_process";
            this.txt_app_process.ReadOnly = true;
            this.txt_app_process.Size = new System.Drawing.Size(100, 20);
            this.txt_app_process.TabIndex = 8;
            this.txt_app_process.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmToolsKeyDown);
            // 
            // cb_app_process
            // 
            this.cb_app_process.AutoSize = true;
            this.cb_app_process.Location = new System.Drawing.Point(6, 96);
            this.cb_app_process.Name = "cb_app_process";
            this.cb_app_process.Size = new System.Drawing.Size(103, 17);
            this.cb_app_process.TabIndex = 7;
            this.cb_app_process.Text = Language.FrmTools_Waiting_Process;
            this.cb_app_process.UseVisualStyleBackColor = true;
            this.cb_app_process.CheckedChanged += new System.EventHandler(this.CbAppProcessCheckedChanged);
            this.cb_app_process.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmToolsKeyDown);
            // 
            // btn_app_select
            // 
            this.btn_app_select.Location = new System.Drawing.Point(244, 120);
            this.btn_app_select.Name = "btn_app_select";
            this.btn_app_select.Size = new System.Drawing.Size(93, 23);
            this.btn_app_select.TabIndex = 11;
            this.btn_app_select.Text = Language.FrmTools_Place_Shortcut;
            this.btn_app_select.UseVisualStyleBackColor = true;
            this.btn_app_select.Click += new System.EventHandler(this.BtnAppSelectClick);
            this.btn_app_select.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmToolsKeyDown);
            // 
            // rb_app_extended
            // 
            this.rb_app_extended.AutoSize = true;
            this.rb_app_extended.Location = new System.Drawing.Point(110, 19);
            this.rb_app_extended.Name = "rb_app_extended";
            this.rb_app_extended.Size = new System.Drawing.Size(100, 17);
            this.rb_app_extended.TabIndex = 1;
            this.rb_app_extended.Text = Language.FrmTools_Extended_Mode;
            this.rb_app_extended.UseVisualStyleBackColor = true;
            this.rb_app_extended.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmToolsKeyDown);
            // 
            // rb_app_surround
            // 
            this.rb_app_surround.AutoSize = true;
            this.rb_app_surround.Checked = true;
            this.rb_app_surround.Location = new System.Drawing.Point(6, 19);
            this.rb_app_surround.Name = "rb_app_surround";
            this.rb_app_surround.Size = new System.Drawing.Size(98, 17);
            this.rb_app_surround.TabIndex = 0;
            this.rb_app_surround.TabStop = true;
            this.rb_app_surround.Text = Language.FrmTools_Surround_Mode;
            this.rb_app_surround.UseVisualStyleBackColor = true;
            this.rb_app_surround.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmToolsKeyDown);
            // 
            // dialog_open
            // 
            this.dialog_open.DefaultExt = "exe";
            this.dialog_open.FileName = "*.exe";
            this.dialog_open.Filter = "Executable Files|*.exe";
            this.dialog_open.RestoreDirectory = true;
            this.dialog_open.SupportMultiDottedExtensions = true;
            this.dialog_open.Title = Language.FrmTools_Select_an_application_s_executable_file;
            // 
            // dialog_save
            // 
            this.dialog_save.DefaultExt = "lnk";
            this.dialog_save.DereferenceLinks = false;
            this.dialog_save.Filter = "Shortcuts|*.lnk";
            this.dialog_save.RestoreDirectory = true;
            this.dialog_save.Title = Language.FrmTools_Place_Shortcut;
            // 
            // rb_com_tools
            // 
            this.rb_com_tools.AutoSize = true;
            this.rb_com_tools.Location = new System.Drawing.Point(110, 42);
            this.rb_com_tools.Name = "rb_com_tools";
            this.rb_com_tools.Size = new System.Drawing.Size(80, 17);
            this.rb_com_tools.TabIndex = 4;
            this.rb_com_tools.Text = Language.FrmTools_Open_Tools;
            this.rb_com_tools.UseVisualStyleBackColor = true;
            // 
            // rb_com_options
            // 
            this.rb_com_options.AutoSize = true;
            this.rb_com_options.Location = new System.Drawing.Point(6, 42);
            this.rb_com_options.Name = "rb_com_options";
            this.rb_com_options.Size = new System.Drawing.Size(92, 17);
            this.rb_com_options.TabIndex = 3;
            this.rb_com_options.Text = Language.FrmTools_Open_Options;
            this.rb_com_options.UseVisualStyleBackColor = true;
            // 
            // FrmTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 248);
            this.Controls.Add(this.gb_app);
            this.Controls.Add(this.gb_com);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTools";
            this.Icon = Properties.Resources.Surround;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = Language.FrmTools_Tools;
            this.TopMost = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmToolsKeyDown);
            this.gb_com.ResumeLayout(false);
            this.gb_com.PerformLayout();
            this.gb_app.ResumeLayout(false);
            this.gb_app.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_app_timeout)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_com;
        private System.Windows.Forms.Button btn_com_select;
        private System.Windows.Forms.RadioButton rb_com_toggle;
        private System.Windows.Forms.RadioButton rb_com_extended;
        private System.Windows.Forms.RadioButton rb_com_surround;
        private System.Windows.Forms.GroupBox gb_app;
        private System.Windows.Forms.Button btn_app_select;
        private System.Windows.Forms.RadioButton rb_app_extended;
        private System.Windows.Forms.RadioButton rb_app_surround;
        private System.Windows.Forms.NumericUpDown nud_app_timeout;
        private System.Windows.Forms.TextBox txt_app_process;
        private System.Windows.Forms.CheckBox cb_app_process;
        private System.Windows.Forms.OpenFileDialog dialog_open;
        private System.Windows.Forms.TextBox txt_app_args;
        private System.Windows.Forms.CheckBox cb_app_args;
        private System.Windows.Forms.TextBox txt_app_executable;
        private System.Windows.Forms.Label lbl_app_executable;
        private System.Windows.Forms.Button btn_app_executable;
        private System.Windows.Forms.SaveFileDialog dialog_save;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rb_com_tools;
        private System.Windows.Forms.RadioButton rb_com_options;
    }
}