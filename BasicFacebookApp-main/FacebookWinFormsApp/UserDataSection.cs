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
    //TODO: Add things from the note
    //TODO: Change the name from UserDataSection? Maybe just DisplayableListBoxWithLink
    // TODO: Change the link to a searchbox?
    public partial class UserDataSection : UserControl
    {
        //TODO: Should it be public? I changed the class' visibility from internal to public for that
        public FacebookDataAndFormSynchronizer _facebookDataAndFormSynchronizer { private get; set; }
        public string linkText

        {
            get { return this.link.Text; }
            set { this.link.Text = value; }
        }
        // TODO: Is that a better way to pass this facebookUserManagerInterface to all the subforms? Maybe transient/singelton?
        public UserDataSection()
        {
            InitializeComponent();
        }

        // TODO: Understand when it happens - why is it different from the ctor?
        private void UserDataSection_Load(object sender, EventArgs e)
        {
        }

        private void link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _facebookDataAndFormSynchronizer.InsertDataToListBox(this.listBox, this.Name);
            //if (listBox.Items.Count == 0)
            //{
            //    MessageBox.Show($"No items to show for the command {this.linkText}");
            //}
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
