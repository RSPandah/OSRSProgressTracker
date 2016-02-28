using OSRS_Progress_Tracker.ItemManaging;
using OSRS_Progress_Tracker.Properties;
using System;
using System.Collections.Generic;
using OSRS_Progress_Tracker.Highscore_Tracking;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace OSRS_Progress_Tracker.Forms
{
    public partial class TaskBarMenu : Form
    {

        public NotifyIcon trayIcon;
        private ContextMenu trayMenu;
        private MenuItem exitMI;
        public ItemManager im;
        public static bool denied = false;
        public UserSettings u; 
        public Dictionary<string, Bitmap> mainMenuItems = new Dictionary<string,Bitmap>()
        {
            {"Skilling", Resources.Lumberjack_hat},
            {"Minigames", Resources.Void_melee_helm},
            {"Regular Bosses", Resources.Bandos_chestplate},
            {"Slayer Bosses", Resources.Abyssal_bludgeon},
            {"Wilderness Bosses", Resources.Pet_chaos_elemental},
            {"Treasure Trials", Resources._3rd_age_platebody},
            {"Capes", Resources.achievement_diary_cape},
            {"Pets", Resources.Chompy_pet},
            {"Achievement Diaries", Resources.Falador_shield_4},
            {"Miscellaneous", Resources.Dragon_archer_hat}


        };



        public TaskBarMenu()
        {
            InitializeComponent();

            im = new ItemManager(mainMenuItems);

            ItemContainerSaving.loadAllItems(im);
           
            trayMenu = new ContextMenu();
            MenuItem toMainProgress = new MenuItem("Main Menu");
            MenuItem settingMI = new MenuItem("Settings");
            MenuItem aboutMI = new MenuItem("About...");
            exitMI = new MenuItem("Exit");

            toMainProgress.Click += toMainProgressAction;
            exitMI.Click += exitApp;
            settingMI.Click += settingMI_Click;
            aboutMI.Click += aboutMI_Click;
            trayMenu.MenuItems.Add(toMainProgress);
            trayMenu.MenuItems.Add(settingMI);
            trayMenu.MenuItems.Add(aboutMI);
            trayMenu.MenuItems.Add(exitMI);
            // Create a tray icon. In this example we use a
            // standard system icon for simplicity, but you
            // can of course use your own custom icon too.
            trayIcon = new NotifyIcon();
            trayIcon.Text = "OSRS Progress Tracker";

            trayIcon.Icon = new Icon(Resources.Spellbook_Swap_icon, 40, 40);

            // Add menu to tray icon and show it.
            trayIcon.ContextMenu = trayMenu;
            trayIcon.Visible = true;
          

            //LOAD SETTINGS
            u = new UserSettings();
            if(SaveSettings.loadSettings() != null)
            {
                u = SaveSettings.loadSettings();
            }
            else
            {
                SaveSettings.saveSettings(this.u);
            }
            welcomeNotification();

            if (u.firstBootup)
            {
                DialogResult dialogResult = MessageBox.Show("Hello and welcome to the OSRS Progress Tracker, would you like your username tracked for some extra functionality?", "Welcome!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    MainSettingForm msf = new MainSettingForm(u, this.im);

                    FormCollection fc = Application.OpenForms;
                    bool already = false;
                    foreach (Form frm in fc)
                    {
                        if(frm is MainSettingForm)
                        {
                            already = true;

                        }
                    }

                    if (!already)
                    {
                        
                        msf.Show();
                        msf.BringToFront();
                    }
                    //FirstTimeEntry fte = new FirstTimeEntry();

                    //fte.Show();
                    //fte.TopMost = true;

                    //do something
                }
                else if (dialogResult == DialogResult.No)
                {
                    u.firstBootup = false; 
                    FormCollection fc = Application.OpenForms;
                    MainMenu mm = new MainMenu(this.im, new Point(300,300), this.u); 
                    bool already = false;
                    foreach (Form frm in fc)
                    {
                        already = true;
                    }

                    if (!already)
                    {
                         mm.fillMenu();
                         mm.Show();
                         mm.BringToFront();
                    }

                }
           }
            else
            {
                MainMenu mm = new MainMenu(this.im, new Point(300, 300), this.u);
                mm.fillMenu();
                mm.Show();
                mm.BringToFront();
            }
            

        }

        void aboutMI_Click(object sender, EventArgs e)
        {
            AboutForm af = new AboutForm();
            FormCollection fc = Application.OpenForms;
            bool already = false;
            foreach (Form frm in fc)
            {
                if (frm is AboutForm)
                {
                    already = true;

                }
            }

            if (!already)
            {
                af.Show();
                af.BringToFront();
            }
        }

        public void welcomeNotification()
        {
            this.trayIcon.BalloonTipTitle = "Hello!";
            this.trayIcon.BalloonTipText = "Thanks for using the OSRS Progress Tracker! Be sure to check the options at this menu!";
            this.trayIcon.Visible = true;
            this.trayIcon.ShowBalloonTip(10);
        }

        void settingMI_Click(object sender, EventArgs e)
        {
            MainSettingForm msf = new MainSettingForm(u, this.im);

            FormCollection fc = Application.OpenForms;
            bool already = false;
            foreach (Form frm in fc)
            {
                if (frm is MainSettingForm)
                {
                    already = true;

                }
            }

            if (!already)
            {
                msf.Show();
                msf.BringToFront();
            }
           
        }
        protected override void OnLoad(EventArgs e)
        {
            Visible = false; // Hide form window.
            ShowInTaskbar = false; // Remove from taskbar.

            base.OnLoad(e);
        }

        private void toMainProgressAction(object sender, EventArgs e)
        {
           
            MainMenu mm = new MainMenu(this.im, new Point(300, 300), this.u); 
            bool already = true;
            FormCollection fc = Application.OpenForms;
            foreach (Form frm in fc)
            {
              if(frm is MainMenu)
              {
                  already = false;
              }
            }

            if (already)
            {
                mm.fillMenu();
                mm.Show();
                mm.BringToFront();
            }


        }
        private void exitApp(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        
    }
}
