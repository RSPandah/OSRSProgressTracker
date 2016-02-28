namespace OSRS_Progress_Tracker.Forms
{
    partial class MainSettingForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.usernameTB = new System.Windows.Forms.TextBox();
            this.normal_iron_radioBT = new System.Windows.Forms.RadioButton();
            this.ult_iron_radioBT = new System.Windows.Forms.RadioButton();
            this.returnBT = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.BootOnStartCB = new System.Windows.Forms.CheckBox();
            this.useUsernameCB = new System.Windows.Forms.CheckBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(24, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username:";
            // 
            // usernameTB
            // 
            this.usernameTB.Location = new System.Drawing.Point(89, 77);
            this.usernameTB.Name = "usernameTB";
            this.usernameTB.Size = new System.Drawing.Size(183, 20);
            this.usernameTB.TabIndex = 1;
            // 
            // normal_iron_radioBT
            // 
            this.normal_iron_radioBT.AutoSize = true;
            this.normal_iron_radioBT.BackColor = System.Drawing.Color.Transparent;
            this.normal_iron_radioBT.Image = global::OSRS_Progress_Tracker.Properties.Resources.Ironman_chat_badge;
            this.normal_iron_radioBT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.normal_iron_radioBT.Location = new System.Drawing.Point(27, 115);
            this.normal_iron_radioBT.Name = "normal_iron_radioBT";
            this.normal_iron_radioBT.Size = new System.Drawing.Size(108, 17);
            this.normal_iron_radioBT.TabIndex = 2;
            this.normal_iron_radioBT.TabStop = true;
            this.normal_iron_radioBT.Text = "     I\'m an ironman";
            this.normal_iron_radioBT.UseVisualStyleBackColor = false;
            // 
            // ult_iron_radioBT
            // 
            this.ult_iron_radioBT.AutoSize = true;
            this.ult_iron_radioBT.BackColor = System.Drawing.Color.Transparent;
            this.ult_iron_radioBT.Image = global::OSRS_Progress_Tracker.Properties.Resources.Ultimate_ironman_chat_badge;
            this.ult_iron_radioBT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ult_iron_radioBT.Location = new System.Drawing.Point(27, 138);
            this.ult_iron_radioBT.Name = "ult_iron_radioBT";
            this.ult_iron_radioBT.Size = new System.Drawing.Size(147, 17);
            this.ult_iron_radioBT.TabIndex = 3;
            this.ult_iron_radioBT.TabStop = true;
            this.ult_iron_radioBT.Text = "     I\'m an ultimate ironman";
            this.ult_iron_radioBT.UseVisualStyleBackColor = false;
            // 
            // returnBT
            // 
            this.returnBT.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.returnBT.BackgroundImage = global::OSRS_Progress_Tracker.Properties.Resources.osrs_bt;
            this.returnBT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.returnBT.FlatAppearance.BorderSize = 0;
            this.returnBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.returnBT.ForeColor = System.Drawing.Color.Yellow;
            this.returnBT.Location = new System.Drawing.Point(41, 270);
            this.returnBT.Name = "returnBT";
            this.returnBT.Size = new System.Drawing.Size(88, 38);
            this.returnBT.TabIndex = 5;
            this.returnBT.Text = "Save";
            this.returnBT.UseVisualStyleBackColor = true;
            this.returnBT.Click += new System.EventHandler(this.returnBT_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.BackgroundImage = global::OSRS_Progress_Tracker.Properties.Resources.osrs_bt;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Yellow;
            this.button1.Location = new System.Drawing.Point(147, 270);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 38);
            this.button1.TabIndex = 6;
            this.button1.Text = "Clear all items";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BootOnStartCB
            // 
            this.BootOnStartCB.AutoSize = true;
            this.BootOnStartCB.BackColor = System.Drawing.Color.Transparent;
            this.BootOnStartCB.Location = new System.Drawing.Point(27, 206);
            this.BootOnStartCB.Name = "BootOnStartCB";
            this.BootOnStartCB.Size = new System.Drawing.Size(96, 17);
            this.BootOnStartCB.TabIndex = 7;
            this.BootOnStartCB.Text = "Run on startup";
            this.BootOnStartCB.UseVisualStyleBackColor = false;
            // 
            // useUsernameCB
            // 
            this.useUsernameCB.AutoSize = true;
            this.useUsernameCB.BackColor = System.Drawing.Color.Transparent;
            this.useUsernameCB.Location = new System.Drawing.Point(27, 229);
            this.useUsernameCB.Name = "useUsernameCB";
            this.useUsernameCB.Size = new System.Drawing.Size(146, 17);
            this.useUsernameCB.TabIndex = 8;
            this.useUsernameCB.Text = "Use username in program";
            this.useUsernameCB.UseVisualStyleBackColor = false;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.ForeColor = System.Drawing.Color.Yellow;
            this.titleLabel.Location = new System.Drawing.Point(115, 31);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(45, 13);
            this.titleLabel.TabIndex = 9;
            this.titleLabel.Text = "Settings";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // MainSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::OSRS_Progress_Tracker.Properties.Resources.empty_menus;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(284, 320);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.useUsernameCB);
            this.Controls.Add(this.BootOnStartCB);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.returnBT);
            this.Controls.Add(this.ult_iron_radioBT);
            this.Controls.Add(this.normal_iron_radioBT);
            this.Controls.Add(this.usernameTB);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(284, 400);
            this.MinimumSize = new System.Drawing.Size(284, 261);
            this.Name = "MainSettingForm";
            this.Text = "MainSettingForm";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox usernameTB;
        private System.Windows.Forms.RadioButton normal_iron_radioBT;
        private System.Windows.Forms.RadioButton ult_iron_radioBT;
        private System.Windows.Forms.Button returnBT;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox BootOnStartCB;
        private System.Windows.Forms.CheckBox useUsernameCB;
        private System.Windows.Forms.Label titleLabel;
    }
}