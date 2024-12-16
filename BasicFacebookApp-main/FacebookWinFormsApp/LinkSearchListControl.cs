using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures
{
    public partial class LinkSearchListControl : UserControl
    {
        public UIBridge m_bridge { get; set; }
        private bool m_isDataDisplayedInListBox { get; set; } = false;
        public string m_linkText

        {
            get { return this.link.Text; }
            set { this.link.Text = value; }
        }
        
        // TODO: Listen to this event and update the image/video/etc...
        public event Action IndexChanged;
        public LinkSearchListControl()
        {
            InitializeComponent();
            m_linkText = $"Show {Name.Replace("DataSection", "")}";
        }

        private void UserDataSection_Load(object sender, EventArgs e)
        {
        }

        private void link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!m_isDataDisplayedInListBox)
            {
                if (m_bridge.m_loggedInUser != null)
                {
                    InsertDataToListBox(this.Name);
                    handleDataInsertionToListBox();
                }
                else
                {
                    MessageBox.Show("Please log in to display information");
                }
            }
            else
            {
                hideDataFromListBox();
            }
        }
        public void hideDataFromListBox()
        {
            this.listBox.DataSource = null;
            m_isDataDisplayedInListBox = false;
            this.m_linkText = $"Show {this.Name.Replace("DataSection", "")}";
        }

        private void handleDataInsertionToListBox()
        {
            if (this.listBox.Items.Count != 0)
            {
                this.m_linkText = $"Hide {this.Name.Replace("DataSection", "")}";
                m_isDataDisplayedInListBox = true;
            }
            else
            {
                MessageBox.Show($"No items to show for the command '{this.m_linkText}'");
            }
        }

        private void InsertDataToListBox(string i_ControlName)
        {
            if (i_ControlName == "PostsDataSection")
            {
                this.listBox.DataSource = m_bridge.m_posts;
            }
            if (i_ControlName == "FriendsDataSection")
            {
                this.listBox.DataSource = m_bridge.m_friends;
            }
            if (i_ControlName == "VideosDataSection")
            {
                this.listBox.DataSource = m_bridge.m_videos;
            }
            if (i_ControlName == "GalleryDataSection")
            {
                this.listBox.DataSource = m_bridge.m_photos;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            object selectedItem = listBox.SelectedItem;
        }
    }
}
