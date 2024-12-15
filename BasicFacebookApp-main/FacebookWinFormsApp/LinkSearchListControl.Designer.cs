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
            this.link.Size = new System.Drawing.Size(40, 16);
            this.link.TabIndex = 0;
            this.link.TabStop = true;
            this.link.Text = "Show";
            this.link.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_LinkClicked);
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.Location = new System.Drawing.Point(0, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(143, 22);
            this.textBox1.TabIndex = 3;
            // 
            // listBox
            // 
            this.listBox.BackColor = System.Drawing.SystemColors.HighlightText;
            this.listBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 16;
            this.listBox.Location = new System.Drawing.Point(0, 38);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(143, 132);
            this.listBox.TabIndex = 1;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // LinkSearchListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.link);
            this.Name = "LinkSearchListControl";
            this.Size = new System.Drawing.Size(143, 167);
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
