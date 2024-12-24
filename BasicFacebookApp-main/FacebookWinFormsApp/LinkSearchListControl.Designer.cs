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
            this.listBox = new System.Windows.Forms.ListBox();
            this.comboBoxFilter = new System.Windows.Forms.ComboBox();
            this.textBoxFilter = new System.Windows.Forms.TextBox();
            this.buttonFilter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // link
            // 
            this.link.AutoSize = true;
            this.link.Dock = System.Windows.Forms.DockStyle.Top;
            this.link.Location = new System.Drawing.Point(0, 0);
            this.link.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.link.Name = "link";
            this.link.Size = new System.Drawing.Size(34, 13);
            this.link.TabIndex = 0;
            this.link.TabStop = true;
            this.link.Text = "Show";
            this.link.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_LinkClicked);
            // 
            // listBox
            // 
            this.listBox.BackColor = System.Drawing.SystemColors.HighlightText;
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(-2, 50);
            this.listBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(161, 82);
            this.listBox.TabIndex = 1;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // comboBoxFilter
            // 
            this.comboBoxFilter.FormattingEnabled = true;
            this.comboBoxFilter.Location = new System.Drawing.Point(0, 15);
            this.comboBoxFilter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxFilter.Name = "comboBoxFilter";
            this.comboBoxFilter.Size = new System.Drawing.Size(161, 21);
            this.comboBoxFilter.TabIndex = 4;
            this.comboBoxFilter.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textBoxFilter
            // 
            this.textBoxFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxFilter.Location = new System.Drawing.Point(0, 33);
            this.textBoxFilter.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBoxFilter.Name = "textBoxFilter";
            this.textBoxFilter.Size = new System.Drawing.Size(115, 20);
            this.textBoxFilter.TabIndex = 3;
            this.textBoxFilter.TextChanged += new System.EventHandler(this.textBoxFilter_TextChanged);
            // 
            // buttonFilter
            // 
            this.buttonFilter.BackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonFilter.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonFilter.Location = new System.Drawing.Point(114, 31);
            this.buttonFilter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonFilter.Name = "buttonFilter";
            this.buttonFilter.Size = new System.Drawing.Size(47, 24);
            this.buttonFilter.TabIndex = 5;
            this.buttonFilter.Text = "Filter";
            this.buttonFilter.UseVisualStyleBackColor = false;
            this.buttonFilter.Click += new System.EventHandler(this.buttonFilter_Click);
            // 
            // LinkSearchListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonFilter);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.textBoxFilter);
            this.Controls.Add(this.comboBoxFilter);
            this.Controls.Add(this.link);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "LinkSearchListControl";
            this.Size = new System.Drawing.Size(159, 131);
            this.Load += new System.EventHandler(this.UserDataSection_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel link;
        // TODO: Check if it's ok to define it like this and if I can use private "set"
        public System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.ComboBox comboBoxFilter;
        private System.Windows.Forms.TextBox textBoxFilter;
        private System.Windows.Forms.Button buttonFilter;
    }
}
