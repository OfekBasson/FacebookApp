using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;
using System.Runtime.Remoting.Messaging;

namespace BasicFacebookFeatures
{
    // TODO: Implement Video change...
    // TODO: Why is the access token text needed? If it is I have to implement it again
    public partial class FormMain : Form
    {
        //TODO: Is this name with the underscore good? should the "f" be capital letter?
        private FacebookDataAndFormSynchronizer _facebookDataAndFormSynchronizer;
        // TODO: Should it be with m_ before foemUpdator?
        // TODO: Should I add private/public before this?
        
        public FormMain()
        {
            InitializeComponent();
            _facebookDataAndFormSynchronizer = new FacebookDataAndFormSynchronizer(buttonLogin, buttonLogout, pictureBoxProfile, new List<UserDataSection>() { this.infoDataSection, this.postsDataSection, this.videosDataSection, this.friendsDataSection, this.galleryDataSection });
            // TODO: Why is that?
            FacebookWrapper.FacebookService.s_CollectionLimit = 25;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            // TODO: What's this clipboard text?
            Clipboard.SetText("design.patterns");
            //TODO: Is it good? not one responsibility...
            _facebookDataAndFormSynchronizer.LogInAndUpdateForm(textBoxAppID.Text);
        }



        // TODO: Is it ok to invoke 2 different classes here? or should I wrap it in one class?
        private void buttonLogout_Click(object sender, EventArgs e)
        {
            _facebookDataAndFormSynchronizer.LogoutAndUpdateForm();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxAppID_TextChanged(object sender, EventArgs e)
        {

        }


        // TODO: implement
        //private void listBoxPosts_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Post selectedPost = listBoxPosts.SelectedItem as Post;
        //    if (selectedPost != null && selectedPost.PictureURL != null)
        //    {
        //        pictureBoxPost.ImageLocation = selectedPost.PictureURL;
        //    }
        //}

        // TODO: Are the tabs necessary?
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        // TODO: implement
        //private void listBoxGallery_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Photo selectedPhoto = listBoxGallery.SelectedItem as Photo;
        //    if (selectedPhoto != null && selectedPhoto.PictureAlbumURL != null)
        //        pictureBox1.ImageLocation = selectedPhoto.PictureAlbumURL;
        //}

        // TODO: implement
        //private void listBoxVideos_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Video video = listBoxVideos.SelectedItem as Video;
        //    try
        //    {
        //        if (video != null && video.URL != null)
        //        {
        //            axWindowsMediaPlayer1.URL = video.URL;
        //        }
        //        else
        //        {
        //            MessageBox.Show("Cannot play the selected video :(");
        //        }
        //    }
        //    catch (Exception ex) { }

        //}

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        // TODO: For what do we need it?
        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void InfoDataSection_Load(object sender, EventArgs e)
        {

        }

        private void infoDataSection_Load_1(object sender, EventArgs e)
        {

        }

        private void labelToken_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
