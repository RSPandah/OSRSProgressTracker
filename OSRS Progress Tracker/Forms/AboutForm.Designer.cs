namespace OSRS_Progress_Tracker.Forms
{
    partial class AboutForm
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
            this.versionLabel = new System.Windows.Forms.Label();
            this.informationLabel = new System.Windows.Forms.Label();
            this.setValBT = new System.Windows.Forms.Button();
            this.githubLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.ForeColor = System.Drawing.Color.Yellow;
            this.titleLabel.Location = new System.Drawing.Point(198, 35);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(44, 13);
            this.titleLabel.TabIndex = 12;
            this.titleLabel.Text = "About...";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.BackColor = System.Drawing.Color.Transparent;
            this.versionLabel.Location = new System.Drawing.Point(23, 84);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(45, 13);
            this.versionLabel.TabIndex = 10;
            this.versionLabel.Text = "Version:";
            // 
            // informationLabel
            // 
            this.informationLabel.AutoSize = true;
            this.informationLabel.BackColor = System.Drawing.Color.Transparent;
            this.informationLabel.Location = new System.Drawing.Point(23, 116);
            this.informationLabel.Name = "informationLabel";
            this.informationLabel.Size = new System.Drawing.Size(16, 13);
            this.informationLabel.TabIndex = 13;
            this.informationLabel.Text = "---";
            // 
            // setValBT
            // 
            this.setValBT.BackgroundImage = global::OSRS_Progress_Tracker.Properties.Resources.osrs_bt;
            this.setValBT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.setValBT.FlatAppearance.BorderSize = 0;
            this.setValBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.setValBT.ForeColor = System.Drawing.Color.Yellow;
            this.setValBT.Location = new System.Drawing.Point(168, 212);
            this.setValBT.Name = "setValBT";
            this.setValBT.Size = new System.Drawing.Size(93, 37);
            this.setValBT.TabIndex = 14;
            this.setValBT.Text = "Continue";
            this.setValBT.UseVisualStyleBackColor = true;
            this.setValBT.Click += new System.EventHandler(this.setValBT_Click);
            // 
            // githubLabel
            // 
            this.githubLabel.AutoSize = true;
            this.githubLabel.BackColor = System.Drawing.Color.Transparent;
            this.githubLabel.Location = new System.Drawing.Point(23, 191);
            this.githubLabel.Name = "githubLabel";
            this.githubLabel.Size = new System.Drawing.Size(265, 13);
            this.githubLabel.TabIndex = 16;
            this.githubLabel.TabStop = true;
            this.githubLabel.Text = "https://github.com/RSPandah/OSRSProgressTracker";
            this.githubLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.githubLabel_LinkClicked);
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::OSRS_Progress_Tracker.Properties.Resources.empty_menus;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(452, 261);
            this.Controls.Add(this.githubLabel);
            this.Controls.Add(this.setValBT);
            this.Controls.Add(this.informationLabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.versionLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AboutForm";
            this.Text = "About";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Label informationLabel;
        private System.Windows.Forms.Button setValBT;
        private System.Windows.Forms.LinkLabel githubLabel;
    }
}