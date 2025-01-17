using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFacebookFeatures
{
    public class VideosDataHandler : IControlDataHandler<Video>
    {
        public List<Video> GetData(UIBridge i_Bridge)
        {
            return i_Bridge.GetVideos();
        }
        public List<string> GetFilterOptions()
        {
            return new List<string> { "Name", "Location", "Created Time" };
        }
    }
}
