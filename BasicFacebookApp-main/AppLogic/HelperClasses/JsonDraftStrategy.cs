using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.IO;
using Newtonsoft.Json;

namespace AppLogic.HelperClasses
{
    public class JsonDraftStrategy : IDraftStrategy
    {
        private readonly string r_FilePathJson = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "FacebookApp", "draftPosts.json");

        public void SaveDrafts(BindingList<PostDraft> drafts)
        {
            try
            {
                string json = JsonConvert.SerializeObject(drafts, Formatting.Indented);
                File.WriteAllText(r_FilePathJson, json);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error saving drafts to JSON: {ex.Message}", ex);
            }
        }

        public BindingList<PostDraft> LoadDrafts()
        {
            BindingList<PostDraft> listDrafts = new BindingList<PostDraft>();
            
            if (File.Exists(r_FilePathJson))
            {
                try
                {
                    string json = File.ReadAllText(r_FilePathJson);
                    listDrafts =  JsonConvert.DeserializeObject<BindingList<PostDraft>>(json) ?? new BindingList<PostDraft>();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error loading drafts to JSON: {ex.Message}", ex);
                }
            }

            return listDrafts;
        }
    }
}
