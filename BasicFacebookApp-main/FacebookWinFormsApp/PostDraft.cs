using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFacebookFeatures
{
    public class PostDraft
    {
        public string m_Title { get; set; }
        public string m_Content { get; set; }


        public override string ToString()
        {
            return $"{m_Title} - {m_Content}"; ;
        }
    }
}
