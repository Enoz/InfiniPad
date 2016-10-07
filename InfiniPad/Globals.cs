using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace InfiniPad
{
    static class Globals
    {
        public static readonly string MoveToDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\InfiniPad\";
        public static readonly string logFile = MoveToDir + "log.txt";
        public static Main getMainForm()
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f is Main)
                    return (Main)f;
            }
            return null;
        }

        private static Color oldDialogPicker()
        {
            ColorDialog cd = new ColorDialog();
            cd.ShowHelp = false;
            if (cd.ShowDialog() == DialogResult.OK)
                return cd.Color;
            return Color.Empty;
        }


        public static Color requestColorDialog(Control sender)
        {
            Color res = Color.Empty;
            ContextMenuStrip cm = new ContextMenuStrip();
            var ColorDic = new Dictionary<string, Color>();

            ColorDic.Add("Red", Color.Red);
            ColorDic.Add("Blue", Color.Blue);
            ColorDic.Add("Yellow", Color.Yellow);
            ColorDic.Add("Green", Color.Green);
            ColorDic.Add("Transparent", Color.FromArgb(0, 255, 255, 255));

            foreach ( KeyValuePair<string, Color> pair in ColorDic)
            {
                Bitmap bmp = new Bitmap(10, 10);
                for(int k = 0; k < bmp.Width; k++)
                {
                    for(int v = 0; v < bmp.Height; v++)
                    {
                        bmp.SetPixel(k, v, pair.Value);
                    }
                }
                cm.Items.Add(new ToolStripMenuItem(pair.Key, bmp, (s, e) => { res = pair.Value; }));
            }
            cm.Items.Add(new ToolStripMenuItem("Custom...", new Bitmap(1, 1), (s, e) => { res = oldDialogPicker(); }));

            cm.Show(sender, sender.PointToClient(new Point(Cursor.Position.X, Cursor.Position.Y)));
            cm.Focus();
            while (cm.Visible == true) { Application.DoEvents(); }
            return res;
        }

        public static string getVersion()
        {
            return System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString().TrimEnd(new char[] { '.', '0' });
        }

        public static void addToStartup(bool enabled)
        {
            try
            {
                RegistryKey startupKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                if (enabled)
                    startupKey.SetValue("InfiniPad", Assembly.GetEntryAssembly().Location.Replace(@"\\", @"/"));
                else
                    startupKey.DeleteValue("InfiniPad");
            }
            catch (Exception ex){ ErrorLog(ex.Message, false); }//Key does not exist
            
        }

        public static void moveFile(string location)
        {

            if (Assembly.GetEntryAssembly().Location == location)
                return;

            MessageBox.Show("InfiniPad.exe will now be moved to:\n" + location, 
                "InfiniPad", 
                MessageBoxButtons.OK, 
                MessageBoxIcon.Information);

            try
            {
                if (File.Exists(location))
                    File.Delete(location);
                File.Move(Assembly.GetExecutingAssembly().Location, location);
                System.Diagnostics.Process.Start(location);
                
            }
            catch(Exception ex)
            {
                Globals.ErrorLog("moveFile() Failed: " + ex.Message + "\n\n Make sure an older version of InfiniPad is not running.", true);
            }
            Environment.Exit(0);
        }

        //http://stackoverflow.com/a/19689415
        public static void Uninstall()
        {
            if(MessageBox.Show("This will remove InfiniPad from your computer completely. Are you sure you would like to continue?",
                "InfiniPad",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    addToStartup(false); //Remove startup key
                    if (File.Exists(logFile))
                        File.Delete(logFile);
                    string batchFile = string.Empty;
                    string location = Assembly.GetExecutingAssembly().Location.Replace("/", "\\");
                    batchFile += "@echo off\n";
                    batchFile += "echo j | taskkill /f /im InfiniPad.exe\n";
                    batchFile += "echo j | del /F " + location + "\n";
                    batchFile += "echo j | rd /s /q " + MoveToDir + "\n";
                    batchFile += "echo j | del InfiniUninstall.bat";


                    File.WriteAllText("InfiniUninstall.bat", batchFile);
                    System.Diagnostics.Process.Start("InfiniUninstall.bat");
                }
                catch(Exception ex)
                {
                    Globals.ErrorLog("Globals.Uninstall() Failed: " + ex.Message, true);
                }
            }
        }

        public static void CreateMoveDir()
        {
            if (!Directory.Exists(MoveToDir))
                Directory.CreateDirectory(MoveToDir);
        }

        public static void ErrorLog(string error, bool shouldShow)
        {
            CreateMoveDir();
            using (var sw = File.Exists(logFile) ? File.AppendText(logFile) : File.CreateText(logFile))
            {
                var culture = new System.Globalization.CultureInfo("en-US");

                sw.WriteLine(string.Format("{0} -- {1}",DateTime.Now.ToString(culture),error.Replace("\n","\t")));
            }
            if (shouldShow)
                MessageBox.Show(string.Format("An error has occured:\n\n{0}",error), "InfiniPad", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //http://stackoverflow.com/questions/2367718/automating-the-invokerequired-code-pattern/12179408#12179408
        public static void InvokeIfRequired(this Control control, MethodInvoker action)
        {
            if (control.InvokeRequired)
                control.Invoke(action);
            else
                action();
        }
    }
}
