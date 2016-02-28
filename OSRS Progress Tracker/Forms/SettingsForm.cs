using OSRS_Progress_Tracker.FontManaging;
using OSRS_Progress_Tracker.Highscore_Tracking;
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
    public partial class SettingsForm : Form
    {

        bool ironManIsChecked = false;
        bool ult_ironManIsChecked = false;
        Font f;
        TaskBarMenu startMenu;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public SettingsForm(TaskBarMenu startMenu)
        {
            this.startMenu = startMenu;
            InitializeComponent();
            FontManager.setFont(12F);

            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            this.Icon = Resources.Gnome_child_chathead;

            this.f = FontManager.customFont;
            titleLabel.Font = new Font(f.FontFamily, 16, FontStyle.Bold);
            userNameLabel.Font = f;
            UserTB.Font = f;




            ironmanBT.Font = userNameLabel.Font;
            ult_IronmanBT.Font = userNameLabel.Font;
            saveBT.Font = userNameLabel.Font;
            clearAllBT.Font = saveBT.Font;

            bootCB.Font = f;
            useUsernameCB.Font = f;

            ironmanBT.Checked = UserSettings.isIronMan;
            ult_IronmanBT.Checked = UserSettings.isUltimateIronMan;
            useUsernameCB.Checked = UserSettings.useUserName;
            bootCB.Checked = UserSettings.startOnBoot;

            if (UserSettings.firstBootup)
            {
                useUsernameCB.Checked = true;
            }

            ironmanBT.CheckedChanged += normal_iron_radioBT_CheckedChanged;
            ironmanBT.Click += normal_iron_radioBT_Click;

            ult_IronmanBT.CheckedChanged += ult_iron_radioBT_CheckedChanged;
            ult_IronmanBT.Click += ult_iron_radioBT_Click;

            if (UserSettings.UserName != "")
            {
                bool exists = HighScoreReceiver.checkFirstUsername(UserSettings.UserName, UserSettings.isIronMan, UserSettings.isUltimateIronMan);
                if (exists)
                {

                }
                else
                {
                    MessageBox.Show("Your current username: (" + UserSettings.UserName + ") is either set incorrectly or doesn't exist!");
                }
                UserTB.Text = UserSettings.UserName;

            }
        }
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }

            base.WndProc(ref m);
        }

        void ult_iron_radioBT_Click(object sender, EventArgs e)
        {
            if (ult_IronmanBT.Checked && !ult_ironManIsChecked)
                ult_IronmanBT.Checked = false;
            else
            {
                ult_IronmanBT.Checked = true;
                ult_ironManIsChecked = false;
            }
        }

        void ult_iron_radioBT_CheckedChanged(object sender, EventArgs e)
        {
            ult_ironManIsChecked = ult_IronmanBT.Checked;
        }

        void normal_iron_radioBT_Click(object sender, EventArgs e)
        {
            if (ironmanBT.Checked && !ironManIsChecked)
                ironmanBT.Checked = false;
            else
            {
                ironmanBT.Checked = true;
                ironManIsChecked = false;
            }
        }

        void normal_iron_radioBT_CheckedChanged(object sender, EventArgs e)
        {
            ironManIsChecked = ironmanBT.Checked;
        }

        private void saveBT_Click(object sender, EventArgs e)
        {
            try
            {
                bool shouldClose = true;
                UserSettings.UserName = UserTB.Text;
                UserSettings.useUserName = useUsernameCB.Checked;
                UserSettings.isIronMan = ironmanBT.Checked;
                UserSettings.isUltimateIronMan = ult_IronmanBT.Checked;
                UserSettings.startOnBoot = bootCB.Checked;
                UserSettings.useUserName = useUsernameCB.Checked;



                //if (UserSettings.useUserName)
                //{
                //    if (HighScoreReceiver.checkFirstUsername(UserSettings.UserName, UserSettings.isIronMan, UserSettings.isUltimateIronMan))
                //    {
                //        shouldClose = true;
                //    }
                //    else
                //    {
                //        MessageBox.Show("Something went wrong while looking for the username, please check your settings!");
                //        shouldClose = false;
                //    }
                //    //setSkillcapeBoxes
                //}

                if (shouldClose)
                {
                    //MainMenu mm = new MainMenu(this.startMenu.im);
                    //bool already = true;
                    //FormCollection fc = Application.OpenForms;
                    //foreach (Form frm in fc)
                    //{
                    //    if (frm is MainMenu)
                    //    {
                    //        already = false;
                    //    }
                    //}

                    //if (already)
                    //{
                    //    mm.Show();
                    //    mm.BringToFront();
                    //}
                    UserSettings.firstBootup = false;
                    SaveSettings.saveUserSettings();

                    this.Close();

                }





            }
            catch (Exception evc)
            {
                MessageBox.Show("Please only enter numbers for setting numbers!");
                MessageBox.Show(evc.Message);
            }
        }

        private void clearAllBT_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you really want to clear all items?", "Are you realllly sure?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (this.startMenu.im != null)
                {
                    if (this.startMenu.im.itemGroups != null)
                    {
                        this.startMenu.im.clearAll();
                    }
                }
                //CLEAR ALLLL.
            }
            else if (dialogResult == DialogResult.No)
            {

            }
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
