using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;

namespace InfiniPad
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            pictureIcon.Image = new Icon(Properties.Resources.icon, 256, 256).ToBitmap();
            labelVersion.Text = "Version: " + Assembly.GetEntryAssembly().GetName().Version;
        }

        private void btnGitHub_Click(object sender, System.EventArgs e)
        {
            Process.Start("https://github.com/Enoz/InfiniPad");
        }

        private void btnImgur_Click(object sender, System.EventArgs e)
        {
            Process.Start("https://api.imgur.com/");
        }

        private void About_Load(object sender, System.EventArgs e)
        {
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }
    }
}
