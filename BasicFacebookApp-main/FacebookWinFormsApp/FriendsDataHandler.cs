using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFacebookFeatures
{
    public class FriendsDataHandler : IControlDataHandler<User>
    {
        // TODO: Move those classes under the facade...
        public async Task<List<User>> RunDataTask()
        {
            return await Task.Run(() => (List<User>)Singleton<Facade>.Instance.GetFriends().m_ResultData);
        }
        public List<string> GetFilterOptions()
        {
            return new List<string> { "Name", "Location", "Email" };
        }
    }
}
