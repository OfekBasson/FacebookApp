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
        private FacebooktUserManager m_UserManager;
        private DraftSManager m_DraftManager;
        public User m_LoggedInUser { get; set; }
        public List<Post> m_Posts { get; set; }
        public List<Video> m_Videos { get; set; }
        public List<User> m_Friends { get; set; }
        public List<Photo> m_Photos { get; set; }
        public List<PostDraft> m_Drafts { get; set; }
        public event Action<string> ErrorOccured;

        public UIBridge()
        {
            m_UserManager = new FacebooktUserManager();
            m_DraftManager = new DraftSManager();
        }

        public User LogIn(string i_AppId)
        {
            try
            {
                m_LoggedInUser = m_UserManager.EnsureLoggedIn(i_AppId);
                saveAllFacebookCollectionsAsListsToBridge();
            }
            catch (Exception ex)
            {
                OnErrorOccured(ex.Message);
            }
            return m_LoggedInUser;
        }

        private void saveAllFacebookCollectionsAsListsToBridge()
        {
            saveFacebookCollectionAsListToBridge("post");
            saveFacebookCollectionAsListToBridge("video");
            saveFacebookCollectionAsListToBridge("friend");
            saveFacebookCollectionAsListToBridge("photo");
        }

        protected virtual void OnErrorOccured(string i_ErrorMessage)
        {
            ErrorOccured?.Invoke(i_ErrorMessage);
        }
        public void Logout()
        {
            try
            {
                m_UserManager.Logout();
            }
            catch (Exception ex)
            {
                OnErrorOccured(ex.Message);
            }
        }

        private void saveFacebookCollectionAsListToBridge(string i_CollectionType)
        {
            object collection = m_UserManager.GetDataCollectionByType(i_CollectionType);
            saveCollectionToBridge((dynamic)collection, i_CollectionType);
        }
        private void saveCollectionToBridge(dynamic collection, string i_CollectionType)
        {
            if (i_CollectionType == "post" && collection is FacebookObjectCollection<Post> postCollection)
            {
                m_Posts = postCollection.ToList();
            }
            else if (i_CollectionType == "video" && collection is FacebookObjectCollection<Video> videoCollection)
            {
                m_Videos = videoCollection.ToList();
            }
            else if (i_CollectionType == "friend" && collection is FacebookObjectCollection<User> userCollection)
            {
                m_Friends = userCollection.ToList();
            }
            else if (i_CollectionType == "photo" && collection is FacebookObjectCollection<Photo> photoCollection)
            {
                m_Photos = photoCollection.ToList();
            }
            else
            {
                throw new InvalidOperationException($"Unsupported collection type or invalid i_Name: {i_CollectionType}");
            }
        }

        public void PostStatus(string i_Status)
        {
            try
            {
                m_UserManager.PostStatus(i_Status);
            }
            catch (Exception ex)
            {
                OnErrorOccured(ex.Message);
            }
        }

        public List<PostDraft> AddDraft(string i_Title, string i_Content)
        {
            try
            {
                PostDraft post = new PostDraft();
                post.m_Title = i_Title;
                post.m_Content = i_Content;
                m_DraftManager.m_Drafts.Add(post);
            }
            catch (Exception ex)
            { 
                OnErrorOccured(ex.Message);
            }
            return m_DraftManager.m_Drafts;
        }

        public void SaveDraftsToFile()
        {
            try
            {
                m_DraftManager.SaveDrafts();
            }
            catch (Exception ex)
            {
                OnErrorOccured(ex.Message);
            }
        }

        public List<PostDraft> LoadDrafts()
        {
            try
            {
                m_Drafts = m_DraftManager.LoadDrafts();
            }
            catch (Exception ex)
            {
                OnErrorOccured(ex.Message);
            }
            return m_Drafts;
        }

        public List<PostDraft> GetDrafts()
        {
            return m_DraftManager.m_Drafts;
        }

        public List<PostDraft> ClearDrafts()
        {
            try
            {
                m_DraftManager.ClearDrafts();
            }
            catch (Exception ex)
            {
                OnErrorOccured(ex.Message);
            }
            return m_DraftManager.m_Drafts;
        }

    }
}


