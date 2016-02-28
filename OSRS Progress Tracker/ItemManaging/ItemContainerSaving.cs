using Microsoft.Win32;
using OSRS_Progress_Tracker.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSRS_Progress_Tracker.ItemManaging
{
    public class ItemContainerSaving
    {
        RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        public static string folderPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "OSRS Progress Tracker");

        public static void loadAllItems(ItemManager manager)
        {
            Dictionary<string, List<ItemContainer>> loadedValues = new Dictionary<string, List<ItemContainer>>();
            string contPath = folderPath + "\\Containers\\";
            if(Directory.Exists(contPath))
            {
                 foreach (KeyValuePair<MenuValue, List<ItemContainer>> pair in manager.itemGroups)
                {
                    string containerPath = folderPath + "\\Containers\\" + pair.Key.menuItemName + "\\";

                    if (Directory.Exists(containerPath))
                    {
                        string[] files = Directory.GetFiles(containerPath);
                        foreach (string s in files)
                        {
                            string fname = s.Remove(0, containerPath.Length);
                            string fileName = fname.Remove(fname.IndexOf("."), fname.Length - fname.IndexOf("."));
                            string[] entries = File.ReadAllLines(s);
                            
                            ItemContainer ic = new ItemContainer(fileName, fileName);

                            foreach (string line in entries)
                            {
                                int seperatorIndex1 = line.IndexOf(":");
                                int seperatorIndex2 = line.IndexOf("(");
                                int seperatorIndex3 = line.IndexOf(")");

                                string itemName = line.Substring(0, seperatorIndex1);
                                int itemID = Convert.ToInt32(line.Substring(seperatorIndex1 + 1, seperatorIndex2 - seperatorIndex1 - 1));
                                int itemAmount = Convert.ToInt32(line.Substring(seperatorIndex2 + 1, seperatorIndex3 - seperatorIndex2 - 1));
                                RSItem item = new RSItem(itemName, itemID);
                                item.ownedAmount = itemAmount;
                                if (item.itemid == 0)
                                {
                                    item.shouldOnlyHaveOne = true;
                                }
                                ic.items.Add(item);

                                if (!manager.itemGroups[pair.Key].Contains(ic))
                                {
                                    manager.addToItemGroup(pair.Key.menuItemName, ic);

                                }
                            }
                        }
                    }
                    else
                    {
                        fillManagerWithResourceData(manager, pair.Key.menuItemName);
                    }
                }
            }
            else
                {
                    //GET stuff from resources?
                    foreach (KeyValuePair<MenuValue, List<ItemContainer>> pair in manager.itemGroups)
                    {
                        fillManagerWithResourceData(manager, pair.Key.menuItemName);
                    }
                }
        }

        public static void clearAll()
        {
            string contPath = folderPath + "\\Containers\\";
            if(Directory.Exists(contPath))
            {
                DirectoryInfo di = new DirectoryInfo(contPath);

                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    dir.Delete(true);
                }

                Directory.Delete(contPath);
            }

        }

        public static void fillManagerWithResourceData(ItemManager manager, string menuValue)
        {
            string val = menuValue;
            val = val.Replace(" ", "_");
            List<string> skillFileNames = textfileFromResources(val + "_names");
            if(skillFileNames != null)
            {
                foreach (string container_name in skillFileNames)
                {
                    string l = val + "_";
                    string actualName = container_name.Remove(0, l.Length);
                    ItemContainer ic = new ItemContainer(actualName, actualName);
                    if (!manager.itemGroups[manager.getValueByName(menuValue)].Contains(ic))
                    {
                        List<string> ItemFileNames = textfileFromResources(container_name);
                        foreach (string item in ItemFileNames)
                        {
                            int seperatorIndex1 = item.IndexOf(":");
                            int seperatorIndex2 = item.IndexOf("(");
                            int seperatorIndex3 = item.IndexOf(")");

                            string itemName = item.Substring(0, seperatorIndex1);
                            int itemID = Convert.ToInt16(item.Substring(seperatorIndex1 + 1, seperatorIndex2 - seperatorIndex1 - 1));
                            int itemAmount = Convert.ToInt16(item.Substring(seperatorIndex2 + 1, seperatorIndex3 - seperatorIndex2 - 1));
                            RSItem rsItem = new RSItem(itemName, itemID);
                            rsItem.ownedAmount = itemAmount;
                            if (rsItem.itemid == 0)
                            {
                                rsItem.shouldOnlyHaveOne = true;
                            }
                            ic.items.Add(rsItem);
                        }
                        manager.addToItemGroup(menuValue, ic);

                    }

                }
            }
           
        }

        public static List<string> textfileFromResources(string name)
        {
            try
            {
                Object resource_data = Resources.ResourceManager.GetObject(name);
                string try_parsing = (string)resource_data;
                List<string> words = try_parsing.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();

                return words;
            }
            catch (Exception e)
            {
                //MessageBox.Show("Something went wrong! If this keeps happening contact /u/PandahGoRawr on reddit!");
            }

            return null;
        }

        // Process all files in the directory passed in, recurse on any directories 
        // that are found, and process the files they contain.
        public static void ProcessDirectory(string targetDirectory)
        {
            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
                ProcessFile(fileName);

            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                ProcessDirectory(subdirectory);
        }

        public static void ProcessFile(string path)
        {
            Console.WriteLine("Processed file '{0}'.", path);
        }

        public static void saveAllItemData(ItemManager manager)
        {
            Dictionary<string, List<ItemContainer>> loadedValues = new Dictionary<string, List<ItemContainer>>();

            foreach (KeyValuePair<MenuValue, List<ItemContainer>> pair in manager.itemGroups)
            {
                string containerPath = folderPath + "\\Containers\\" + pair.Key.menuItemName + "\\";

                if (Directory.Exists(containerPath))
                {
                    foreach (ItemContainer ic in pair.Value)
                    {
                        string fileName = containerPath + ic.CategoryName + ".txt";
                        using (StreamWriter writer = new StreamWriter(fileName))
                        {
                            if (ic.items.Count > 0)
                            {
                                foreach (RSItem rsi in ic.items)
                                {
                                    writer.WriteLine(rsi.imageName + ":" + rsi.itemid + "(" + rsi.ownedAmount + ")");
                                    writer.Flush();
                                }
                            }
                        }

                    }
                }
                else
                {
                    Directory.CreateDirectory(containerPath);
                    foreach (ItemContainer ic in pair.Value)
                    {
                        string fileName = containerPath + ic.CategoryName + ".txt";
                        using (StreamWriter writer = new StreamWriter(fileName))
                        {
                            if (ic.items.Count > 0)
                            {
                                foreach (RSItem rsi in ic.items)
                                {
                                    writer.WriteLine(rsi.imageName + ":" + rsi.itemid + "(" + rsi.ownedAmount + ")");
                                    writer.Flush();
                                }
                            }
                        }

                    }
                }
            }


        }
    }
}
