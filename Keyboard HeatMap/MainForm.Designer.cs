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
            this.keyboard_Layout = new Keyboard_HeatMap.Keyboard_Layout();
            this.help_Page = new Keyboard_HeatMap.Help_Page();
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
            this.keyboard_Layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keyboard_Layout.Location = new System.Drawing.Point(0, 0);
            this.keyboard_Layout.Name = "keyboard_Layout";
            this.keyboard_Layout.Size = new System.Drawing.Size(844, 321);
            this.keyboard_Layout.TabIndex = 0;
            // 
            // help_Page
            // 
            this.help_Page.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(173)))), ((int)(((byte)(186)))));
            this.help_Page.Dock = System.Windows.Forms.DockStyle.Fill;
            this.help_Page.Location = new System.Drawing.Point(0, 0);
            this.help_Page.Name = "help_Page";
            this.help_Page.Size = new System.Drawing.Size(844, 321);
            this.help_Page.TabIndex = 1;
            this.help_Page.Visible = false;
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(844, 321);
            this.Controls.Add(this.keyboard_Layout);
            this.Controls.Add(this.help_Page);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Form_Main";
            this.Opacity = 0.9D;
            this.Text = "Keyboard HeatMap";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Main_FormClosing);
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_Main_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer detectKeyPress;
        private System.Windows.Forms.Timer Frame_Update;
        private Keyboard_Layout keyboard_Layout;
        private Help_Page help_Page;
    }
}