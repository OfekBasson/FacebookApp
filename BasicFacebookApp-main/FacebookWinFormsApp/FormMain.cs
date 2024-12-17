using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;
using System.Runtime.Remoting.Messaging;

namespace BasicFacebookFeatures
{
    // TODO: Why is the access token text needed?
    internal partial class FormMain : Form
    {
        private string m_AppId = "917683610037169";
        private UIBridge m_bridge { get; set; }
        
        public FormMain()
        {
            InitializeComponent();
            m_bridge = new UIBridge();
            this.Name = "FormMain"; // Explicitly set the form's name for linksearchcontrol
            foreach (LinkSearchListControl control in userDataGroupBox.Controls.OfType<LinkSearchListControl>())
            {
                control.m_bridge = m_bridge;
            }
            m_bridge.LogInError += bridge_LogInError;
            showOrHideControlers(false);
            FacebookService.s_CollectionLimit = 25;
        }


        private void bridge_LogInError()
        {
            MessageBox.Show("Login Error, please try again");
        }


        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("ofekofekfacebook@gmail.com");
            //Clipboard.SetText("design.patterns");
            User loggedInUser = m_bridge.LogIn(m_AppId);
            if (loggedInUser != null)
            {
                updateFormOnLogin(loggedInUser);
            }
        }

        private void updateFormOnLogin(User loggedInUser)
        {
            updateButtonsOnLogin();
            pictureBoxProfile.ImageLocation = m_bridge.m_loggedInUser.PictureNormalURL;
            //displayInvisibleComponentsOnLogin();
            showOrHideControlers(true);
            updateUserSummaryLabel(loggedInUser);
        }

        private void updateUserSummaryLabel(User loggedInUser)
        {
            UserSummaryLabel.Text += $"Summary:\nThe user {loggedInUser.Name}\nwas born on {loggedInUser.Birthday}";
            if (!string.IsNullOrEmpty(loggedInUser?.Location?.Name))
            {
                UserSummaryLabel.Text += $"\nand born in {loggedInUser.Location.Name}";
            }
        }
        private void showOrHideControlers(bool i_isShown)
        {
            this.richTextBoxPosts.Visible = i_isShown;
            this.buttonPost.Visible = i_isShown;
            this.userDataGroupBox.Visible = i_isShown;
            this.axWindowsMediaPlayer1.Visible = i_isShown;
            this.pictureBoxLeft.Visible = i_isShown;
            UserSummaryLabel.Visible = i_isShown;
        }
        //private void displayInvisibleComponentsOnLogin()
        //{
        //    userDataGroupBox.Visible = true;
        //    axWindowsMediaPlayer1.Visible = true;
        //    UserSummaryLabel.Visible= true;
        //}

        private void updateButtonsOnLogin()
        {
            buttonLogout.Enabled = true;
            buttonLogin.Enabled = false;
            buttonLogin.BackColor = Color.LightGreen;
            buttonLogin.Text = $"Logged in as {m_bridge.m_loggedInUser.Name}";
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            m_bridge.Logout();
            UpdateFormOnLogout();
        }

        private void UpdateFormOnLogout()
        {
            buttonLogin.Text = "Login";
            buttonLogin.BackColor = this.buttonLogout.BackColor;
            buttonLogin.Enabled = true;
            buttonLogout.Enabled = false;
            pictureBoxProfile.ImageLocation = null;
            foreach (LinkSearchListControl control in userDataGroupBox.Controls.OfType<LinkSearchListControl>())
            {
                control.hideDataFromListBox();
            }
            showOrHideControlers(false);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxAppID_TextChanged(object sender, EventArgs e)
        {

        }

        // TODO: implement
        //private void listBoxPosts_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Post selectedPost = listBoxPosts.SelectedItem as Post;
        //    if (selectedPost != null && selectedPost.PictureURL != null)
        //    {
        //        pictureBoxPost.ImageLocation = selectedPost.PictureURL;
        //    }
        //}

        public PictureBox PictureBoxLeft
        {
            get
            {
                return this.pictureBoxLeft;
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        // TODO: implement
        //private void listBoxGallery_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Photo selectedPhoto = listBoxGallery.SelectedItem as Photo;
        //    if (selectedPhoto != null && selectedPhoto.PictureAlbumURL != null)
        //        pictureBox1.ImageLocation = selectedPhoto.PictureAlbumURL;
        //}

 

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void InfoDataSection_Load(object sender, EventArgs e)
        {

        }

        private void infoDataSection_Load_1(object sender, EventArgs e)
        {

        }

        private void labelToken_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBoxProfile_Click(object sender, EventArgs e)
        {

        }

        private void VideosDataSection_Load(object sender, EventArgs e)
        {

        }

        private void FacebookLogo_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonPost_Click(object sender, EventArgs e)
        {
            PostStatus();
        }
        private void PostStatus()
        {
            MessageBox.Show("Status: " + this.richTextBoxPosts.Text);
            m_bridge.PostStatus(this.richTextBoxPosts.Text);
            this.richTextBoxPosts.Text = "Write Here...";
        }

        private void pictureBoxLeft_Click(object sender, EventArgs e)
        {

        }

    }
}
