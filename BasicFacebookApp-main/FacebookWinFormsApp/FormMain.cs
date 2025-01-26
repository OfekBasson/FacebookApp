using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;
using System.Threading;

namespace BasicFacebookFeatures
{
    internal partial class FormMain : Form
    {
        private string m_AppId = "917683610037169";
        private Facade m_Facade;
        
        public PictureBox m_PictureBoxLeft()
        {
                return this.pictureBoxLeft;
        }

        public FormMain()
        {
            InitializeComponent();
            m_Facade = Singleton<Facade>.Instance;
            m_Facade.ErrorOccured += facade_ErrorOccured;
            this.Name = "FormMain"; 
            postDraftBindingSource.DataSource = m_Facade.GetDrafts().m_ResultData;
            showOrHideControlers(false);
            this.richTextBoxPosts.Text = "Write Here...";
            FacebookService.s_CollectionLimit = 25;
        }


        private void facade_ErrorOccured(string i_ErrorMessage)
        {
            MessageBox.Show($"Error occured, please try again or call support 052538164, and add also 8.\nError message: {i_ErrorMessage}");
        }


        private void buttonLogin_Click(object sender, EventArgs e)
        {
            LogicLayerResult loginResult = m_Facade.LogIn(m_AppId);

            if (loginResult.m_Status == LogicLayerResult.ResultStatus.Success)
            {
                User loggedInUser = (User)loginResult.m_ResultData;
                updateFormOnLogin(loggedInUser);
            }
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
            LogicLayerResult logoutResult = m_Facade.Logout();
            if (logoutResult.m_Status == LogicLayerResult.ResultStatus.Success)
            {
                UpdateFormOnLogout();
            }
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

        private void buttonPost_Click(object sender, EventArgs e)
        {
            PostStatus();
        }
        private void PostStatus()
        {
            MessageBox.Show("Status: " + this.richTextBoxPosts.Text);
            m_Facade.PostStatus(this.richTextBoxPosts.Text);
            richTextBoxPosts.Text = "Write Here...";
        }

        private void buttonSaveDraft_Click(object sender, EventArgs e)
        {
            saveDraft();
        }

        private void saveDraft()
        {
            m_Facade.AddDraft(DateTime.Now.ToString(), richTextBoxPosts.Text);
        }

        private void buttonClearDrafts_Click(object sender, EventArgs e)
        {
            m_Facade.ClearDrafts();
        }

    }
}
