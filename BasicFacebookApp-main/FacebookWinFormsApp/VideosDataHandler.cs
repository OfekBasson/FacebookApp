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
        public List<Video> GetData(Facade i_Facade)
        {
            return i_Facade.GetVideos();
        }
        public List<string> GetFilterOptions()
        {
            return new List<string> { "Name", "Location", "Created Time" };
        }
    }
}
