using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace Keyboard_HeatMap
{
    // Find: this\.(keyboard_Layout|MenuBar|BTN_Minimize|BTN_Close)        Replace: $1
    public partial class Form_Main : Form
    {
        [DllImport("User32.dll", EntryPoint = "GetAsyncKeyState")]
        private extern static short GetAsyncKeyState(int vKey);
        [DllImport("User32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        public Form_Main()
        {
            InitializeComponent();
        }

        // The URL of the Pastebin Server.
        private readonly string URL = "https://pastebin.com/raw/kcDCqpgn";
        // Program's version.
        private readonly string? Program_Version = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductVersion;
        // Static program's handle for switching to light/dark mode.
        private static IntPtr m_Handle;
        private bool ApplicationStarted = false;

        // Before starting checkings.
        private async void Form_Main_Load(object sender, EventArgs e)
        {
            // Check for new version.
            #if RELEASE
                Dictionary<string, string>? data_parsed = new Dictionary<string, string>();
                try
                {
                    #pragma warning disable SYSLIB0014
                    using (WebClient web = new WebClient())
                    #pragma warning restore SYSLIB0014
                    {
                        #region WEB Scraper
                        List<string>? data_scraped = new List<string>(web.DownloadString(URL).Split('\n', StringSplitOptions.TrimEntries).ToArray());

                        // Remove comment lines --> lines that starts with '#' & blank lines.
                        for (int i = 0; i < data_scraped.Count; i++)
                        {
                            // Remove comments and blank lines.
                            if (data_scraped[i].StartsWith('#') || String.IsNullOrWhiteSpace(data_scraped[i]))
                                data_scraped.Remove(data_scraped[i--]);
                        }

                        // Parse values into the dictionary.
                        Regex regex = new Regex("\"(.*?)\"");
                        foreach (string data in data_scraped)
                        {
                            var matches = regex.Matches(data);
                            if (matches.Count == 2)
                            {
                                string key = matches[0].Groups[1].ToString();
                                string value = matches[1].Groups[1].ToString();
                                data_parsed.Add(key, value);
                            }
                        }
                        data_scraped = null;
                    #endregion

                        // Check if data was gathered from the server.
                        if (data_parsed == null || data_parsed.Count == 0)
                                throw new Exception("Couldn't retrive data from server.");

                            // Check if versions have syntax: x.x.x where x is a digit.
                            regex = new Regex("^[1-9].[0-9].[0-9][0-9]?$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                            if (regex.IsMatch(data_parsed["Version"]) == false)
                                throw new Exception("Corrupted or invalid data retrieved.");

                        // After all check if there is an downgrade / upgrade.
                        await Task.Run(() =>
                        {
                            if (data_parsed["Version"] != Program_Version)
                            {
                                DialogResult dialogResult;

                                // It's a downgrade.
                                if (data_parsed["Version"].CompareTo(Program_Version) < 0)
                                    dialogResult = MessageBox.Show($"The current update encountered a manufacturing problem. Please download the previous package version. (prev: {data_parsed["Version"]}). Reason: {(data_parsed.ContainsKey("Downgrade-Reason") ? data_parsed["Downgrade-Reason"] : "undefined")}.", "Immediate Downgrade Needed!", MessageBoxButtons.YesNo);
                                // It's an upgrade.
                                else
                                    dialogResult = MessageBox.Show($"New version of Keyboard HeatMap found! (latest: {data_parsed["Version"]} | current: {Program_Version}) Would you like to download the new package?", "New Version Found!", MessageBoxButtons.YesNo);

                                // If user wants to download the new package.
                                if (dialogResult == DialogResult.Yes)
                                {
                                    // Open google drive with the newest update for the program for user to download.
                                    Process.Start(new ProcessStartInfo(data_parsed["Download-Link"]) { UseShellExecute = true });
                                    // Kill the process.
                                    Application.Exit();
                                }
                            }
                        });
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Server Error", MessageBoxButtons.OK);
                }
                finally
                {
                    data_parsed = null;
                }
            #endif

            // Lock program size.
            this.MinimumSize = new Size(this.Size.Width, this.Size.Height);
            this.MaximumSize = new Size(this.Size.Width, this.Size.Height);
            m_Handle = this.Handle;

            // Load user settings.
            await Task.Run(() => help_Page.LoadSetup());
            ApplicationStarted = true;
        }
        // Autosave file on close (ALT+F4 or task kill because button is disabled).
        private void Form_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            // The progress is saved automacally if the program is closed.
            if (detectKeyPress.Enabled == true)
                keyboard_Layout.WriteLogFile();

            Application.Exit();
        }
        // Check for shortcut combinations pressed.
        private void Form_Main_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2) // Start/Stop Program.
            {
                // If user on help page hide and show kb_layout.
                if (help_Page.Visible)
                {
                    help_Page.SendToBack();
                    help_Page.Visible = false;
                }

                if (keyboard_Layout.program_Status.Text == "Disabled")
                {
                    // Disable the X button to prevent closing while program running.
                    BTN_Close.Enabled = false;
                    // Disable user action to drop a saved record.
                    keyboard_Layout.AllowDrop = false;
                    keyboard_Layout.program_Status.Text = "Enabled";
                    keyboard_Layout.program_Status.BackColor = Color.Green;

                    // Restart the program and reset all past progress.
                    keyboard_Layout.Reload();
                }
                else
                {
                    // Enable the X button when program is stopped.
                    BTN_Close.Enabled = true;
                    // Enable user action to drop a saved record.
                    keyboard_Layout.AllowDrop = true;
                    keyboard_Layout.program_Status.Text = "Disabled";
                    keyboard_Layout.program_Status.BackColor = Color.Red;

                    // Save all the progress into a log file.
                    keyboard_Layout.WriteLogFile();
                }

                Thread.Sleep(50);
                detectKeyPress.Enabled = Frame_Update.Enabled = !detectKeyPress.Enabled;
            }
            else if (e.KeyCode == Keys.F1) // Help Page.
            {
                Thread.Sleep(50);
                help_Page.Visible = !help_Page.Visible;

                if (help_Page.Visible)
                    help_Page.BringToFront();
                else
                    help_Page.SendToBack();
            }
        }     

        #region MenuBar Buttons
        // Fade-In animation on form restore.
        private async void FadeIn(Form o, int interval = 80)
        {
            //Object is not fully invisible. Fade it in
            if (o.InvokeRequired)
            {
                Action safeFade = delegate { FadeIn(o, interval); };
                await Task.Run(() => o.Invoke(safeFade));
            }
            else
            {
                while (o.Opacity < 1.0)
                {
                    await Task.Delay(interval);
                    o.Opacity += 0.05;
                }
                o.Opacity = 0.9; //make fully visible
                o.WindowState = FormWindowState.Normal;
            }
        }
        // Fade-Out animation on form minimize.
        private async void FadeOut(Form o, int interval = 80)
        {
            //Object is fully visible. Fade it out
            if(o.InvokeRequired)
            {
                Action safeFade = delegate { FadeOut(o, interval); };
                await Task.Run(() => o.Invoke(safeFade));
            }
            else { 
                while (o.Opacity > 0.0)
                {
                    await Task.Delay(interval);
                    o.Opacity -= 0.05;
                }
                o.Opacity = 0; //make fully invisible
                o.WindowState = FormWindowState.Minimized;
            }
        }

        private async void RestoreForm(object sender, EventArgs e)
        {
            if (ApplicationStarted == false)
                return;

            if (this.WindowState == FormWindowState.Normal)
            {
                await Task.Run(() => FadeIn(this, 25));
                await Task.Delay(1000);
                Debug.WriteLine("FadeIN");
            }
        }
        private async void MinimizeForm(object sender, EventArgs e)
        {
            await Task.Run(() => FadeOut(this, 25));
            await Task.Delay(1000);
        }
        // Turn close button red.
        private void FocusCloseButton(object sender, EventArgs e)
        {
            BTN_Close.BackColor = Color.Red;
        }
        private void UnfocusCloseButton(object sender, EventArgs e)
        {
            BTN_Close.BackColor = Color.Transparent;
        }
        private void CloseForm(object sender, EventArgs e)
        {
            Application.Exit();
        }
        // Drag & move form.
        private void MoveForm(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0x112, 0xf012, 0);
            }
        }
        #endregion 

        #region Read Log File
        private void keyboard_Layout_DragEnter(object sender, DragEventArgs e)
        {
            #pragma warning disable CS8602
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
            #pragma warning restore CS8602
        }
        private void keyboard_Layout_DragDrop(object sender, DragEventArgs e)
        {
            #pragma warning disable CS8602
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            #pragma warning restore CS8602

            if (files.Length > 1)
            {
                MessageBox.Show("Cannot open more than 1 file at once.", "Operation Denied!", MessageBoxButtons.OK);
                return;
            }

            keyboard_Layout.Reload();
            if (keyboard_Layout.ReadLogFile(files[0]))
            {
                Frame_Update_Tick(sender, e);
            }
        }
        #endregion

        #region Record Keypresses Algorithm
        // Update the keys panel colors.
        private void CheckNumberOfPresses(long number_of_presses, int key)
        {
            // If the key is not found in the dictionary, exit to avoid crashes.
            if (!keyboard_Layout.keys.ContainsKey(key))
                return;

            /*
                Colors and frequency of changing colors are just a concept
                'till I have a statistic from different people.
             */

            // Green Gradient. => some keypresses.
            if (number_of_presses < 10)
            { keyboard_Layout.keys[key].Controls[0].ForeColor = Color.Black; keyboard_Layout.keys[key].BackColor = Color.LightGreen; return; }
            else if (number_of_presses >= 10 && number_of_presses < 50)
            { keyboard_Layout.keys[key].Controls[0].ForeColor = Color.Black; keyboard_Layout.keys[key].BackColor = Color.LimeGreen; return; }
            else if (number_of_presses >= 50 && number_of_presses < 100)
            { keyboard_Layout.keys[key].Controls[0].ForeColor = Color.Black; keyboard_Layout.keys[key].BackColor = Color.Green; return; }

            // Yellow Gradient. => bag of keypresses.
            if (number_of_presses >= 100 && number_of_presses < 250)
            { keyboard_Layout.keys[key].Controls[0].ForeColor = Color.Black; keyboard_Layout.keys[key].BackColor = Color.FromArgb(255, 255, 0); return; }
            else if (number_of_presses >= 250 && number_of_presses < 650)
            { keyboard_Layout.keys[key].Controls[0].ForeColor = Color.Black; keyboard_Layout.keys[key].BackColor = Color.FromArgb(255, 146, 0); return; }
            else if (number_of_presses >= 650 && number_of_presses < 1000)
            { keyboard_Layout.keys[key].Controls[0].ForeColor = Color.Black; keyboard_Layout.keys[key].BackColor = Color.IndianRed; return; }

            // Red Gradient. => lot of keypresses.
            if (number_of_presses >= 1000 && number_of_presses < 2500)
            { keyboard_Layout.keys[key].Controls[0].ForeColor = Color.Black; keyboard_Layout.keys[key].BackColor = Color.FromArgb(255, 85, 0); return; }
            else if (number_of_presses >= 2500 && number_of_presses < 6500)
            { keyboard_Layout.keys[key].Controls[0].ForeColor = Color.Black; keyboard_Layout.keys[key].BackColor = Color.Red; return; }
            else if (number_of_presses >= 6500)
            { keyboard_Layout.keys[key].Controls[0].ForeColor = Color.Black; keyboard_Layout.keys[key].BackColor = Color.FromArgb(136, 8, 8); return; }
        }

        // Checks for each key how many times was pressed.
        private void Frame_Update_Tick(object sender, EventArgs e)
        {
            /*
                If key exists in number_of_keyPress dictionary, it will be displayed
                by coloring the coresponding key.
             */
            for (int i = 0; i < 256; i++)
                if (keyboard_Layout.number_of_keyPress.ContainsKey(i))
                    if (keyboard_Layout.number_of_keyPress[i] != 0)
                        CheckNumberOfPresses(keyboard_Layout.number_of_keyPress[i], i);

            // Creating a new var to bypass 'marshal-by-reference' CS1690 warning.
            long _total_keypresses = keyboard_Layout.TOTAL_KEYPRESSES;
            keyboard_Layout.LABEL_total_number_of_keypresses.Text = "Total number of keypresses: " + _total_keypresses.ToString();
        }

        // Used this method to prevent helding down a key.
        private static readonly int DEFAULT = -1, HELD_DOWN = -32767, PRESSED = 1, UNPRESSED = 0;
        private int lastKeyPressed = DEFAULT, actionKeyPressed = UNPRESSED;
        private void detectKeyPress_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 256; i++)
            {
                if (GetAsyncKeyState(i) == HELD_DOWN)
                {
                    // Remember the last key pressed.
                    lastKeyPressed = i;

                    /*
                        If action key pressed it will ignore this to prevent infinite total keypresses.
                        Otherwise if it's a normal key it'll run once.
                     */
                    if (actionKeyPressed == UNPRESSED)
                    {
                        keyboard_Layout.TOTAL_KEYPRESSES++;
                        if (keyboard_Layout.number_of_keyPress.ContainsKey(i))
                            keyboard_Layout.number_of_keyPress[i]++;
                    }

                    /*
                        If action key pressed such as: ctrls, shifts, alts.
                        Then I need to check if it is pressed and stop the key pressing event
                        to prevent bugs such as infite total_keypresses.
                     */
                    if (actionKeyPressed == UNPRESSED && (i >= 160 && i <= 165))
                    {
                        // It will be x2 everytime and I always need to decrement it.
                        keyboard_Layout.TOTAL_KEYPRESSES--;
                        actionKeyPressed = PRESSED; // mark action key as pressed.
                    }
                }
                else if (lastKeyPressed != DEFAULT && GetAsyncKeyState(lastKeyPressed) == UNPRESSED)
                /*
                    Runs only when a key is held down.
                    If current key  is the same as last key, it means the user
                    is still pressing the button and the program will ignore
                    continuous keypress. If the user releases the button, it will
                    reset lastKeyPressed and actionKeyPressed.
                 */
                { lastKeyPressed = DEFAULT; actionKeyPressed = UNPRESSED; }
            }
        }
        #endregion

        #region Switch to Dark-Mode
        private class DarkTitleBarClass
        {
            [DllImport("dwmapi.dll")]
            private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr,
            ref int attrValue, int attrSize);

            private const int DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1 = 19;
            private const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;

            internal static bool UseImmersiveDarkMode(IntPtr handle, bool enabled)
            {
                if (IsWindows10OrGreater(17763))
                {
                    var attribute = DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1;
                    if (IsWindows10OrGreater(18985))
                    {
                        attribute = DWMWA_USE_IMMERSIVE_DARK_MODE;
                    }

                    int useImmersiveDarkMode = enabled ? 1 : 0;
                    return DwmSetWindowAttribute(handle, attribute, ref useImmersiveDarkMode, sizeof(int)) == 0;
                }

                return false;
            }
            private static bool IsWindows10OrGreater(int build = -1)
            {
                return Environment.OSVersion.Version.Major >= 10 && Environment.OSVersion.Version.Build >= build;
            }
        }
        public static void SwitchToDarkMode(bool mode)
        {
            //DarkTitleBarClass.UseImmersiveDarkMode(m_Handle, mode);
            if(mode == true)
            {
                MenuBar.BackColor = Color.FromArgb(27, 27, 27);
                MenuBar.ForeColor = Color.White;
            }
            else
            {
                MenuBar.BackColor = Color.FromArgb(242, 243, 245);
                MenuBar.ForeColor = Color.Black;
            }

            keyboard_Layout.SwitchToDarkMode(mode);
        }
        private void UpdateTitlebarColor(object sender, EventArgs e)
        {
            if (ApplicationStarted == false)
                return;

            BTN_Minimize.BackColor = MenuBar.BackColor;

            this.Visible = false;
            this.Visible = true;
        }
        #endregion
    }
}