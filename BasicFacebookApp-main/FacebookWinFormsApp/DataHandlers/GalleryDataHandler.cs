using AppLogic.HelperClasses;
using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFacebookFeatures
{
    public class GalleryDataHandler : IControlDataHandler<Photo>
    {
        public Task<List<Photo>> RunDataTask()
        {
            return Task.Run(() =>
            {
                LogicLayerResult getPhotosResult = Singleton<Facade>.Instance.GetPhotos();
                if (getPhotosResult.m_Status == LogicLayerResult.ResultStatus.Success)
                {
                    List<Photo> photos = (List<Photo>)getPhotosResult.m_ResultData;
                    return photos;
                }
                else
                {
                    List<Photo> photos = new List<Photo>();
                    return photos;
                }
            });
        }
        public List<string> GetFilterOptions()
        {
            return new List<string> { "To String", "Location", "Description" };
        }
    }
}
