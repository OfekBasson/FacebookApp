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
            loadDrafts();
            showOrHideControlers(false);
            this.richTextBoxPosts.Text = "Write Here...";
            FacebookService.s_CollectionLimit = 25;
            //Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
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
            showOrHideControlers(true);
            updateUserSummaryLabel(loggedInUser);
        }

        private void updateUserSummaryLabel(User loggedInUser)
        {
            UserSummaryLabel.Text = $"Summary:\nThe user {loggedInUser.Name}\nwas born on {loggedInUser.Birthday}";
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
            this.buttonClearDrafts.Visible = i_isShown;
            this.buttonSaveDraft.Visible = i_isShown;
            this.listBoxDrafts.Visible = i_isShown;

        }

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
            m_bridge.saveDraftsToFile();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxAppID_TextChanged(object sender, EventArgs e)
        {

        }

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

        private void FriendsDataSection_Load(object sender, EventArgs e)
        {

        }

        private void GalleryDataSection_Load(object sender, EventArgs e)
        {

        }

        private void buttonSaveDraft_Click(object sender, EventArgs e)
        {
            saveDraft();
        }

        private void saveDraft()
        {
            Console.WriteLine("on posts: " + this.richTextBoxPosts.Text);
            List<PostDraft> postsDraft = m_bridge.AddDraft(DateTime.Now.ToString(), this.richTextBoxPosts.Text);
            refreshListBoxDrafts(postsDraft);
        }

        private void refreshListBoxDrafts(List<PostDraft> postsDraft)
        {
            // Reset the DataSource to refresh the ListBox
            this.listBoxDrafts.DataSource = null;
            this.listBoxDrafts.DataSource = postsDraft;
            this.listBoxDrafts.DisplayMember = "m_Title";
        }

        private void loadDrafts()
        {
            this.listBoxDrafts.DataSource = m_bridge.LoadDrafts();
        }

        private void listBoxDrafts_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBoxDrafts.SelectedIndex;
            if (index == -1) return;
            List<PostDraft> drafts = m_bridge.GetDrafts();
            Console.WriteLine("content: " + drafts[index].m_Content);
            this.richTextBoxPosts.Text = drafts[index].m_Content;
        }

        private void buttonClearDrafts_Click(object sender, EventArgs e)
        {
            refreshListBoxDrafts(m_bridge.ClearDrafts());
        }
    }
}
