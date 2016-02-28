using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSRS_Progress_Tracker.Highscore_Tracking
{
    public static class SaveSettings
    {
        static RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        static string folderPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "OSRS Progress Tracker")  +  "\\Settings\\";
        static string savePath = folderPath + "SavedInfo.bin";


        public static void saveSettings(UserSettings u)
        {
            if (Directory.Exists(folderPath))
            {

            }
            else
            {
                Directory.CreateDirectory(folderPath);
            }


                using (Stream stream = File.Open(savePath, FileMode.Create))
                {
                    var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    bformatter.Serialize(stream, u);
                }


                if (u.startOnBoot)
                {
                    rkApp.SetValue("OSRSTracker", "\"" + Application.ExecutablePath.ToString() + "\"");
                }
                else
                {
                    rkApp.DeleteValue("OSRSTracker", false);
                }
        }

        public static UserSettings loadSettings()
        {
            UserSettings u = new UserSettings();
            if(File.Exists(savePath))
            {
                using (Stream stream = File.Open(savePath, FileMode.Open))
                {
                    if(stream.Length > 0)
                    {
                        var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                        u = (UserSettings)bformatter.Deserialize(stream);
                        return u;
                    }
                    else
                    {
                        return null;
                    }

                }
            }

            return null;
        }

    }
}
