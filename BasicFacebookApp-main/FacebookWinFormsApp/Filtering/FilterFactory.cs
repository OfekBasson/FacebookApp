using AppLogic.HelperClasses;
using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public static class FilterFactory
    {
        public static List<T> FilterByMember<T>(string selectedMember)
        {
            dynamic filteredList = null;
            if (typeof(T) == typeof(Post))
            {
                List<Post> posts = (List<Post>)Singleton<Facade>.Instance.GetPosts().m_ResultData;
                filteredList = ItemsFilter.FilterByMember(posts, selectedMember).Cast<T>().ToList();
            }
            else if (typeof(T) == typeof(User))
            {
                List<User> friends = (List<User>)Singleton<Facade>.Instance.GetFriends().m_ResultData;
                filteredList = ItemsFilter.FilterByMember(friends, selectedMember).Cast<T>().ToList();
            }
            else if (typeof(T) == typeof(Video))
            {
                List<Video> videos = (List<Video>)Singleton<Facade>.Instance.GetVideos().m_ResultData;
                filteredList = ItemsFilter.FilterByMember(videos, selectedMember).Cast<T>().ToList();
            }
            else if (typeof(T) == typeof(Photo))
            {
                List<Photo> photos = (List<Photo>)Singleton<Facade>.Instance.GetPhotos().m_ResultData;
                filteredList = ItemsFilter.FilterByMember(photos, selectedMember).Cast<T>().ToList();
            }
            else
            {
                throw new ArgumentException($"Unsupported type: {typeof(T).Name}");
            }

            return filteredList;
        }


        public static List<T> FilterByProperty<T>(string i_PropertyName, string i_FilterValue, string i_ControlName)
        {
            dynamic filteredList = null;
            try
            {
                if (i_ControlName == "PostsDataSection")
                {
                    if (i_PropertyName == "Desecription")
                    {
                        i_PropertyName = "ToString";
                    }

                    List<Post> posts = (List<Post>)Singleton<Facade>.Instance.GetPosts().m_ResultData;
                    filteredList = ItemsFilter.FilterByProperty(posts, i_PropertyName, i_FilterValue);
                }
                if (i_ControlName == "FriendsDataSection")
                {
                    List<User> friends = (List<User>)Singleton<Facade>.Instance.GetFriends().m_ResultData;
                   filteredList = ItemsFilter.FilterByProperty(friends, i_PropertyName, i_FilterValue);
                    
                }
                if (i_ControlName == "VideosDataSection")
                {
                    List<Video> videos = (List<Video>)Singleton<Facade>.Instance.GetVideos().m_ResultData;
                    filteredList = ItemsFilter.FilterByProperty(videos, i_PropertyName, i_FilterValue);
                }
                if (i_ControlName == "GalleryDataSection")
                {
                    if (i_PropertyName == "Description")
                    {
                        i_PropertyName = "Name";
                    }

                    List<Photo> photos = (List<Photo>)Singleton<Facade>.Instance.GetPhotos().m_ResultData;
                    filteredList = ItemsFilter.FilterByProperty(photos, i_PropertyName, i_FilterValue);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return filteredList;
        }
    }
}


