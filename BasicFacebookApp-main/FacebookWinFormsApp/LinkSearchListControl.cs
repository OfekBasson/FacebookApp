using CefSharp.DevTools.Accessibility;
using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public partial class LinkSearchListControl : UserControl
    {
        private Facade m_Facade { get; set; }
        private bool m_IsDataDisplayedInListBox { get; set; } = false;
        private FormMain m_FormMain;
        private dynamic m_DataHandler;
        public string m_LinkText

        {
            get { return this.link.Text; }
            set { this.link.Text = value; }
        }
        
        public LinkSearchListControl()
        {
            InitializeComponent();
            m_LinkText = $"Show {Name.Replace("DataSection", "")}";
            m_Facade = Singleton<Facade>.Instance;
        }


        private async void link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!m_IsDataDisplayedInListBox)
            {
                if (m_Facade.m_LoggedInUser != null)
                {
                    InitializeHandler(this.Name);
                    if (m_DataHandler != null)
                    {
                        listBox.DataSource = await m_DataHandler.RunDataTask();
                        PopulateComboBoxWithFilters(m_DataHandler.GetFilterOptions());
                        handleDataInsertionToListBox();
                    }
                    else
                    {
                        throw new InvalidOperationException($"Could not initialize handler for {this.Name}");
                    }
                }
                else
                {
                    MessageBox.Show("Please log in to display information");
                }
            }
            else
            {
                HideDataFromListBox();
            }
                
        }

        public void InitializeHandler(string i_ControlName)
        {
            Type dataType = ControlTypeMappings.s_ControlTypeMappings[i_ControlName];
            MethodInfo factoryMethod = typeof(ControlDataHandlerFactory)
                .GetMethod("CreateHandler")
                ?.MakeGenericMethod(dataType);

            m_DataHandler = factoryMethod?.Invoke(null, new object[] { i_ControlName });
        }

        private void PopulateComboBoxWithFilters(List<string> filters)
        {
            comboBoxFilter.Items.Clear();
            comboBoxFilter.Items.AddRange(filters.ToArray());
        }

        public void HideDataFromListBox()
        {
            this.listBox.DataSource = null;
            m_IsDataDisplayedInListBox = false;
            this.m_LinkText = $"Show {this.Name.Replace("DataSection", "")}";
        }

        private void handleDataInsertionToListBox()
        {
            if (this.listBox.Items.Count != 0)
            {
                this.m_LinkText = $"Hide {this.Name.Replace("DataSection", "")}";
                m_IsDataDisplayedInListBox = true;
            }
            else
            {
                MessageBox.Show($"No items to show for the command '{this.m_LinkText}'");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!m_IsDataDisplayedInListBox || m_Facade.m_LoggedInUser == null)
            {

                return;
            }
            genericListBox_SelectedIndexChanged(sender, e);
        }

        private void genericListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is ListBox listBox && listBox.SelectedItem != null)
            {
                var selectedItem = listBox.SelectedItem;
                var pictureUrlProperty = selectedItem.GetType() == typeof(Photo) ?
                        selectedItem.GetType().GetProperty("PictureAlbumURL") :
                        selectedItem.GetType().GetProperty("PictureURL");
                if (pictureUrlProperty != null)
                {
                    string pictureUrl = pictureUrlProperty.GetValue(selectedItem) as string;
                    if (!string.IsNullOrEmpty(pictureUrl))
                    {
                        if (m_FormMain == null)
                        {
                            m_FormMain = Application.OpenForms["FormMain"] as FormMain;
                        }

                        PictureBox pictureBox = m_FormMain.m_PictureBoxLeft();
                        pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox.ImageLocation = pictureUrl;
                    }
                }
            }
        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterByMember(this.Name);
        }

        
        private void textBoxFilter_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void filterByMember(string i_ControlName)
        {
            string selectedMember = this.comboBoxFilter.SelectedItem.ToString().Replace(" ", "");
            this.listBox.DataSource = null; 
            Type dataType = ControlTypeMappings.s_ControlTypeMappings[i_ControlName];
            MethodInfo factoryMethod = typeof(FilterFactory).GetMethod("FilterByMember").MakeGenericMethod(dataType);
            var dataSource = factoryMethod.Invoke(null, new object[] { selectedMember, m_Facade });
            if (i_ControlName == "PostsDataSection" && selectedMember == "CreatedTime")
            {
                this.listBox.DisplayMember = selectedMember; 
            }
            else if (i_ControlName == "GalleryDataSection" && selectedMember == "ToString")
            {
                this.listBox.DisplayMember = "ToString";
            }
            this.listBox.DataSource = dataSource;
        }


        private void buttonFilter_Click(object sender, EventArgs e)
        {
            if(this.comboBoxFilter.SelectedItem != null && !string.IsNullOrEmpty(this.textBoxFilter.Text))
            {
                String propertyName = this.comboBoxFilter.SelectedItem.ToString().Replace(" ", "");
                string i_ControlName = this.Name;
                Type dataType = ControlTypeMappings.s_ControlTypeMappings[i_ControlName];
                MethodInfo factoryMethod = typeof(FilterFactory).GetMethod("FilterByProperty").MakeGenericMethod(dataType);
                var dataSource = factoryMethod.Invoke(null, new object[] { propertyName, textBoxFilter.Text, m_Facade, i_ControlName });
                this.listBox.DataSource = dataSource;
            }
        }
    }
}
