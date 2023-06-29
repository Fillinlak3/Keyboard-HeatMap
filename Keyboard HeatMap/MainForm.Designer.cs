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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            detectKeyPress = new System.Windows.Forms.Timer(components);
            Frame_Update = new System.Windows.Forms.Timer(components);
            keyboard_Layout = new Keyboard_Layout();
            help_Page = new Remastered_Help_Page();
            MenuBar = new Panel();
            BTN_AlwaysOnTop = new Button();
            BTN_Minimize = new Button();
            BTN_Maximize = new Button();
            BTN_Close = new Button();
            ApplicationTitle = new Label();
            ApplicationLogo = new PictureBox();
            MenuBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ApplicationLogo).BeginInit();
            SuspendLayout();
            // 
            // detectKeyPress
            // 
            detectKeyPress.Interval = 1;
            detectKeyPress.Tick += detectKeyPress_Tick;
            // 
            // Frame_Update
            // 
            Frame_Update.Interval = 20;
            Frame_Update.Tick += Frame_Update_Tick;
            // 
            // keyboard_Layout
            // 
            keyboard_Layout.AllowDrop = true;
            keyboard_Layout.AutoSize = true;
            keyboard_Layout.BackColor = Color.FromArgb(167, 173, 186);
            keyboard_Layout.Dock = DockStyle.Fill;
            keyboard_Layout.Location = new Point(0, 29);
            keyboard_Layout.Name = "keyboard_Layout";
            keyboard_Layout.Size = new Size(845, 326);
            keyboard_Layout.TabIndex = 0;
            keyboard_Layout.TabStop = false;
            keyboard_Layout.BackColorChanged += UpdateTitlebarColor;
            keyboard_Layout.DragDrop += keyboard_Layout_DragDrop;
            keyboard_Layout.DragEnter += keyboard_Layout_DragEnter;
            // 
            // help_Page
            // 
            help_Page.AutoSize = true;
            help_Page.BackColor = Color.FromArgb(167, 173, 186);
            help_Page.BackgroundImage = (Image)resources.GetObject("help_Page.BackgroundImage");
            help_Page.BackgroundImageLayout = ImageLayout.Stretch;
            help_Page.Dock = DockStyle.Fill;
            help_Page.Location = new Point(0, 29);
            help_Page.Name = "help_Page";
            help_Page.Size = new Size(845, 326);
            help_Page.TabIndex = 0;
            help_Page.TabStop = false;
            help_Page.Visible = false;
            // 
            // MenuBar
            // 
            MenuBar.Controls.Add(BTN_AlwaysOnTop);
            MenuBar.Controls.Add(BTN_Minimize);
            MenuBar.Controls.Add(BTN_Maximize);
            MenuBar.Controls.Add(BTN_Close);
            MenuBar.Controls.Add(ApplicationTitle);
            MenuBar.Controls.Add(ApplicationLogo);
            MenuBar.Dock = DockStyle.Top;
            MenuBar.Location = new Point(0, 0);
            MenuBar.Name = "MenuBar";
            MenuBar.Size = new Size(845, 29);
            MenuBar.TabIndex = 1;
            MenuBar.MouseMove += MoveForm;
            // 
            // BTN_AlwaysOnTop
            // 
            BTN_AlwaysOnTop.BackColor = Color.Transparent;
            BTN_AlwaysOnTop.Dock = DockStyle.Right;
            BTN_AlwaysOnTop.FlatAppearance.BorderSize = 0;
            BTN_AlwaysOnTop.FlatStyle = FlatStyle.Flat;
            BTN_AlwaysOnTop.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            BTN_AlwaysOnTop.Image = Properties.Resources.lock_unlocked;
            BTN_AlwaysOnTop.Location = new Point(685, 0);
            BTN_AlwaysOnTop.Name = "BTN_AlwaysOnTop";
            BTN_AlwaysOnTop.Size = new Size(25, 29);
            BTN_AlwaysOnTop.TabIndex = 4;
            BTN_AlwaysOnTop.TabStop = false;
            BTN_AlwaysOnTop.TextAlign = ContentAlignment.MiddleRight;
            BTN_AlwaysOnTop.UseVisualStyleBackColor = false;
            BTN_AlwaysOnTop.Click += LockOnTop;
            // 
            // BTN_Minimize
            // 
            BTN_Minimize.BackColor = Color.Transparent;
            BTN_Minimize.Dock = DockStyle.Right;
            BTN_Minimize.FlatAppearance.BorderSize = 0;
            BTN_Minimize.FlatStyle = FlatStyle.Flat;
            BTN_Minimize.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            BTN_Minimize.Location = new Point(710, 0);
            BTN_Minimize.Name = "BTN_Minimize";
            BTN_Minimize.Size = new Size(45, 29);
            BTN_Minimize.TabIndex = 1;
            BTN_Minimize.TabStop = false;
            BTN_Minimize.Text = "─";
            BTN_Minimize.UseVisualStyleBackColor = false;
            BTN_Minimize.Click += MinimizeForm;
            // 
            // BTN_Maximize
            // 
            BTN_Maximize.BackColor = Color.Transparent;
            BTN_Maximize.Dock = DockStyle.Right;
            BTN_Maximize.Enabled = false;
            BTN_Maximize.FlatAppearance.BorderSize = 0;
            BTN_Maximize.FlatStyle = FlatStyle.Flat;
            BTN_Maximize.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            BTN_Maximize.Location = new Point(755, 0);
            BTN_Maximize.Name = "BTN_Maximize";
            BTN_Maximize.Size = new Size(45, 29);
            BTN_Maximize.TabIndex = 2;
            BTN_Maximize.TabStop = false;
            BTN_Maximize.Text = "▢";
            BTN_Maximize.UseVisualStyleBackColor = false;
            // 
            // BTN_Close
            // 
            BTN_Close.BackColor = Color.Transparent;
            BTN_Close.Dock = DockStyle.Right;
            BTN_Close.FlatAppearance.BorderSize = 0;
            BTN_Close.FlatStyle = FlatStyle.Flat;
            BTN_Close.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            BTN_Close.Location = new Point(800, 0);
            BTN_Close.Name = "BTN_Close";
            BTN_Close.Size = new Size(45, 29);
            BTN_Close.TabIndex = 3;
            BTN_Close.TabStop = false;
            BTN_Close.Text = "⨉";
            BTN_Close.UseVisualStyleBackColor = false;
            BTN_Close.Click += CloseForm;
            BTN_Close.MouseEnter += FocusCloseButton;
            BTN_Close.MouseLeave += UnfocusCloseButton;
            // 
            // ApplicationTitle
            // 
            ApplicationTitle.AutoSize = true;
            ApplicationTitle.Location = new Point(29, 7);
            ApplicationTitle.Name = "ApplicationTitle";
            ApplicationTitle.Size = new Size(109, 15);
            ApplicationTitle.TabIndex = 0;
            ApplicationTitle.Text = "Keyboard HeatMap";
            ApplicationTitle.MouseMove += MoveForm;
            // 
            // ApplicationLogo
            // 
            ApplicationLogo.BackgroundImage = Properties.Resources.keyboard_icon_help_page;
            ApplicationLogo.BackgroundImageLayout = ImageLayout.Stretch;
            ApplicationLogo.Location = new Point(6, 3);
            ApplicationLogo.Name = "ApplicationLogo";
            ApplicationLogo.Size = new Size(20, 20);
            ApplicationLogo.TabIndex = 0;
            ApplicationLogo.TabStop = false;
            ApplicationLogo.MouseMove += MoveForm;
            // 
            // Form_Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(845, 355);
            ControlBox = false;
            Controls.Add(keyboard_Layout);
            Controls.Add(help_Page);
            Controls.Add(MenuBar);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form_Main";
            Opacity = 0.9D;
            RightToLeft = RightToLeft.No;
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Keyboard HeatMap";
            FormClosing += Form_Main_FormClosing;
            Load += Form_Main_Load;
            KeyDown += Form_Main_KeyDown;
            Resize += RestoreForm;
            MenuBar.ResumeLayout(false);
            MenuBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ApplicationLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private Button BTN_AlwaysOnTop;
        static private Panel MenuBar;
        static private Keyboard_Layout keyboard_Layout;
    }
}