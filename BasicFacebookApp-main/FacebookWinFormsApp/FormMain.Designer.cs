namespace BasicFacebookFeatures
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.buttonLogin = new System.Windows.Forms.Button();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.labelAppID = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.userDataGroupBox = new System.Windows.Forms.GroupBox();
            this.infoDataSection = new BasicFacebookFeatures.UserDataSection();
            this.galleryDataSection = new BasicFacebookFeatures.UserDataSection();
            this.postsDataSection = new BasicFacebookFeatures.UserDataSection();
            this.friendsDataSection = new BasicFacebookFeatures.UserDataSection();
            this.videosDataSection = new BasicFacebookFeatures.UserDataSection();
            this.labelToken = new System.Windows.Forms.Label();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxPost = new System.Windows.Forms.PictureBox();
            this.newTextBox = new System.Windows.Forms.TextBox();
            this.pictureBoxProfile = new System.Windows.Forms.PictureBox();
            this.textBoxAppID = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.userDataGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonLogin
            // 
            this.buttonLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogin.Location = new System.Drawing.Point(38, 23);
            this.buttonLogin.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(268, 58);
            this.buttonLogin.TabIndex = 36;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // buttonLogout
            // 
            this.buttonLogout.Enabled = false;
            this.buttonLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogout.Location = new System.Drawing.Point(38, 88);
            this.buttonLogout.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(268, 58);
            this.buttonLogout.TabIndex = 52;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // labelAppID
            // 
            this.labelAppID.AutoSize = true;
            this.labelAppID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAppID.Location = new System.Drawing.Point(480, 25);
            this.labelAppID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAppID.Name = "labelAppID";
            this.labelAppID.Size = new System.Drawing.Size(73, 24);
            this.labelAppID.TabIndex = 53;
            this.labelAppID.Text = "AppID:";
            this.labelAppID.Click += new System.EventHandler(this.label1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1238, 774);
            this.tabControl1.TabIndex = 54;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.userDataGroupBox);
            this.tabPage1.Controls.Add(this.labelToken);
            this.tabPage1.Controls.Add(this.axWindowsMediaPlayer1);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.pictureBoxPost);
            this.tabPage1.Controls.Add(this.newTextBox);
            this.tabPage1.Controls.Add(this.pictureBoxProfile);
            this.tabPage1.Controls.Add(this.textBoxAppID);
            this.tabPage1.Controls.Add(this.labelAppID);
            this.tabPage1.Controls.Add(this.buttonLogout);
            this.tabPage1.Controls.Add(this.buttonLogin);
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1230, 739);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // userDataGroupBox
            // 
            this.userDataGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.userDataGroupBox.Controls.Add(this.infoDataSection);
            this.userDataGroupBox.Controls.Add(this.galleryDataSection);
            this.userDataGroupBox.Controls.Add(this.postsDataSection);
            this.userDataGroupBox.Controls.Add(this.friendsDataSection);
            this.userDataGroupBox.Controls.Add(this.videosDataSection);
            this.userDataGroupBox.Location = new System.Drawing.Point(-4, 181);
            this.userDataGroupBox.Name = "userDataGroupBox";
            this.userDataGroupBox.Size = new System.Drawing.Size(1238, 248);
            this.userDataGroupBox.TabIndex = 78;
            this.userDataGroupBox.TabStop = false;
            this.userDataGroupBox.Text = "User Data";
            this.userDataGroupBox.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // infoDataSection
            // 
            this.infoDataSection.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.infoDataSection.AutoSize = true;
            this.infoDataSection.linkText = "Show Info";
            this.infoDataSection.Location = new System.Drawing.Point(63, 40);
            this.infoDataSection.Margin = new System.Windows.Forms.Padding(4);
            this.infoDataSection.Name = "infoDataSection";
            this.infoDataSection.Size = new System.Drawing.Size(215, 232);
            this.infoDataSection.TabIndex = 73;
            // 
            // galleryDataSection
            // 
            this.galleryDataSection.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.galleryDataSection.AutoSize = true;
            this.galleryDataSection.linkText = "Show Gallery";
            this.galleryDataSection.Location = new System.Drawing.Point(979, 42);
            this.galleryDataSection.Margin = new System.Windows.Forms.Padding(10, 15, 10, 15);
            this.galleryDataSection.Name = "galleryDataSection";
            this.galleryDataSection.Size = new System.Drawing.Size(215, 232);
            this.galleryDataSection.TabIndex = 77;
            // 
            // postsDataSection
            // 
            this.postsDataSection.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.postsDataSection.AutoSize = true;
            this.postsDataSection.linkText = "Show Posts";
            this.postsDataSection.Location = new System.Drawing.Point(291, 40);
            this.postsDataSection.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.postsDataSection.Name = "postsDataSection";
            this.postsDataSection.Size = new System.Drawing.Size(215, 232);
            this.postsDataSection.TabIndex = 74;
            // 
            // friendsDataSection
            // 
            this.friendsDataSection.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.friendsDataSection.AutoSize = true;
            this.friendsDataSection.linkText = "Show Friends";
            this.friendsDataSection.Location = new System.Drawing.Point(519, 40);
            this.friendsDataSection.Margin = new System.Windows.Forms.Padding(8, 11, 8, 11);
            this.friendsDataSection.Name = "friendsDataSection";
            this.friendsDataSection.Size = new System.Drawing.Size(215, 232);
            this.friendsDataSection.TabIndex = 76;
            // 
            // videosDataSection
            // 
            this.videosDataSection.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.videosDataSection.AutoSize = true;
            this.videosDataSection.linkText = "Show Videos";
            this.videosDataSection.Location = new System.Drawing.Point(748, 40);
            this.videosDataSection.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.videosDataSection.Name = "videosDataSection";
            this.videosDataSection.Size = new System.Drawing.Size(215, 232);
            this.videosDataSection.TabIndex = 75;
            // 
            // labelToken
            // 
            this.labelToken.AutoSize = true;
            this.labelToken.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelToken.Location = new System.Drawing.Point(478, 75);
            this.labelToken.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelToken.Name = "labelToken";
            this.labelToken.Size = new System.Drawing.Size(75, 24);
            this.labelToken.TabIndex = 72;
            this.labelToken.Text = "Token:";
            this.labelToken.Click += new System.EventHandler(this.labelToken_Click);
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(420, 449);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(345, 254);
            this.axWindowsMediaPlayer1.TabIndex = 69;
            this.axWindowsMediaPlayer1.Enter += new System.EventHandler(this.axWindowsMediaPlayer1_Enter);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(802, 462);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(260, 218);
            this.pictureBox1.TabIndex = 68;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBoxPost
            // 
            this.pictureBoxPost.Location = new System.Drawing.Point(28, 462);
            this.pictureBoxPost.Name = "pictureBoxPost";
            this.pictureBoxPost.Size = new System.Drawing.Size(313, 194);
            this.pictureBoxPost.TabIndex = 62;
            this.pictureBoxPost.TabStop = false;
            // 
            // newTextBox
            // 
            this.newTextBox.Location = new System.Drawing.Point(566, 75);
            this.newTextBox.Name = "newTextBox";
            this.newTextBox.Size = new System.Drawing.Size(237, 28);
            this.newTextBox.TabIndex = 56;
            this.newTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // pictureBoxProfile
            // 
            this.pictureBoxProfile.Location = new System.Drawing.Point(313, 23);
            this.pictureBoxProfile.Name = "pictureBoxProfile";
            this.pictureBoxProfile.Size = new System.Drawing.Size(148, 123);
            this.pictureBoxProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxProfile.TabIndex = 55;
            this.pictureBoxProfile.TabStop = false;
            // 
            // textBoxAppID
            // 
            this.textBoxAppID.Location = new System.Drawing.Point(566, 25);
            this.textBoxAppID.Name = "textBoxAppID";
            this.textBoxAppID.Size = new System.Drawing.Size(237, 28);
            this.textBoxAppID.TabIndex = 54;
            this.textBoxAppID.Text = "917683610037169";
            this.textBoxAppID.TextChanged += new System.EventHandler(this.textBoxAppID_TextChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 31);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1230, 739);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1238, 774);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.userDataGroupBox.ResumeLayout(false);
            this.userDataGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).EndInit();
            this.ResumeLayout(false);

        }

		#endregion

		private System.Windows.Forms.Button buttonLogin;
		private System.Windows.Forms.Button buttonLogout;
		private System.Windows.Forms.Label labelAppID;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox textBoxAppID;
        private System.Windows.Forms.PictureBox pictureBoxProfile;
        private System.Windows.Forms.TextBox newTextBox;
        private System.Windows.Forms.PictureBox pictureBoxPost;
        private System.Windows.Forms.PictureBox pictureBox1;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.Label labelToken;
        private System.Windows.Forms.GroupBox userDataGroupBox;
        private UserDataSection infoDataSection;
        private UserDataSection galleryDataSection;
        private UserDataSection postsDataSection;
        private UserDataSection friendsDataSection;
        private UserDataSection videosDataSection;
    }
}

