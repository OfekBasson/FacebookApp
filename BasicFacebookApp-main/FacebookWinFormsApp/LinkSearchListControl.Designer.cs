namespace BasicFacebookFeatures
{
    partial class LinkSearchListControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.link = new System.Windows.Forms.LinkLabel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.listBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // link
            // 
            this.link.AutoSize = true;
            this.link.Dock = System.Windows.Forms.DockStyle.Top;
            this.link.Location = new System.Drawing.Point(0, 0);
            this.link.Name = "link";
            this.link.Size = new System.Drawing.Size(49, 20);
            this.link.TabIndex = 0;
            this.link.TabStop = true;
            this.link.Text = "Show";
            this.link.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_LinkClicked);
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.Location = new System.Drawing.Point(0, 20);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(161, 26);
            this.textBox1.TabIndex = 3;
            // 
            // listBox
            // 
            this.listBox.BackColor = System.Drawing.SystemColors.HighlightText;
            this.listBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 20;
            this.listBox.Location = new System.Drawing.Point(0, 46);
            this.listBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(161, 164);
            this.listBox.TabIndex = 1;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // LinkSearchListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.link);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "LinkSearchListControl";
            this.Size = new System.Drawing.Size(161, 209);
            this.Load += new System.EventHandler(this.UserDataSection_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel link;
        private System.Windows.Forms.TextBox textBox1;
        // TODO: Check if it's ok to define it like this and if I can use private "set"
        public System.Windows.Forms.ListBox listBox;
    }
}
