using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace AppLogic.HelperClasses
{
    public class XmlDraftStrategy : IDraftStrategy
    {
        private readonly string r_FilePathXml = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "FacebookApp", "draftPosts.xml");

        public void SaveDrafts(BindingList<PostDraft> drafts)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(BindingList<PostDraft>));
            using (Stream stream = new FileStream(r_FilePathXml, FileMode.Create))
            {
                serializer.Serialize(stream, drafts);
            }
        }

        public BindingList<PostDraft> LoadDrafts()
        {
            BindingList<PostDraft> listDrafts = new BindingList<PostDraft>();
            if (File.Exists(r_FilePathXml))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(BindingList<PostDraft>));
                using (Stream stream = new FileStream(r_FilePathXml, FileMode.Open))
                {
                    listDrafts = (BindingList<PostDraft>)serializer.Deserialize(stream);
                }
            }

            return listDrafts;
        }
    }
}
