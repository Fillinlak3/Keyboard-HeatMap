using IWshRuntimeLibrary;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Keyboard_HeatMap
{
    public partial class Remastered_Help_Page : UserControl
    {
        // Get the desktop folder.
        private readonly static string Desktop_Folder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        private readonly string ApplicationDesktopShortcut = Desktop_Folder + @"\Keyboard HeatMap.lnk";
        private bool DesktopShortcutExists = false;
        //Get window's startup folder.
        private readonly static string Startup_Folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Microsoft\Windows\Start Menu\Programs\Startup";
        // Get program's exe path.
        private readonly string ApplicationExecutablePath = Application.ExecutablePath;
        // Get program's shortcut path + name_of_shortcut.
        private readonly string ApplicationStartupShortcut = Startup_Folder + @"\Keyboard HeatMap.lnk";
        private bool StartupShortcutExists = false;
        // Get the appdata folder.
        private readonly static string Appdata_Folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Keyboard HeatMap";
        // Get program's user_config path.
        private readonly string UserConfigPath = Appdata_Folder + @"\user_config.conf";
        
        private readonly string? Program_Version = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductVersion;

        Dictionary<string, string> user_settings;
        private bool DarkMode = false;

        public Remastered_Help_Page()
        {
            InitializeComponent();

            // Create dictionary instance.
            user_settings = new Dictionary<string, string>();
        }

        // Load theme and settings.
        public async void LoadSetup()
        {
            if (this.InvokeRequired)
            {
                Action safeChange = delegate { LoadSetup(); };
                await Task.Run(() => this.Invoke(safeChange));
            }
            else
            {
                _CheckUserConfig();

                // Checkbox checked if the ShortcutExists in startup folder.
                CHECKBOX_open_on_startup.Checked = StartupShortcutExists = System.IO.File.Exists(ApplicationStartupShortcut);
                CHECKBOX_desktop_shortcut.Checked = DesktopShortcutExists = System.IO.File.Exists(ApplicationDesktopShortcut);
                CHECKBOX_dark_theme.Checked = bool.Parse(user_settings["Dark-Mode"]);
            }
        }

        #region User Config File
        private void _UserConfig_WriteSettings()
        {
            if (user_settings.Count != 0)
                user_settings.Clear();

            user_settings.Add("Application-Exe-Path", ApplicationExecutablePath);
            #pragma warning disable CS8604
            user_settings.Add("Version", Program_Version);
            #pragma warning restore
            user_settings.Add("Dark-Mode", DarkMode.ToString());

            string data = $"# User Settings Config File #\n";
            foreach (var setting in user_settings)
                data += $"\"{setting.Key}\": \"{setting.Value}\"\n";

            System.IO.File.WriteAllText(UserConfigPath, data);
        }

        private void _UserConfig_ReadSettings()
        {
            List<string>? data_scraped = new List<string>(System.IO.File.ReadAllText(UserConfigPath).Split('\n', StringSplitOptions.TrimEntries).ToArray());

            // Remove comments and blank lines and add to list the values.
            Regex sWhitespace = new Regex(@"\s+");
            for (int i = 0; i < data_scraped.Count; i++)
            {
                // Remove comments and blank lines.
                if (data_scraped[i].StartsWith('#') || String.IsNullOrWhiteSpace(data_scraped[i]))
                    data_scraped.Remove(data_scraped[i--]);
            }

            if (user_settings.Count != 0)
                user_settings.Clear();

            // Parse values into the dictionary.
            Regex regex = new Regex("\"(.*?)\"");
            foreach (string data in data_scraped)
            {
                var matches = regex.Matches(data);
                if (matches.Count == 2)
                {
                    string key = matches[0].Groups[1].ToString();
                    string value = matches[1].Groups[1].ToString();
                    user_settings.Add(key, value);
                }
            }

            data_scraped = null;

            DarkMode = bool.Parse(user_settings["Dark-Mode"]);
        }

        private void _CheckUserConfig()
        {
            if (Directory.Exists(Appdata_Folder) == false)
            {
                Directory.CreateDirectory(Appdata_Folder);
                _UserConfig_WriteSettings();
            }
            _UserConfig_ReadSettings();
        }
        #endregion

        private void GoBack(object sender, EventArgs e)
        {
            // Remove focus from any button.
            this.LABEL_title.Focus();

            this.Visible = false;
            this.SendToBack();
        }

        private void OpenInstagramPage(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Remove focus from any button.
            this.LABEL_title.Focus();

            Process.Start(new ProcessStartInfo("https://www.instagram.com/iambucuriee") { UseShellExecute = true });
        }

        #region Shortcuts
        // Startup folder shortcut.
        private void CHECKBOX_open_on_startup_CheckedChanged(object sender, EventArgs e)
        {
            // Remove focus from any button.
            this.LABEL_title.Focus();

            #if RELEASE
                // Check if user had interaction.
                if (CHECKBOX_open_on_startup.Checked == true)
                {
                    if (StartupShortcutExists == false)
                        // Create shortcut.
                        CreateShortcut("Keyboard HeatMap", Startup_Folder, ApplicationExecutablePath);
                }
                else if (StartupShortcutExists == true)
                {
                    // Delete shortcut.
                    System.IO.File.Delete(ApplicationStartupShortcut);
                }
                // Finally, update the ShortcutExists.
                StartupShortcutExists = System.IO.File.Exists(ApplicationStartupShortcut);
            #endif
        }
        // Desktop folder shortcut.
        private void CHECKBOX_desktop_shortcut_CheckedChanged(object sender, EventArgs e)
        {
            // Remove focus from any button.
            this.LABEL_title.Focus();

            #if RELEASE
                // Check if user had interaction.
                if (CHECKBOX_desktop_shortcut.Checked == true)
                {
                    if (DesktopShortcutExists == false)
                        // Create shortcut.
                        CreateShortcut("Keyboard HeatMap", Desktop_Folder, ApplicationExecutablePath);
                }
                else if (DesktopShortcutExists == true)
                {
                    // Delete shortcut.
                    System.IO.File.Delete(ApplicationDesktopShortcut);
                }
                // Finally, update the ShortcutExists.
                DesktopShortcutExists = System.IO.File.Exists(ApplicationDesktopShortcut);
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
        #endregion

        private void BTN_open_saves_folder_Click(object sender, EventArgs e)
        {
            // Remove focus from any button.
            this.LABEL_title.Focus();

            try
            {
                if (System.IO.Directory.Exists(Keyboard_Layout.SavedRecordsPath))
                    Process.Start("explorer.exe", Keyboard_Layout.SavedRecordsPath);
                else throw new Exception(@"Saved Records path doesn't exists.");
            }
            catch { }
        }

        public void ChangeTheme(object sender, EventArgs e)
        {
            // Remove focus from any button.
            this.LABEL_title.Focus();

            DarkMode = CHECKBOX_dark_theme.Checked;

            if (DarkMode)
            {
                this.BackgroundImage = Properties.Resources.remastered_help_page_dark;
                this.BackColor = Color.FromArgb(45, 45, 45);
                BTN_GoBack.BackColor = Color.FromArgb(45, 45, 45);
                BTN_GoBack.Image = Properties.Resources.go_back_white;
                CHECKBOX_open_on_startup.BackColor = Color.FromArgb(45, 45, 45);
                LABEL_launch_on_startup.ForeColor = Color.White;
                LABEL_dark_theme.ForeColor = Color.White;
                BTN_open_saves_folder.ForeColor = Color.White;
                BTN_open_saves_folder.BackColor = Color.FromArgb(45, 45, 45);
                LABEL_contact.ForeColor = Color.White;
                LINKLABEL_ig_page.LinkColor = Color.DodgerBlue;
                LABEL_title.ForeColor = Color.White;
                LABEL_creator.ForeColor = Color.White;
                CHECKBOX_desktop_shortcut.BackColor = Color.FromArgb(45, 45, 45);
                LABEL_desktop_shortcut.ForeColor = Color.White;
            }
            else
            {
                this.BackgroundImage = Properties.Resources.remastered_help_page_light;
                this.BackColor = Color.FromArgb(167, 173, 186);
                BTN_GoBack.BackColor = Color.FromArgb(167, 173, 186);
                BTN_GoBack.Image = Properties.Resources.go_back_black;
                CHECKBOX_open_on_startup.BackColor = Color.FromArgb(167, 173, 186);
                LABEL_launch_on_startup.ForeColor = Color.Black;
                LABEL_dark_theme.ForeColor = Color.Black;
                BTN_open_saves_folder.ForeColor = Color.Black;
                BTN_open_saves_folder.BackColor = Color.FromArgb(167, 173, 186);
                LABEL_contact.ForeColor = Color.Black;
                LINKLABEL_ig_page.LinkColor = Color.Blue;
                LABEL_title.ForeColor = Color.Black;
                LABEL_creator.ForeColor = Color.Black;
                CHECKBOX_desktop_shortcut.BackColor = Color.FromArgb(45, 45, 45);
                LABEL_desktop_shortcut.ForeColor = Color.Black;
            }

            Form_Main.SwitchToDarkMode(DarkMode);
            #if RELEASE
                _UserConfig_WriteSettings();
            #endif
        }
    }
}
