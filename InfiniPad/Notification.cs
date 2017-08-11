using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfiniPad
{
    class Notification
    {
        private static NotifyIcon nfi;

        public static void Initialize()
        {
            if (nfi == null)
            {
                nfi = new NotifyIcon();
                nfi.Icon = Properties.Resources.icon;
                nfi.Visible = true;
                nfi.Text = string.Format("InfiniPad v{0}", Globals.getVersion());
                nfi.MouseClick += nfiClicked;

                ContextMenu ctm = new ContextMenu();
                ctm.MenuItems.Add("Exit", new EventHandler(nfiExit));

                nfi.ContextMenu = ctm;
            }
        }

        static Notification()
        {
            Initialize();
        }

        private static void nfiClicked(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    Main.setShouldDisplay(true);
                    Main.fmMainWindow.Show();
                    break;
            }
        }

        private static void nfiExit(object sender, EventArgs e)
        {
            Main.fmMainWindow.DisposeHotkey();
            Environment.Exit(1);
        }

        public static void DisplayBubbleMessage(int timeout, string tipTitle, string tipText)
        {
            nfi.ShowBalloonTip(timeout, tipTitle, tipText, ToolTipIcon.Info);
        }


    }
}
