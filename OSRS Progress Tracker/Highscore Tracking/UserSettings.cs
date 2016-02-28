using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSRS_Progress_Tracker.Highscore_Tracking
{
    [Serializable]
    public class UserSettings
    {
        public  string UserName = "Zezima";
        public  bool isIronMan = true;
        public  bool isUltimateIronMan = false;
        public  bool startOnBoot = false;
        public  bool firstBootup = true;
        public  bool useUserName = false;

        public UserSettings()
        {

        }
    }
}
