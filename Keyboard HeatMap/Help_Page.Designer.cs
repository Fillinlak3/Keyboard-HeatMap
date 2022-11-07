namespace Keyboard_HeatMap
{
    partial class Help_Page
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Help_Page));
            this.LABEL_title = new System.Windows.Forms.Label();
            this.LABEL_program_description = new System.Windows.Forms.Label();
            this.PICBOX_logo = new System.Windows.Forms.PictureBox();
            this.LABEL_copyright_signature = new System.Windows.Forms.Label();
            this.LABEL_creator = new System.Windows.Forms.Label();
            this.LABEL_key_list = new System.Windows.Forms.Label();
            this.BTN_GoBack = new System.Windows.Forms.Button();
            this.LINKLABEL_ig_page = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PICBOX_logo)).BeginInit();
            this.SuspendLayout();
            // 
            // LABEL_title
            // 
            this.LABEL_title.AutoSize = true;
            this.LABEL_title.BackColor = System.Drawing.Color.Transparent;
            this.LABEL_title.Font = new System.Drawing.Font("Segoe UI", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.LABEL_title.Location = new System.Drawing.Point(82, 3);
            this.LABEL_title.Name = "LABEL_title";
            this.LABEL_title.Size = new System.Drawing.Size(279, 40);
            this.LABEL_title.TabIndex = 0;
            this.LABEL_title.Text = "Keyboard HeatMap";
            // 
            // LABEL_program_description
            // 
            this.LABEL_program_description.AutoSize = true;
            this.LABEL_program_description.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LABEL_program_description.Location = new System.Drawing.Point(12, 79);
            this.LABEL_program_description.Name = "LABEL_program_description";
            this.LABEL_program_description.Size = new System.Drawing.Size(605, 204);
            this.LABEL_program_description.TabIndex = 1;
            this.LABEL_program_description.Text = resources.GetString("LABEL_program_description.Text");
            // 
            // PICBOX_logo
            // 
            this.PICBOX_logo.Image = global::Keyboard_HeatMap.Properties.Resources.keyboard_1_64x64;
            this.PICBOX_logo.Location = new System.Drawing.Point(12, 3);
            this.PICBOX_logo.Name = "PICBOX_logo";
            this.PICBOX_logo.Size = new System.Drawing.Size(64, 64);
            this.PICBOX_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PICBOX_logo.TabIndex = 2;
            this.PICBOX_logo.TabStop = false;
            // 
            // LABEL_copyright_signature
            // 
            this.LABEL_copyright_signature.AutoSize = true;
            this.LABEL_copyright_signature.Location = new System.Drawing.Point(323, 305);
            this.LABEL_copyright_signature.Name = "LABEL_copyright_signature";
            this.LABEL_copyright_signature.Size = new System.Drawing.Size(198, 15);
            this.LABEL_copyright_signature.TabIndex = 3;
            this.LABEL_copyright_signature.Text = "© FillInHack, Inc. All rights reserved.";
            // 
            // LABEL_creator
            // 
            this.LABEL_creator.AutoSize = true;
            this.LABEL_creator.BackColor = System.Drawing.Color.Transparent;
            this.LABEL_creator.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.LABEL_creator.Location = new System.Drawing.Point(82, 43);
            this.LABEL_creator.Name = "LABEL_creator";
            this.LABEL_creator.Size = new System.Drawing.Size(173, 15);
            this.LABEL_creator.TabIndex = 4;
            this.LABEL_creator.Text = "Program developed by Bucurie";
            // 
            // LABEL_key_list
            // 
            this.LABEL_key_list.AutoSize = true;
            this.LABEL_key_list.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LABEL_key_list.Location = new System.Drawing.Point(323, 197);
            this.LABEL_key_list.Name = "LABEL_key_list";
            this.LABEL_key_list.Size = new System.Drawing.Size(233, 51);
            this.LABEL_key_list.TabIndex = 5;
            this.LABEL_key_list.Text = "Program-defined keys list:\r\nF1 - Hide/Show Help Page (this page)\r\nF2 - Start/Stop" +
    " Program";
            // 
            // BTN_GoBack
            // 
            this.BTN_GoBack.BackColor = System.Drawing.Color.Transparent;
            this.BTN_GoBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_GoBack.FlatAppearance.BorderSize = 0;
            this.BTN_GoBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_GoBack.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BTN_GoBack.Image = global::Keyboard_HeatMap.Properties.Resources.go_back;
            this.BTN_GoBack.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTN_GoBack.Location = new System.Drawing.Point(786, 3);
            this.BTN_GoBack.Name = "BTN_GoBack";
            this.BTN_GoBack.Size = new System.Drawing.Size(56, 23);
            this.BTN_GoBack.TabIndex = 0;
            this.BTN_GoBack.TabStop = false;
            this.BTN_GoBack.Text = "back";
            this.BTN_GoBack.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTN_GoBack.UseVisualStyleBackColor = false;
            this.BTN_GoBack.Click += new System.EventHandler(this.GoBack);
            // 
            // LINKLABEL_ig_page
            // 
            this.LINKLABEL_ig_page.AutoSize = true;
            this.LINKLABEL_ig_page.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.LINKLABEL_ig_page.Location = new System.Drawing.Point(741, 305);
            this.LINKLABEL_ig_page.Name = "LINKLABEL_ig_page";
            this.LINKLABEL_ig_page.Size = new System.Drawing.Size(101, 15);
            this.LINKLABEL_ig_page.TabIndex = 6;
            this.LINKLABEL_ig_page.TabStop = true;
            this.LINKLABEL_ig_page.Text = "IG: @iambucuriee";
            this.LINKLABEL_ig_page.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OpenInstagramPage);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(687, 305);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Contact:";
            // 
            // Help_Page
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(173)))), ((int)(((byte)(186)))));
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LINKLABEL_ig_page);
            this.Controls.Add(this.BTN_GoBack);
            this.Controls.Add(this.LABEL_key_list);
            this.Controls.Add(this.LABEL_title);
            this.Controls.Add(this.LABEL_creator);
            this.Controls.Add(this.LABEL_copyright_signature);
            this.Controls.Add(this.PICBOX_logo);
            this.Controls.Add(this.LABEL_program_description);
            this.Name = "Help_Page";
            this.Size = new System.Drawing.Size(845, 320);
            ((System.ComponentModel.ISupportInitialize)(this.PICBOX_logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label LABEL_title;
        private Label LABEL_program_description;
        private PictureBox PICBOX_logo;
        private Label LABEL_copyright_signature;
        private Label LABEL_creator;
        private Label LABEL_key_list;
        private Button BTN_GoBack;
        private LinkLabel LINKLABEL_ig_page;
        private Label label1;
    }
}
