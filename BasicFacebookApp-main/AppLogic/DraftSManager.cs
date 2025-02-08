using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using AppLogic.HelperClasses;
using static AppLogic.HelperClasses.LogicLayerResult;

namespace BasicFacebookFeatures
{
    internal class DraftSManager
    {
        private readonly string r_DirectoryPath;
        private readonly string r_DefaultSaveTypeFile;
        public BindingList<PostDraft> m_Drafts { get; set; }
        private IDraftStrategy m_DraftStrategy;

        public DraftSManager()
        {
            m_Drafts = new BindingList<PostDraft>();
            r_DirectoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "FacebookApp");
            r_DefaultSaveTypeFile = Path.Combine(r_DirectoryPath, "saveType.txt");

            if (!Directory.Exists(r_DirectoryPath))
            {
                Directory.CreateDirectory(r_DirectoryPath);
            }

            loadLastUsedStrategy();
            loadDrafts();
        }

        public void SaveDrafts()
        {
            try
            {
                m_DraftStrategy?.SaveDrafts(m_Drafts);
                saveLastUsedStrategy();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error saving drafts: {ex.Message}", ex);
            }
        }

        private void loadDrafts()
        {
            try
            {
                m_Drafts = m_DraftStrategy?.LoadDrafts() ?? new BindingList<PostDraft>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error loading drafts: {ex.Message}", ex);
            }  
        }

        private void saveLastUsedStrategy()
        {
            try
            {
                File.WriteAllText(r_DefaultSaveTypeFile, m_DraftStrategy.GetType().AssemblyQualifiedName);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error saving last used strategy: {ex.Message}", ex);
            }
        }

        private void loadLastUsedStrategy()
        {
            if (File.Exists(r_DefaultSaveTypeFile))
            {
                try
                {
                    string lastUsedStrategy = File.ReadAllText(r_DefaultSaveTypeFile);
                    Type strategyType = Type.GetType(lastUsedStrategy);
                    if (strategyType != null && typeof(IDraftStrategy).IsAssignableFrom(strategyType))
                    {
                        SetDraftStrategy((IDraftStrategy)Activator.CreateInstance(strategyType));
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error loading last used strategy: {ex.Message}", ex);
                }
            }
        }

        public void SetDraftStrategy(IDraftStrategy i_DraftStrategy)
        {
            m_DraftStrategy = i_DraftStrategy;
        }

        public void AddDraft(string i_TimeOfCreation, string i_Content)
        {
            PostDraft post = new PostDraft { m_TimeOfCreation = i_TimeOfCreation, m_Content = i_Content };
            m_Drafts.Add(post);
        }

        public void ClearDrafts()
        {
            m_Drafts.Clear();
        }
    }
}
