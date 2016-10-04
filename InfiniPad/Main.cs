using System;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Runtime.InteropServices;

namespace InfiniPad
{
    public partial class Main : Form
    {

        #region Imports
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetForegroundWindow();

        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);
        #endregion
        public static NotifyIcon nfi;
        private Hotkeys hk;
        public Main()
        {
            InitializeComponent();
            string headerText = string.Format("InfiniPad v{0}", Globals.getVersion());
            this.Icon = Properties.Resources.icon;
            this.Text = headerText;

            hk = new Hotkeys();
            
            nfi = new NotifyIcon();
            nfi.Icon = Properties.Resources.icon;
            nfi.Visible = true;
            nfi.Text = headerText;
            nfi.MouseClick += nfiClicked;

            ContextMenu ctm = new ContextMenu();
            ctm.MenuItems.Add("Exit", new EventHandler(nfiExit));

            nfi.ContextMenu = ctm;

            hk.ReapplyHotkeys();
            Globals.CreateMoveDir();

            #region movefile
#if !DEBUG
                    Globals.moveFile(Globals.MoveToDir + "InfiniPad.exe");
#endif
            #endregion
            


        }

        private bool shouldDisplay = !Properties.Settings.Default.HideOnStartup;
        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(shouldDisplay ? value : false);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            
        }

        private void nfiExit(object sender, EventArgs e)
        {
            hk.Dispose();
            Environment.Exit(1);
        }

        private void nfiClicked(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    shouldDisplay = true;
                    this.Show();
                    break;
            }
        }

        public static void DisplayBubbleMessage(int timeout, string tipTitle, string tipText)
        {
           nfi.ShowBalloonTip(timeout, tipTitle, tipText, ToolTipIcon.Info);
        }

        public static void TakePartialScreen()
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f is PartialScreenie)
                    return;
            }
            new PartialScreenie();
        }


        public static void TakeFullScreen()
        {
            Screen scr = PaintHelp.getCursorScreen();
            Bitmap bmp = PaintHelp.GetScreen(new Point(scr.Bounds.X, scr.Bounds.Y),
                                                new Size(scr.Bounds.Width, scr.Bounds.Height));
            new editor(bmp);
        }

        public static void UploadImage()
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Title = "Open Image";
                ofd.Filter = Imgur.FileFilter;
                ofd.Multiselect = false;
                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    Bitmap bmp = new Bitmap(ofd.FileName);
                    new editor(bmp);
                }
                ofd.Dispose();
            }
        }

        public static void TakeWindowScreen()
        {
            //takes a SS of the foreground window, needs to be completed
            //dllimport -> GetForegroundWindow()
            /*var hWnd = GetForegroundWindow();
            Rectangle rectBuffer = new Rectangle();
            GetWindowRect(hWnd, ref rectBuffer);
            Bitmap bmp = PaintHelp.GetScreen(rectBuffer.Location, rectBuffer.Size);
            new editor(bmp);*/

            IntPtr hWnd = GetForegroundWindow();
            RECT recBuff;
            GetWindowRect(hWnd, out recBuff);
            Rectangle recReal = new Rectangle();
            recReal.X = recBuff.Left;
            recReal.Y = recBuff.Top;
            recReal.Width = recBuff.Right - recBuff.Left + 1;
            recReal.Height = recBuff.Bottom - recBuff.Top + 1;
            new editor(PaintHelp.GetScreen(recReal.Location, recReal.Size));

        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Properties.Settings.Default.TaskbarMessage)
            {
                MessageBox.Show("The application will now hide in the taskbar. To close the application, right click the icon and click \"Exit\"",
                    "InfiniPad",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                Properties.Settings.Default.TaskbarMessage = false;
                Properties.Settings.Default.Save();
            }
            
             
            e.Cancel = true;
            shouldDisplay = false;
            this.Hide();
        }

        private void buttonPartial_Click(object sender, EventArgs e)
        {
            TakePartialScreen();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var stngs = new Settings(hk);
            stngs.Icon = this.Icon;
            stngs.Show();
        }

        private void buttonMonitor_Click(object sender, EventArgs e)
        {
            TakeFullScreen();
        }

        private void uploadImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UploadImage();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Abt = new About();
            Abt.Icon = this.Icon;
            Abt.Show();
        }

        public void addImgurItem(Uri link, string deletehash)
        {
            if (listViewLinks.InvokeRequired)
            {
                listViewLinks.Invoke((MethodInvoker)delegate {
                    listViewLinks.Items.Add(new ListViewItem(new String[] { link.ToString(), deletehash }));
                });
                return;
            }
            listViewLinks.Items.Add(new ListViewItem(new String[] {link.ToString(), deletehash}));
        }

        private void listViewLinks_ItemActivate(object sender, EventArgs e)
        {
            var toDelete = new Imgur.ImageInfo();
            toDelete.link = new Uri(listViewLinks.SelectedItems[0].SubItems[0].Text);
            toDelete.deletehash = listViewLinks.SelectedItems[0].SubItems[1].Text;
            Imgur.deleteImage(toDelete);
            listViewLinks.SelectedItems[0].Remove();
            Main.DisplayBubbleMessage(3, "Image Deletion", "You have deleted the image located at " + toDelete.link);
            GC.Collect();
        }
    }
}
