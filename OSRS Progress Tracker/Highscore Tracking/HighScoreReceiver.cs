using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSRS_Progress_Tracker.Highscore_Tracking
{
    class HighScoreReceiver
    {
        public static string osrs_normal_acc = "http://services.runescape.com/m=hiscore_oldschool/index_lite.ws?player=";
        public static string osrs_ironman = "http://services.runescape.com/m=hiscore_oldschool_ironman/index_lite.ws?player=";
        public static string osrs_ult_ironman = "http://services.runescape.com/m=hiscore_oldschool_ultimate/index_lite.ws?player=";
        public static Dictionary<string, bool> playerStatsChecked;
        public static bool isMaxed = false;
        public static string[] skillNamesInOrder = new string[]
        {
            "Overall",
            "Attack",
            "Defence",
            "Strength",
            "Hitpoints",
            "Ranged",
            "Prayer",
            "Magic",
            "Cooking",
            "Woodcutting",
            "Fletching",
            "Fishing",
            "Firemaking",
            "Crafting",
            "Smithing",
            "Mining",
            "Herblore",
            "Agility",
            "Thieving",
            "Slayer",
            "Farming",
            "Runecrafting",
            "Hunter",
            "Construction"
        };


        public static void getHighScoreInformation(string username)
        {
            try
            {
                playerStatsChecked = new Dictionary<string, bool>();
                List<string> LineResults = new List<string>();
                string path = "http://services.runescape.com/m=hiscore_oldschool/index_lite.ws?player=" + username;

                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(path);
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

                StreamReader sr = new StreamReader(resp.GetResponseStream());
                string totalresults = sr.ReadToEnd();
                sr.Close();

                string[] tempStr;

                tempStr = totalresults.Split('\n');

                for (int i = 0; i < 24; i++)
                {
                    string newstr = tempStr[i];
                    if (!string.IsNullOrWhiteSpace(newstr))
                    {
                        LineResults.Add(newstr);
                    }
                }

                List<string> levels = new List<string>();
                List<int> xp = new List<int>();

                foreach (string s in LineResults)
                {
                    string[] splitted = s.Split(',');
                    bool maxedInSkill = false;
                    string level = splitted[1];
                    //RAnk > level > XP;
                    //MessageBox.Show("Player has level " + splitted[1] + "in the skill: " + skillNamesInOrder[LineResults.IndexOf(s)]);

                    if (level == "2277")
                    {
                        maxedInSkill = true;
                    }
                    else if (level == "99")
                    {
                        maxedInSkill = true;
                    }
                    else
                    {
                        maxedInSkill = false;
                    }

                    playerStatsChecked.Add(skillNamesInOrder[LineResults.IndexOf(s)], maxedInSkill);

                }


            }
            catch (Exception ec)
            {
                MessageBox.Show("Your current username is either set incorrectly or doesn't exist!" + Environment.NewLine + "Please check your information at the settings");
            }
        }

        void checkUserNames()
        {

        }

        public static bool checkFirstUsername(string username, bool isIron, bool isUlti)
        {
            try
            {

                if (!isIron && !isUlti)
                {
                    string path = osrs_normal_acc + username;

                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(path);
                    HttpWebResponse resp = (HttpWebResponse)req.GetResponse();


                    return true;
                    //Normal account.
                }
                else if (isIron)
                {
                    string path = osrs_ironman + username;
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(path);
                    HttpWebResponse resp = (HttpWebResponse)req.GetResponse();



                    return true;

                    //Iron man. 
                }
                else if (isUlti)
                {
                    string path = osrs_ult_ironman + username;
                    HttpWebRequest req = (HttpWebRequest)WebRequest.Create(path);
                    HttpWebResponse resp = (HttpWebResponse)req.GetResponse();


                    return true;

                    //Ultimate ironman.
                }
            }
            catch (Exception e)
            {
                return false;
            }



            return false;
        }
    }
}
