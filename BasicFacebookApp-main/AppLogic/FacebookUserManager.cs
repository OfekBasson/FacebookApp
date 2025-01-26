using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures
{
    internal class FacebooktUserManager
    {
        private User m_LoggedInUser { get; set; }
        
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
            LoginResult loginResult = FacebookService.Login(
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
            if (string.IsNullOrEmpty(loginResult.ErrorMessage))
            {
                m_LoggedInUser = loginResult.LoggedInUser;
                if (m_LoggedInUser == null)
                {
                    throw new LoginException("Logging in wasn't successful - Facebook server response to login was unsuccessful");
                }

                return;
            }

            throw new LoginException("Logging in wasn't successful - unknown problem");
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

        // TOOO: Change all of those to properties with get? I mean not private?
        public FacebookObjectCollection<Post> GetPosts()
        {
            return m_LoggedInUser.Posts;
        }
        public FacebookObjectCollection<Video> GetVideos()
        {
            return m_LoggedInUser.Videos;
        }
        public FacebookObjectCollection<Album> GetAlbums()
        {
            return m_LoggedInUser.Albums;
        }
        public FacebookObjectCollection<User> GetFriends()
        {
            return m_LoggedInUser.Friends;
        }
        public FacebookObjectCollection<Photo> GetPhotos()
        {
            List<Photo> allPhotos = this.m_LoggedInUser.Albums.SelectMany(album => album.Photos).ToList();
            FacebookObjectCollection<Photo> photoCollection = new FacebookObjectCollection<Photo>(allPhotos.Count);
            foreach (var photo in allPhotos)
            {
                photoCollection.Add(photo);
            }
            return photoCollection;
        }

        public void PostStatus(string i_Status)
        {
           m_LoggedInUser.PostStatus(i_Status);            
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
            else
            {
                throw new DataCollectionInformationException($"Collection type {i_CollectionType} isn't recognized.");
            }
        }
    }
}
