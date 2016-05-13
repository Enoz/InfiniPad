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
            Color res = Color.Empty;
            cd.ShowHelp = false;
            if (cd.ShowDialog() == DialogResult.OK)
                res = cd.Color;
            cd.Dispose();
            return res;
            //need to make this a custom color picker because the default one is awful
        }
    }
}
