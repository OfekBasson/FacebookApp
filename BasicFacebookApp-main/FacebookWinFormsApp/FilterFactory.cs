using CefSharp.DevTools.Accessibility;
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
        public static List<T> FilterByMember<T>(string selectedMember, Facade i_Facade)
        {
            dynamic filteredList = null;
            if (typeof(T) == typeof(Post))
            {
                List<Post> posts = i_Facade.GetPosts();
                filteredList = ItemsFilter.FilterByMember(posts, selectedMember).Cast<T>().ToList();
            }
            else if (typeof(T) == typeof(User))
            {
                List<User> friends = i_Facade.GetFriends();
                filteredList = ItemsFilter.FilterByMember(friends, selectedMember).Cast<T>().ToList();
            }
            else if (typeof(T) == typeof(Video))
            {
                List<Video> videos = i_Facade.GetVideos();
                filteredList = ItemsFilter.FilterByMember(videos, selectedMember).Cast<T>().ToList();
            }
            else if (typeof(T) == typeof(Photo))
            {
                List <Photo> photos = i_Facade.GetPhotos();
                filteredList = ItemsFilter.FilterByMember(photos, selectedMember).Cast<T>().ToList();
            }
            else
            {
                throw new ArgumentException($"Unsupported type: {typeof(T).Name}");
            }

            return filteredList;
        }


        public static List<T> FilterByProperty<T>(string i_PropertyName, string i_FilterValue, Facade i_Facade, string i_ControlName)
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

                    List<Post> posts = i_Facade.GetPosts();
                    filteredList = ItemsFilter.FilterByProperty(posts, i_PropertyName, i_FilterValue);
                }
                if (i_ControlName == "FriendsDataSection")
                {
                   List<User> friends = i_Facade.GetFriends();
                   filteredList = ItemsFilter.FilterByProperty(friends, i_PropertyName, i_FilterValue);
                    
                }
                if (i_ControlName == "VideosDataSection")
                {
                    List<Video> videos = i_Facade.GetVideos();
                    filteredList = ItemsFilter.FilterByProperty(videos, i_PropertyName, i_FilterValue);
                }
                if (i_ControlName == "GalleryDataSection")
                {
                    if (i_PropertyName == "Description")
                    {
                        i_PropertyName = "Name";
                    }

                    List<Photo> photos = i_Facade.GetPhotos();
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


