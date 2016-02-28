using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSRS_Progress_Tracker.ItemManaging
{
    public class MenuValue
    {
        public string menuItemName = "";
        public Bitmap resourceImage;

        public MenuValue(string mItem, Bitmap img)
        {
            this.menuItemName = mItem;
            this.resourceImage = img;
        }
    }
}
