using System;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace InfiniPad
{
    public partial class Settings : Form
    {
        private Hotkeys hkInstance;
        public Settings(Hotkeys hk)
        {
            hkInstance = hk;
            InitializeComponent();
            applySettings();
        }

        private void applySettings()
        {
            checkEnabledHotkeys.Checked         = Properties.Settings.Default.HotkeysEnabled;
            checkEnabledEdit.Checked            = Properties.Settings.Default.EditorEnabled;
            checkEnabledWatermark.Checked       = Properties.Settings.Default.WatermarkEnabled;

            textBoxPartial.Text                 = ((char)Properties.Settings.Default.PartialHotkey).ToString().ToUpper();
            textBoxMonitor.Text                 = ((char)Properties.Settings.Default.MonitorHotkey).ToString().ToUpper();
            textboxWindow.Text                  = ((char)Properties.Settings.Default.WindowHotkey).ToString().ToUpper();

            checkPartialCtrl.Checked            = (Properties.Settings.Default.PartialModifiers & KeyModifiers.MOD_CONTROL) == KeyModifiers.MOD_CONTROL;
            checkPartialShift.Checked           = (Properties.Settings.Default.PartialModifiers & KeyModifiers.MOD_SHIFT) == KeyModifiers.MOD_SHIFT;

            checkMonitorCtrl.Checked            = (Properties.Settings.Default.MonitorModifiers & KeyModifiers.MOD_CONTROL) == KeyModifiers.MOD_CONTROL;
            checkMonitorShift.Checked           = (Properties.Settings.Default.MonitorModifiers & KeyModifiers.MOD_SHIFT) == KeyModifiers.MOD_SHIFT;

            checkWindowCtrl.Checked             = (Properties.Settings.Default.WindowModifiers & KeyModifiers.MOD_CONTROL) == KeyModifiers.MOD_CONTROL;
            checkWindowShift.Checked            = (Properties.Settings.Default.WindowModifiers & KeyModifiers.MOD_SHIFT) == KeyModifiers.MOD_SHIFT;



            btnPenColor.BackColor               = Properties.Settings.Default.PenColor;
            textEdit.Text                       = Properties.Settings.Default.TextDefault;
            chkClipboard.Checked                = Properties.Settings.Default.ClipboardOnUpload;
            chkStartup.Checked                  = Properties.Settings.Default.RunOnStartup;
            chkHideStartup.Checked              = Properties.Settings.Default.HideOnStartup;

            trackOpacity.Value                  = (int)(Properties.Settings.Default.WatermarkOpacity * 100);
            trackScale.Value                    = (int)(Properties.Settings.Default.WatermarkScale * 100);

            btnOutlineColor.BackColor           = Properties.Settings.Default.OutlineColor;
            btnMeasurementColor.BackColor       = Properties.Settings.Default.MeasurementColor;


            checkMonitorCtrl.CheckedChanged     += RefreshModifiers;
            checkPartialCtrl.CheckedChanged     += RefreshModifiers;
            checkWindowCtrl.CheckedChanged      += RefreshModifiers;
            checkMonitorShift.CheckedChanged    += RefreshModifiers;
            checkPartialShift.CheckedChanged    += RefreshModifiers;
            checkWindowShift.CheckedChanged     += RefreshModifiers;
            


            RefreshEnabledStatus();

            Thread accountRefreshThread = new Thread(refreshAccountStatus);
            accountRefreshThread.Start();

            if (checkEnabledWatermark.Checked)
                RefreshImages();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        #region General
        private void chkClipboard_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ClipboardOnUpload = chkClipboard.Checked;
            Properties.Settings.Default.Save();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will reset settings to when you first started\n the program. Continue?", "InfiniPad", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Properties.Settings.Default.Reset();
                Globals.addToStartup(Properties.Settings.Default.HideOnStartup);
                applySettings();
            }
        }

        private void chkStartup_CheckedChanged(object sender, EventArgs e)
        {
            bool enabled = chkStartup.Checked;
            Properties.Settings.Default.RunOnStartup = enabled;
            Properties.Settings.Default.Save();
            Globals.addToStartup(enabled);
        }

        private void btnUninstall_Click(object sender, EventArgs e)
        {
            Globals.Uninstall();
        }

        private void chkHideStartup_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.HideOnStartup = chkHideStartup.Checked;
            Properties.Settings.Default.Save();
        }
        #endregion
        #region Hotkeys
        private void RefreshEnabledStatus()
        {
            groupHotkeys.Enabled = Properties.Settings.Default.HotkeysEnabled;
            groupEditor.Enabled = Properties.Settings.Default.EditorEnabled;
            groupWatermark.Enabled = Properties.Settings.Default.WatermarkEnabled;
        }



        private void RefreshModifiers(object sender, EventArgs e)
        {
            int PartialMod = 0;
            if (checkPartialCtrl.Checked)
                PartialMod = PartialMod | KeyModifiers.MOD_CONTROL;
            if (checkPartialShift.Checked)
                PartialMod = PartialMod | KeyModifiers.MOD_SHIFT;
            Properties.Settings.Default.PartialModifiers = PartialMod;

            int MonitorMod = 0;
            if (checkMonitorCtrl.Checked)
                MonitorMod = MonitorMod | KeyModifiers.MOD_CONTROL;
            if (checkMonitorShift.Checked)
                MonitorMod = MonitorMod | KeyModifiers.MOD_SHIFT;
            Properties.Settings.Default.MonitorModifiers = MonitorMod;

            int WindowMod = 0;
            if (checkWindowCtrl.Checked)
                WindowMod = WindowMod | KeyModifiers.MOD_CONTROL;
            if (checkWindowShift.Checked)
                WindowMod = WindowMod | KeyModifiers.MOD_SHIFT;
            Properties.Settings.Default.WindowModifiers = WindowMod;


            Properties.Settings.Default.Save();

            hkInstance.ReapplyHotkeys();
        }

        private void checkEnabledHotkeys_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.HotkeysEnabled = checkEnabledHotkeys.Checked;
            Properties.Settings.Default.Save();
            RefreshEnabledStatus();
        }



        private void textBoxChanged(object sender, KeyPressEventArgs e)
        {
            var tb = (TextBox)sender;
            int newChar = (int)(char)(e.KeyChar.ToString().ToUpper()[0]);
            if (sender == textBoxMonitor)
                Properties.Settings.Default.MonitorHotkey = newChar;
            else if (sender == textBoxPartial)
                Properties.Settings.Default.PartialHotkey = newChar;
            else if (sender == textboxWindow)
                Properties.Settings.Default.WindowHotkey = newChar;
            Properties.Settings.Default.Save();
            tb.Text = ((char)e.KeyChar).ToString().ToUpper();

            e.Handled = true;
            hkInstance.ReapplyHotkeys();
        }

        #endregion
        #region Editor

        private void checkEnabledEdit_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.EditorEnabled = checkEnabledEdit.Checked;
            Properties.Settings.Default.Save();
            RefreshEnabledStatus();
        }

        private void btnPenColor_Click(object sender, EventArgs e)
        {
            Color res = Globals.requestColorDialog(btnPenColor);
            if (res == Color.Empty)
                return;
            Properties.Settings.Default.PenColor = res;
            Properties.Settings.Default.Save();
            btnPenColor.BackColor = res;
        }

        private void textEdit_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.TextDefault = (!String.IsNullOrWhiteSpace(textEdit.Text) ? textEdit.Text : "Text");
            Properties.Settings.Default.Save();
        }
        #endregion
        #region Watermark
        private void RefreshImages()
        {
            if (checkEnabledWatermark.Checked)
                pictureWatermark.Image = PaintHelp.setOpacity(PaintHelp.getWatermark(), Properties.Settings.Default.WatermarkOpacity);
            else
                pictureWatermark.Image = null;
            GC.Collect();

        }

        private void checkEnabledWatermark_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.WatermarkEnabled = checkEnabledWatermark.Checked;
            Properties.Settings.Default.Save();
            RefreshEnabledStatus();
            RefreshImages();
        }

        private void buttonChangeWatermark_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = Imgur.FileFilter;
            ofd.Title = "Open Image";
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.WatermarkPath = ofd.FileName;
                Properties.Settings.Default.Save();
                RefreshImages();
            }
            ofd.Dispose();
        }

        private void trackOpacity_Scroll(object sender, EventArgs e)
        {
            Properties.Settings.Default.WatermarkOpacity = (float)trackOpacity.Value / 100f;
            Properties.Settings.Default.Save();
            RefreshImages();
        }


        private void trackScale_Scroll(object sender, EventArgs e)
        {
            Properties.Settings.Default.WatermarkScale = (float)trackScale.Value / 100f;
            Properties.Settings.Default.Save();
        }
        #endregion
        #region Screenshot
        private void btnOutlineColor_Click(object sender, EventArgs e)
        {
            Color col = Globals.requestColorDialog(btnOutlineColor);
            if (col == Color.Empty)
                return;
            btnOutlineColor.BackColor = col;
            Properties.Settings.Default.OutlineColor = col;
            Properties.Settings.Default.Save();
        }

        private void btnMeasurementColor_Click(object sender, EventArgs e)
        {
            Color col = Globals.requestColorDialog(btnMeasurementColor);
            if (col == Color.Empty)
                return;
            btnMeasurementColor.BackColor = col;
            Properties.Settings.Default.MeasurementColor = col;
            Properties.Settings.Default.Save();
        }
        #endregion
        #region Account
        private void btnRedirectAuth_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(APIKeys.ImgurAuthURL);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(btnConfirmHelper);
            t.Start();
        }
        private void btnConfirmHelper()
        {
            btnConfirm.Invoke((MethodInvoker)delegate
            {
                btnConfirm.Enabled = false;
            });
            string pin = textboxPin.Text;
            if (String.IsNullOrWhiteSpace(pin))
                pin = "Invalid PIN";
            Imgur.AuthInfo info = Imgur.authAccount(textboxPin.Text);
            if (info.success)
            {
                Properties.Settings.Default.account_access_token = info.access_token;
                Properties.Settings.Default.account_refresh_token = info.refresh_token;
                Properties.Settings.Default.account_id = info.account_id;
                Properties.Settings.Default.account_authed = true;
                Properties.Settings.Default.Save();
                refreshAccountStatus();
            }
            else
            {
                Globals.ErrorLog("Imgur.authAccount() Failed from btnConfirm_Click() : " + info.ex.Message, false);
            }

            btnConfirm.Invoke((MethodInvoker)delegate
            {
                btnConfirm.Enabled = true;
            });
        }

        private void refreshAccountStatus()
        {

            bool linked = Properties.Settings.Default.account_authed;
            lblLinked.InvokeIfRequired(() => {
                lblLinked.Text = linked ? "Linked!" : "Not Linked!";
                lblLinked.ForeColor = linked ? Color.Green : Color.Red;
            });


            Imgur.Account acc = new Imgur.Account();
            acc.url = "none";
            if (linked)
            {
                acc = Imgur.accountInfo(Properties.Settings.Default.account_id);
                if (!acc.success)
                {
                    Globals.ErrorLog("Imgur.accountInfo() Failed from refreshAccountStatus() : " + acc.ex.Message, false);
                    acc.url = "Failed To Retrieve Username";
                }
            }
                
            lblUsername.InvokeIfRequired(() =>
            {
                lblUsername.Text = linked ? "Signed in as " + acc.url : "";
            });

            lblAccountID.InvokeIfRequired(() =>
            {
                lblAccountID.Text = linked ? "ID: " + acc.id : "";
            });

            btnUnlink.InvokeIfRequired(() =>
            {
                btnUnlink.Visible = Properties.Settings.Default.account_authed;
            });


        }
        private void btnUnlink_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you wish to unlink your Imgur Account?", "Confirmation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Properties.Settings.Default.account_authed = false;
                Properties.Settings.Default.Save();
                refreshAccountStatus();
                Main.DisplayBubbleMessage(10, "Unlinked", "Your account has been unlinked. Complete this process in your  Settings on http://www.imgur.com");
            }
        }
    }
    #endregion


}
