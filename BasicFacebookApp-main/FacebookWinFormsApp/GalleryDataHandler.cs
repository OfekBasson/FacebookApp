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
        public async Task<List<Photo>> RunDataTask()
        {
            return await Task.Run(() => (List<Photo>)Singleton<Facade>.Instance.GetPhotos().m_ResultData);
        }
        public List<string> GetFilterOptions()
        {
            return new List<string> { "To String", "Location", "Description" };
        }
    }
}
