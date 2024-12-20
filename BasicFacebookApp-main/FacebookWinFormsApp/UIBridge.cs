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
        private DraftSManager m_draftManager;
        public User m_loggedInUser { get; set; }
        public List<Post> m_posts { get; set; }
        public List<Video> m_videos { get; set; }
        public List<User> m_friends { get; set; }
        public List<Photo> m_photos { get; set; }
        public List<PostDraft> m_drafts { get; set; }
        public event Action<string> ErrorOccured;

        public UIBridge()
        {
            m_userManager = new FacebooktUserManager();
            m_draftManager = new DraftSManager();
        }

        public User LogIn(string i_AppId)
        {
            try
            {
                m_loggedInUser = m_userManager.EnsureLoggedIn(i_AppId);
                saveAllFacebookCollectionsAsListsToBridge();
            }
            catch (Exception ex)
            {
                OnErrorOccured(ex.Message);
            }
            return m_loggedInUser;
        }

        private void saveAllFacebookCollectionsAsListsToBridge()
        {
            saveFacebookCollectionAsListToBridge("post");
            saveFacebookCollectionAsListToBridge("video");
            saveFacebookCollectionAsListToBridge("friend");
            saveFacebookCollectionAsListToBridge("photo");
        }

        protected virtual void OnErrorOccured(string errorMessage)
        {
            ErrorOccured?.Invoke(errorMessage);
        }
        public void Logout()
        {
            try
            {
                m_userManager.Logout();
            }
            catch (Exception ex)
            {
                OnErrorOccured(ex.Message);
            }
        }

        private void saveFacebookCollectionAsListToBridge(string i_CollectionType)
        {
            object collection = m_userManager.GetDataCollectionByType(i_CollectionType);
            saveCollectionToBridge((dynamic)collection, i_CollectionType);
        }
        private void saveCollectionToBridge(dynamic collection, string i_CollectionType)
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
            try
            {
                m_userManager.PostStatus(status);
            }
            catch (Exception ex)
            {
                OnErrorOccured(ex.Message);
            }
        }

        public List<PostDraft> AddDraft(string i_title, string i_content)
        {
            try
            {
                PostDraft post = new PostDraft();
                post.m_Title = i_title;
                post.m_Content = i_content;
                m_draftManager.m_Drafts.Add(post);
            }
            catch (Exception ex)
            { 
                OnErrorOccured(ex.Message);
            }
            return m_draftManager.m_Drafts;
        }

        public void saveDraftsToFile()
        {
            try
            {
                m_draftManager.SaveDrafts();
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
                m_drafts = m_draftManager.LoadDrafts();
            }
            catch (Exception ex)
            {
                OnErrorOccured(ex.Message);
            }
            return m_drafts;
        }

        public List<PostDraft> GetDrafts()
        {
            return m_draftManager.m_Drafts;
        }

        public List<PostDraft> ClearDrafts()
        {
            try
            {
                m_draftManager.ClearDrafts();
            }
            catch (Exception ex)
            {
                OnErrorOccured(ex.Message);
            }
            return m_draftManager.m_Drafts;
        }

    }
}


