using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using System.Threading;

namespace BasicFacebookFeatures
{
    public class UIBridge
    {
        private readonly FacebooktUserManager m_UserManager;
        private readonly DraftSManager m_DraftManager;
        public User m_LoggedInUser { get; set; }
        public List<Post> m_Posts { get; set; }
        public List<Video> m_Videos { get; set; }
        public List<User> m_Friends { get; set; }
        public List<Photo> m_Photos { get; set; }
        public BindingList<PostDraft> m_Drafts { get; set; }
        public event Action<string> ErrorOccured;

        public UIBridge()
        {
            m_UserManager = new FacebooktUserManager();
            m_DraftManager = new DraftSManager();
            loadDrafts();
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
        //public User LogIn(string i_AppId)
        //{
        //    try
        //    {
        //        Thread loginThread = new Thread(() =>
        //        {
        //            m_LoggedInUser = m_UserManager.EnsureLoggedIn(i_AppId);
        //        });

        //        // Start the login thread
        //        loginThread.Start();

        //        // Wait for the login thread to complete
        //        loginThread.Join();

        //        // Proceed to save collections after login is complete
        //        saveAllFacebookCollectionsAsListsToBridge();
        //    }
        //    catch (Exception ex)
        //    {
        //        OnErrorOccured(ex.Message);
        //    }

        //    return m_LoggedInUser;
        //}


        private void saveAllFacebookCollectionsAsListsToBridge()
        {
            //saveFacebookCollectionAsListToBridge("post");
            //saveFacebookCollectionAsListToBridge("video");
            //saveFacebookCollectionAsListToBridge("friend");
            //saveFacebookCollectionAsListToBridge("photo");
            
            saveFacebookCollectionToBridge<Post>("post", data => m_Posts = data);
            saveFacebookCollectionToBridge<Video>("video", data => m_Videos = data);
            saveFacebookCollectionToBridge<User>("friend", data => m_Friends = data);
            saveFacebookCollectionToBridge<Photo>("photo", data => m_Photos = data);
            
        }
        private void saveFacebookCollectionToBridge<T>(string collectionType, Action<List<T>> assignCollection)
        {
            object collection = m_UserManager.GetDataCollectionByType(collectionType);
            if (collection is FacebookObjectCollection<T> typedCollection)
            {
                new Thread(() => assignCollection(typedCollection.ToList())).Start();
            }
            else
            {
                throw new InvalidOperationException($"Unsupported collection type: {collectionType}");
            }
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
            new Thread(() => saveCollectionToBridge((dynamic)collection, i_CollectionType)).Start();
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

        public void AddDraft(string i_Title, string i_Content)
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

        private void loadDrafts()
        {
            try
            {
                m_DraftManager.LoadDrafts();
                m_Drafts = m_DraftManager.m_Drafts; //initialize m_Drafts
            }
            catch (Exception ex)
            {
                OnErrorOccured(ex.Message);
            }
        }

        public void ClearDrafts()
        {
            try
            {
                m_DraftManager.ClearDrafts();
            }
            catch (Exception ex)
            {
                OnErrorOccured(ex.Message);
            }
        }

    }
}


