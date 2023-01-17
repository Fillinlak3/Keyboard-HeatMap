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
            this.LABEL_contact = new System.Windows.Forms.Label();
            this.BTN_Settings = new System.Windows.Forms.Button();
            this.PANEL_program_cfg = new System.Windows.Forms.Panel();
            this.LABEL_program_cfg_panel = new System.Windows.Forms.Label();
            this.BTN_open_saves_folder = new System.Windows.Forms.Button();
            this.CHECKBOX_open_on_startup = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.PICBOX_logo)).BeginInit();
            this.PANEL_program_cfg.SuspendLayout();
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
            this.PICBOX_logo.Image = global::Keyboard_HeatMap.Properties.Resources.keyboard_icon_help_page;
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
            this.BTN_GoBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(173)))), ((int)(((byte)(186)))));
            this.BTN_GoBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_GoBack.FlatAppearance.BorderSize = 0;
            this.BTN_GoBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_GoBack.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BTN_GoBack.Image = global::Keyboard_HeatMap.Properties.Resources.go_back_black;
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
            // LABEL_contact
            // 
            this.LABEL_contact.AutoSize = true;
            this.LABEL_contact.Location = new System.Drawing.Point(687, 305);
            this.LABEL_contact.Name = "LABEL_contact";
            this.LABEL_contact.Size = new System.Drawing.Size(52, 15);
            this.LABEL_contact.TabIndex = 7;
            this.LABEL_contact.Text = "Contact:";
            // 
            // BTN_Settings
            // 
            this.BTN_Settings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(173)))), ((int)(((byte)(186)))));
            this.BTN_Settings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_Settings.FlatAppearance.BorderSize = 0;
            this.BTN_Settings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Settings.Image = global::Keyboard_HeatMap.Properties.Resources.setting;
            this.BTN_Settings.Location = new System.Drawing.Point(752, 2);
            this.BTN_Settings.Name = "BTN_Settings";
            this.BTN_Settings.Size = new System.Drawing.Size(35, 24);
            this.BTN_Settings.TabIndex = 8;
            this.BTN_Settings.TabStop = false;
            this.BTN_Settings.UseVisualStyleBackColor = false;
            this.BTN_Settings.Click += new System.EventHandler(this.BTN_Settings_Click);
            // 
            // PANEL_program_cfg
            // 
            this.PANEL_program_cfg.Controls.Add(this.LABEL_program_cfg_panel);
            this.PANEL_program_cfg.Controls.Add(this.BTN_open_saves_folder);
            this.PANEL_program_cfg.Controls.Add(this.CHECKBOX_open_on_startup);
            this.PANEL_program_cfg.Location = new System.Drawing.Point(660, 62);
            this.PANEL_program_cfg.Name = "PANEL_program_cfg";
            this.PANEL_program_cfg.Size = new System.Drawing.Size(155, 186);
            this.PANEL_program_cfg.TabIndex = 9;
            this.PANEL_program_cfg.Visible = false;
            // 
            // LABEL_program_cfg_panel
            // 
            this.LABEL_program_cfg_panel.AutoSize = true;
            this.LABEL_program_cfg_panel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LABEL_program_cfg_panel.Location = new System.Drawing.Point(7, 7);
            this.LABEL_program_cfg_panel.Name = "LABEL_program_cfg_panel";
            this.LABEL_program_cfg_panel.Size = new System.Drawing.Size(142, 34);
            this.LABEL_program_cfg_panel.TabIndex = 2;
            this.LABEL_program_cfg_panel.Text = "Program Configuration\r\n            Panel";
            // 
            // BTN_open_saves_folder
            // 
            this.BTN_open_saves_folder.BackColor = System.Drawing.Color.Transparent;
            this.BTN_open_saves_folder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_open_saves_folder.FlatAppearance.BorderSize = 0;
            this.BTN_open_saves_folder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_open_saves_folder.Image = global::Keyboard_HeatMap.Properties.Resources.diskette;
            this.BTN_open_saves_folder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTN_open_saves_folder.Location = new System.Drawing.Point(2, 74);
            this.BTN_open_saves_folder.Name = "BTN_open_saves_folder";
            this.BTN_open_saves_folder.Size = new System.Drawing.Size(127, 23);
            this.BTN_open_saves_folder.TabIndex = 1;
            this.BTN_open_saves_folder.Text = "Open saves folder";
            this.BTN_open_saves_folder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTN_open_saves_folder.UseVisualStyleBackColor = false;
            this.BTN_open_saves_folder.Click += new System.EventHandler(this.BTN_open_saves_folder_Click);
            // 
            // CHECKBOX_open_on_startup
            // 
            this.CHECKBOX_open_on_startup.AutoSize = true;
            this.CHECKBOX_open_on_startup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CHECKBOX_open_on_startup.Location = new System.Drawing.Point(7, 54);
            this.CHECKBOX_open_on_startup.Name = "CHECKBOX_open_on_startup";
            this.CHECKBOX_open_on_startup.Size = new System.Drawing.Size(122, 19);
            this.CHECKBOX_open_on_startup.TabIndex = 0;
            this.CHECKBOX_open_on_startup.Text = "Launch on startup";
            this.CHECKBOX_open_on_startup.UseVisualStyleBackColor = true;
            this.CHECKBOX_open_on_startup.CheckedChanged += new System.EventHandler(this.CHECKBOX_open_on_startup_CheckedChanged);
            // 
            // Help_Page
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(173)))), ((int)(((byte)(186)))));
            this.Controls.Add(this.PANEL_program_cfg);
            this.Controls.Add(this.BTN_Settings);
            this.Controls.Add(this.LABEL_contact);
            this.Controls.Add(this.LINKLABEL_ig_page);
            this.Controls.Add(this.BTN_GoBack);
            this.Controls.Add(this.LABEL_key_list);
            this.Controls.Add(this.LABEL_title);
            this.Controls.Add(this.LABEL_creator);
            this.Controls.Add(this.LABEL_copyright_signature);
            this.Controls.Add(this.PICBOX_logo);
            this.Controls.Add(this.LABEL_program_description);
            this.Name = "Help_Page";
            this.Size = new System.Drawing.Size(845, 325);
            ((System.ComponentModel.ISupportInitialize)(this.PICBOX_logo)).EndInit();
            this.PANEL_program_cfg.ResumeLayout(false);
            this.PANEL_program_cfg.PerformLayout();
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
        private Label LABEL_contact;
        private Button BTN_Settings;
        private Panel PANEL_program_cfg;
        private Button BTN_open_saves_folder;
        private CheckBox CHECKBOX_open_on_startup;
        private Label LABEL_program_cfg_panel;
    }
}
