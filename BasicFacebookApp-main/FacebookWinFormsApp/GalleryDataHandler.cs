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
        public List<Photo> GetData(Facade i_Facade)
        {
            return i_Facade.GetPhotos();
        }
        public List<string> GetFilterOptions()
        {
            return new List<string> { "To String", "Location", "Description" };
        }
    }
}
