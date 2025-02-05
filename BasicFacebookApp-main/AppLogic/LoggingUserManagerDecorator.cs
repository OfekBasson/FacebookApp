using System;
using System.IO;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures
{
    public class LoggingUserManagerDecorator : UserManagerDecorator
    {
        private readonly string m_LogFilePath;

        public LoggingUserManagerDecorator(IUserManager i_WrappedUserManager)
                    : base(i_WrappedUserManager)
        {
            string logDirectory = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "MyApp", "Logs");

            Directory.CreateDirectory(logDirectory);

            m_LogFilePath = Path.Combine(logDirectory, "log.txt");
        }
        private void LogToFile(string message)
        {
            using (StreamWriter writer = new StreamWriter(m_LogFilePath, true))
            {
                writer.WriteLine($"{DateTime.Now}: {message}");
            }
        }

        public override User EnsureLoggedIn(string i_AppId)
        {
            LogToFile("Logging: Ensuring user is logged in.");
            User user = m_WrappedUserManager.EnsureLoggedIn(i_AppId); 
            LogToFile("Logging: User logged in.");
            return user;
        }

        public override void Logout()
        {
            LogToFile("Logging: Logging out user.");
            m_WrappedUserManager.Logout(); 
            LogToFile("Logging: User logged out.");
        }

        public override bool IsLoggedIn()
        {
            LogToFile("Logging: Checking if user is logged in.");
            bool isLoggedIn = m_WrappedUserManager.IsLoggedIn();
            LogToFile($"Logging: User is {(isLoggedIn ? "logged in" : "not logged in")}.");
            return isLoggedIn;
        }

        public override FacebookObjectCollection<Post> GetPosts()
        {
            LogToFile("Logging: Fetching posts.");
            FacebookObjectCollection<Post> posts = m_WrappedUserManager.GetPosts(); 
            LogToFile($"Logging: Fetched {posts.Count} posts.");
            return posts;
        }

        public override FacebookObjectCollection<Video> GetVideos()
        {
            LogToFile("Logging: Fetching videos.");
            FacebookObjectCollection<Video> videos = m_WrappedUserManager.GetVideos(); 
            LogToFile($"Logging: Fetched {videos.Count} videos.");
            return videos;
        }

        public override FacebookObjectCollection<Album> GetAlbums()
        {
            LogToFile("Logging: Fetching albums.");
            FacebookObjectCollection<Album> albums = m_WrappedUserManager.GetAlbums(); 
            LogToFile($"Logging: Fetched {albums.Count} albums.");
            return albums;
        }

        public override FacebookObjectCollection<User> GetFriends()
        {
            LogToFile("Logging: Fetching friends.");
            FacebookObjectCollection<User> friends = m_WrappedUserManager.GetFriends(); 
            LogToFile($"Logging: Fetched {friends.Count} friends.");
            return friends;
        }

        public override FacebookObjectCollection<Photo> GetPhotos()
        {
            LogToFile("Logging: Fetching photos.");
            FacebookObjectCollection<Photo> photos = m_WrappedUserManager.GetPhotos(); 
            LogToFile($"Logging: Fetched {photos.Count} photos.");
            return photos;
        }

        public override void PostStatus(string i_Status)
        {
            LogToFile($"Logging: Posting status: {i_Status}");
            m_WrappedUserManager.PostStatus(i_Status); 
            LogToFile("Logging: Status posted.");
        }

        public override object GetDataCollectionByType(string i_CollectionType)
        {
            LogToFile($"Logging: Fetching data collection of type {i_CollectionType}.");
            object collection = m_WrappedUserManager.GetDataCollectionByType(i_CollectionType); 
            LogToFile($"Logging: Fetched data collection of type {i_CollectionType}.");
            return collection;
        }
    }
}
