using OSRS_Progress_Tracker.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSRS_Progress_Tracker.ItemManaging
{
    public class RSItem
    {
        //Keyvalue: Contains the used name of an item and the itemID;
        public int itemid = 0;
        public string imageName;
        public int ownedAmount;
        public bool shouldOnlyHaveOne = false;
        public RSItem(string imageName, int itemid)
        {
            this.imageName = imageName;
            this.itemid = itemid;


        }


    }
}
