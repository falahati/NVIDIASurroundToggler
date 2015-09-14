namespace NVIDIASurroundToggle
{
    using System;
    using System.Drawing;
    using System.Threading;
    using System.Windows.Forms;
    using System.Windows.Threading;

    using NVIDIASurroundToggle.Native;
    using NVIDIASurroundToggle.Native.Enums;
    using NVIDIASurroundToggle.Resources;

    public partial class FrmSplash : Form
    {
        private static FrmSplash instance;

        private readonly Action action;

        private readonly bool showButtons;

        private int time = 5;

        public FrmSplash(Action action = null, bool showButtons = true)
        {
            this.InitializeComponent();
            this.FrmSplashLocationChanged(null, null);
            this.action = action;
            this.showButtons = showButtons;
            Instance = this;
        }

        public static FrmSplash Instance
        {
            get
            {
                if (instance == null)
                {
                    throw new Exception(Language.FrmSplash_There_is_no_active_splash_screen_);
                }
                return instance;
            }
            private set
            {
                instance = value;
            }
        }

        private void FrmSplashLoad(object sender, EventArgs e)
        {
            this.TopMost = true;
            Utility.ToggleTaskbar(false);
            if (!this.showButtons)
            {
                this.time = 0;
            }
            this.HiderTick(null, null);
        }

        private async void HiderTick(object sender, EventArgs e)
        {
            this.time--;
            if (this.time > 0)
            {
                this.lbl_message.Text = string.Format(Language.FrmSplash_Starting_in__0__seconds____, this.time);
                if (!this.t_hider.Enabled)
                {
                    this.t_hider.Start();
                }
            }
            else
            {
                Cursor.Hide();
                this.lbl_message.Text = Language.FrmSplash_Please_wait____;
                this.t_hider.Stop();
                this.btn_options.Visible = false;
                this.btn_tools.Visible = false;
                if (this.action != null)
                {
                    this.t_killer.Start();
                    try
                    {
                        await Dispatcher.CurrentDispatcher.BeginInvoke(this.action, null);
                    }
                    catch
                    {
                    }
                }
                this.Close();
            }
        }

        private void FrmSplashLocationChanged(object sender, EventArgs e)
        {
            this.Size = new Size(
                Methods.GetSystemMetrics(SystemMetric.WidthVirtualScreen),
                Methods.GetSystemMetrics(SystemMetric.HeightVirtualScreen));
            this.Location = new Point(
                Methods.GetSystemMetrics(SystemMetric.XVirtualScreen),
                Methods.GetSystemMetrics(SystemMetric.YVirtualScreen));
        }

        private void FrmSplashFormClosed(object sender, FormClosedEventArgs e)
        {
            this.t_hider.Stop();
            this.t_killer.Stop();
            Utility.ToggleTaskbar(true);
            Cursor.Show();
        }

        private void FrmSplashPaint(object sender, PaintEventArgs e)
        {
            this.FrmSplashLocationChanged(null, null);
        }

        private void FrmSplashKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape && this.t_hider.Enabled)
            {
                this.Close();
            }
        }

        private void KillerTick(object sender, EventArgs e)
        {
            this.lbl_message.Text = Language.FrmSplash_Failed__Closing____;
            Application.DoEvents();
            Thread.Sleep(5000);
            this.Close();
            Application.Exit();
        }

        private void BtnToolsClick(object sender, EventArgs e)
        {
            new FrmTools().Show();
            this.Close();
        }

        private void BtnOptionsClick(object sender, EventArgs e)
        {
            new FrmOptions().Show();
            this.Close();
        }
    }
}