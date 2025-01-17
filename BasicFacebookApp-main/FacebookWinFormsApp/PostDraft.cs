using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFacebookFeatures
{
    public class PostDraft
    {
        public string m_TimeOfCreation { get; set; }
        public string m_Content { get; set; }

        public override string ToString()
        {
            return $"{m_TimeOfCreation} - {m_Content}"; ;
        }
    }
}
