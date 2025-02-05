using System.ComponentModel;
using FacebookWrapper.ObjectModel;
using static AppLogic.HelperClasses.LogicLayerResult;
using AppLogic.HelperClasses;

namespace BasicFacebookFeatures
{
    public sealed class Facade
    {
        private readonly IUserManager m_UserManager;
        private readonly DraftSManager m_DraftManager;
        public User m_LoggedInUser { get; set; }
        private List<Post> m_Posts;
        private List<Video> m_Videos;
        private List<User> m_Friends;
        private List<Album> m_Albums;
        private List<Photo> m_Photos;
        public event Action<string> ErrorOccured;
        public event Action<List<Post>> GetPostsCompleted;
        public event Action<List<Video>> GetVideosCompleted;
        public event Action<List<Album>> GetAlbumsCompleted;
        public event Action<List<User>> GetFriendsCompleted;
        public event Action<List<Photo>> GetPhotosCompleted;

        private Facade()
        {
            m_UserManager = new LoggingUserManagerDecorator(new FacebooktUserManager());
            m_DraftManager = new DraftSManager();
            loadDrafts();
        }

        public LogicLayerResult LogIn(string i_AppId)
        {
            try
            {
                m_LoggedInUser = m_UserManager.EnsureLoggedIn(i_AppId);
                return new LogicLayerResult(ResultStatus.Success, m_LoggedInUser);
            }
            catch (Exception ex)
            {
                ErrorOccured?.Invoke(ex.Message);
                return new LogicLayerResult(ResultStatus.Failure, ex.Message);
            }
        }

        public LogicLayerResult GetPosts()
        {
            try
            {
                saveFacebookCollectionToBridge<Post>("post", data => m_Posts = data);
                GetPostsCompleted?.Invoke(m_Posts);
                return new LogicLayerResult(ResultStatus.Success, m_Posts);
            }
            catch (Exception ex)
            {
                ErrorOccured?.Invoke(ex.Message);
                return new LogicLayerResult(ResultStatus.Failure, ex.Message);
            }
        }

        public LogicLayerResult GetVideos()
        {
            try
            {
                saveFacebookCollectionToBridge<Video>("video", data => m_Videos = data);
                GetVideosCompleted?.Invoke(m_Videos);
                return new LogicLayerResult(ResultStatus.Success, m_Videos);
            }
            catch (Exception ex)
            {
                ErrorOccured?.Invoke(ex.Message);
                return new LogicLayerResult(ResultStatus.Failure, ex.Message);
            }
            
        }

        public LogicLayerResult GetAlbums()
        {
            try
            {
                saveFacebookCollectionToBridge<Album>("album", data => m_Albums = data);
                GetAlbumsCompleted?.Invoke(m_Albums);
                return new LogicLayerResult(ResultStatus.Success, m_Albums);
            }
            catch (Exception ex)
            {
                ErrorOccured?.Invoke(ex.Message);
                return new LogicLayerResult(ResultStatus.Failure, ex.Message);
            }
        }

        public LogicLayerResult GetFriends()
        {
            try
            {
                saveFacebookCollectionToBridge<User>("friend", data => m_Friends = data);
                GetFriendsCompleted?.Invoke(m_Friends);
                return new LogicLayerResult(ResultStatus.Success, m_Friends);
            }
            catch (Exception ex)
            {
                ErrorOccured?.Invoke(ex.Message);
                return new LogicLayerResult(ResultStatus.Failure, ex.Message);
            }
        }

        public LogicLayerResult GetPhotos()
        {
            try
            {
                saveFacebookCollectionToBridge<Photo>("photo", data => m_Photos = data);
                GetPhotosCompleted?.Invoke(m_Photos);
                return new LogicLayerResult(ResultStatus.Success, m_Photos);
            }
            catch (Exception ex)
            {
                ErrorOccured?.Invoke(ex.Message);
                return new LogicLayerResult(ResultStatus.Failure, ex.Message);
            }
            
        }

        public LogicLayerResult Logout()
        {
            try
            {
                m_UserManager.Logout();
                return new LogicLayerResult(ResultStatus.Success, null);
            }
            catch (Exception ex)
            {
                ErrorOccured?.Invoke(ex.Message);
                return new LogicLayerResult(ResultStatus.Failure, ex.Message);
            }
        }

        public LogicLayerResult PostStatus(string i_Status)
        {
            try
            {
                m_UserManager.PostStatus(i_Status);
                return new LogicLayerResult(ResultStatus.Success, null);
            }
            catch (Exception ex)
            {
                ErrorOccured?.Invoke(ex.Message);
                return new LogicLayerResult(ResultStatus.Failure, ex.Message);
            }
        }

        public LogicLayerResult AddDraft(string i_TimeOfCreation, string i_Content)
        {
            try
            {
                m_DraftManager.AddDraft(i_TimeOfCreation, i_Content);
                return new LogicLayerResult(ResultStatus.Success, null);
            }
            catch (Exception ex)
            {
                ErrorOccured?.Invoke(ex.Message);
                return new LogicLayerResult(ResultStatus.Failure, ex.Message);
            }
        }

        public LogicLayerResult SaveDraftsToFile()
        {
            try
            {
                m_DraftManager.SaveDrafts();
                return new LogicLayerResult(ResultStatus.Success, null);
            }
            catch (Exception ex)
            {
                ErrorOccured?.Invoke(ex.Message);
                return new LogicLayerResult(ResultStatus.Failure, ex.Message);
            }
        }

        public LogicLayerResult GetDrafts()
        {
            try
            {
                BindingList<PostDraft> drafts = m_DraftManager.GetDrafts();
                return new LogicLayerResult(ResultStatus.Success, drafts);
            }
            catch (Exception ex)
            {
                ErrorOccured?.Invoke(ex.Message);
                return new LogicLayerResult(ResultStatus.Failure, ex.Message);
            }
        }

        private void loadDrafts()
        {
            try
            {
                m_DraftManager.LoadDrafts();
            }
            catch (Exception ex)
            {
                ErrorOccured?.Invoke(ex.Message);
            }
        }

        public LogicLayerResult ClearDrafts()
        {
            try
            {
                m_DraftManager.ClearDrafts();
                return new LogicLayerResult(ResultStatus.Success, null);
            }
            catch (Exception ex)
            {
                ErrorOccured?.Invoke(ex.Message);
                return new LogicLayerResult(ResultStatus.Failure, ex.Message);
            }
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

    }

}


