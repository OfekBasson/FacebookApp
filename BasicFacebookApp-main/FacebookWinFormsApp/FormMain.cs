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
    internal partial class FormMain : Form
    {
        private string m_AppId = "917683610037169";
        private UIBridge m_Bridge { get; set; }
        public PictureBox m_PictureBoxLeft
        {
            get
            {
                return this.pictureBoxLeft;
            }
        }

        public FormMain()
        {
            InitializeComponent();
            m_Bridge = new UIBridge();
            this.Name = "FormMain"; // Explicitly set the form's name for linksearchcontrol
            foreach (LinkSearchListControl control in userDataGroupBox.Controls.OfType<LinkSearchListControl>())
            {
                control.m_Bridge = m_Bridge;
            }
            m_Bridge.ErrorOccured += bridge_ErrorOccured;
            loadDrafts();
            showOrHideControlers(false);
            this.richTextBoxPosts.Text = "Write Here...";
            FacebookService.s_CollectionLimit = 25;
            //Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
        }


        private void bridge_ErrorOccured(string i_ErrorMessage)
        {
            MessageBox.Show($"Error occured, please try again or call support 052538164, and add also 8.\nError message: {i_ErrorMessage}");
        }


        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("ofekofekfacebook@gmail.com");
            //Clipboard.SetText("design.patterns");
            User loggedInUser = m_Bridge.LogIn(m_AppId);
            if (loggedInUser != null)
            {
                updateFormOnLogin(loggedInUser);
            }
        }

        private void updateFormOnLogin(User i_LoggedInUser)
        {
            updateButtonsOnLogin();
            pictureBoxProfile.ImageLocation = m_Bridge.m_LoggedInUser.PictureNormalURL;
            showOrHideControlers(true);
            updateUserSummaryLabel(i_LoggedInUser);
        }

        private void updateUserSummaryLabel(User i_LoggedInUser)
        {
            UserSummaryLabel.Text = $"Summary:\nThe user {i_LoggedInUser.Name}\nwas born on {i_LoggedInUser.Birthday}";
            if (!string.IsNullOrEmpty(i_LoggedInUser?.Location?.Name))
            {
                UserSummaryLabel.Text += $"\nand born in {i_LoggedInUser.Location.Name}";
            }
        }
        private void showOrHideControlers(bool i_IsShown)
        {
            this.richTextBoxPosts.Visible = i_IsShown;
            this.buttonPost.Visible = i_IsShown;
            this.userDataGroupBox.Visible = i_IsShown;
            this.axWindowsMediaPlayer1.Visible = i_IsShown;
            this.pictureBoxLeft.Visible = i_IsShown;
            UserSummaryLabel.Visible = i_IsShown;
            this.buttonClearDrafts.Visible = i_IsShown;
            this.buttonSaveDraft.Visible = i_IsShown;
            this.listBoxDrafts.Visible = i_IsShown;

        }

        private void updateButtonsOnLogin()
        {
            buttonLogout.Enabled = true;
            buttonLogin.Enabled = false;
            buttonLogin.BackColor = Color.LightGreen;
            buttonLogin.Text = $"Logged in as {m_Bridge.m_LoggedInUser.Name}";
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            m_Bridge.Logout();
            UpdateFormOnLogout();
        }

        private void UpdateFormOnLogout()
        {
            updateButtonsOnLogout();
            pictureBoxProfile.ImageLocation = null;
            foreach (LinkSearchListControl control in userDataGroupBox.Controls.OfType<LinkSearchListControl>())
            {
                control.HideDataFromListBox();
            }
            showOrHideControlers(false);
            m_Bridge.SaveDraftsToFile();
        }

        private void updateButtonsOnLogout()
        {
            buttonLogin.Text = "Login";
            buttonLogin.BackColor = this.buttonLogout.BackColor;
            buttonLogin.Enabled = true;
            buttonLogout.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxAppID_TextChanged(object sender, EventArgs e)
        {

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
            m_Bridge.PostStatus(this.richTextBoxPosts.Text);
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
            List<PostDraft> postsDraft = m_Bridge.AddDraft(DateTime.Now.ToString(), this.richTextBoxPosts.Text);
            refreshListBoxDrafts(postsDraft);
        }

        private void refreshListBoxDrafts(List<PostDraft> i_PostsDraft)
        {
            // Reset the DataSource to refresh the ListBox
            this.listBoxDrafts.DataSource = null;
            this.listBoxDrafts.DataSource = i_PostsDraft;
            this.listBoxDrafts.DisplayMember = "m_Title";
        }

        private void loadDrafts()
        {
            this.listBoxDrafts.DataSource = m_Bridge.LoadDrafts();
        }

        private void listBoxDrafts_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBoxDrafts.SelectedIndex;
            if (index == -1) return;
            List<PostDraft> drafts = m_Bridge.GetDrafts();
            Console.WriteLine("content: " + drafts[index].m_Content);
            this.richTextBoxPosts.Text = drafts[index].m_Content;
        }

        private void buttonClearDrafts_Click(object sender, EventArgs e)
        {
            refreshListBoxDrafts(m_Bridge.ClearDrafts());
        }
    }
}
