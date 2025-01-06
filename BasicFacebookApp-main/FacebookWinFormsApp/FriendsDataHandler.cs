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
        public List<User> GetData(UIBridge i_Bridge)
        {
            return i_Bridge.m_Friends;
        }
        public List<string> GetFilterOptions()
        {
            return new List<string> { "Name", "Location", "Email" };
        }
    }
}
