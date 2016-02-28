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
    public partial class MainSettingForm : Form
    {

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();



        UserSettings settings;
        ItemManager itemManager;
        bool ironManIsChecked = false;
        bool ult_ironManIsChecked = false;




        public MainSettingForm(UserSettings us, ItemManager im)
        {
            InitializeComponent();
            this.Icon = Resources.Gnome_child_chathead;
            this.settings = us;
            this.itemManager = im;
            usernameTB.Text = us.UserName;
            normal_iron_radioBT.Checked = us.isIronMan;
            ult_iron_radioBT.Checked = us.isUltimateIronMan;
            BootOnStartCB.Checked = us.startOnBoot;
            useUsernameCB.Checked = us.useUserName;

            FontManager.setFont(12F);
            Font f = FontManager.customFont;
            foreach(Control c in this.Controls)
            {
                c.Font = f;
            }

            titleLabel.Font = new Font(titleLabel.Font.FontFamily, 14, FontStyle.Regular);

            normal_iron_radioBT.CheckedChanged += normal_iron_radioBT_CheckedChanged;
            normal_iron_radioBT.Click += normal_iron_radioBT_Click;
            ult_iron_radioBT.CheckedChanged += ult_iron_radioBT_CheckedChanged;
            ult_iron_radioBT.Click += ult_iron_radioBT_Click;
        }

        private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }


        void ult_iron_radioBT_Click(object sender, EventArgs e)
        {
            if (ult_iron_radioBT.Checked && !ult_ironManIsChecked)
                ult_iron_radioBT.Checked = false;
            else
            {
                ult_iron_radioBT.Checked = true;
                ult_ironManIsChecked = false;
            }
        }

        void ult_iron_radioBT_CheckedChanged(object sender, EventArgs e)
        {
            ult_ironManIsChecked = ult_iron_radioBT.Checked;
        }

        void normal_iron_radioBT_Click(object sender, EventArgs e)
        {
            if (normal_iron_radioBT.Checked && !ironManIsChecked)
                normal_iron_radioBT.Checked = false;
            else
            {
                normal_iron_radioBT.Checked = true;
                ironManIsChecked = false;
            }
        }

        void normal_iron_radioBT_CheckedChanged(object sender, EventArgs e)
        {
            ironManIsChecked = normal_iron_radioBT.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
               DialogResult dialogResult = MessageBox.Show("Clear all lad?", "Welcome!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                   itemManager.clearAll();
                    //this.itemManager;
                }
                else if(dialogResult == DialogResult.No)
                {

                }
        }

        private void returnBT_Click(object sender, EventArgs e)
        {
            //try
            //{
                string username = usernameTB.Text;
                bool isironMan = normal_iron_radioBT.Checked;
                bool isUlt = ult_iron_radioBT.Checked;
                bool startup = BootOnStartCB.Checked;
                bool useUsername = useUsernameCB.Checked;

                if(useUsername)
                {
                    bool checkForUsername = HighScoreReceiver.checkFirstUsername(username, isironMan, isUlt);
                    if (checkForUsername)
                    {
                        settings.UserName = username;
                        settings.isIronMan = isironMan;
                        settings.isUltimateIronMan = isUlt;
                        settings.firstBootup = false;
                        settings.useUserName = useUsername;
                        settings.startOnBoot = startup;

                        MainMenu mm = new MainMenu(this.itemManager, new Point(300, 300), this.settings);
                        FormCollection fc = Application.OpenForms;
                        bool already = false;
                        foreach (Form frm in fc)
                        {
                            if (frm is MainMenu)
                            {
                                already = true;
                                MainMenu m = frm as MainMenu;
                                m.us = settings;
                                m.fillMenu();
                            }
                        }

                        if (!already)
                        {
                            mm.fillMenu();
                            mm.Show();
                            mm.BringToFront();
                        }

                        SaveSettings.saveSettings(this.settings);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("The username can't be found, please check your settings!");
                    }
                }
                else
                {
                    settings.UserName = username;
                    settings.isIronMan = isironMan;
                    settings.isUltimateIronMan = isUlt;
                    settings.firstBootup = false;
                    settings.useUserName = useUsername;
                    settings.startOnBoot = startup;


                    MainMenu mm = new MainMenu(this.itemManager, new Point(300, 300), this.settings);
                    FormCollection fc = Application.OpenForms;
                    bool already = false;
                    foreach (Form frm in fc)
                    {
                        if (frm is MainMenu)
                        {
                            already = true;
                            MainMenu m = frm as MainMenu;
                            m.us = settings;
                            m.fillMenu();
                        }
                    }

                    if (!already)
                    {
                        mm.fillMenu();
                        mm.Show();
                        mm.BringToFront();
                    }

                    SaveSettings.saveSettings(this.settings);
                    this.Close();
                }
               
            //}
            //catch(Exception exc)
            //{
            //    MessageBox.Show("Something went wrong, please check your settings again");
            //    MessageBox.Show(exc.Message);
            //}

        }



    }
}
