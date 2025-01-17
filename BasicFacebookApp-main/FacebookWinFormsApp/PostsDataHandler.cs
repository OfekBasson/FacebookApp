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
        public List<Post> GetData(Facade i_Facade)
        {
            return i_Facade.GetPosts();  
        }

        public List<string> GetFilterOptions()
        {
            return new List<string> { "Name", "Created Time", "Place", "Description" };
        }
    }
}
