using Newtonsoft.Json.Linq;
using OSRS_Progress_Tracker.FontManaging;
using OSRS_Progress_Tracker.Highscore_Tracking;
using OSRS_Progress_Tracker.ItemManaging;
using OSRS_Progress_Tracker.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSRS_Progress_Tracker.Forms
{
    public partial class ContainView : Form
    {
        //Other variables.
        ItemManager im;
        static List<ItemContainer> valueItems;
        Font textfont;
        ContextMenu cm = new ContextMenu();
        MenuItem deleteOne, deleteAll, editValue;
        string filledVal = "";
        UserSettings u;

        //===VARIABLES FOR FORM MOVEMENT 
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]

        public static extern bool ReleaseCapture();
        //===VARIABLES FOR FORM MOVEMENT 


        //Items that are used in several containers but are set with different values.
        string[] multipleItemExceptions = new string[]
        {
            "Dragon_axe",
            "Dragon_pickaxe",
            "Dragon_chainbody",
            "Dragon_2h_sword",
            "Seercull"
        };
        
        //Diary terms that should be filtered to handle easier.
        string[] diaryTerms = new string[]
        {
            "Kandarin_headgear",
            "Varrock_armour",
            "Morytania_legs",
            "Falador_shield",
            "Ardougne_cloak",
            "Desert_amulet",
            "Fremennik_sea_boots",
            "Karamja_gloves",
            "Explorer_ring",
            "Wilderness_sword",
            "Western_banner"
        };

        //Covers the current skill names to be used for highscores and skillcapes.
        public static string[] skillNamesInOrder = new string[]
        {

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

        //Keeps track of how many chompy kills each hat takes for visualization.
        public Dictionary<string, int> chompyHatsWithKills = new Dictionary<string, int>()
        {
            {"Ogre_bowman_hat",30},
            {"Bowman_hat",40},
            {"Ogre_yeoman_hat",50},
            {"Yeoman_hat",70},
            {"Ogre_marksman_hat",95},
            {"Marksman_hat",125},
            {"Ogre_woodsman_hat",170},
            {"Woodsman_hat",225},
            {"Ogre_forester_hat",300},
            {"Forester_hat",400},
            {"Ogre_bowmaster_hat",550},
            {"Bowmaster_hat",700},
            {"Ogre_expert_hat",1000},
            {"Expert_hat",1300},
            {"Ogre_dragon_archer_hat",1700},
            {"Dragon_archer_hat",2250},
            {"Expert_ogre_dragon_archer_hat",3000},
            {"Expert_dragon_archer_hat",4000},
        };

        //Keeps track of the definition of each option that's permanently unlockable with Slayer.
        public Dictionary<string, string> slayerUnlocks = new Dictionary<string, string>()
        {
            {"Broader_fletching","Learn to fletch Broad arrows (level 52 Fletching) and Broad bolts (level 55 Fletching)."},
            {"Slayer_helmet","Learn to assemble a Slayer helmet, which requires level 55 Crafting."},
            {"Slayer_ring","Learn to craft a Slayer ring, which requires level 75 Crafting."},
            {"Herb_sack", "A herb sack is an item which allows players to store grimy herbs" + Environment.NewLine + "for up to 30 of each herb (a total of 420 herbs of all types)."},
            {"Gargoyle_finishing_blow","Gargoyles are automatically dealt the finishing blow, providing the player has a Rock hammer in their inventory."},
            {"Rockslug_finishing_blow","Rock slugs are automatically dealt the finishing blow, providing the player has a Bag of salt in their inventory." + Environment.NewLine + "(Or the /r/2007scape subreddit after a new poll ☜(ﾟヮﾟ☜) )"},
            {"Desert_lizard_finishing_blow","Desert lizards are automatically dealt the finishing blow if the player has an Ice cooler in their inventory."},
            {"Mutated_zygomite_finishing_blow","Mutated zygomites are automatically dealt the finishing blow if the player has Fungicide spray & Fungicide."},
            {"Mithril_dragon_unlock","Duradel and Nieve will be able to assign you Mithril dragons as your task."},
            {"Aviansie_unlock","Duradel, Nieve and Chaeldar will be able to assign you Aviansies as your task."},
            {"Tzhaar_unlock","Duradel and Nieve will be able to assign TzHaar as your task" + Environment.NewLine + "You may also be offered a chance to slay TzTok-Jad."},
            {"Like_a_boss","Duradel and Nieve will be able to assign boss monsters as your task, excluding the Corporeal Beast."}
        };

        //Constructor.
        public ContainView(string name, ItemManager im, Point startPoint, UserSettings u)
        {
            InitializeComponent();

            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            this.Icon = Resources.Gnome_child_chathead;
            this.u = u;
            this.DoubleBuffered = true;
            this.filledVal = name;
            StartPosition = FormStartPosition.Manual;
            Location = startPoint;
            this.im = im;
            valueItems = im.itemGroups[im.getValueByName(name)];
            deleteOne = new MenuItem("Drop one of item");
            deleteAll = new MenuItem("Drop items");
            editValue = new MenuItem("Edit amount");
            deleteAll.Click += deleteAll_Click;
            deleteOne.Click += removeNumber;
            editValue.Click += editValue_Click;
            cm.MenuItems.Add(editValue);
            cm.MenuItems.Add(deleteOne);
            cm.MenuItems.Add(deleteAll);
            
            FontManager.setFont(14F);
            textfont = FontManager.customFont;
            TitleLabel.Font = new Font(textfont.FontFamily, 18F);
            TitleLabel.Text = name;
            itemslabel.Font = textfont;
            itemslabel.Text = "Select a set:";
            TipLabel.Font = new Font(textfont.FontFamily, 12F);
            itemComboBox.Font = new Font(textfont.FontFamily, 12F);


            returnBT.Font = textfont;
            foreach(ItemContainer valueItem in valueItems)
            {
                string catName = valueItem.CategoryName;
                catName = catName.Replace("_", " ");
                if(catName == "Vetion")
                {
                    catName = "Vet'ion";
                }
                itemComboBox.Items.Add(catName);
                //valueItem.items;
            }

            if (name != "Pets" && name != "Achievement Diaries" && name != "Treasure Trials")
            {
                itemComboBox.Sorted = true;
            }
            else
            {
                itemComboBox.Sorted = false;
            }

            if(name == "Capes" && u.useUserName)
            {
                setskillCapeValues(im);
            }

            if(name == "Achievement Diaries")
            {
                TipLabel.Text = "Tip: Use higher tier diaries to tick off lower ones!";
            }
            else
            {
                TipLabel.Text = string.Empty;
            }


            itemComboBox.SelectedValueChanged += itemComboBox_SelectedValueChanged;

           
 
        }

        /// <summary>
        /// Occurs once the "Edit value" menu is pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void editValue_Click(object sender, EventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            if (menuItem != null)
            {
                // Retrieve the ContextMenu that contains this MenuItem
                ContextMenu menu = menuItem.GetContextMenu();

                // Get the control that is displaying this context menu
                Control sourceControl = menu.SourceControl;
                string itemName = sourceControl.Name;
                RSItem item = findItemInValues(itemName);
                EditValue ev = new EditValue(item, this.im, this);
                ev.Show();
                ev.BringToFront();


            }
           
        }

        /// <summary>
        /// Checks if the item name is possibly an achievement diary name. 
        /// </summary>
        /// <param name="name">Name of the item</param>
        /// <returns>True if an item is part of a diary, false if it isn't. </returns>
        public bool checkForDiary(string name)
        {
            if(name.Contains("Kandarin") || name.Contains("Varrock") || name.Contains("Morytania") || name.Contains("Falador")  || name.Contains("Ardougne") || name.Contains("Desert") || name.Contains("Fremennik") || name.Contains("Karamja") ||name.Contains("Explorer") || name.Contains("Western") || name.Contains("Wilderness"))
            {
                if(!name.ToLower().Contains("lizard"))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Checks that an itemname is a chompy hat.
        /// </summary>
        /// <param name="name">Name of the item</param>
        /// <returns>The most fitting chompy-hat name for this item.</returns>
        public string checkForChompy(string name)
        {
            foreach(KeyValuePair<string, int> pair in chompyHatsWithKills)
            {
                if(name.Contains(pair.Key) || name == pair.Key)
                {
                    return pair.Key;
                }
            }
            return "";
        }


        /// <summary>
        /// Occurs once the itemComboBox changes values.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void itemComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                string selectedItem = itemComboBox.SelectedItem.ToString();
                if (selectedItem == "Head Drops")
                {
                    TipLabel.Text = "( ͡⊙ ͜ʖ ͡⊙)";
                }
 
                clearStuff();
                Refresh();
            
                if (selectedItem != "")
                {

                    selectedItem = selectedItem.Replace(" ", "_");
                    if(selectedItem == "Vet'ion")
                    {
                        selectedItem = "Vetion";
                    }
                    int widthCounter = 0;
                    int heightset = 0;
                    foreach (ItemContainer valItem in valueItems)
                    {
                        if (valItem.CategoryName == selectedItem)
                        {
                            for (int i = 0; i < valItem.items.Count; i++)
                            {
                                RSItem selItem = valItem.items[i];
                                if (im.lookForFilledValue(valItem.items[i]) != null)
                                {
                                    if (!multipleItemExceptions.Contains(im.lookForFilledValue(selItem).imageName))
                                    {
                                        valItem.items[i] = im.lookForFilledValue(valItem.items[i]);
                                    }
                                }

                                PictureBox pb = new PictureBox();
                                pb.Location = new Point(30 + (50 * widthCounter), 120 + (heightset * 60));
                                pb.Size = new Size(40, 40);
                                pb.BackColor = Color.Transparent;
                                pb.Name = selItem.imageName;
                                pb.SizeMode = PictureBoxSizeMode.CenterImage;
                                
                                Label l = new Label();
                                l.Font = textfont;
                                l.Size = new Size(50, 25);
                                //l.AutoSize = true;
                                int newX = pb.Location.X - 5;
                                int newY = pb.Location.Y + 35;
                                l.Location = new Point(newX, newY);
                                l.BackColor = Color.Transparent;
                                l.Name = pb.Name;
                                l.TextAlign = ContentAlignment.MiddleCenter;

             

                                pb.MouseClick += controlMouseClick;
                                l.MouseClick += controlMouseClick;

                                pb.MouseHover += controlHover;
                                l.MouseHover += controlHover;

                                pb.ContextMenu = cm;
                                l.ContextMenu = cm;

                                if (selItem.ownedAmount > 0)
                                {
                                    if (selItem.shouldOnlyHaveOne)
                                    {
                                        l.Text = "";
                                    }
                                    else
                                    {
                                        if (selItem.ownedAmount < 1000)
                                        {
                                            l.Text = selItem.ownedAmount.ToString();

                                        }
                                        else if (selItem.ownedAmount >= 1000 && selItem.ownedAmount < 1000000)
                                        {
                                            //IS K
                                            double kAmount = Convert.ToDouble(selItem.ownedAmount) / 1000;
                                            l.Text = Math.Floor(kAmount) + "K";

                                        }
                                        else if (selItem.ownedAmount < 1000000000)
                                        {
                                            double MAmount = Convert.ToDouble(selItem.ownedAmount) / 1000000;
                                            l.Text = Math.Floor(MAmount) + "M";
                                        }
                                        else
                                        {
                                            double BAmount = Convert.ToDouble(selItem.ownedAmount) / 1000000000;
                                            l.Text = Math.Floor(BAmount) + "B";


                                            //IS B
                                        }
                                    }
                                    Image img = findImageInResources(selItem.imageName);
                                    pb.Image = img;
                                }
                                else
                                {
                                    l.Text = "";
                                    Image img = findImageInResources(selItem.imageName);
                                    pb.Image = SetImageOpacity(img, 0.3f);
                                }
                                if (Controls.ContainsKey(pb.Name))
                                {
                                    pb.Name += 1;
                                }
                                if (Controls.ContainsKey(pb.Name))
                                {
                                    pb.Name += 1;
                                }

                                Control.ControlCollection cc = Controls;
                                cc.Add(l);
                                cc.Add(pb);

                                if (widthCounter == 4)
                                {
                                    heightset++;
                                    widthCounter = 0;
                                }
                                else
                                {
                                    widthCounter++;
                                }
                            }
                        }
                    }
                }
            }
            catch(InvalidCastException ae)
            {
                MessageBox.Show(ae.Message);
                
            }
        }


        /// <summary>
        /// Sets values for the skillcape items incase the user has set the "UseUsername" setting.
        /// </summary>
        /// <param name="im">ItemManager which holds the values.</param>
        public void setskillCapeValues(ItemManager im)
        {

            if (HighScoreReceiver.playerStatsChecked != null)
            {
                foreach (KeyValuePair<string, bool> pair in HighScoreReceiver.playerStatsChecked)
                {
                    string capeName = pair.Key.ToLower() + "_cape";
                    if (capeName == "overall_cape")
                    {
                        if (pair.Value)
                        {
                            activateMax();
                            capeName = "Max_cape";
                            RSItem maxCape = findItemInValues(capeName);
                            if(maxCape.ownedAmount < 1)
                            {
                                maxCape.ownedAmount++;
                                setItemValue(maxCape);
                            }
                        }
                    }
                    else
                    {
                        RSItem foundCape = findItemInValues(capeName);
                        if (foundCape != null)
                        {
                            if (pair.Value)
                            {
                                if (foundCape.ownedAmount < 1)
                                {
                                    foundCape.ownedAmount = 1;
                                }

                            }

                        }
                    }
                }

            }
            else
            {
                if (u.useUserName)
                {
                    HighScoreReceiver.getHighScoreInformation(u.UserName);
                    setskillCapeValues(im);
                }
            }

        }

        /// <summary>
        /// Finds an item from the current ItemContainer that's being used.
        /// </summary>
        /// <param name="itemname">Name of the item.</param>
        /// <returns>The item that matches the name, null if it couldn't be found.</returns>
        public static RSItem findItemInValues(string itemname)
        {

            foreach(ItemContainer ic in valueItems)
            {
                if(ic.items.Count > 0)
                {
                    foreach(RSItem rsi in ic.items)
                    {
                        if (rsi.imageName == itemname)
                        {
                            return rsi;
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Searches an item in a category, such as "Abyssal_Sire".
        /// </summary>
        /// <param name="itemname"></param>
        /// <param name="catName"></param>
        /// <returns></returns>
        public RSItem findItemInCategory(string itemname, string catName)
        {

            foreach (ItemContainer ic in valueItems)
            {
                if(ic.CategoryName == catName)
                {
                    if (ic.items.Count > 0)
                    {
                        foreach (RSItem rsi in ic.items)
                        {
                            if (rsi.imageName == itemname)
                            {
                                return rsi;
                            }
                        }
                    }
                }

            }

            return null;
        }

        void controlMouseClick(object sender, MouseEventArgs e)
        {
           switch(e.Button)
           {
               case MouseButtons.Left:
                   addToNumber(sender as Control, 1);
                   //TODO: Add extra to value and save.
                   break;
               case MouseButtons.Right:
                   break;
           }
        }

        /// <summary>
        /// Occurs if the user hovers their mouse over an item. Should display information about said item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void controlHover(object sender, EventArgs e)
        {
            Control c = sender as Control;
            RSItem foundItem = findItemInValues(c.Name);
            if(foundItem != null)
            {
                ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
                if(foundItem.itemid == 0 || foundItem.itemid == 1)
                {
                    if(foundItem.imageName.ToLower().Contains("pet"))
                    {
                        ToolTip1.SetToolTip(c, "This new friend is priceless!");
                    }
                    else if(foundItem.imageName.ToLower().Contains("hat"))
                    {
                        string foundChompyHat = checkForChompy(foundItem.imageName);
                        if(foundChompyHat != "")
                        {
                            string toPutName = foundItem.imageName;
                            toPutName = foundItem.imageName.Replace("_", " ");
                            int kc = chompyHatsWithKills[foundChompyHat];
                            ToolTip1.SetToolTip(c, "Chompy hat: " + toPutName + Environment.NewLine + kc + " chompy kills");
                        }
                    }
                    else if(slayerUnlocks.Keys.Contains(foundItem.imageName))
                    {
                        string unlockText = slayerUnlocks[foundItem.imageName];
                        ToolTip1.SetToolTip(c,unlockText);

                    }
                    else
                    {
                        if (!foundItem.imageName.ToLower().Contains("cape") && !foundItem.imageName.ToLower().Contains("_clue"))
                        {
                            string toPutName = foundItem.imageName;
                            toPutName = foundItem.imageName.Replace("_", " ");
                            if (toPutName.Contains(" s "))
                            {
                                toPutName = toPutName.Replace(" s ", "'s ");
                            }
                            ToolTip1.SetToolTip(c, "Item: " + toPutName + Environment.NewLine + "This item doesn't have a price :)");
                        }
                        else if (foundItem.imageName.ToLower().Contains("_clue"))
                        {
                            string toPutName = foundItem.imageName;
                            toPutName = foundItem.imageName.Replace("_", " ") + " counter: " + foundItem.ownedAmount + " clues completed!";

                            ToolTip1.SetToolTip(c, toPutName);
                        }
                    }
                }
                else
                {
                    int ownPrice = getGEPrice(foundItem.itemid);
                    long totalPrice = ownPrice * foundItem.ownedAmount;
                    if(totalPrice >= 2147483647 || totalPrice < 0)
                    {
                        ToolTip1.SetToolTip(c, "Price per: " + string.Format("{0:#,###0.#}", ownPrice) + " gp || Total: 2147M+ gp!");
                    }
                    else
                    {
                        if(foundItem.imageName.Contains("page"))
                        {
                            int lastindex = foundItem.imageName.LastIndexOf("_");
                            string pageNumber = foundItem.imageName.Substring(lastindex + 1, foundItem.imageName.Length - lastindex - 1);
                            ToolTip1.SetToolTip(c, "Page " + pageNumber + Environment.NewLine + "Price per: " + string.Format("{0:#,###0.#}", ownPrice) + " gp || Total: " + string.Format("{0:#,###0.#}", totalPrice) + " gp");
                        }
                        else
                        {
                            string toPutName = foundItem.imageName;
                            toPutName = foundItem.imageName.Replace("_", " ");
                            if (toPutName.Contains(" s "))
                            {
                                toPutName = toPutName.Replace(" s ", "'s ");
                            }
                            ToolTip1.SetToolTip(c, "Item: " + toPutName + Environment.NewLine + "Price per: " + string.Format("{0:#,###0.#}", ownPrice) + " gp || Total: " + string.Format("{0:#,###0.#}", totalPrice) + " gp");
                        }

                    }
                }
            }
        }

        /// <summary>
        /// Clears the Form of un-used controls before another category is set. 
        /// </summary>
        public void clearStuff()
        {
            List<Control> toClear = new List<Control>();
            foreach(Control c in Controls)
            {
                if(c is Label)
                {
                    if (c.Name != TitleLabel.Name && c.Name != itemslabel.Name && c.Name != TipLabel.Name)
                    {
                        toClear.Add(c);
                    }
                }
                else if (c is PictureBox)
                {
                    toClear.Add(c);
                }
            }

            foreach(Control c in toClear)
            {
                Controls.Remove(c);
            }
        }

        /// <summary>
        /// Adds a set number to the OwnedAmount of the clicked/edited item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="number"></param>
        public void addToNumber(Control sender, int number)
        {
            string selectedItem = itemComboBox.SelectedItem.ToString();
            selectedItem = selectedItem.Replace(" ", "_");
            if (selectedItem == "Vet'ion")
            {
                selectedItem = "Vetion";
            }
            string itemName = sender.Name;

            RSItem item = findItemInValues(itemName);
             if (multipleItemExceptions.Contains(itemName))
             {
                 item = findItemInCategory(itemName, selectedItem);
             }

      
            if(item.ownedAmount == 1 && item.shouldOnlyHaveOne)
            {
                //YOU ALREADY HAVE 1 of UNTRADABLE
            }
            else
            {
                if (checkForDiary(item.imageName))
                {

                    foreach (string s in diaryTerms)
                    {
                        if (item.imageName.Contains(s))
                        {
                            int lastNumber = Convert.ToInt16(item.imageName.Substring(item.imageName.Length - 1, 1));
                            string withoutNumber = item.imageName.Substring(0, item.imageName.Length - 1);
                            item.ownedAmount += number;
                            
                            for (int i = 1; i <= lastNumber; i++)
                            {
                                string nameToFill = withoutNumber + i;
                                RSItem itemFromName = findItemInValues(nameToFill);
                                if(itemFromName.ownedAmount < 1 && itemFromName.shouldOnlyHaveOne)
                                {
                                    itemFromName.ownedAmount++;
                                }

                            }
                        }
                        else
                        {
                            //NOTHING.
                        }
                    }
                }
                else if(checkForChompy(item.imageName) != "")
                {
                    string chompyName = checkForChompy(item.imageName);
                    int chompyIndex = 0;
                    for(int i = 0; i < chompyHatsWithKills.Count; i++)
                    {
                        if(chompyHatsWithKills.Keys.ElementAt(i) == chompyName)
                        {
                            chompyIndex = i;
                        }
                    }
                    item.ownedAmount += number;
                    setItemValue(item);

                    for(int chompy = 0; chompy < chompyIndex; chompy++)
                    {
                        RSItem chompyHat = findItemInValues(chompyHatsWithKills.Keys.ElementAt(chompy));
                        if(chompyHat != null)
                        {
                            if(chompyHat.ownedAmount < 1 && chompyHat.shouldOnlyHaveOne)
                            {
                                chompyHat.ownedAmount++;
                                setItemValue(chompyHat);
                            }
                        }
                    }
                }
                else if (item.imageName.Contains("Bludgeon_"))
                {
                    findItemInValues(item.imageName).ownedAmount += number;
                  
                    while(item.ownedAmount > 0)
                    {
                        if (findItemInValues("Bludgeon_claw").ownedAmount >= 1 && findItemInValues("Bludgeon_axon").ownedAmount >= 1 && findItemInValues("Bludgeon_spine").ownedAmount >= 1)
                        {
                            findItemInValues("Abyssal_bludgeon").ownedAmount++;
                            findItemInValues("Bludgeon_claw").ownedAmount--;
                            findItemInValues("Bludgeon_axon").ownedAmount--;
                            findItemInValues("Bludgeon_spine").ownedAmount--;
                            setItemValue(findItemInValues("Abyssal_bludgeon"));
                            setItemValue(findItemInValues("Bludgeon_claw"));
                            setItemValue(findItemInValues("Bludgeon_axon"));
                            setItemValue(findItemInValues("Bludgeon_spine"));
                        }
                        else
                        {
                            break;
                        }
                    }       
                }
                else if(item.imageName.Contains("_clue"))
                {
                    findItemInValues(item.imageName).ownedAmount += number;

                    int easyClueCount = findItemInValues("Easy_clue").ownedAmount;
                    int medClueCount = findItemInValues("Medium_clue").ownedAmount;
                    int hardClueCount = findItemInValues("Hard_clue").ownedAmount;
                    int eliteClueCount = findItemInValues("Elite_clue").ownedAmount;
                    findItemInValues("Total_clue").ownedAmount = easyClueCount + medClueCount + hardClueCount + eliteClueCount;
                    setItemValue(findItemInValues("Easy_clue"));
                    setItemValue(findItemInValues("Medium_clue"));
                    setItemValue(findItemInValues("Hard_clue"));
                    setItemValue(findItemInValues("Elite_clue"));
                    setItemValue(findItemInValues("Total_clue"));
                }
                else if(item.imageName.ToLower().Contains("max"))
                {
                    item.ownedAmount += number;
                    foreach(string s in skillNamesInOrder)
                    {
                        string capename = s.ToLower() + "_cape";
                        RSItem findItem = findItemInValues(capename);
                        if (findItem != null)
                        {
                            if (findItem.ownedAmount < 1 && findItem.shouldOnlyHaveOne)
                            {
                                findItem.ownedAmount++;
                            }
                        }
                    }
                }
                else
                {
                    item.ownedAmount += number;
                }                   
                if(item != null)
                {
                    if (!multipleItemExceptions.Contains(item.imageName))
                    {
                        im.setFilledValue(item);
                    }
                }
            }

            setItemValue(item);
        }

        /// <summary>
        /// Occurs when skillcapeValues has noticed a user has a total level of 2277.
        /// </summary>
        public void activateMax()
        {
            foreach (string s in skillNamesInOrder)
            {
                string capename = s.ToLower() + "_cape";
                RSItem findItem = findItemInValues(capename);
                if (findItem != null)
                {
                    if (findItem.ownedAmount < 1 && findItem.shouldOnlyHaveOne)
                    {
                        findItem.ownedAmount++;
                        setItemValue(findItem);
                    }
                }
            }
        }

        /// <summary>
        /// Sets values of an item into specific pictureboxes and labels.
        /// </summary>
        /// <param name="item"></param>
        public void setItemValue(RSItem item)
        {
            foreach (Control c in Controls)
            {
                if (c is Label)
                {
                    if (c.Name == item.imageName)
                    {
                        if (item.ownedAmount == 1 && item.shouldOnlyHaveOne)
                        {
                            c.Text = "";
                        }
                        else if(item.ownedAmount > 0)
                        {
                           
                            if(item.ownedAmount < 1000)
                            {
                                c.Text = item.ownedAmount.ToString();
                            }
                            else if (item.ownedAmount >= 1000 && item.ownedAmount < 1000000)
                            {
                                //IS K
                                double kAmount = Convert.ToDouble(item.ownedAmount) / 1000;
                                c.Text = Math.Floor(kAmount) + "K";

                            }
                            else if(item.ownedAmount < 1000000000)
                            {
                                    double MAmount = Convert.ToDouble(item.ownedAmount) / 1000000;
                                    c.Text = Math.Floor(MAmount) + "M";
                            }
                            else
                            {
                                double BAmount = Convert.ToDouble(item.ownedAmount) / 1000000000;
                                c.Text = Math.Floor(BAmount) + "B";
    
                      
                                //IS B
                            }
                        }
                        else
                        {
                            c.Text = "";
                        }
                    }
                }
                else if (c is PictureBox)
                {
                    if (c.Name == item.imageName)
                    {
                        if (item.ownedAmount >= 1)
                        {
                            Image itemIMG = findImageInResources(item.imageName);
                            PictureBox picture = c as PictureBox;
                            picture.Image = itemIMG;
                        }
                        else
                        {
                            Image itemIMG = findImageInResources(item.imageName);
                            PictureBox picture = c as PictureBox;
                            picture.Image = SetImageOpacity(itemIMG, 0.3F);
                        }

                    }
                }
            }

            ItemContainerSaving.saveAllItemData(this.im);
        }

        /// <summary>
        /// Removes a number from the ownedAmount of an item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void removeNumber(object sender, EventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            if (menuItem != null)
            {
                // Retrieve the ContextMenu that contains this MenuItem
                ContextMenu menu = menuItem.GetContextMenu();

                // Get the control that is displaying this context menu
                Control sourceControl = menu.SourceControl;
                string itemName = sourceControl.Name;
                RSItem item = findItemInValues(itemName);

                if (item.ownedAmount >= 1)
                {
                    item.ownedAmount--;
                }

                if (item.imageName.Contains("_clue"))
                {
                    int easyClueCount = findItemInValues("Easy_clue").ownedAmount;
                    int medClueCount = findItemInValues("Medium_clue").ownedAmount;
                    int hardClueCount = findItemInValues("Hard_clue").ownedAmount;
                    int eliteClueCount = findItemInValues("Elite_clue").ownedAmount;
                    findItemInValues("Total_clue").ownedAmount = easyClueCount + medClueCount + hardClueCount + eliteClueCount;
                    setItemValue(findItemInValues("Easy_clue"));
                    setItemValue(findItemInValues("Medium_clue"));
                    setItemValue(findItemInValues("Hard_clue"));
                    setItemValue(findItemInValues("Elite_clue"));
                    setItemValue(findItemInValues("Total_clue"));
                }

                setItemValue(item);
            }

        }

        /// <summary>
        /// Looks for an image in resources so it could be set in a pictureBox.
        /// </summary>
        /// <param name="pictureName"></param>
        /// <returns></returns>
        public Bitmap findImageInResources(string pictureName)
        {
            Object O = Resources.ResourceManager.GetObject(pictureName);
            return (Bitmap)O;
        }

        /// <summary>
        /// Sets the opacity of an image, incase an item is NOT unlocked/has an OwnedAmount of 0
        /// </summary>
        /// <param name="image"></param>
        /// <param name="opacity"></param>
        /// <returns></returns>
        public Image SetImageOpacity(Image image, float opacity)
        {
            try
            {
                //create a Bitmap the size of the image provided  
                Bitmap bmp = new Bitmap(image.Width, image.Height);

                //create a graphics object from the image  
                using (Graphics gfx = Graphics.FromImage(bmp))
                {

                    //create a color matrix object  
                    ColorMatrix matrix = new ColorMatrix();

                    //set the opacity  
                    matrix.Matrix33 = opacity;

                    //create image attributes  
                    ImageAttributes attributes = new ImageAttributes();

                    //set the color(opacity) of the image  
                    attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                    //now draw the image  
                    gfx.DrawImage(image, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attributes);
                }
                return bmp;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }


        /// <summary>
        /// Returns the player to the main menu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void returnBT_Click(object sender, EventArgs e)
        {
            MainMenu mm = new MainMenu(this.im, this.Location, this.u);
            mm.fillMenu();
            mm.Show();
            mm.BringToFront();
            this.Close();
        }

        void deleteAll_Click(object sender, EventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            if (menuItem != null)
            {
                // Retrieve the ContextMenu that contains this MenuItem
                ContextMenu menu = menuItem.GetContextMenu();

                // Get the control that is displaying this context menu
                Control sourceControl = menu.SourceControl;
                RSItem item = findItemInValues(sourceControl.Name);
                
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to clear the information for this item?", "Rly?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    item.ownedAmount = 0; 
                    
                    foreach(Control c in Controls)
                    {
                        if(c is Label)
                        {
                            if(c.Name == item.imageName)
                            {
                                Label cLabel = c as Label;
                                cLabel.Text = "";
                            }
                        }
                        else if (c is PictureBox)
                        {
                            if (c.Name == item.imageName)
                            {
                                Image itemIMG = findImageInResources(item.imageName);
                                PictureBox picture = c as PictureBox;
                                picture.Image = SetImageOpacity(itemIMG, 0.3f);
                            }
                        }
                    }

                    if (item.imageName.Contains("_clue"))
                    {
                        int easyClueCount = findItemInValues("Easy_clue").ownedAmount;
                        int medClueCount = findItemInValues("Medium_clue").ownedAmount;
                        int hardClueCount = findItemInValues("Hard_clue").ownedAmount;
                        int eliteClueCount = findItemInValues("Elite_clue").ownedAmount;
                        findItemInValues("Total_clue").ownedAmount = easyClueCount + medClueCount + hardClueCount + eliteClueCount;
                        setItemValue(findItemInValues("Easy_clue"));
                        setItemValue(findItemInValues("Medium_clue"));
                        setItemValue(findItemInValues("Hard_clue"));
                        setItemValue(findItemInValues("Elite_clue"));
                        setItemValue(findItemInValues("Total_clue"));
                    }

                    //SAVE STUFF:
                    ItemContainerSaving.saveAllItemData(this.im);

                    //do something
                }
                else if (dialogResult == DialogResult.No)
                {

                }

            }

        }

        /// <summary>
        /// Receives the GE price from an item with the given itemID
        /// </summary>
        /// <param name="id">ITEMID of the item.</param>
        /// <returns></returns>
        public int getGEPrice(int id)
        {
            WebClient c = new WebClient();
            var data = c.DownloadString("http://services.runescape.com/m=itemdb_oldschool/api/catalogue/detail.json?item=" + id);
            string valueOriginal = Convert.ToString(data);
            JObject o = JObject.Parse(data);

            string price = Convert.ToString(o["item"]["current"]["price"]);
            int finalPrice = 0;
            if (price.ToLower().Contains("m"))
            {
                double newPrice = Convert.ToDouble(price.Substring(0, price.IndexOf("m")));
                finalPrice = Convert.ToInt32(newPrice * 100000);
            }
            else if (price.ToLower().Contains("k"))
            {
                double newPrice = Convert.ToDouble(price.Substring(0, price.IndexOf("k")));
                finalPrice = Convert.ToInt32(newPrice * 100);
            }
            else if(price.ToLower().Contains(","))
            {
                string fixedPrice = price.Replace(",", "");
                finalPrice = Convert.ToInt32(fixedPrice);
            }
            else
            {
                finalPrice = Convert.ToInt16(price);
            }
            return finalPrice;
        }

        /// <summary>
        /// Makes it possible to drag the form around without borders.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
