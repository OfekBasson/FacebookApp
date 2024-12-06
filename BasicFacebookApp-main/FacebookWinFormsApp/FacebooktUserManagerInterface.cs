using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures
{
    //TODO: Should I implement something like connect using "m_LoginResult = FacebookService.Connect(AccessToken);"
    public class FacebooktUserManagerInterface
    {
        public User m_LoggedInUser { get; private set; }
        // TODO: SHould I even save it? Is it necessary somewhere?
        public string m_AccessToken { get; private set; }
        public User LogInIfNotLoggedInYetAndReturnLoggedInUser(string i_AppId)
        {
            if (!IsLoggedIn())
            {
                login(i_AppId);
            }
            return m_LoggedInUser;
            
        }
        private void login(string i_AppID)
        {
            LoginResult m_LoginResult = FacebookService.Login(
                i_AppID,
                "email",
                "public_profile",
                "user_photos",
                "user_posts",
                "user_friends",
                "user_location",
                "user_birthday",
                "user_hometown",
                "user_gender",
                "user_videos"
                );


            if (string.IsNullOrEmpty(m_LoginResult.ErrorMessage))
            {
                m_LoggedInUser = m_LoginResult.LoggedInUser;
                m_AccessToken = m_LoginResult.AccessToken;

            }
        }
        public void Logout()
        {
            FacebookService.LogoutWithUI();
            // TODO: If someone closes the window before he logged out there isn't a way to get this data from the FacebookService... What to do?
            m_LoggedInUser = null;
        }
        // TODO: Is it better to save this as a field? or it's good as a function?

        public bool IsLoggedIn()
        {
            return m_LoggedInUser != null;
        }
        public object GetDataCollectionByName(string i_Name)
        {
            if (i_Name == "infoDataSection")
            {
                //_dataCollection = facebookUserManagerInterface.m_LoggedInUser.Posts;
                //TODO: Implement
                return new object();
            }
            else if (i_Name == "postsDataSection")
            {
                return this.m_LoggedInUser.Posts;
            }
            else if (i_Name == "videosDataSection")
            {
                return this.m_LoggedInUser.Videos;
            }
            else if (i_Name == "friendsDataSection")
            {
                return this.m_LoggedInUser.Friends;
            }
            else if (i_Name == "galleryDataSection")
            {
                List<Photo> allPhotos = this.m_LoggedInUser.Albums.SelectMany(album => album.Photos).ToList();
                FacebookObjectCollection<Photo> photoCollection = new FacebookObjectCollection<Photo>(allPhotos.Count);
                foreach (var photo in allPhotos)
                {
                    photoCollection.Add(photo);
                }
                return photoCollection;
            }
            else {
                //TODO: Implement maybe null isn't good...
                return null;
            }

    }

}
}
