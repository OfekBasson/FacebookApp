using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures
{
    public interface IUserManager
    {
        User EnsureLoggedIn(string i_AppId);
        void Logout();
        bool IsLoggedIn();
        FacebookObjectCollection<Post> GetPosts();
        FacebookObjectCollection<Video> GetVideos();
        FacebookObjectCollection<Album> GetAlbums();
        FacebookObjectCollection<User> GetFriends();
        FacebookObjectCollection<Photo> GetPhotos();
        void PostStatus(string i_Status);
        object GetDataCollectionByType(string i_CollectionType);
    }
}