using AppLogic.HelperClasses;
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
            return Task.Run(() =>
            {
                LogicLayerResult getPostsResult = Singleton<Facade>.Instance.GetPosts();
                if (getPostsResult.m_Status == LogicLayerResult.ResultStatus.Success)
                {
                    List<Post> posts = (List<Post>)getPostsResult.m_ResultData;
                    return posts;
                }
                else
                {
                    List<Post> posts = new List<Post>();
                    return posts;
                }
            });
        }

        public List<string> GetFilterOptions()
        {
            return new List<string> { "Name", "Created Time", "Place", "Description" };
        }
    }
}
