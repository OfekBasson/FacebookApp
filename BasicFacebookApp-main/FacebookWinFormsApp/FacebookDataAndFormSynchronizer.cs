using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures
{
    // TODO: Why is it initiated as internal class?
    public class FacebookDataAndFormSynchronizer
    {
        private FacebooktUserManagerInterface m_userManager;
        private FormUpdator m_formUpdator;

        // TODO: Change to get all buttons instead of specific buttons
        public FacebookDataAndFormSynchronizer(Button buttonLogin, Button buttonLogout, PictureBox pictureBoxProfile, List<UserDataSection> dataSections)
        {
            m_userManager = new FacebooktUserManagerInterface();
            //TODO: Change the name dataSection everywhere
            m_formUpdator = new FormUpdator(buttonLogin, buttonLogout, pictureBoxProfile, dataSections);
            foreach (UserDataSection dataSection in dataSections)
            {
                dataSection._facebookDataAndFormSynchronizer = this;
            }
        }
        public void LogInAndUpdateForm(string i_AppId)
        {
            User loggedInUser = m_userManager.LogInIfNotLoggedInYetAndReturnLoggedInUser(i_AppId);
            if (m_userManager.IsLoggedIn())
            {
                m_formUpdator.UpdateFormOnUserLogin(loggedInUser);
            }
        }
        public void LogoutAndUpdateForm()
        {
            m_userManager.Logout();
            if (!m_userManager.IsLoggedIn())
            {
                m_formUpdator.UpdateFormOnUserLogout();
            }
        }
      
        // TODO: Should change i_Name to something better (Form Name or something...)
        public void InsertDataToListBox(ListBox i_ListBox, string i_Name)
        {
            if (m_userManager.IsLoggedIn())
            {
            object collection = m_userManager.GetDataCollectionByName(i_Name);
            m_formUpdator.InsertDataToListBox(i_ListBox, collection);
            }
            else
            {
                MessageBox.Show("There is no logged in user, please log in");
            }
        }
    }
}
