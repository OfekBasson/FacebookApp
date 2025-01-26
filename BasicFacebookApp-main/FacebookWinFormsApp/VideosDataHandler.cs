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
        public async Task<List<Video>> RunDataTask()
        {
            return await Task.Run(() => (List<Video>)Singleton<Facade>.Instance.GetVideos().m_ResultData);
        }
        public List<string> GetFilterOptions()
        {
            return new List<string> { "Name", "Location", "Created Time" };
        }
    }
}
