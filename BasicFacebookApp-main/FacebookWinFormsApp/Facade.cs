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
    public class Facade
    {
        private readonly FacebooktUserManager m_UserManager;
        private readonly DraftSManager m_DraftManager;
        public User m_LoggedInUser { get; set; }
        private List<Post> m_Posts;
        private List<Video> m_Videos;
        private List<User> m_Friends;
        private List<Photo> m_Photos;
        public event Action<string> ErrorOccured;

        public Facade()
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
            }
            catch (Exception ex)
            {
                OnErrorOccured(ex.Message);
            }

            return m_LoggedInUser;
        }
        
        public List<Post> GetPosts()
        {
            if (m_Posts == null)
            {
                saveFacebookCollectionToBridge<Post>("post", data => m_Posts = data);
            }

            return m_Posts ?? new List<Post>();
        }

        public List<Video> GetVideos()
        {
            if (m_Videos == null)
            {
                saveFacebookCollectionToBridge<Video>("video", data => m_Videos = data);
            }

            return m_Videos ?? new List<Video>();
        }

        public List<User> GetFriends()
        {
            if (m_Friends == null)
            {
                saveFacebookCollectionToBridge<User>("friend", data => m_Friends = data);
            }

            return m_Friends ?? new List<User>();
        }

        public List<Photo> GetPhotos()
        {
            if (m_Photos == null)
            {
              saveFacebookCollectionToBridge<Photo>("photo", data => m_Photos = data);
            }

            return m_Photos ?? new List<Photo>();
        }

                
        private void saveFacebookCollectionToBridge<T>(string collectionType, Action<List<T>> assignCollection)
        {
            object collection = m_UserManager.GetDataCollectionByType(collectionType);
            if (collection is FacebookObjectCollection<T> typedCollection)
            {
                assignCollection(typedCollection.ToList());
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

        public void AddDraft(string i_TimeOfCreation, string i_Content)
        {
            m_DraftManager.AddDraft(i_TimeOfCreation, i_Content);
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

        public BindingList<PostDraft> GetDrafts()
        {
            return m_DraftManager.GetDrafts();
        }

        private void loadDrafts()
        {
            try
            {
                m_DraftManager.LoadDrafts();
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


