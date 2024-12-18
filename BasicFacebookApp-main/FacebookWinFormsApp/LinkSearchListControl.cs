﻿using System;
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
        private FormMain m_formMain;
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
                    InsertDataToComboBoxFilter(this.Name);
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

        private void InsertDataToComboBoxFilter(string i_ControlName)
        {
            if (i_ControlName == "PostsDataSection")
            {
                this.comboBoxFilter.Items.Add("Name");
                this.comboBoxFilter.Items.Add("Created Time");
                this.comboBoxFilter.Items.Add("Place");
                this.comboBoxFilter.Items.Add("Description");
            }
            if (i_ControlName == "FriendsDataSection")
            {
                this.comboBoxFilter.Items.Add("Name");
                this.comboBoxFilter.Items.Add("Location");
                this.comboBoxFilter.Items.Add("Email");
            }
            if (i_ControlName == "VideosDataSection")
            {
                this.comboBoxFilter.Items.Add("Name"); 
                this.comboBoxFilter.Items.Add("Created Time");
                this.comboBoxFilter.Items.Add("Location");
            }
            if (i_ControlName == "GalleryDataSection")
            {
                this.comboBoxFilter.Items.Add("To String");
                this.comboBoxFilter.Items.Add("Location");
                this.comboBoxFilter.Items.Add("Description");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!m_isDataDisplayedInListBox || m_bridge.m_loggedInUser == null)
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
                var pictureUrlProperty = selectedItem.GetType() == typeof(FacebookWrapper.ObjectModel.Photo) ?
                        selectedItem.GetType().GetProperty("PictureAlbumURL") :
                        selectedItem.GetType().GetProperty("PictureURL");

                if (pictureUrlProperty != null)
                {
                    string pictureUrl = pictureUrlProperty.GetValue(selectedItem) as string;
                    if (!string.IsNullOrEmpty(pictureUrl))
                    {
                        if (m_formMain == null)
                        {
                            m_formMain = Application.OpenForms["FormMain"] as FormMain;
                        }

                        PictureBox pictureBox = m_formMain.PictureBoxLeft;
                        pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox.ImageLocation = pictureUrl;
                    }
                }
            }
        }
        //why its still box1 and not filter? 
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("here");
            //TODO: sometimes the list is full of empty string due to location="" or something.. 
            // Filter out items with an empty or null property for DisplayMember
            string selectedMember = this.comboBoxFilter.SelectedItem.ToString().Replace(" ", "");
            string controlName = this.Name;
            this.listBox.DataSource = null;
            if (controlName == "PostsDataSection")
            {
                if(selectedMember == "CreatedTime")
                {
                    this.listBox.DisplayMember = selectedMember;
                }
                this.listBox.DataSource = FilterItems.FilterByMember(m_bridge.m_posts, selectedMember);
               
            }
            if (controlName == "FriendsDataSection")
            {
                this.listBox.DataSource = FilterItems.FilterByMember(m_bridge.m_friends, selectedMember);
            }
            if (controlName == "VideosDataSection")
            {
                this.listBox.DataSource = FilterItems.FilterByMember(m_bridge.m_videos, selectedMember);
            }
            if (controlName == "GalleryDataSection")
            {
                if(selectedMember == "ToString")
                {
                    this.listBox.DisplayMember = "ToString";
                }
                this.listBox.DataSource = FilterItems.FilterByMember(m_bridge.m_photos, selectedMember);
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
                        this.listBox.DataSource = FilterItems.FilterByProperty(m_bridge.m_posts, propertyName, textBoxFilter.Text);
                    }
                    if (linkSearchName == "FriendsDataSection")
                    {
                        this.listBox.DataSource = FilterItems.FilterByProperty(m_bridge.m_friends, propertyName, textBoxFilter.Text);
                        this.listBox.DataSource = FilterItems.FilterByProperty(m_bridge.m_friends, propertyName, textBoxFilter.Text);
                    }
                    if (linkSearchName == "VideosDataSection")
                    {
                        this.listBox.DataSource = FilterItems.FilterByProperty(m_bridge.m_videos, propertyName, textBoxFilter.Text);
                    }
                    if (linkSearchName == "GalleryDataSection")
                    {
                        if (propertyName == "Description")
                        {
                            propertyName = "Name";
                        }
                        this.listBox.DataSource = FilterItems.FilterByProperty(m_bridge.m_photos, propertyName, textBoxFilter.Text);
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
