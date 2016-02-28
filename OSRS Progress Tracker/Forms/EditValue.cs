using OSRS_Progress_Tracker.FontManaging;
using OSRS_Progress_Tracker.ItemManaging;
using OSRS_Progress_Tracker.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSRS_Progress_Tracker.Forms
{
    public partial class EditValue : Form
    {
        Font font;
        RSItem item;
        ItemManager im;
        ContainView cv; 
        private bool _dragging = false;
        private Point _offset;
        private Point _start_point = new Point(0, 0);
        public EditValue(RSItem item, ItemManager im, ContainView cv)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            FontManager.setFont(14);
            this.font = FontManager.customFont;
            this.item = item;
            this.im = im;
            this.cv = cv;

            setValBT.Font = font;
            editItemLabel.Font = font;
            txtLBL.Font = font;
            txtLBL.Font = new Font(font.FontFamily, 12, FontStyle.Regular);
            editItemLabel.ForeColor = Color.Yellow;
            valueTB.Font = txtLBL.Font;
            valueTB.Text = item.ownedAmount.ToString();
            Image nameImage = cv.findImageInResources(item.imageName);
            if(item.ownedAmount > 0)
            {
                itemPB.Image = nameImage;
            }
            else
            {
                itemPB.Image = cv.SetImageOpacity(nameImage, 0.3f);
            }
        }

        private void setValBT_Click(object sender, EventArgs e)
        {
            try
            {
                int newNumber = Convert.ToInt32(valueTB.Text);
                if(item.shouldOnlyHaveOne && newNumber > 1)
                {
                    MessageBox.Show("You can only have 1 of this item");
                }
                else
                {
                    Control c = new Control();
                    c.Name = item.imageName;
                    cv.addToNumber(c, newNumber - item.ownedAmount);
                    this.Close();
                }

            }
            catch (Exception ec)
            {
                MessageBox.Show("Please only use numbers!");
            }
        }

        private void form_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;  // _dragging is your variable flag
            _start_point = new Point(e.X, e.Y);
        }

        private void form_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }

        private void form_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }




    }
}
