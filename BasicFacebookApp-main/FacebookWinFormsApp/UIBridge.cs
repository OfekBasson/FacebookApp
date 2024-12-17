using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures
{
    public class UIBridge
    {
        private FacebooktUserManager m_userManager;
        public User m_loggedInUser { get; set; }
        public List<Post> m_posts { get; set; }
        public List<Video> m_videos { get; set; }
        public List<User> m_friends { get; set; }
        public List<Photo> m_photos { get; set; }
        public event Action LogInError;

        public UIBridge()
        {
            m_userManager = new FacebooktUserManager();
        }

        public User LogIn(string i_AppId)
        {
            try
            {
                m_loggedInUser = m_userManager.EnsureLoggedIn(i_AppId);
            }
            catch (Exception e)
            {
                OnLogInError();
            }
            
            if (m_loggedInUser != null)
            {
                SaveFacebookCollectionAsListToBridge("post");
                SaveFacebookCollectionAsListToBridge("video");
                SaveFacebookCollectionAsListToBridge("friend");
                SaveFacebookCollectionAsListToBridge("photo");
                return m_loggedInUser;
            }
            else
            {
                return null;
            }
        }
        protected virtual void OnLogInError()
        {
            LogInError?.Invoke();
        }
        public void Logout()
        {
            m_userManager.Logout();
        }

        public void SaveFacebookCollectionAsListToBridge(string i_CollectionType)
        {
            object collection = m_userManager.GetDataCollectionByType(i_CollectionType);
            SaveCollectionToBridge((dynamic)collection, i_CollectionType);
        }
        private void SaveCollectionToBridge(dynamic collection, string i_CollectionType)
        {
            if (i_CollectionType == "post" && collection is FacebookObjectCollection<Post> postCollection)
            {
                m_posts = postCollection.ToList();
            }
            else if (i_CollectionType == "video" && collection is FacebookObjectCollection<Video> videoCollection)
            {
                m_videos = videoCollection.ToList();
            }
            else if (i_CollectionType == "friend" && collection is FacebookObjectCollection<User> userCollection)
            {
                m_friends = userCollection.ToList();
            }
            else if (i_CollectionType == "photo" && collection is FacebookObjectCollection<Photo> photoCollection)
            {
                m_photos = photoCollection.ToList();
            }
            else
            {
                throw new InvalidOperationException($"Unsupported collection type or invalid i_Name: {i_CollectionType}");
            }
        }

        public void PostStatus(string status)
        {
            m_userManager.PostStatus(status);
        }
    }
}


