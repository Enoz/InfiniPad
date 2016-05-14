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

        public static Color requestColorDialog()
        {
            ColorDialog cd = new ColorDialog();
            cd.ShowHelp = false;
            if (cd.ShowDialog() == DialogResult.OK)
                return cd.Color;
            return Color.Empty;
        }
    }
}
