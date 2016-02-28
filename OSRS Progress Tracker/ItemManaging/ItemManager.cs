using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSRS_Progress_Tracker.ItemManaging
{
    public class ItemManager
    {
        public Dictionary<MenuValue, List<ItemContainer>> itemGroups;

        public ItemManager(Dictionary<string, Bitmap> menuValues)
        {
            itemGroups = new Dictionary<MenuValue, List<ItemContainer>>();

            //Example record.
            foreach(KeyValuePair<string, Bitmap> pair in menuValues)
            {
                itemGroups.Add(new MenuValue(pair.Key, pair.Value), new List<ItemContainer>());
            }
        }

        /// <summary>
        /// Adds an item container (like "Pest Control" in a category (like "Minigames")
        /// </summary>
        /// <param name="itemCategory"></param>
        /// <param name="addition"></param>
        public void addToItemGroup(string itemCategory, ItemContainer addition)
        {
            MenuValue menuSpot = getValueByName(itemCategory);
            itemGroups[menuSpot].Add(addition);
        }

        /// <summary>
        /// Adds an item into an existing item container.
        /// </summary>
        /// <param name="itemCategory"></param>
        /// <param name="containerName"></param>
        /// <param name="addition"></param>
        public void addToItemContainer(string itemCategory, string containerName, RSItem addition)
        {
            MenuValue menuSpot = getValueByName(itemCategory);
            foreach (ItemContainer ic in itemGroups[menuSpot])
            {
                if(ic.CategoryName == containerName)
                {
                    ic.items.Add(addition);
                }
            }
        }

        /// <summary>
        /// Searches the name of a container .
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public MenuValue getValueByName(string name)
        {
            foreach(KeyValuePair<MenuValue, List<ItemContainer>> pair in itemGroups)
            {
                if(pair.Key.menuItemName == name)
                {
                    return pair.Key;
                }
            }

            return null;
        }

        /// <summary>
        /// searches for an item in all items from a container.
        /// </summary>
        /// <param name="itemname"></param>
        /// <param name="containername"></param>
        /// <param name="rs_name"></param>
        /// <returns></returns>
        public RSItem getItem(string itemname, string containername, string rs_name)
        {
            MenuValue menuSpot = getValueByName(itemname);
            foreach (ItemContainer ic in itemGroups[menuSpot])
            {
                if (ic.CategoryName == containername)
                {
                    foreach(RSItem rsi in ic.items)
                    {
                        if (rsi.imageName == rs_name)
                        {
                            return rsi;
                        }

                    }
                }
            }

            return null;
        }

        public int getTotalItems(string menuItemName)
        {
            int total = 0;
            MenuValue name = getValueByName(menuItemName);
            if(itemGroups.Count > 0)
            {
                foreach (KeyValuePair<MenuValue, List<ItemContainer>> pair in itemGroups)
                {
                    if(pair.Key == name)
                    {
                        foreach (ItemContainer ic in pair.Value)
                        {
                            total += ic.items.Count;
                        }
                        
                    }
                }
            }
            else
            {
                return 0;
            }

            return total;
        }

        public RSItem lookForFilledValue(RSItem item)
        {
            foreach(KeyValuePair<MenuValue, List<ItemContainer>> pair in itemGroups)
            {
                foreach(ItemContainer ic in pair.Value)
                {
                    foreach (RSItem rsi in ic.items)
                    {
                        if (rsi.imageName == item.imageName)
                        {
                            if (rsi.ownedAmount > 0)
                            {
                                return rsi;
                            }
                        }
                    }
                }
            }
           

            return null;
        }


        public void setFilledValue(RSItem item)
        {
            foreach (KeyValuePair<MenuValue, List<ItemContainer>> pair in itemGroups)
            {
                foreach (ItemContainer ic in pair.Value)
                {
                    for (int i = 0; i < ic.items.Count; i++)
                    {
                        if(ic.items[i].imageName == item.imageName)
                        {
                            ic.items[i] = item;

                        }
                    }
                }
            }

        }

        public int getOwnedItems(string menuItemName)
        {
            int total = 0;
            MenuValue name = getValueByName(menuItemName);
            if (itemGroups.Count > 0)
            {
                foreach (KeyValuePair<MenuValue, List<ItemContainer>> pair in itemGroups)
                {
                    if (pair.Key == name)
                    {
                        foreach(ItemContainer ic in pair.Value)
                        {
                            foreach(RSItem rsi in ic.items)
                            {
                                if(rsi.ownedAmount > 0)
                                {
                                    total++;
                                }

                            }
                        }
                       
                    }
                }
            }
            else
            {
                return 0;
            }

            return total;
        }

        public void clearAll()
        {
            foreach(KeyValuePair<MenuValue, List<ItemContainer>> pair in itemGroups)
            {
                foreach(ItemContainer ic in pair.Value)
                {
                    foreach(RSItem item in ic.items)
                    {
                        item.ownedAmount = 0;
                    }
                }
            }

            ItemContainerSaving.clearAll();
        }
       
    }
}
