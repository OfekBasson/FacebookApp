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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.userDataGroupBox = new System.Windows.Forms.GroupBox();
            this.UserSummaryLabel = new System.Windows.Forms.Label();
            this.FacebookLogo = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxPost = new System.Windows.Forms.PictureBox();
            this.pictureBoxProfile = new System.Windows.Forms.PictureBox();
            this.GalleryDataSection = new BasicFacebookFeatures.LinkSearchListControl();
            this.PostsDataSection = new BasicFacebookFeatures.LinkSearchListControl();
            this.FriendsDataSection = new BasicFacebookFeatures.LinkSearchListControl();
            this.VideosDataSection = new BasicFacebookFeatures.LinkSearchListControl();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.userDataGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FacebookLogo)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1238, 775);
            this.tabControl1.TabIndex = 54;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.userDataGroupBox);
            this.tabPage1.Controls.Add(this.FacebookLogo);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.axWindowsMediaPlayer1);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.pictureBoxPost);
            this.tabPage1.Controls.Add(this.pictureBoxProfile);
            this.tabPage1.Location = new System.Drawing.Point(4, 35);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1230, 736);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // userDataGroupBox
            // 
            this.userDataGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.userDataGroupBox.Controls.Add(this.UserSummaryLabel);
            this.userDataGroupBox.Controls.Add(this.GalleryDataSection);
            this.userDataGroupBox.Controls.Add(this.PostsDataSection);
            this.userDataGroupBox.Controls.Add(this.FriendsDataSection);
            this.userDataGroupBox.Controls.Add(this.VideosDataSection);
            this.userDataGroupBox.Location = new System.Drawing.Point(3, 174);
            this.userDataGroupBox.Name = "userDataGroupBox";
            this.userDataGroupBox.Size = new System.Drawing.Size(1229, 267);
            this.userDataGroupBox.TabIndex = 78;
            this.userDataGroupBox.TabStop = false;
            this.userDataGroupBox.Visible = false;
            this.userDataGroupBox.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // UserSummaryLabel
            // 
            this.UserSummaryLabel.AutoSize = true;
            this.UserSummaryLabel.Location = new System.Drawing.Point(38, 27);
            this.UserSummaryLabel.Name = "UserSummaryLabel";
            this.UserSummaryLabel.Size = new System.Drawing.Size(0, 26);
            this.UserSummaryLabel.TabIndex = 1;
            this.UserSummaryLabel.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // FacebookLogo
            // 
            this.FacebookLogo.Image = global::BasicFacebookFeatures.Properties.Resources.Facebook_Logo;
            this.FacebookLogo.Location = new System.Drawing.Point(435, 1);
            this.FacebookLogo.Name = "FacebookLogo";
            this.FacebookLogo.Size = new System.Drawing.Size(355, 176);
            this.FacebookLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.FacebookLogo.TabIndex = 80;
            this.FacebookLogo.TabStop = false;
            this.FacebookLogo.Click += new System.EventHandler(this.FacebookLogo_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonLogin);
            this.panel1.Controls.Add(this.buttonLogout);
            this.panel1.Location = new System.Drawing.Point(41, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(148, 123);
            this.panel1.TabIndex = 79;
            // 
            // buttonLogin
            // 
            this.buttonLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogin.Location = new System.Drawing.Point(0, -1);
            this.buttonLogin.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(148, 58);
            this.buttonLogin.TabIndex = 36;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // buttonLogout
            // 
            this.buttonLogout.Enabled = false;
            this.buttonLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogout.Location = new System.Drawing.Point(0, 64);
            this.buttonLogout.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(148, 58);
            this.buttonLogout.TabIndex = 52;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(436, 473);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(345, 254);
            this.axWindowsMediaPlayer1.TabIndex = 69;
            this.axWindowsMediaPlayer1.Enter += new System.EventHandler(this.axWindowsMediaPlayer1_Enter);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(808, 473);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(387, 210);
            this.pictureBox1.TabIndex = 68;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBoxPost
            // 
            this.pictureBoxPost.Location = new System.Drawing.Point(38, 473);
            this.pictureBoxPost.Name = "pictureBoxPost";
            this.pictureBoxPost.Size = new System.Drawing.Size(373, 210);
            this.pictureBoxPost.TabIndex = 62;
            this.pictureBoxPost.TabStop = false;
            // 
            // pictureBoxProfile
            // 
            this.pictureBoxProfile.Location = new System.Drawing.Point(1042, 23);
            this.pictureBoxProfile.Name = "pictureBoxProfile";
            this.pictureBoxProfile.Size = new System.Drawing.Size(148, 123);
            this.pictureBoxProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxProfile.TabIndex = 55;
            this.pictureBoxProfile.TabStop = false;
            this.pictureBoxProfile.Click += new System.EventHandler(this.pictureBoxProfile_Click);
            // 
            // GalleryDataSection
            // 
            this.GalleryDataSection.Location = new System.Drawing.Point(990, 27);
            this.GalleryDataSection.m_bridge = null;
            this.GalleryDataSection.m_linkText = "Show Gallery";
            this.GalleryDataSection.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GalleryDataSection.Name = "GalleryDataSection";
            this.GalleryDataSection.Size = new System.Drawing.Size(200, 209);
            this.GalleryDataSection.TabIndex = 0;
            // 
            // PostsDataSection
            // 
            this.PostsDataSection.Location = new System.Drawing.Point(273, 27);
            this.PostsDataSection.m_bridge = null;
            this.PostsDataSection.m_linkText = "Show Posts";
            this.PostsDataSection.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PostsDataSection.Name = "PostsDataSection";
            this.PostsDataSection.Size = new System.Drawing.Size(200, 209);
            this.PostsDataSection.TabIndex = 0;
            // 
            // FriendsDataSection
            // 
            this.FriendsDataSection.Location = new System.Drawing.Point(509, 27);
            this.FriendsDataSection.m_bridge = null;
            this.FriendsDataSection.m_linkText = "Show Friends";
            this.FriendsDataSection.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.FriendsDataSection.Name = "FriendsDataSection";
            this.FriendsDataSection.Size = new System.Drawing.Size(200, 209);
            this.FriendsDataSection.TabIndex = 0;
            // 
            // VideosDataSection
            // 
            this.VideosDataSection.Location = new System.Drawing.Point(753, 27);
            this.VideosDataSection.m_bridge = null;
            this.VideosDataSection.m_linkText = "Show Videos";
            this.VideosDataSection.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.VideosDataSection.Name = "VideosDataSection";
            this.VideosDataSection.Size = new System.Drawing.Size(200, 209);
            this.VideosDataSection.TabIndex = 0;
            this.VideosDataSection.Load += new System.EventHandler(this.VideosDataSection_Load);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1238, 775);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facebook App - Design Patterns Course";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.userDataGroupBox.ResumeLayout(false);
            this.userDataGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FacebookLogo)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBoxPost;
        private System.Windows.Forms.PictureBox pictureBoxProfile;
        private LinkSearchListControl VideosDataSection;
        private LinkSearchListControl FriendsDataSection;
        private LinkSearchListControl PostsDataSection;
        private LinkSearchListControl GalleryDataSection;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.GroupBox userDataGroupBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox FacebookLogo;
        private System.Windows.Forms.Label UserSummaryLabel;
    }
}

