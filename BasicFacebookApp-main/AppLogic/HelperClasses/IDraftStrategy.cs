using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.HelperClasses
{
    public interface IDraftStrategy
    {
        public void SaveDrafts(BindingList<PostDraft> drafts);
        public BindingList<PostDraft> LoadDrafts();
    }
}
