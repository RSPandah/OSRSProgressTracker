namespace OSRS_Progress_Tracker.Forms
{
    partial class ContainView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TitleLabel = new System.Windows.Forms.Label();
            this.itemslabel = new System.Windows.Forms.Label();
            this.itemComboBox = new System.Windows.Forms.ComboBox();
            this.returnBT = new System.Windows.Forms.Button();
            this.TipLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.TitleLabel.ForeColor = System.Drawing.Color.Yellow;
            this.TitleLabel.Location = new System.Drawing.Point(12, 37);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(35, 13);
            this.TitleLabel.TabIndex = 1;
            this.TitleLabel.Text = "label1";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // itemslabel
            // 
            this.itemslabel.AutoSize = true;
            this.itemslabel.BackColor = System.Drawing.Color.Transparent;
            this.itemslabel.Location = new System.Drawing.Point(12, 89);
            this.itemslabel.Name = "itemslabel";
            this.itemslabel.Size = new System.Drawing.Size(35, 13);
            this.itemslabel.TabIndex = 2;
            this.itemslabel.Text = "label1";
            this.itemslabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // itemComboBox
            // 
            this.itemComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.itemComboBox.FormattingEnabled = true;
            this.itemComboBox.Location = new System.Drawing.Point(111, 86);
            this.itemComboBox.Name = "itemComboBox";
            this.itemComboBox.Size = new System.Drawing.Size(182, 21);
            this.itemComboBox.TabIndex = 3;
            // 
            // returnBT
            // 
            this.returnBT.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.returnBT.BackgroundImage = global::OSRS_Progress_Tracker.Properties.Resources.osrs_bt;
            this.returnBT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.returnBT.FlatAppearance.BorderSize = 0;
            this.returnBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.returnBT.ForeColor = System.Drawing.Color.Yellow;
            this.returnBT.Location = new System.Drawing.Point(68, 512);
            this.returnBT.Name = "returnBT";
            this.returnBT.Size = new System.Drawing.Size(149, 65);
            this.returnBT.TabIndex = 4;
            this.returnBT.Text = "Return to Main Menu";
            this.returnBT.UseVisualStyleBackColor = true;
            this.returnBT.Click += new System.EventHandler(this.returnBT_Click);
            // 
            // TipLabel
            // 
            this.TipLabel.AutoSize = true;
            this.TipLabel.BackColor = System.Drawing.Color.Transparent;
            this.TipLabel.Location = new System.Drawing.Point(12, 62);
            this.TipLabel.Name = "TipLabel";
            this.TipLabel.Size = new System.Drawing.Size(0, 13);
            this.TipLabel.TabIndex = 5;
            this.TipLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ContainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::OSRS_Progress_Tracker.Properties.Resources.empty_menus;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(305, 600);
            this.Controls.Add(this.TipLabel);
            this.Controls.Add(this.returnBT);
            this.Controls.Add(this.itemComboBox);
            this.Controls.Add(this.itemslabel);
            this.Controls.Add(this.TitleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ContainView";
            this.Text = "ContainView";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label itemslabel;
        private System.Windows.Forms.ComboBox itemComboBox;
        private System.Windows.Forms.Button returnBT;
        private System.Windows.Forms.Label TipLabel;
    }
}