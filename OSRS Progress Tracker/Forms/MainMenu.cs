using OSRS_Progress_Tracker.FontManaging;
using OSRS_Progress_Tracker.Highscore_Tracking;
using OSRS_Progress_Tracker.ItemManaging;
using OSRS_Progress_Tracker.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSRS_Progress_Tracker.Forms
{
    public partial class MainMenu : Form
    {
        public ItemManager im;
        public UserSettings us;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        Font f = new Font(FontFamily.GenericMonospace, 14, FontStyle.Regular);
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        ContextMenu cm = new ContextMenu();

        public MainMenu(ItemManager im, Point spawn, UserSettings us)
        {
            this.im = im;
            this.us = us;
            InitializeComponent();
            this.DoubleBuffered = true;

            this.Icon = Resources.Gnome_child_chathead;
            StartPosition = FormStartPosition.Manual;
            this.Location = spawn;
       
            FontManager.setFont(12F);
            Font buttonFont = new Font(FontManager.customFont.FontFamily, FontManager.customFont.Size, FontStyle.Bold);
            f = buttonFont;
            TitleLabel.Font = new Font(buttonFont.FontFamily, 18);
            TitleLabel.Text = "Please select a category!";
            TitleLabel.ForeColor = Color.Yellow;

            MenuItem closePage = new MenuItem("Close main menu");
            closePage.Click += closePage_Click;
            cm.MenuItems.Add(closePage);
            this.ContextMenu = cm;

        }

        void closePage_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void fillMenu()
        {
            for (int i = 0; i < im.itemGroups.Count; i++)
            {

                string name = im.itemGroups.Keys.ElementAt(i).menuItemName;
                Label l = new Label();

                l.Location = new Point(50, 100 + (i * 40));
                l.Text = name;
                l.Font = f;
                l.ForeColor = Color.Yellow;
                l.BackColor = Color.Transparent;
                l.AutoSize = true;
                PictureBox pb = new PictureBox();
                pb.Size = new Size(36, 36);
                pb.Image = im.itemGroups.Keys.ElementAt(i).resourceImage;
                pb.BackColor = Color.Transparent;
                pb.Location = new Point(l.Location.X - pb.Size.Width, l.Location.Y - (pb.Size.Height / 5));
                pb.Name = name;
                l.Name = name;

                Label completion = new Label();

                completion.Location = new Point(200, 100 + (i * 40));
                completion.Text = name;
                completion.Font = f;
                completion.ForeColor = Color.Yellow;
                completion.BackColor = Color.Transparent;
                completion.AutoSize = true;
                int owned = 0;
                if (name != "Slayer Bosses")
                {
     
                    owned = im.getOwnedItems(name);
                }
                else
                {
                    RSItem item = im.getItem(name, "Abyssal_Sire", "Abyssal_bludgeon");
                    if (item.ownedAmount >= 1)
                    {
                        owned = im.getOwnedItems(name) + 3;
                    }
                }
                int all = im.getTotalItems(name);
                completion.Text = "(" + owned + "/" + all + ")";
                if (owned == all)
                {
                    completion.ForeColor = Color.ForestGreen;
                }
                this.Controls.Add(completion);

                this.Controls.Add(pb);
                this.Controls.Add(l);

                pb.Click += goToMenu;
                l.Click += goToMenu;
            }
        }

        void goToMenu(object sender, EventArgs e)
        {
            Control sentBy = sender as Control;
            string formName = sentBy.Name;
            ContainView cv = new ContainView(formName, this.im, this.Location, this.us);
            this.Close();
            cv.Show();
            cv.BringToFront();
        }

        public Bitmap findImageInResources(string pictureName)
        {
            Object O = Resources.ResourceManager.GetObject(pictureName);
            return (Bitmap)O;
        }

        private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

     
    }
}
