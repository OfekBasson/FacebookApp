using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLogic.HelperClasses;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures
{
    public class VideosDataHandler : IControlDataHandler<Video>
    {
        public Task<List<Video>> RunDataTask()
        {
            return Task.Run(() =>
            {
                LogicLayerResult getVideosResult = Singleton<Facade>.Instance.GetVideos();
                if (getVideosResult.m_Status == LogicLayerResult.ResultStatus.Success)
                {
                    List<Video> videos = (List<Video>)getVideosResult.m_ResultData;
                    return videos;
                }
                else
                {
                    List<Video> videos = new List<Video>();
                    return videos;
                }
            });
        }

        public List<string> GetFilterOptions()
        {
            return new List<string> { "Name", "Location", "Created Time" };
        }
    }
}
