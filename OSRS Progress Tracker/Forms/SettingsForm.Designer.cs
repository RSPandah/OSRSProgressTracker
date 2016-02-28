namespace OSRS_Progress_Tracker.Forms
{
    partial class SettingsForm
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
            this.titleLabel = new System.Windows.Forms.Label();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.UserTB = new System.Windows.Forms.TextBox();
            this.ironmanBT = new System.Windows.Forms.RadioButton();
            this.ult_IronmanBT = new System.Windows.Forms.RadioButton();
            this.saveBT = new System.Windows.Forms.Button();
            this.bootCB = new System.Windows.Forms.CheckBox();
            this.useUsernameCB = new System.Windows.Forms.CheckBox();
            this.clearAllBT = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.ForeColor = System.Drawing.Color.Yellow;
            this.titleLabel.Location = new System.Drawing.Point(101, 20);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(45, 13);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Settings";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // userNameLabel
            // 
            this.userNameLabel.AutoSize = true;
            this.userNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.userNameLabel.ForeColor = System.Drawing.Color.Black;
            this.userNameLabel.Location = new System.Drawing.Point(12, 51);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(58, 13);
            this.userNameLabel.TabIndex = 1;
            this.userNameLabel.Text = "Username:";
            this.userNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UserTB
            // 
            this.UserTB.Location = new System.Drawing.Point(77, 48);
            this.UserTB.Name = "UserTB";
            this.UserTB.Size = new System.Drawing.Size(181, 20);
            this.UserTB.TabIndex = 2;
            // 
            // ironmanBT
            // 
            this.ironmanBT.AutoSize = true;
            this.ironmanBT.BackColor = System.Drawing.Color.Transparent;
            this.ironmanBT.Image = global::OSRS_Progress_Tracker.Properties.Resources.Ironman_chat_badge;
            this.ironmanBT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ironmanBT.Location = new System.Drawing.Point(12, 95);
            this.ironmanBT.Name = "ironmanBT";
            this.ironmanBT.Size = new System.Drawing.Size(114, 17);
            this.ironmanBT.TabIndex = 3;
            this.ironmanBT.TabStop = true;
            this.ironmanBT.Text = "       I\'m an ironman";
            this.ironmanBT.UseVisualStyleBackColor = false;
            // 
            // ult_IronmanBT
            // 
            this.ult_IronmanBT.AutoSize = true;
            this.ult_IronmanBT.BackColor = System.Drawing.Color.Transparent;
            this.ult_IronmanBT.Image = global::OSRS_Progress_Tracker.Properties.Resources.Ultimate_ironman_chat_badge;
            this.ult_IronmanBT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ult_IronmanBT.Location = new System.Drawing.Point(12, 118);
            this.ult_IronmanBT.Name = "ult_IronmanBT";
            this.ult_IronmanBT.Size = new System.Drawing.Size(153, 17);
            this.ult_IronmanBT.TabIndex = 4;
            this.ult_IronmanBT.TabStop = true;
            this.ult_IronmanBT.Text = "       I\'m an ultimate ironman";
            this.ult_IronmanBT.UseVisualStyleBackColor = false;
            // 
            // saveBT
            // 
            this.saveBT.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.saveBT.BackgroundImage = global::OSRS_Progress_Tracker.Properties.Resources.osrs_bt;
            this.saveBT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.saveBT.FlatAppearance.BorderSize = 0;
            this.saveBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveBT.ForeColor = System.Drawing.Color.Yellow;
            this.saveBT.Location = new System.Drawing.Point(44, 257);
            this.saveBT.Name = "saveBT";
            this.saveBT.Size = new System.Drawing.Size(82, 34);
            this.saveBT.TabIndex = 5;
            this.saveBT.Text = "Save";
            this.saveBT.UseVisualStyleBackColor = true;
            this.saveBT.Click += new System.EventHandler(this.saveBT_Click);
            // 
            // bootCB
            // 
            this.bootCB.AutoSize = true;
            this.bootCB.BackColor = System.Drawing.Color.Transparent;
            this.bootCB.Location = new System.Drawing.Point(12, 167);
            this.bootCB.Name = "bootCB";
            this.bootCB.Size = new System.Drawing.Size(150, 17);
            this.bootCB.TabIndex = 6;
            this.bootCB.Text = "Run when computer starts";
            this.bootCB.UseVisualStyleBackColor = false;
            // 
            // useUsernameCB
            // 
            this.useUsernameCB.AutoSize = true;
            this.useUsernameCB.BackColor = System.Drawing.Color.Transparent;
            this.useUsernameCB.Location = new System.Drawing.Point(12, 190);
            this.useUsernameCB.Name = "useUsernameCB";
            this.useUsernameCB.Size = new System.Drawing.Size(149, 17);
            this.useUsernameCB.TabIndex = 7;
            this.useUsernameCB.Text = "Use username in program.";
            this.useUsernameCB.UseVisualStyleBackColor = false;
            // 
            // clearAllBT
            // 
            this.clearAllBT.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.clearAllBT.BackgroundImage = global::OSRS_Progress_Tracker.Properties.Resources.osrs_bt;
            this.clearAllBT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.clearAllBT.FlatAppearance.BorderSize = 0;
            this.clearAllBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearAllBT.ForeColor = System.Drawing.Color.Yellow;
            this.clearAllBT.Location = new System.Drawing.Point(156, 257);
            this.clearAllBT.Name = "clearAllBT";
            this.clearAllBT.Size = new System.Drawing.Size(102, 34);
            this.clearAllBT.TabIndex = 11;
            this.clearAllBT.Text = "Clear all items";
            this.clearAllBT.UseVisualStyleBackColor = true;
            this.clearAllBT.Click += new System.EventHandler(this.clearAllBT_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::OSRS_Progress_Tracker.Properties.Resources.empty_menus;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(296, 303);
            this.Controls.Add(this.clearAllBT);
            this.Controls.Add(this.useUsernameCB);
            this.Controls.Add(this.bootCB);
            this.Controls.Add(this.saveBT);
            this.Controls.Add(this.ult_IronmanBT);
            this.Controls.Add(this.ironmanBT);
            this.Controls.Add(this.UserTB);
            this.Controls.Add(this.userNameLabel);
            this.Controls.Add(this.titleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SettingsForm";
            this.Text = "W";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label userNameLabel;
        private System.Windows.Forms.TextBox UserTB;
        private System.Windows.Forms.RadioButton ironmanBT;
        private System.Windows.Forms.RadioButton ult_IronmanBT;
        private System.Windows.Forms.Button saveBT;
        private System.Windows.Forms.CheckBox bootCB;
        private System.Windows.Forms.CheckBox useUsernameCB;
        private System.Windows.Forms.Button clearAllBT;
    }
}