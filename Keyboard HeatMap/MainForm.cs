using Keyboard_HeatMap.Properties;
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
        public Form_Main()
        {
            InitializeComponent();

            this.Opacity = 0;
        }

        // The URL of the Pastebin Server.
        private readonly string URL = "https://pastebin.com/raw/kcDCqpgn";
        // Program's version.
        private readonly string? Program_Version = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductVersion;
        // Static program's handle for switching to light/dark mode.
        private bool ApplicationStarted = false;

        private bool IsAnotherInstanceRunning(bool kill_it = false)
        {
            Process currentProcess = Process.GetCurrentProcess();
            Process[] runningProcesses = Process.GetProcessesByName(currentProcess.ProcessName);

            // Check if there is another running process with the same process name
            foreach (Process process in runningProcesses)
            {
                // Ignore the current process
                if (process.Id != currentProcess.Id)
                {
                    if (kill_it)
                        process.Kill();

                    return true;
                }
            }

            return false;
        }
        private async void CheckForNewVersionUpdate()
        {
            #region Check for Updates
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

                    #region Data Parser & Checker
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
                                dialogResult = MessageBox.Show($"The current update encountered a manufacturing problem. Please download the previous package version. (prev: {data_parsed["Version"]}). Reason: {(data_parsed.ContainsKey("Downgrade-Reason") ? data_parsed["Downgrade-Reason"] : "undefined")}.", "Immediate Downgrade Needed!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            // It's an upgrade.
                            else
                                dialogResult = MessageBox.Show($"New version of Keyboard HeatMap found! (latest: {data_parsed["Version"]} | current: {Program_Version}) Would you like to download the new package?", "New Version Found!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

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
                    #endregion
                }
            }
            catch (System.Net.WebException)
            {
                MessageBox.Show("No internet connection. Couldn't retrive server information.", "Server Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"The server encountered an error: {ex.Message}", "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                data_parsed = null;
            }
            #endregion
        }
        private void TryOpenKeymapFile(string[] args)
        {
            #region Open Keymap File
            // arg[0] is the dll file and arg[1] is the `.keymap` file if it was opened.
            string? keymap_file = args.Length > 1 ? (args[1].EndsWith(".keymap") ? args[1] : null) : null;

            // If the user tries to open another type of file.
            if (args.Length == 2 && args[1].EndsWith(".keymap") == false)
            {
                MessageBox.Show("Cannot open this type of files. `keymap` files only.", "Invalid File Type!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Environment.Exit(1);
            }
            /*
                If the user tries to open by double-click more than 1 file at the same time.
                If there are more than 2 arguments.
             */
            else if (args.Length > 2)
            {
                MessageBox.Show("Cannot open more than 1 file at once.", "Operation Denied!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Environment.Exit(1);
            }

            // If there is a `.keymap` file found, load in into the program.
            OpenFile(keymap_file);
            #endregion
        }
        private bool OpenFile(string? filepath)
        {
            if (!String.IsNullOrEmpty(filepath))
            {
                keyboard_Layout.Reload();
                if (keyboard_Layout.ReadLogFile(filepath))
                {
                #pragma warning disable 8625
                    Frame_Update_Tick(null, null);
                #pragma warning restore 8625

                    return true;
                }
            }
            return false;
        }

        #region Form Methods
        // Before starting (on load) checkings.
        private async void Form_Main_Load(object sender, EventArgs e)
        {
            #if RELEASE
            /*
                Having the command line args we can get the file(s) that is(are) being opened by double-clicking and get
                their path. Also, we can check if the program is launched without any special parameters that we need to
                take care of.

                Idea of implementation:
                -> If the program is launched without args => CheckForNewVersionUpdate
                -> If the program is launched with args => {
                                                                - If there are 2 arguments => If the 2nd argument is a `.keymap` file open it,
                                                                                            otherwise throw an error of `incorrect file type`.
                                                                - If there are more than 2 arguments => throw an error of `cannot open more than 1 file`.
                                                           }

                Problems:   - What if there are more than 1 instance running?
                            - What if user also tries to open a `.keymap` file?
                Idea:
                * NEED TO BE ADDED A NEW USER CONFIG THAT CHECKS FOR KEYPRESSES <RECORDING STATE> OF THE PROGRAM (ON / OFF) *

                From the beginning, check if is another instance of the program running.
                After that, if another program is launched without args => throw an error of `another instance of the program running`.
                Else if another program is launched with args => {
                                                                    If <RECORDING STATE> ON => throw an error of `cannot open file when the program is recording keypresses`
                                                                    Keep the fist instance running (the one that is recording).
                                                                    Else => Kill the first instance and try to open keymap file.
                                                                 }
             */
            // Load user settings first of all.
            await Task.Run(() => help_Page.LoadSetup());

            // Get the cmd line args.
            string[] args = Environment.GetCommandLineArgs();
            bool AnotherInstanceRunning = IsAnotherInstanceRunning();

            // Check if the program is launched without args and if so check for new version update.
            if (args.Length == 1)
            {
                // Check if there isn't another instance of the program already running.
                if (AnotherInstanceRunning == false) CheckForNewVersionUpdate();
                // Otherwise, keep the first & kill the second.
                else
                {
                    MessageBox.Show("Another instance of the program is already running.", "Program Already Running", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Environment.Exit(1);
                }
            }
            // If the program is launched with args => check and try to open file.
            else if (args.Length > 1)
            {
                // Check if there isn't another instance of the program already running.
                if (AnotherInstanceRunning == false) TryOpenKeymapFile(args);
                // Otherwise, check if the first has <recording state> OFF and can be killed for the second to be launched and load the `.keymap` file.
                else
                {
                    // If <RECORDING STATE> is OFF, kill the first instance and open the `.keymap` file in the 2nd instance.
                    if (help_Page.RecordingState == false)
                    {
                        IsAnotherInstanceRunning(kill_it: true);
                        TryOpenKeymapFile(args);
                    }
                    // Otherwise, keep the 1st alive and kill the second.
                    else
                    {
                        MessageBox.Show("Cannot open the file while the program is recording keypresses.", "Program is Recording Keypresses", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Environment.Exit(1);
                    }
                }
            }
            #endif

            #region Program Setup Settings
            // Lock program size.
            this.MinimumSize = new Size(this.Size.Width, this.Size.Height);
            this.MaximumSize = new Size(this.Size.Width, this.Size.Height);

            // Update title bar to current settings.
            await Task.Run(() => UpdateTitlebarColor(sender, e));
            ApplicationStarted = true;
            RestoreForm(sender, e);
            #endregion
        }
        // Autosave file on close (ALT+F4 or task kill because button is disabled).
        private void Form_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            // The progress is saved automacally if the program is closed.
            if (detectKeyPress.Enabled == true)
            {
                keyboard_Layout.WriteLogFile();
            }

            // Also update the user's config file <RECORDING STATE> to off.
            help_Page.RecordingState = false;
        }
        // Check for shortcut combinations pressed.
        private void Form_Main_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2) // Start & Stop the Program.
            {
                // Remove focus from any button.
                this.ApplicationTitle.Focus();

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
                    // Mark <recording state> to ON:
                    help_Page.RecordingState = true;
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
                    // Mark <recording state> to ON:
                    help_Page.RecordingState = false;
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
                { /*Remove focus from any button.*/ this.ApplicationTitle.Focus(); help_Page.SendToBack(); }
            }
        }
        #endregion

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
                    o.Opacity += 0.08;
                }
                o.Opacity = 0.9; //make fully visible
                o.WindowState = FormWindowState.Normal;
            }
        }
        // Fade-Out animation on form minimize.
        private async void FadeOut(Form o, int interval = 80)
        {
            //Object is fully visible. Fade it out
            if (o.InvokeRequired)
            {
                Action safeFade = delegate { FadeOut(o, interval); };
                await Task.Run(() => o.Invoke(safeFade));
            }
            else
            {
                while (o.Opacity > 0.0)
                {
                    await Task.Delay(interval);
                    o.Opacity -= 0.08;
                }
                o.Opacity = 0; //make fully invisible
                o.WindowState = FormWindowState.Minimized;
            }
        }

        // Buttons functions.
        private void LockOnTop(object sender, EventArgs e)
        {
            // Remove button focus.
            this.ApplicationTitle.Focus();
            this.TopMost = !this.TopMost;

            if (this.TopMost == true)
                BTN_AlwaysOnTop.Image = Resources.lock_locked;
            else
                BTN_AlwaysOnTop.Image = Resources.lock_unlocked;
        }
        private async void MinimizeForm(object sender, EventArgs e)
        {
            await Task.Run(() => FadeOut(this, 5));
            await Task.Delay(200);
        }
        private async void RestoreForm(object sender, EventArgs e)
        {
            if (ApplicationStarted == false)
                return;

            if (this.WindowState == FormWindowState.Normal)
            {
                // Remove focus from any button.
                this.ApplicationTitle.Focus();

                await Task.Run(() => FadeIn(this, 5));
                await Task.Delay(200);
            }
        }
        private async void CloseForm(object sender, EventArgs e)
        {
            await Task.Run(() => MinimizeForm(sender, e));
            await Task.Delay(200);
            Application.Exit();
        }

        // Animation on AlwaysOnTop button.
        private void FocusAlwaysOnTopButton(object sender, EventArgs e)
        {
            BTN_AlwaysOnTop.Image = (this.TopMost == false) ? Resources.lock_locked : Resources.lock_unlocked;
        }
        private void UnfocusAlwaysOnTopButton(object sender, EventArgs e)
        {
            BTN_AlwaysOnTop.Image = (this.TopMost == true) ? Resources.lock_locked : Resources.lock_unlocked;
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
            string droped_file = files[0];

            if (files.Length > 1)
            {
                MessageBox.Show("Cannot open more than 1 file at once.", "Operation Denied!", MessageBoxButtons.OK);
                return;
            }

            OpenFile(droped_file);
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
            // 0-99 kps.
            if (number_of_presses < 10)
            { keyboard_Layout.keys[key].Controls[0].ForeColor = Color.Black; keyboard_Layout.keys[key].BackColor = Color.LightGreen; return; }
            else if (number_of_presses >= 10 && number_of_presses < 50)
            { keyboard_Layout.keys[key].Controls[0].ForeColor = Color.Black; keyboard_Layout.keys[key].BackColor = Color.LimeGreen; return; }
            else if (number_of_presses >= 50 && number_of_presses < 100)
            { keyboard_Layout.keys[key].Controls[0].ForeColor = Color.Black; keyboard_Layout.keys[key].BackColor = Color.Green; return; }

            // Yellow Gradient. => bag of keypresses.
            // 100 - 999 kps.
            if (number_of_presses >= 100 && number_of_presses < 250)
            { keyboard_Layout.keys[key].Controls[0].ForeColor = Color.Black; keyboard_Layout.keys[key].BackColor = Color.FromArgb(255, 255, 0); return; }
            else if (number_of_presses >= 250 && number_of_presses < 650)
            { keyboard_Layout.keys[key].Controls[0].ForeColor = Color.Black; keyboard_Layout.keys[key].BackColor = Color.FromArgb(255, 146, 0); return; }
            else if (number_of_presses >= 650 && number_of_presses < 1000)
            { keyboard_Layout.keys[key].Controls[0].ForeColor = Color.Black; keyboard_Layout.keys[key].BackColor = Color.IndianRed; return; }

            // Red Gradient. => lot of keypresses.
            // 1000 - 6500 kps.
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
        public static void SwitchToDarkMode(bool mode)
        {
            if (mode == true)
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
        private async void UpdateTitlebarColor(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Action safeUpdate = delegate { UpdateTitlebarColor(sender, e); };
                await Task.Run(() => this.Invoke(safeUpdate));
            }
            else
            {
                this.BackColor = BTN_Minimize.BackColor = BTN_AlwaysOnTop.BackColor = MenuBar.BackColor;

                this.Visible = false;
                this.Visible = true;
            }
        }
        #endregion

        #region DLL Imports
        [DllImport("User32.dll", EntryPoint = "GetAsyncKeyState")]
        private extern static short GetAsyncKeyState(int vKey);
        [DllImport("User32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        #endregion
    }
}