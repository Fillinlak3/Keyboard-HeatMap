using IWshRuntimeLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Keyboard_HeatMap
{
    public partial class Remastered_Help_Page : UserControl
    {
        private readonly string Desktop_Folder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        private readonly static string Startup_Folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft\Windows\Start Menu\Programs\Startup";
        private readonly string ApplicationExecutablePath = Application.ExecutablePath;
        private string ApplicationShortcut = Startup_Folder + @"\Keyboard HeatMap.lnk";
        private bool ShortcutExists = false;
        private bool DarkMode = false;

        public Remastered_Help_Page()
        {
            InitializeComponent();

            // Checkbox checked if the ShortcutExists in startup folder.
            CHECKBOX_open_on_startup.Checked = ShortcutExists = System.IO.File.Exists(ApplicationShortcut);
        }

        //private void GoBack(object sender, EventArgs e)
        //{
        //    PANEL_program_cfg.Visible = this.Visible = false;
        //    this.SendToBack();
        //}

        private void OpenInstagramPage(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://www.instagram.com/iambucuriee") { UseShellExecute = true });
        }

        private void CHECKBOX_open_on_startup_CheckedChanged(object sender, EventArgs e)
        {
#if RELEASE
                // Check if user had interaction.
                if(CHECKBOX_open_on_startup.Checked == true)
                {
                    if(ShortcutExists == false)
                        // Create shortcut.
                        CreateShortcut("Keyboard HeatMap", Startup_Folder, ApplicationExecutablePath);
                }
                else if(ShortcutExists == true)
                {
                    // Delete shortcut.
                    System.IO.File.Delete(ApplicationShortcut);
                }
                // Finally, update the ShortcutExists.
                ShortcutExists = System.IO.File.Exists(ApplicationShortcut);
#endif
        }

        /// <summary>
        /// Create a shortcut of a file into a path.
        /// </summary>
        /// <param name="shortcutName">Set the name for the shortcut.</param>
        /// <param name="shortcutPath">Wehre do you want to save it.</param>
        /// <param name="targetFileLocation">Program's path you want to create a shortcut of.</param>
        public static void CreateShortcut(string shortcutName, string shortcutPath, string targetFileLocation)
        {
            string shortcutLocation = System.IO.Path.Combine(shortcutPath, shortcutName + ".lnk");
            WshShell shell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutLocation);

            shortcut.Description = "Keyboard HeatMap shortcut.";
            shortcut.TargetPath = targetFileLocation;
            shortcut.Save();
        }

        private void BTN_open_saves_folder_Click(object sender, EventArgs e)
        {
            try
            {
                if (System.IO.Directory.Exists(Keyboard_Layout.SavedRecordsPath))
                    Process.Start("explorer.exe", Keyboard_Layout.SavedRecordsPath);
                else throw new Exception(@"Saved Records path doesn't exists.");
            }
            catch { }
        }

        private void ChangeTheme(object sender, EventArgs e)
        {
            DarkMode = !DarkMode;
            Form_Main.SwitchToDarkMode(DarkMode);
        }
    }
}
