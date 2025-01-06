using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public interface IControlDataHandler<T>
    {
        List<T> GetData(UIBridge io_bridge);
        List<string> GetFilterOptions();
    }
}
