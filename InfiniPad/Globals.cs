using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace InfiniPad
{
    static class Globals
    {
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
            ColorDic.Add("Pink", Color.Pink);
            ColorDic.Add("Aqua", Color.Aqua);

            foreach ( KeyValuePair<string, Color> pair in ColorDic)
                cm.Items.Add(new ToolStripMenuItem(pair.Key, new Bitmap(1, 1), (s, e) => { res = pair.Value; }));
            cm.Items.Add(new ToolStripMenuItem("Custom...", new Bitmap(1, 1), (s, e) => { res = oldDialogPicker(); }));

            cm.Show(sender, sender.PointToClient(new Point(Cursor.Position.X, Cursor.Position.Y)));
            cm.Focus();
            while (cm.Visible == true) { Application.DoEvents(); }
            return res;
        }
    }
}
