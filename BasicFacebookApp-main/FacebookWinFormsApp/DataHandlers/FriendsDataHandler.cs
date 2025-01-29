using AppLogic.HelperClasses;
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
        public  Task<List<User>> RunDataTask()
        {
            return Task.Run(() =>
            {
                LogicLayerResult getFriendsResult = Singleton<Facade>.Instance.GetFriends();
                if (getFriendsResult.m_Status == LogicLayerResult.ResultStatus.Success)
                {
                    List<User> friends = (List<User>)getFriendsResult.m_ResultData;
                    return friends;
                }
                else
                {
                    List<User> friends = new List<User>();
                    return friends;
                }
            });
        }

        public List<string> GetFilterOptions()
        {
            return new List<string> { "Name", "Location", "Email" };
        }
    }
}
