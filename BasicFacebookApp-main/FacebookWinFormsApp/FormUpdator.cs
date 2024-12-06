using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures
{
    // TODO: Why is this initiated as internal?
    public class FormUpdator
    {
        // TODO: Does this make sense to define it as a private property?
        private Button m_buttonLogin;
        private Button m_buttonLogout;
        private PictureBox m_pictureBoxProfile;
        private List<UserDataSection> m_userDataSections;
        // TODO: Naming using conventions
        public FormUpdator(Button i_ButtonLogin, Button i_ButtonLogout, PictureBox i_PictureBoxProfile, List<UserDataSection> i_UserDataSections)
        {
            m_buttonLogin = i_ButtonLogin;
            m_buttonLogout = i_ButtonLogout;   
            m_pictureBoxProfile = i_PictureBoxProfile;
            m_userDataSections = i_UserDataSections;
        }
        public void UpdateFormOnUserLogin(User loggedInUser)
        {
            m_buttonLogout.Enabled = true;
            m_buttonLogin.Enabled = false;
            m_buttonLogin.BackColor = Color.LightGreen;
            m_buttonLogin.Text = $"Logged in as {loggedInUser.Name}";
            m_pictureBoxProfile.ImageLocation = loggedInUser.PictureNormalURL;
            // TODO: Change newTextBox to accessTokenTextBox if neccessary (Should I even save it?)
            // newTextBox.Text = facebookUserManagerInterface.m_AccessToken;
        }
        public void UpdateFormOnUserLogout()
        {
            FacebookService.LogoutWithUI();
            m_buttonLogin.Text = "Login";
            m_buttonLogin.BackColor = m_buttonLogout.BackColor;
            m_buttonLogin.Enabled = true;
            m_buttonLogout.Enabled = false;
            m_pictureBoxProfile.ImageLocation = null;
            foreach (UserDataSection userDataSection in m_userDataSections)
            {
                removeDataFromDataSectionsListBox(userDataSection);
            }
        }

        private void removeDataFromDataSectionsListBox(UserDataSection userDataSection)
        {
            userDataSection.listBox.Items.Clear();
        }

        // TODO: Did they learn switch?
        // TODO: Check with guy if it's better to implement the UserForm using a visitor (It's not that simple because it already inherits from UserForm and now it should also implement methods of a new interface)
        public void InsertDataToListBox(ListBox i_ListBox, object i_Collection)
        {
            if (i_Collection == null)
            {
                // TODO: Throw exceptions?
                Console.WriteLine("No collection found.");
                return;
            }

            switch (i_Collection)
            {
                case FacebookObjectCollection<Post> postsCollection:
                case FacebookObjectCollection<Video> videosCollection:
                case FacebookObjectCollection<User> friendsCollection:
                case FacebookObjectCollection<Photo> photosCollection:
                    insertDataAsFaceBookObjectCollectionToListBox(i_ListBox, (dynamic)i_Collection);
                    break;
                default:
                    Console.WriteLine("Unsupported collection type.");
                    break;
            }
        }
        private void insertDataAsFaceBookObjectCollectionToListBox<T>(ListBox listBox, FacebookObjectCollection<T> dataCollection)
        {
            foreach (object dataMember in dataCollection)
            {
                if (dataMember != null)
                {
                    listBox.Items.Add(dataMember);
                }
            }
            // TODO: Throw exception if I don't have data? Catch it later?
        }
    }
}
