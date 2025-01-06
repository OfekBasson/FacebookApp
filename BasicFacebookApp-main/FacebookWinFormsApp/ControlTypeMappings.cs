using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFacebookFeatures
{
    public class ControlTypeMappings
    {
        public static readonly Dictionary<string, Type> s_ControlTypeMappings = new Dictionary<string, Type>
        {
            { "PostsDataSection", typeof(Post) },
            { "FriendsDataSection", typeof(User) },
            { "VideosDataSection", typeof(Video) },
            { "GalleryDataSection", typeof(Photo) }
        };
    }
}
