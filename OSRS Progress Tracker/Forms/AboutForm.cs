using OSRS_Progress_Tracker.FontManaging;
using OSRS_Progress_Tracker.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSRS_Progress_Tracker.Forms
{
    public partial class AboutForm : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public AboutForm()
        {
            InitializeComponent();
            FontManager.setFont(12F);
            this.Icon = Resources.Gnome_child_chathead;

            Font f = FontManager.customFont;
            foreach (Control c in this.Controls)
            {
                if(c.Name != informationLabel.Name)
                {
                    c.Font = f;
                }
            }
            titleLabel.Font = new Font(titleLabel.Font.FontFamily, 14F, FontStyle.Regular);
            versionLabel.Text += " 1.0";
            informationLabel.Text =
                "Application made by /u/PandahGoRawr on Reddit" + Environment.NewLine +
                "The idea originated from /u/MiniYoyo05 on Reddit" + Environment.NewLine + Environment.NewLine +
                "Source code is available at:" + Environment.NewLine;
        }

        private void setValBT_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string ConvertUrlsToLinks(string msg)
        {
            string regex = @"((www\.|(http|https|ftp|news|file)+\:\/\/)[&#95;.a-z0-9-]+\.[a-z0-9\/&#95;:@=.+?,##%&~-]*[^.|\'|\# |!|\(|?|,| |>|<|;|\)])";
            Regex r = new Regex(regex, RegexOptions.IgnoreCase);
            return r.Replace(msg, "<a href=\"$1\" title=\"Click to open in a new window or tab\" target=\"&#95;blank\">$1</a>").Replace("href=\"www", "href=\"http://www");
        }


        private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void githubLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo(githubLabel.Text);
            Process.Start(sInfo);
        }
    }
}
