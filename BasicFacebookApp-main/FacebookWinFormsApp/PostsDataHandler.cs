using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFacebookFeatures
{
    public class PostsDataHandler : IControlDataHandler<Post>
    {
        public List<Post> GetData(UIBridge i_Bridge)
        {
            return i_Bridge.m_Posts;
        }
        
        public List<string> GetFilterOptions()
        {
            return new List<string> { "Name", "Created Time", "Place", "Description" };
        }
    }
}
