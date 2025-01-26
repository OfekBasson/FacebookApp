using System;
using FacebookWrapper.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public interface IControlDataHandler<T>
    {
        Task<List<T>> RunDataTask();
        List<string> GetFilterOptions();
    }
}
