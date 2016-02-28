namespace OSRS_Progress_Tracker.Forms
{
    partial class EditValue
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
            this.setValBT = new System.Windows.Forms.Button();
            this.editItemLabel = new System.Windows.Forms.Label();
            this.txtLBL = new System.Windows.Forms.Label();
            this.valueTB = new System.Windows.Forms.TextBox();
            this.itemPB = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.itemPB)).BeginInit();
            this.SuspendLayout();
            // 
            // setValBT
            // 
            this.setValBT.BackgroundImage = global::OSRS_Progress_Tracker.Properties.Resources.osrs_bt;
            this.setValBT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.setValBT.FlatAppearance.BorderSize = 0;
            this.setValBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setValBT.ForeColor = System.Drawing.Color.Yellow;
            this.setValBT.Location = new System.Drawing.Point(80, 196);
            this.setValBT.Name = "setValBT";
            this.setValBT.Size = new System.Drawing.Size(120, 53);
            this.setValBT.TabIndex = 5;
            this.setValBT.Text = "Continue";
            this.setValBT.UseVisualStyleBackColor = true;
            this.setValBT.Click += new System.EventHandler(this.setValBT_Click);
            // 
            // editItemLabel
            // 
            this.editItemLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.editItemLabel.AutoSize = true;
            this.editItemLabel.BackColor = System.Drawing.Color.Transparent;
            this.editItemLabel.Location = new System.Drawing.Point(104, 29);
            this.editItemLabel.Name = "editItemLabel";
            this.editItemLabel.Size = new System.Drawing.Size(47, 13);
            this.editItemLabel.TabIndex = 6;
            this.editItemLabel.Text = "Edit item";
            this.editItemLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtLBL
            // 
            this.txtLBL.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtLBL.AutoSize = true;
            this.txtLBL.BackColor = System.Drawing.Color.Transparent;
            this.txtLBL.Location = new System.Drawing.Point(12, 107);
            this.txtLBL.Name = "txtLBL";
            this.txtLBL.Size = new System.Drawing.Size(87, 13);
            this.txtLBL.TabIndex = 7;
            this.txtLBL.Text = "Set a new value:";
            this.txtLBL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // valueTB
            // 
            this.valueTB.Location = new System.Drawing.Point(107, 103);
            this.valueTB.Name = "valueTB";
            this.valueTB.Size = new System.Drawing.Size(165, 20);
            this.valueTB.TabIndex = 8;
            // 
            // itemPB
            // 
            this.itemPB.BackColor = System.Drawing.Color.Transparent;
            this.itemPB.Location = new System.Drawing.Point(125, 56);
            this.itemPB.Name = "itemPB";
            this.itemPB.Size = new System.Drawing.Size(35, 35);
            this.itemPB.TabIndex = 9;
            this.itemPB.TabStop = false;
            // 
            // EditValue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::OSRS_Progress_Tracker.Properties.Resources.empty_menus;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.itemPB);
            this.Controls.Add(this.valueTB);
            this.Controls.Add(this.txtLBL);
            this.Controls.Add(this.editItemLabel);
            this.Controls.Add(this.setValBT);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EditValue";
            this.Text = "EditValue";
            ((System.ComponentModel.ISupportInitialize)(this.itemPB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button setValBT;
        private System.Windows.Forms.Label editItemLabel;
        private System.Windows.Forms.Label txtLBL;
        private System.Windows.Forms.TextBox valueTB;
        private System.Windows.Forms.PictureBox itemPB;
    }
}