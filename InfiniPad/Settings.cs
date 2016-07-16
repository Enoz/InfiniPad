using System;
using System.Windows.Forms;
using System.Drawing;

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
            checkPartialCtrl.Checked            = (Properties.Settings.Default.PartialModifiers & KeyModifiers.MOD_CONTROL) == KeyModifiers.MOD_CONTROL;
            checkPartialShift.Checked           = (Properties.Settings.Default.PartialModifiers & KeyModifiers.MOD_SHIFT) == KeyModifiers.MOD_SHIFT;

            checkMonitorCtrl.Checked            = (Properties.Settings.Default.MonitorModifiers & KeyModifiers.MOD_CONTROL) == KeyModifiers.MOD_CONTROL;
            checkMonitorShift.Checked           = (Properties.Settings.Default.MonitorModifiers & KeyModifiers.MOD_SHIFT) == KeyModifiers.MOD_SHIFT;

            btnPenColor.BackColor               = Properties.Settings.Default.PenColor;
            textEdit.Text                       = Properties.Settings.Default.TextDefault;
            chkClipboard.Checked                = Properties.Settings.Default.ClipboardOnUpload;
            chkStartup.Checked                  = Properties.Settings.Default.RunOnStartup;

            trackOpacity.Value                  = (int)(Properties.Settings.Default.WatermarkOpacity * 100);
            trackScale.Value                    = (int)(Properties.Settings.Default.WatermarkScale * 100);

            btnOutlineColor.BackColor           = Properties.Settings.Default.OutlineColor;
            btnMeasurementColor.BackColor       = Properties.Settings.Default.MeasurementColor;


            checkMonitorCtrl.CheckedChanged     += RefreshModifiers;
            checkPartialCtrl.CheckedChanged     += RefreshModifiers;
            checkMonitorShift.CheckedChanged    += RefreshModifiers;
            checkPartialShift.CheckedChanged    += RefreshModifiers;


            RefreshEnabledStatus();
            if (checkEnabledWatermark.Checked)
                RefreshImages();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private void RefreshEnabledStatus()
        {
            groupHotkeys.Enabled = Properties.Settings.Default.HotkeysEnabled;
            groupEditor.Enabled = Properties.Settings.Default.EditorEnabled;
            groupWatermark.Enabled = Properties.Settings.Default.WatermarkEnabled;
        }

        private void RefreshImages()
        {
            if (checkEnabledWatermark.Checked)
                pictureWatermark.Image = PaintHelp.setOpacity(PaintHelp.getWatermark(), Properties.Settings.Default.WatermarkOpacity);
            else
                pictureWatermark.Image = null;
            GC.Collect();

        }

        private void RefreshModifiers(object sender, EventArgs e)
        {
            int PartialMod = 0;
            if (checkPartialCtrl.Checked)
                PartialMod = PartialMod | KeyModifiers.MOD_CONTROL;
            if (checkPartialShift.Checked)
                PartialMod = PartialMod | KeyModifiers.MOD_SHIFT;
            Properties.Settings.Default.PartialModifiers = PartialMod;
            Properties.Settings.Default.Save();

            int MonitorMod = 0;
            if (checkMonitorCtrl.Checked)
                MonitorMod = MonitorMod | KeyModifiers.MOD_CONTROL;
            if (checkMonitorShift.Checked)
                MonitorMod = MonitorMod | KeyModifiers.MOD_SHIFT;
            Properties.Settings.Default.MonitorModifiers = MonitorMod;
            Properties.Settings.Default.Save();
            
            hkInstance.ReapplyHotkeys();
        }

        private void checkEnabledHotkeys_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.HotkeysEnabled = checkEnabledHotkeys.Checked;
            Properties.Settings.Default.Save();
            RefreshEnabledStatus();
        }

        private void checkEnabledEdit_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.EditorEnabled = checkEnabledEdit.Checked;
            Properties.Settings.Default.Save();
            RefreshEnabledStatus();
        }

        private void checkEnabledWatermark_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.WatermarkEnabled = checkEnabledWatermark.Checked;
            Properties.Settings.Default.Save();
            RefreshEnabledStatus();
            RefreshImages();
        }


        private void textBoxChanged(object sender, KeyPressEventArgs e)
        {
            var tb = (TextBox)sender;
            int newChar = (int)(char)(e.KeyChar.ToString().ToUpper()[0]);
            if(sender == textBoxMonitor)
            {
                Properties.Settings.Default.MonitorHotkey = newChar;
            }
            else if (sender == textBoxPartial)
            {
                Properties.Settings.Default.PartialHotkey = newChar;
            }
            Properties.Settings.Default.Save();
            tb.Text = ((char)e.KeyChar).ToString().ToUpper();
            
            e.Handled = true;
            hkInstance.ReapplyHotkeys();
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

        private void buttonChangeWatermark_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = Upload.FileFilter;
            ofd.Title = "Open Image";
            ofd.Multiselect = false;
            if(ofd.ShowDialog() == DialogResult.OK)
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

        private void textEdit_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.TextDefault = (!String.IsNullOrWhiteSpace(textEdit.Text) ? textEdit.Text : "Text");
            Properties.Settings.Default.Save();
        }

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

        private void chkClipboard_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ClipboardOnUpload = chkClipboard.Checked;
            Properties.Settings.Default.Save();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("This will reset settings to when you first started\n the program. Continue?", "InfiniPad", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes){
                Properties.Settings.Default.Reset();
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
    }
}
