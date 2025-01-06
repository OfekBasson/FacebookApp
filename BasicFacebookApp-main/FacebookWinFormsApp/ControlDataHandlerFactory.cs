using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFacebookFeatures
{
    public static class ControlDataHandlerFactory
    {
        public static IControlDataHandler<T> CreateHandler<T>(string i_ControlName)
        {
            dynamic dataHandler = null;

            if (i_ControlName == "PostsDataSection")
            {
                dataHandler = new PostsDataHandler();
            }
            else if (i_ControlName == "FriendsDataSection")
            {
                dataHandler = new FriendsDataHandler();
            }
            else if (i_ControlName == "GalleryDataSection")
            {
                dataHandler = new GalleryDataHandler();
            }
            else if (i_ControlName == "VideosDataSection")
            {
                dataHandler = new VideosDataHandler();
            }
            else
            {
                throw new ArgumentException($"Unsupported control name: {i_ControlName}");
            }
            
            return (IControlDataHandler<T>)dataHandler;
        }



    }

}
