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
using System.Threading;

namespace BasicFacebookFeatures
{
    internal partial class FormMain : Form
    {
        private string m_AppId = "917683610037169";
        private Facade m_Facade { get; set; }
        
        public PictureBox m_PictureBoxLeft()
        {
                return this.pictureBoxLeft;
        }

        public FormMain()
        {
            InitializeComponent();
            m_Facade = new Facade();
            this.Name = "FormMain"; // Explicitly set the form's name for linksearchcontrol
            foreach (LinkSearchListControl control in userDataGroupBox.Controls.OfType<LinkSearchListControl>())
            {
                control.m_Facade = m_Facade;
            }

            m_Facade.ErrorOccured += bridge_ErrorOccured;
            postDraftBindingSource.DataSource = m_Facade.GetDrafts();
            showOrHideControlers(false);
            this.richTextBoxPosts.Text = "Write Here...";
            FacebookService.s_CollectionLimit = 25;
        }


        private void bridge_ErrorOccured(string i_ErrorMessage)
        {
            MessageBox.Show($"Error occured, please try again or call support 052538164, and add also 8.\nError message: {i_ErrorMessage}");
        }


        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Thread loginThread = new Thread(() =>
            {
                User loggedInUser = m_Facade.LogIn(m_AppId);

                if (loggedInUser != null)
                {
                    this.Invoke(new Action(() =>
                    {
                        updateFormOnLogin(loggedInUser);
                    }));
                }
            });

            loginThread.Start(); 
        }


        private void updateFormOnLogin(User i_LoggedInUser)
        {
            updateButtonsOnLogin();
            pictureBoxProfile.ImageLocation = m_Facade.m_LoggedInUser.PictureNormalURL;
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
            this.pictureBoxLeft.Visible = i_IsShown;
            UserSummaryLabel.Visible = i_IsShown;
            this.buttonClearDrafts.Visible = i_IsShown;
            this.buttonSaveDraft.Visible = i_IsShown;
            this.listBoxDrafts.Visible = i_IsShown;
            this.panelDraft.Visible = i_IsShown;
        }

        private void updateButtonsOnLogin()
        {
            buttonLogout.Enabled = true;
            buttonLogin.Enabled = false;
            buttonLogin.BackColor = Color.LightGreen;
            buttonLogin.Text = $"Logged in as {m_Facade.m_LoggedInUser.Name}";
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            m_Facade.Logout();
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
            m_Facade.SaveDraftsToFile();
        }

        private void updateButtonsOnLogout()
        {
            buttonLogin.Text = "Login";
            buttonLogin.BackColor = this.buttonLogout.BackColor;
            buttonLogin.Enabled = true;
            buttonLogout.Enabled = false;
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void FormMain_Load(object sender, EventArgs e)
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
            m_Facade.PostStatus(this.richTextBoxPosts.Text);
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
            m_Facade.AddDraft(DateTime.Now.ToString(), this.richTextBoxPosts.Text);
        }

        private void buttonClearDrafts_Click(object sender, EventArgs e)
        {
            m_Facade.ClearDrafts();
        }
    }
}
