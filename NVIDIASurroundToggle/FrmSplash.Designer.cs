namespace NVIDIASurroundToggle
{
    using NVIDIASurroundToggle.Resources;

    partial class FrmSplash
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
            this.components = new System.ComponentModel.Container();
            this.lbl_message = new System.Windows.Forms.Label();
            this.btn_options = new System.Windows.Forms.Button();
            this.btn_tools = new System.Windows.Forms.Button();
            this.t_hider = new System.Windows.Forms.Timer(this.components);
            this.t_sizer = new System.Windows.Forms.Timer(this.components);
            this.lbl_info = new System.Windows.Forms.Label();
            this.t_killer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lbl_message
            // 
            this.lbl_message.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_message.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lbl_message.Location = new System.Drawing.Point(12, -2);
            this.lbl_message.Name = "lbl_message";
            this.lbl_message.Size = new System.Drawing.Size(487, 50);
            this.lbl_message.TabIndex = 0;
            this.lbl_message.Text = "Please wait ...";
            this.lbl_message.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_options
            // 
            this.btn_options.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_options.BackColor = System.Drawing.Color.Transparent;
            this.btn_options.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_options.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn_options.Location = new System.Drawing.Point(266, 82);
            this.btn_options.Name = "btn_options";
            this.btn_options.Size = new System.Drawing.Size(175, 35);
            this.btn_options.TabIndex = 3;
            this.btn_options.Text = global::NVIDIASurroundToggle.Resources.Language.FrmSplash__Options;
            this.btn_options.UseVisualStyleBackColor = false;
            this.btn_options.Click += new System.EventHandler(this.BtnOptionsClick);
            this.btn_options.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSplashKeyDown);
            // 
            // btn_tools
            // 
            this.btn_tools.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_tools.BackColor = System.Drawing.Color.Transparent;
            this.btn_tools.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_tools.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn_tools.Location = new System.Drawing.Point(69, 82);
            this.btn_tools.Name = "btn_tools";
            this.btn_tools.Size = new System.Drawing.Size(175, 35);
            this.btn_tools.TabIndex = 2;
            this.btn_tools.Text = global::NVIDIASurroundToggle.Resources.Language.FrmSplash__Tools;
            this.btn_tools.UseVisualStyleBackColor = false;
            this.btn_tools.Click += new System.EventHandler(this.BtnToolsClick);
            this.btn_tools.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSplashKeyDown);
            // 
            // t_hider
            // 
            this.t_hider.Interval = 1000;
            this.t_hider.Tick += new System.EventHandler(this.HiderTick);
            // 
            // t_sizer
            // 
            this.t_sizer.Enabled = true;
            this.t_sizer.Interval = 300;
            this.t_sizer.Tick += new System.EventHandler(this.FrmSplashLocationChanged);
            // 
            // lbl_info
            // 
            this.lbl_info.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_info.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lbl_info.Location = new System.Drawing.Point(12, 50);
            this.lbl_info.Name = "lbl_info";
            this.lbl_info.Size = new System.Drawing.Size(487, 18);
            this.lbl_info.TabIndex = 1;
            this.lbl_info.Text = "While I am working, do not play with mouse and keyboard. This is a serious job.";
            this.lbl_info.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // t_killer
            // 
            this.t_killer.Interval = 200000;
            this.t_killer.Tick += new System.EventHandler(this.KillerTick);
            // 
            // FrmSplash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(511, 124);
            this.Controls.Add(this.lbl_info);
            this.Controls.Add(this.btn_tools);
            this.Controls.Add(this.btn_options);
            this.Controls.Add(this.lbl_message);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSplash";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Icon = Properties.Resources.Surround;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmSplashFormClosed);
            this.Load += new System.EventHandler(this.FrmSplashLoad);
            this.LocationChanged += new System.EventHandler(this.FrmSplashLocationChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmSplashPaint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSplashKeyDown);
            this.Resize += new System.EventHandler(this.FrmSplashLocationChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_message;
        private System.Windows.Forms.Button btn_options;
        private System.Windows.Forms.Button btn_tools;
        private System.Windows.Forms.Timer t_hider;
        private System.Windows.Forms.Timer t_sizer;
        private System.Windows.Forms.Label lbl_info;
        private System.Windows.Forms.Timer t_killer;
    }
}