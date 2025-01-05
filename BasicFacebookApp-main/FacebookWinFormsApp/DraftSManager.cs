using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BasicFacebookFeatures
{
    internal class DraftSManager
    {
        private readonly string m_DirectoryPath;
        private readonly string m_FilePath;
        public BindingList<PostDraft> m_Drafts { get; set; }

        public DraftSManager()
        {
            m_Drafts = new BindingList<PostDraft>();
            m_DirectoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "FacebookApp");
            m_FilePath = Path.Combine(m_DirectoryPath, "draftPosts.xml");
            if (!Directory.Exists(m_DirectoryPath))
            {
                Directory.CreateDirectory(m_DirectoryPath);
            }
        }

        public void SaveDrafts()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(BindingList<PostDraft>));
            using (Stream stream = new FileStream(m_FilePath, FileMode.Create))
            {
                serializer.Serialize(stream, m_Drafts);
            }
        }

        public BindingList<PostDraft> LoadDrafts()
        {
            if (File.Exists(m_FilePath))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(BindingList<PostDraft>));
                using (Stream stream = new FileStream(m_FilePath, FileMode.Open))
                {
                    m_Drafts = (BindingList<PostDraft>)serializer.Deserialize(stream); 
                }
            }

            return m_Drafts;
        }

        public void ClearDrafts()
        {
            m_Drafts.Clear();
            // Check if the file exists before delete
            if (File.Exists(m_FilePath))
            {
                File.Delete(m_FilePath);
            }
        }
    }
}
