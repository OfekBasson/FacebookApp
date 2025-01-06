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
        public UIBridge m_Bridge { get; set; }
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
        }

        private void UserDataSection_Load(object sender, EventArgs e)
        {
        }

        private void link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!m_IsDataDisplayedInListBox)
            {
                if (m_Bridge.m_LoggedInUser != null)
                {
                    InitializeHandler(this.Name);
                    if (m_DataHandler != null)
                    {
                        listBox.DataSource = m_DataHandler.GetData(m_Bridge);
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
        }

        public void InitializeHandler(string i_ControlName)
        {
            Type dataType = ControlDataHandlerFactory.s_ControlTypeMappings[i_ControlName];
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
            if (!m_IsDataDisplayedInListBox || m_Bridge.m_LoggedInUser == null)
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
                Console.WriteLine(selectedItem.GetType().ToString());
                var pictureUrlProperty = selectedItem.GetType() == typeof(Photo) ?
                        selectedItem.GetType().GetProperty("PictureAlbumURL") :
                        selectedItem.GetType().GetProperty("PictureURL");
                Console.WriteLine(pictureUrlProperty.ToString());
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
            string selectedMember = this.comboBoxFilter.SelectedItem.ToString().Replace(" ", "");
            string controlName = this.Name;
            this.listBox.DataSource = null;
            if (controlName == "PostsDataSection")
            {
                if(selectedMember == "CreatedTime")
                {
                    this.listBox.DisplayMember = selectedMember;
                }
                this.listBox.DataSource = ItemsFilter.FilterByMember(m_Bridge.m_Posts, selectedMember);
               
            }
            if (controlName == "FriendsDataSection")
            {
                this.listBox.DataSource = ItemsFilter.FilterByMember(m_Bridge.m_Friends, selectedMember);
            }
            if (controlName == "VideosDataSection")
            {
                this.listBox.DataSource = ItemsFilter.FilterByMember(m_Bridge.m_Videos, selectedMember);
            }
            if (controlName == "GalleryDataSection")
            {
                if(selectedMember == "ToString")
                {
                    this.listBox.DisplayMember = "ToString";
                }
                this.listBox.DataSource = ItemsFilter.FilterByMember(m_Bridge.m_Photos, selectedMember);
            }
        }

        
        private void textBoxFilter_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void buttonFilter_Click(object sender, EventArgs e)
        {
            if(this.comboBoxFilter.SelectedItem != null && !string.IsNullOrEmpty(this.textBoxFilter.Text))
            {
                String propertyName = this.comboBoxFilter.SelectedItem.ToString().Replace(" ", "");
                string linkSearchName = this.Name;
                try
                {
                    if (linkSearchName == "PostsDataSection")
                    {
                        if (propertyName == "Desecription")
                        {
                            propertyName = "ToString";
                        }
                        this.listBox.DataSource = ItemsFilter.FilterByProperty(m_Bridge.m_Posts, propertyName, textBoxFilter.Text);
                    }
                    if (linkSearchName == "FriendsDataSection")
                    {
                        this.listBox.DataSource = ItemsFilter.FilterByProperty(m_Bridge.m_Friends, propertyName, textBoxFilter.Text);
                        this.listBox.DataSource = ItemsFilter.FilterByProperty(m_Bridge.m_Friends, propertyName, textBoxFilter.Text);
                    }
                    if (linkSearchName == "VideosDataSection")
                    {
                        this.listBox.DataSource = ItemsFilter.FilterByProperty(m_Bridge.m_Videos, propertyName, textBoxFilter.Text);
                    }
                    if (linkSearchName == "GalleryDataSection")
                    {
                        if (propertyName == "Description")
                        {
                            propertyName = "Name";
                        }
                        this.listBox.DataSource = ItemsFilter.FilterByProperty(m_Bridge.m_Photos, propertyName, textBoxFilter.Text);
                    }
                }
                catch (Exception ex) 
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
