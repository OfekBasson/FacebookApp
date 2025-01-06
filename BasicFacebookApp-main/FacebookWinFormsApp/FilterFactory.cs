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
        public static List<T> FilterByMember<T>(string selectedMember, UIBridge i_Bridge)
        {
            dynamic filteredList = null;
            if (typeof(T) == typeof(Post))
            {
                filteredList = ItemsFilter.FilterByMember(i_Bridge.m_Posts, selectedMember).Cast<T>().ToList();
            }
            else if (typeof(T) == typeof(User))
            {
                filteredList = ItemsFilter.FilterByMember(i_Bridge.m_Friends, selectedMember).Cast<T>().ToList();
            }
            else if (typeof(T) == typeof(Video))
            {
                filteredList = ItemsFilter.FilterByMember(i_Bridge.m_Videos, selectedMember).Cast<T>().ToList();
            }
            else if (typeof(T) == typeof(Photo))
            {
                filteredList = ItemsFilter.FilterByMember(i_Bridge.m_Photos, selectedMember).Cast<T>().ToList();
            }
            else
            {
                throw new ArgumentException($"Unsupported type: {typeof(T).Name}");
            }

            return filteredList;
        }


        public static List<T> FilterByProperty<T>(string i_PropertyName, string i_FilterValue, UIBridge i_Bridge, string i_ControlName)
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
                    filteredList = ItemsFilter.FilterByProperty(i_Bridge.m_Posts, i_PropertyName, i_FilterValue);
                }
                if (i_ControlName == "FriendsDataSection")
                {
                   filteredList = ItemsFilter.FilterByProperty(i_Bridge.m_Friends, i_PropertyName, i_FilterValue);
                    
                }
                if (i_ControlName == "VideosDataSection")
                {
                    filteredList = ItemsFilter.FilterByProperty(i_Bridge.m_Videos, i_PropertyName, i_FilterValue);
                }
                if (i_ControlName == "GalleryDataSection")
                {
                    if (i_PropertyName == "Description")
                    {
                        i_PropertyName = "Name";
                    }
                    filteredList = ItemsFilter.FilterByProperty(i_Bridge.m_Photos, i_PropertyName, i_FilterValue);
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


