namespace Keyboard_HeatMap
{
    partial class Form_Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.detectKeyPress = new System.Windows.Forms.Timer(this.components);
            this.Frame_Update = new System.Windows.Forms.Timer(this.components);
            keyboard_Layout = new Keyboard_HeatMap.Keyboard_Layout();
            this.help_Page = new Keyboard_HeatMap.Remastered_Help_Page();
            MenuBar = new System.Windows.Forms.Panel();
            this.BTN_Minimize = new System.Windows.Forms.Button();
            this.BTN_Maximize = new System.Windows.Forms.Button();
            this.BTN_Close = new System.Windows.Forms.Button();
            this.ApplicationTitle = new System.Windows.Forms.Label();
            this.ApplicationLogo = new System.Windows.Forms.PictureBox();
            MenuBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ApplicationLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // detectKeyPress
            // 
            this.detectKeyPress.Interval = 1;
            this.detectKeyPress.Tick += new System.EventHandler(this.detectKeyPress_Tick);
            // 
            // Frame_Update
            // 
            this.Frame_Update.Interval = 20;
            this.Frame_Update.Tick += new System.EventHandler(this.Frame_Update_Tick);
            // 
            // keyboard_Layout
            // 
            keyboard_Layout.AllowDrop = true;
            keyboard_Layout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(173)))), ((int)(((byte)(186)))));
            keyboard_Layout.Dock = System.Windows.Forms.DockStyle.Fill;
            keyboard_Layout.Location = new System.Drawing.Point(0, 29);
            keyboard_Layout.Name = "keyboard_Layout";
            keyboard_Layout.Size = new System.Drawing.Size(845, 326);
            keyboard_Layout.TabIndex = 0;
            keyboard_Layout.TabStop = false;
            keyboard_Layout.BackColorChanged += new System.EventHandler(this.UpdateTitlebarColor);
            keyboard_Layout.DragDrop += new System.Windows.Forms.DragEventHandler(keyboard_Layout_DragDrop);
            keyboard_Layout.DragEnter += new System.Windows.Forms.DragEventHandler(keyboard_Layout_DragEnter);
            // 
            // help_Page
            // 
            this.help_Page.AutoSize = true;
            this.help_Page.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(173)))), ((int)(((byte)(186)))));
            this.help_Page.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("help_Page.BackgroundImage")));
            this.help_Page.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.help_Page.Dock = System.Windows.Forms.DockStyle.Fill;
            this.help_Page.Location = new System.Drawing.Point(0, 29);
            this.help_Page.Name = "help_Page";
            this.help_Page.Size = new System.Drawing.Size(845, 326);
            this.help_Page.TabIndex = 0;
            this.help_Page.TabStop = false;
            this.help_Page.Visible = false;
            // 
            // MenuBar
            // 
            MenuBar.Controls.Add(this.BTN_Minimize);
            MenuBar.Controls.Add(this.BTN_Maximize);
            MenuBar.Controls.Add(this.BTN_Close);
            MenuBar.Controls.Add(this.ApplicationTitle);
            MenuBar.Controls.Add(this.ApplicationLogo);
            MenuBar.Dock = System.Windows.Forms.DockStyle.Top;
            MenuBar.Location = new System.Drawing.Point(0, 0);
            MenuBar.Name = "MenuBar";
            MenuBar.Size = new System.Drawing.Size(845, 29);
            MenuBar.TabIndex = 1;
            MenuBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoveForm);
            // 
            // BTN_Minimize
            // 
            this.BTN_Minimize.BackColor = System.Drawing.Color.Transparent;
            this.BTN_Minimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.BTN_Minimize.FlatAppearance.BorderSize = 0;
            this.BTN_Minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Minimize.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BTN_Minimize.Location = new System.Drawing.Point(710, 0);
            this.BTN_Minimize.Name = "BTN_Minimize";
            this.BTN_Minimize.Size = new System.Drawing.Size(45, 29);
            this.BTN_Minimize.TabIndex = 0;
            this.BTN_Minimize.TabStop = false;
            this.BTN_Minimize.Text = "─";
            this.BTN_Minimize.UseVisualStyleBackColor = false;
            this.BTN_Minimize.Click += new System.EventHandler(this.MinimizeForm);
            // 
            // BTN_Maximize
            // 
            this.BTN_Maximize.BackColor = System.Drawing.Color.Transparent;
            this.BTN_Maximize.Dock = System.Windows.Forms.DockStyle.Right;
            this.BTN_Maximize.Enabled = false;
            this.BTN_Maximize.FlatAppearance.BorderSize = 0;
            this.BTN_Maximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Maximize.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BTN_Maximize.Location = new System.Drawing.Point(755, 0);
            this.BTN_Maximize.Name = "BTN_Maximize";
            this.BTN_Maximize.Size = new System.Drawing.Size(45, 29);
            this.BTN_Maximize.TabIndex = 0;
            this.BTN_Maximize.TabStop = false;
            this.BTN_Maximize.Text = "▢";
            this.BTN_Maximize.UseVisualStyleBackColor = false;
            // 
            // BTN_Close
            // 
            this.BTN_Close.BackColor = System.Drawing.Color.Transparent;
            this.BTN_Close.Dock = System.Windows.Forms.DockStyle.Right;
            this.BTN_Close.FlatAppearance.BorderSize = 0;
            this.BTN_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Close.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BTN_Close.Location = new System.Drawing.Point(800, 0);
            this.BTN_Close.Name = "BTN_Close";
            this.BTN_Close.Size = new System.Drawing.Size(45, 29);
            this.BTN_Close.TabIndex = 0;
            this.BTN_Close.TabStop = false;
            this.BTN_Close.Text = "⨉";
            this.BTN_Close.UseVisualStyleBackColor = false;
            this.BTN_Close.Click += new System.EventHandler(this.CloseForm);
            this.BTN_Close.MouseEnter += new System.EventHandler(this.FocusCloseButton);
            this.BTN_Close.MouseLeave += new System.EventHandler(this.UnfocusCloseButton);
            // 
            // ApplicationTitle
            // 
            this.ApplicationTitle.AutoSize = true;
            this.ApplicationTitle.Location = new System.Drawing.Point(29, 7);
            this.ApplicationTitle.Name = "ApplicationTitle";
            this.ApplicationTitle.Size = new System.Drawing.Size(109, 15);
            this.ApplicationTitle.TabIndex = 0;
            this.ApplicationTitle.Text = "Keyboard HeatMap";
            // 
            // ApplicationLogo
            // 
            this.ApplicationLogo.BackgroundImage = global::Keyboard_HeatMap.Properties.Resources.keyboard_icon_help_page;
            this.ApplicationLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ApplicationLogo.Location = new System.Drawing.Point(6, 3);
            this.ApplicationLogo.Name = "ApplicationLogo";
            this.ApplicationLogo.Size = new System.Drawing.Size(20, 20);
            this.ApplicationLogo.TabIndex = 0;
            this.ApplicationLogo.TabStop = false;
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(845, 355);
            this.ControlBox = false;
            this.Controls.Add(keyboard_Layout);
            this.Controls.Add(this.help_Page);
            this.Controls.Add(MenuBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Main";
            this.Opacity = 0.9D;
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Keyboard HeatMap";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Main_FormClosing);
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_Main_KeyDown);
            this.Resize += new System.EventHandler(this.RestoreForm);
            MenuBar.ResumeLayout(false);
            MenuBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ApplicationLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer detectKeyPress;
        private System.Windows.Forms.Timer Frame_Update;
        private Remastered_Help_Page help_Page;
        private PictureBox ApplicationLogo;
        private Label ApplicationTitle;
        private Button BTN_Maximize;
        private Button BTN_Close;
        private Button BTN_Minimize;
        private static Panel MenuBar;
        private static Keyboard_Layout keyboard_Layout;
    }
}