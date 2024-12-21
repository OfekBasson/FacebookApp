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
            this.listBoxDrafts = new System.Windows.Forms.ListBox();
            this.buttonSaveDraft = new System.Windows.Forms.Button();
            this.buttonPost = new System.Windows.Forms.Button();
            this.richTextBoxPosts = new System.Windows.Forms.RichTextBox();
            this.userDataGroupBox = new System.Windows.Forms.GroupBox();
            this.UserSummaryLabel = new System.Windows.Forms.Label();
            this.GalleryDataSection = new BasicFacebookFeatures.LinkSearchListControl();
            this.PostsDataSection = new BasicFacebookFeatures.LinkSearchListControl();
            this.FriendsDataSection = new BasicFacebookFeatures.LinkSearchListControl();
            this.VideosDataSection = new BasicFacebookFeatures.LinkSearchListControl();
            this.FacebookLogo = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.pictureBoxLeft = new System.Windows.Forms.PictureBox();
            this.pictureBoxProfile = new System.Windows.Forms.PictureBox();
            this.buttonClearDrafts = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.userDataGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FacebookLogo)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeft)).BeginInit();
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
            this.tabPage1.Controls.Add(this.buttonClearDrafts);
            this.tabPage1.Controls.Add(this.listBoxDrafts);
            this.tabPage1.Controls.Add(this.buttonSaveDraft);
            this.tabPage1.Controls.Add(this.buttonPost);
            this.tabPage1.Controls.Add(this.richTextBoxPosts);
            this.tabPage1.Controls.Add(this.userDataGroupBox);
            this.tabPage1.Controls.Add(this.FacebookLogo);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.axWindowsMediaPlayer1);
            this.tabPage1.Controls.Add(this.pictureBoxLeft);
            this.tabPage1.Controls.Add(this.pictureBoxProfile);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1230, 744);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // listBoxDrafts
            // 
            this.listBoxDrafts.FormattingEnabled = true;
            this.listBoxDrafts.ItemHeight = 18;
            this.listBoxDrafts.Location = new System.Drawing.Point(845, 628);
            this.listBoxDrafts.Name = "listBoxDrafts";
            this.listBoxDrafts.Size = new System.Drawing.Size(377, 112);
            this.listBoxDrafts.TabIndex = 85;
            this.listBoxDrafts.SelectedIndexChanged += new System.EventHandler(this.listBoxDrafts_SelectedIndexChanged);
            // 
            // buttonSaveDraft
            // 
            this.buttonSaveDraft.BackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonSaveDraft.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonSaveDraft.Location = new System.Drawing.Point(845, 573);
            this.buttonSaveDraft.Name = "buttonSaveDraft";
            this.buttonSaveDraft.Size = new System.Drawing.Size(377, 27);
            this.buttonSaveDraft.TabIndex = 83;
            this.buttonSaveDraft.Text = "Save as Draft";
            this.buttonSaveDraft.UseVisualStyleBackColor = false;
            this.buttonSaveDraft.Click += new System.EventHandler(this.buttonSaveDraft_Click);
            // 
            // buttonPost
            // 
            this.buttonPost.BackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonPost.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonPost.Location = new System.Drawing.Point(1146, 548);
            this.buttonPost.Name = "buttonPost";
            this.buttonPost.Size = new System.Drawing.Size(76, 27);
            this.buttonPost.TabIndex = 82;
            this.buttonPost.Text = "Post";
            this.buttonPost.UseVisualStyleBackColor = false;
            this.buttonPost.Click += new System.EventHandler(this.buttonPost_Click);
            // 
            // richTextBoxPosts
            // 
            this.richTextBoxPosts.Location = new System.Drawing.Point(845, 526);
            this.richTextBoxPosts.Name = "richTextBoxPosts";
            this.richTextBoxPosts.Size = new System.Drawing.Size(377, 49);
            this.richTextBoxPosts.TabIndex = 81;
            this.richTextBoxPosts.Text = "Write Here...";
            this.richTextBoxPosts.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // userDataGroupBox
            // 
            this.userDataGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.userDataGroupBox.Controls.Add(this.UserSummaryLabel);
            this.userDataGroupBox.Controls.Add(this.GalleryDataSection);
            this.userDataGroupBox.Controls.Add(this.PostsDataSection);
            this.userDataGroupBox.Controls.Add(this.FriendsDataSection);
            this.userDataGroupBox.Controls.Add(this.VideosDataSection);
            this.userDataGroupBox.Location = new System.Drawing.Point(3, 251);
            this.userDataGroupBox.Name = "userDataGroupBox";
            this.userDataGroupBox.Size = new System.Drawing.Size(3284, 267);
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
            this.UserSummaryLabel.Size = new System.Drawing.Size(0, 18);
            this.UserSummaryLabel.TabIndex = 1;
            this.UserSummaryLabel.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // GalleryDataSection
            // 
            this.GalleryDataSection.Location = new System.Drawing.Point(982, 27);
            this.GalleryDataSection.m_Bridge = null;
            this.GalleryDataSection.m_LinkText = "Show Gallery";
            this.GalleryDataSection.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GalleryDataSection.Name = "GalleryDataSection";
            this.GalleryDataSection.Size = new System.Drawing.Size(242, 209);
            this.GalleryDataSection.TabIndex = 0;
            this.GalleryDataSection.Load += new System.EventHandler(this.GalleryDataSection_Load);
            // 
            // PostsDataSection
            // 
            this.PostsDataSection.Location = new System.Drawing.Point(240, 24);
            this.PostsDataSection.m_Bridge = null;
            this.PostsDataSection.m_LinkText = "Show Posts";
            this.PostsDataSection.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PostsDataSection.Name = "PostsDataSection";
            this.PostsDataSection.Size = new System.Drawing.Size(241, 209);
            this.PostsDataSection.TabIndex = 0;
            // 
            // FriendsDataSection
            // 
            this.FriendsDataSection.Location = new System.Drawing.Point(487, 24);
            this.FriendsDataSection.m_Bridge = null;
            this.FriendsDataSection.m_LinkText = "Show Friends";
            this.FriendsDataSection.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.FriendsDataSection.Name = "FriendsDataSection";
            this.FriendsDataSection.Size = new System.Drawing.Size(241, 209);
            this.FriendsDataSection.TabIndex = 0;
            this.FriendsDataSection.Load += new System.EventHandler(this.FriendsDataSection_Load);
            // 
            // VideosDataSection
            // 
            this.VideosDataSection.Location = new System.Drawing.Point(734, 27);
            this.VideosDataSection.m_Bridge = null;
            this.VideosDataSection.m_LinkText = "Show Videos";
            this.VideosDataSection.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.VideosDataSection.Name = "VideosDataSection";
            this.VideosDataSection.Size = new System.Drawing.Size(242, 209);
            this.VideosDataSection.TabIndex = 0;
            this.VideosDataSection.Load += new System.EventHandler(this.VideosDataSection_Load);
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
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(444, 524);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(327, 210);
            this.axWindowsMediaPlayer1.TabIndex = 69;
            this.axWindowsMediaPlayer1.Enter += new System.EventHandler(this.axWindowsMediaPlayer1_Enter);
            // 
            // pictureBoxLeft
            // 
            this.pictureBoxLeft.Location = new System.Drawing.Point(36, 524);
            this.pictureBoxLeft.Name = "pictureBoxLeft";
            this.pictureBoxLeft.Size = new System.Drawing.Size(373, 210);
            this.pictureBoxLeft.TabIndex = 62;
            this.pictureBoxLeft.TabStop = false;
            this.pictureBoxLeft.Click += new System.EventHandler(this.pictureBoxLeft_Click);
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
            // buttonClearDrafts
            // 
            this.buttonClearDrafts.BackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonClearDrafts.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonClearDrafts.Location = new System.Drawing.Point(845, 599);
            this.buttonClearDrafts.Name = "buttonClearDrafts";
            this.buttonClearDrafts.Size = new System.Drawing.Size(377, 27);
            this.buttonClearDrafts.TabIndex = 86;
            this.buttonClearDrafts.Text = "Clear All Drafts";
            this.buttonClearDrafts.UseVisualStyleBackColor = false;
            this.buttonClearDrafts.Click += new System.EventHandler(this.buttonClearDrafts_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.PictureBox pictureBoxLeft;
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
        private System.Windows.Forms.RichTextBox richTextBoxPosts;
        private System.Windows.Forms.Button buttonPost;
        private System.Windows.Forms.Button buttonSaveDraft;
        private System.Windows.Forms.ListBox listBoxDrafts;
        private System.Windows.Forms.Button buttonClearDrafts;
    }
}

