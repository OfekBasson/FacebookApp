using System.ComponentModel;
using System.Xml.Serialization;
using AppLogic.HelperClasses;

namespace BasicFacebookFeatures
{
    internal class DraftSManager
    {
        private readonly string r_DirectoryPath;
        private readonly string r_FilePath;
        public BindingList<PostDraft> m_Drafts { get; set; }

        public DraftSManager()
        {
            m_Drafts = new BindingList<PostDraft>();
            r_DirectoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "FacebookApp");
            r_FilePath = Path.Combine(r_DirectoryPath, "draftPosts.xml");
            if (!Directory.Exists(r_DirectoryPath))
            {
                Directory.CreateDirectory(r_DirectoryPath);
            }
        }

        public void SaveDrafts()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(BindingList<PostDraft>));
            using (Stream stream = new FileStream(r_FilePath, FileMode.Create))
            {
                serializer.Serialize(stream, m_Drafts);
            }
        }

        public BindingList<PostDraft> LoadDrafts()
        {
            if (File.Exists(r_FilePath))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(BindingList<PostDraft>));
                using (Stream stream = new FileStream(r_FilePath, FileMode.Open))
                {
                    m_Drafts = (BindingList<PostDraft>)serializer.Deserialize(stream); 
                }
            }

            return m_Drafts;
        }

        public BindingList<PostDraft> GetDrafts()
        {
            return m_Drafts;
        }

        public void AddDraft(string i_TimeOfCreation, string i_Content)
        {
            PostDraft post = new PostDraft();
            post.m_TimeOfCreation = i_TimeOfCreation;
            post.m_Content = i_Content;
            m_Drafts.Add(post);
        }

        public void ClearDrafts()
        {
            m_Drafts.Clear();
            // Check if the file exists before delete
            if (File.Exists(r_FilePath))
            {
                File.Delete(r_FilePath);
            }
        }
    }
}
