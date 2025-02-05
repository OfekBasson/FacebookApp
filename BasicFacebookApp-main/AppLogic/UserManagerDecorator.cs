using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures
{
    public class UserManagerDecorator : IUserManager
    {
        protected IUserManager m_WrappedUserManager;

        public UserManagerDecorator(IUserManager i_WrappedUserManager)
        {
            m_WrappedUserManager = i_WrappedUserManager;
        }

        public virtual User EnsureLoggedIn(string i_AppId)
        {
            return m_WrappedUserManager.EnsureLoggedIn(i_AppId);
        }

        public virtual void Logout()
        {
            m_WrappedUserManager.Logout();
        }

        public virtual bool IsLoggedIn()
        {
            return m_WrappedUserManager.IsLoggedIn();
        }

        public virtual FacebookObjectCollection<Post> GetPosts()
        {
            return m_WrappedUserManager.GetPosts();
        }

        public virtual FacebookObjectCollection<Video> GetVideos()
        {
            return m_WrappedUserManager.GetVideos();
        }

        public virtual FacebookObjectCollection<Album> GetAlbums()
        {
            return m_WrappedUserManager.GetAlbums();
        }

        public virtual FacebookObjectCollection<User> GetFriends()
        {
            return m_WrappedUserManager.GetFriends();
        }

        public virtual FacebookObjectCollection<Photo> GetPhotos()
        {
            return m_WrappedUserManager.GetPhotos();
        }

        public virtual void PostStatus(string i_Status)
        {
            m_WrappedUserManager.PostStatus(i_Status);
        }

        public virtual object GetDataCollectionByType(string i_CollectionType)
        {
            return m_WrappedUserManager.GetDataCollectionByType(i_CollectionType);
        }
    }
}
