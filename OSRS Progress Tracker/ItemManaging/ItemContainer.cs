using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSRS_Progress_Tracker.ItemManaging
{
    public class ItemContainer
    {
        public List<RSItem> items;
        public string CategoryName;
        public string comboBox_name;
        public string file_name;
        public ItemContainer(string catName, string filename)
        {
            this.CategoryName = catName;
            this.comboBox_name = catName;
            this.file_name = filename;
            this.items = new List<RSItem>();
            //Example Record
        }


    }
}
