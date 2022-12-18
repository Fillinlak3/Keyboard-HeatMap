using System.Runtime.InteropServices;

namespace Keyboard_HeatMap
{
    public partial class Form_Main : Form
    {
        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(int vKey);

        public Form_Main()
        {
            InitializeComponent();
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {
            // Lock program size.
            this.MinimumSize = new Size(this.Size.Width, this.Size.Height);
            this.MaximumSize = new Size(this.Size.Width, this.Size.Height);
        }

        private void Form_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            // The progress is saved automacally if the program is closed.
            if (detectKeyPress.Enabled == true)
                keyboard_Layout.WriteLogFile();

            Application.Exit();
        }

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
                    this.ControlBox = false;
                    keyboard_Layout.program_Status.Text = "Enabled";
                    keyboard_Layout.program_Status.BackColor = Color.Green;

                    // Restart the program and reset all past progress.
                    keyboard_Layout.Reload();
                }
                else
                {
                    // Enable the X button when program is stopped.
                    this.ControlBox = true;
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
                help_Page.Visible = !help_Page.Visible;

                if (help_Page.Visible)
                    help_Page.BringToFront();
                else
                    help_Page.SendToBack();
            }
        }

        void CheckNumberOfPresses(long number_of_presses, int key)
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
            { keyboard_Layout.keys[key].BackColor = Color.LightGreen; return; }
            else if (number_of_presses >= 10 && number_of_presses < 50)
            { keyboard_Layout.keys[key].BackColor = Color.LimeGreen; return; }
            else if (number_of_presses >= 50 && number_of_presses < 100)
            { keyboard_Layout.keys[key].BackColor = Color.Green; return; }

            // Yellow Gradient. => bag of keypresses.
            if (number_of_presses >= 100 && number_of_presses < 250)
            { keyboard_Layout.keys[key].BackColor = Color.FromArgb(255, 255, 0); return; }
            else if (number_of_presses >= 250 && number_of_presses < 650)
            { keyboard_Layout.keys[key].BackColor = Color.FromArgb(255, 146, 0); return; }
            else if (number_of_presses >= 650 && number_of_presses < 1000)
            { keyboard_Layout.keys[key].BackColor = Color.IndianRed; return; }

            // Red Gradient. => lot of keypresses.
            if (number_of_presses >= 1000 && number_of_presses < 2500)
            { keyboard_Layout.keys[key].BackColor = Color.FromArgb(255, 85, 0); return; }
            else if (number_of_presses >= 2500 && number_of_presses < 6500)
            { keyboard_Layout.keys[key].BackColor = Color.Red; return; }
            else if (number_of_presses >= 6500 && number_of_presses < 10000)
            { keyboard_Layout.keys[key].BackColor = Color.FromArgb(136, 8, 8); return; }
            else if (number_of_presses >= 10000) return;
        }

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
    }
}