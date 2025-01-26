using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BasicFacebookFeatures
{
    public class PostsDataHandler : IControlDataHandler<Post>
    {
        public Task<List<Post>> RunDataTask()
        {
            // TODO: What happens where there is an exception in the facade? It gets the string...
            return Task.Run(() => (List<Post>)Singleton<Facade>.Instance.GetPosts().m_ResultData);  
        }

        public List<string> GetFilterOptions()
        {
            return new List<string> { "Name", "Created Time", "Place", "Description" };
        }
    }
}
