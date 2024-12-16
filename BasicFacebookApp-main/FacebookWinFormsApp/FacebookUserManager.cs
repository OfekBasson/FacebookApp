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
    //TODO: Should we implement something like connect using "m_LoginResult = FacebookService.Connect(AccessToken);"
    internal class FacebooktUserManager
    {
        private User m_LoggedInUser { get; set; }
        // TODO: Should we save it? Is it necessary somewhere?
        private string m_AccessToken { get; set; }
        public User EnsureLoggedIn(string i_AppId)
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
                return;
            }
            throw new LoginException("Logging in wasn't successful");
        }
        public void Logout()
        {
            FacebookService.LogoutWithUI();
            m_LoggedInUser = null;
        }

        public bool IsLoggedIn()
        {
            return m_LoggedInUser != null;
        }
        public object GetDataCollectionByType(string i_CollectionType)
        {
            if (i_CollectionType == "post")
            {
                return this.m_LoggedInUser.Posts;
            }
            else if (i_CollectionType == "video")
            {
                return this.m_LoggedInUser.Videos;
            }
            else if (i_CollectionType == "friend")
            {
                return this.m_LoggedInUser.Friends;
            }
            else if (i_CollectionType == "photo")
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
