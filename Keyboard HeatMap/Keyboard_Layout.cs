using System.Diagnostics;
using System.IO;

namespace Keyboard_HeatMap
{
    public partial class Keyboard_Layout : UserControl
    {
        public readonly static string SavedRecordsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + $@"\Keyboard HeatMap\Saves\";

        public Dictionary<int, Panel> keys;
        public Dictionary<int, long> number_of_keyPress;
        private Dictionary<int, int> keys_hashcodes;
        public long TOTAL_KEYPRESSES = 0;


        public Keyboard_Layout()
        {
            InitializeComponent();

            keys = new Dictionary<int, Panel>();
            number_of_keyPress = new Dictionary<int, long>();
            keys_hashcodes = new Dictionary<int, int>();

            _assignKeysToDict();
            _assignHashCodes();
            _resetNumberOfKeyPresses();

            if (Directory.Exists(SavedRecordsPath) == false)
                Directory.CreateDirectory(SavedRecordsPath);
        }

        void _assignKeysToDict()
        {
            if (keys.Count != 0)
                keys.Clear();

            keys.Add(192, TILDA_key);
            keys.Add(49, NUMBER_1_key);
            keys.Add(50, NUMBER_2_key);
            keys.Add(51, NUMBER_3_key);
            keys.Add(52, NUMBER_4_key);
            keys.Add(53, NUMBER_5_key);
            keys.Add(54, NUMBER_6_key);
            keys.Add(55, NUMBER_7_key);
            keys.Add(56, NUMBER_8_key);
            keys.Add(57, NUMBER_9_key);
            keys.Add(48, NUMBER_0_key);
            keys.Add(189, MINUS_key);
            keys.Add(187, EQUAL_key);
            keys.Add(8, BKSPC_key);

            keys.Add(9, TAB_key);
            keys.Add(81, Q_key);
            keys.Add(87, W_key);
            keys.Add(69, E_key);
            keys.Add(82, R_key);
            keys.Add(84, T_key);
            keys.Add(89, Y_key);
            keys.Add(85, U_key);
            keys.Add(73, I_key);
            keys.Add(79, O_key);
            keys.Add(80, P_key);
            keys.Add(219, BRACKET_OPEN_key);
            keys.Add(221, BRACKET_CLOSE_key);
            keys.Add(13, ENTER_key);

            keys.Add(20, CAPS_key);
            keys.Add(65, A_key);
            keys.Add(83, S_key);
            keys.Add(68, D_key);
            keys.Add(70, F_key);
            keys.Add(71, G_key);
            keys.Add(72, H_key);
            keys.Add(74, J_key);
            keys.Add(75, K_key);
            keys.Add(76, L_key);
            keys.Add(186, SEMICOLON_key);
            keys.Add(222, QUOTATION_MARK_key);
            keys.Add(220, BACKSLASH_key);

            keys.Add(160, LSHIFT_key);
            keys.Add(161, RSHIFT_key);
            keys.Add(90, Z_key);
            keys.Add(88, X_key);
            keys.Add(67, C_key);
            keys.Add(86, V_key);
            keys.Add(66, B_key);
            keys.Add(78, N_key);
            keys.Add(77, M_key);
            keys.Add(188, COMMA_key);
            keys.Add(190, DOT_key);
            keys.Add(191, SLASH_key);

            keys.Add(162, LCTRL_key);
            keys.Add(163, RCTRL_key);
            keys.Add(164, LALT_key);
            keys.Add(165, RALT_key);
            keys.Add(32, SPACE_key);

            keys.Add(1, LB_key);
            keys.Add(2, RB_key);
        }

        // Number of keypresses.
        void _resetNumberOfKeyPresses()
        {
            if (number_of_keyPress.Count != 0)
                number_of_keyPress.Clear();

            number_of_keyPress.Add(192, 0);
            number_of_keyPress.Add(49, 0);
            number_of_keyPress.Add(50, 0);
            number_of_keyPress.Add(51, 0);
            number_of_keyPress.Add(52, 0);
            number_of_keyPress.Add(53, 0);
            number_of_keyPress.Add(54, 0);
            number_of_keyPress.Add(55, 0);
            number_of_keyPress.Add(56, 0);
            number_of_keyPress.Add(57, 0);
            number_of_keyPress.Add(48, 0);
            number_of_keyPress.Add(189, 0);
            number_of_keyPress.Add(187, 0);
            number_of_keyPress.Add(8, 0);

            number_of_keyPress.Add(9, 0);
            number_of_keyPress.Add(81, 0);
            number_of_keyPress.Add(87, 0);
            number_of_keyPress.Add(69, 0);
            number_of_keyPress.Add(82, 0);
            number_of_keyPress.Add(84, 0);
            number_of_keyPress.Add(89, 0);
            number_of_keyPress.Add(85, 0);
            number_of_keyPress.Add(73, 0);
            number_of_keyPress.Add(79, 0);
            number_of_keyPress.Add(80, 0);
            number_of_keyPress.Add(219, 0);
            number_of_keyPress.Add(221, 0);
            number_of_keyPress.Add(13, 0);

            number_of_keyPress.Add(20, 0);
            number_of_keyPress.Add(65, 0);
            number_of_keyPress.Add(83, 0);
            number_of_keyPress.Add(68, 0);
            number_of_keyPress.Add(70, 0);
            number_of_keyPress.Add(71, 0);
            number_of_keyPress.Add(72, 0);
            number_of_keyPress.Add(74, 0);
            number_of_keyPress.Add(75, 0);
            number_of_keyPress.Add(76, 0);
            number_of_keyPress.Add(186, 0);
            number_of_keyPress.Add(222, 0);
            number_of_keyPress.Add(220, 0);

            number_of_keyPress.Add(160, 0);
            number_of_keyPress.Add(161, 0);
            number_of_keyPress.Add(90, 0);
            number_of_keyPress.Add(88, 0);
            number_of_keyPress.Add(67, 0);
            number_of_keyPress.Add(86, 0);
            number_of_keyPress.Add(66, 0);
            number_of_keyPress.Add(78, 0);
            number_of_keyPress.Add(77, 0);
            number_of_keyPress.Add(188, 0);
            number_of_keyPress.Add(190, 0);
            number_of_keyPress.Add(191, 0);

            number_of_keyPress.Add(162, 0);
            number_of_keyPress.Add(163, 0);
            number_of_keyPress.Add(164, 0);
            number_of_keyPress.Add(165, 0);
            number_of_keyPress.Add(32, 0);

            number_of_keyPress.Add(1, 0);
            number_of_keyPress.Add(2, 0);
            number_of_keyPress.Add(4, 0);
        }

        // To get the on-hover animation to work.s
        void _assignHashCodes()
        {
            if (keys_hashcodes.Count != 0)
                keys_hashcodes.Clear();

            keys_hashcodes.Add(192, SYMBOL_TILDA.GetHashCode());
            keys_hashcodes.Add(49, NUM1.GetHashCode());
            keys_hashcodes.Add(50, NUM2.GetHashCode());
            keys_hashcodes.Add(51, NUM3.GetHashCode());
            keys_hashcodes.Add(52, NUM4.GetHashCode());
            keys_hashcodes.Add(53, NUM5.GetHashCode());
            keys_hashcodes.Add(54, NUM6.GetHashCode());
            keys_hashcodes.Add(55, NUM7.GetHashCode());
            keys_hashcodes.Add(56, NUM8.GetHashCode());
            keys_hashcodes.Add(57, NUM9.GetHashCode());
            keys_hashcodes.Add(48, NUM0.GetHashCode());
            keys_hashcodes.Add(189, SYMBOL_MINUS.GetHashCode());
            keys_hashcodes.Add(187, SYMBOL_EQUAL.GetHashCode());
            keys_hashcodes.Add(8, FUNC_BKSPC.GetHashCode());

            keys_hashcodes.Add(9, FUNC_TAB.GetHashCode());
            keys_hashcodes.Add(81, LETTER_Q.GetHashCode());
            keys_hashcodes.Add(87, LETTER_W.GetHashCode());
            keys_hashcodes.Add(69, LETTER_E.GetHashCode());
            keys_hashcodes.Add(82, LETTER_R.GetHashCode());
            keys_hashcodes.Add(84, LETTER_T.GetHashCode());
            keys_hashcodes.Add(89, LETTER_Y.GetHashCode());
            keys_hashcodes.Add(85, LETTER_U.GetHashCode());
            keys_hashcodes.Add(73, LETTER_I.GetHashCode());
            keys_hashcodes.Add(79, LETTER_O.GetHashCode());
            keys_hashcodes.Add(80, LETTER_P.GetHashCode());
            keys_hashcodes.Add(219, SYMBOL_BRACKET_OPEN.GetHashCode());
            keys_hashcodes.Add(221, SYMBOL_BRACKET_CLOSE.GetHashCode());
            keys_hashcodes.Add(13, FUNC_ENTER.GetHashCode());

            keys_hashcodes.Add(20, FUNC_CAPSLK.GetHashCode());
            keys_hashcodes.Add(65, LETTER_A.GetHashCode());
            keys_hashcodes.Add(83, LETTER_S.GetHashCode());
            keys_hashcodes.Add(68, LETTER_D.GetHashCode());
            keys_hashcodes.Add(70, LETTER_F.GetHashCode());
            keys_hashcodes.Add(71, LETTER_G.GetHashCode());
            keys_hashcodes.Add(72, LETTER_H.GetHashCode());
            keys_hashcodes.Add(74, LETTER_J.GetHashCode());
            keys_hashcodes.Add(75, LETTER_K.GetHashCode());
            keys_hashcodes.Add(76, LETTER_L.GetHashCode());
            keys_hashcodes.Add(186, SYMBOL_SEMICOLON.GetHashCode());
            keys_hashcodes.Add(222, SYMBOL_QUOTATION_MARK.GetHashCode());
            keys_hashcodes.Add(220, SYMBOL_BACKSLASH.GetHashCode());

            keys_hashcodes.Add(160, FUNC_LSHIFT.GetHashCode());
            keys_hashcodes.Add(161, FUNC_RSHIFT.GetHashCode());
            keys_hashcodes.Add(90, LETTER_Z.GetHashCode());
            keys_hashcodes.Add(88, LETTER_X.GetHashCode());
            keys_hashcodes.Add(67, LETTER_C.GetHashCode());
            keys_hashcodes.Add(86, LETTER_V.GetHashCode());
            keys_hashcodes.Add(66, LETTER_B.GetHashCode());
            keys_hashcodes.Add(78, LETTER_N.GetHashCode());
            keys_hashcodes.Add(77, LETTER_M.GetHashCode());
            keys_hashcodes.Add(188, SYMBOL_COMMA.GetHashCode());
            keys_hashcodes.Add(190, SYMBOL_DOT.GetHashCode());
            keys_hashcodes.Add(191, SYMBOL_SLASH.GetHashCode());

            keys_hashcodes.Add(162, FUNC_LCTRL.GetHashCode());
            keys_hashcodes.Add(163, FUNC_RCTRL.GetHashCode());
            keys_hashcodes.Add(164, FUNC_LALT.GetHashCode());
            keys_hashcodes.Add(165, FUNC_RALT.GetHashCode());
            keys_hashcodes.Add(32, FUNC_SPACE.GetHashCode());

            keys_hashcodes.Add(1, MOUSE_LB.GetHashCode());
            keys_hashcodes.Add(2, MOUSE_RB.GetHashCode());
        }

        // Keypresses progress.
        void _resetKeyboardColors()
        {
            for (int i = 0; i < 256; i++)
                if (keys.ContainsKey(i))
                    keys[i].BackColor = Color.White;
        }

        void _writeLogFile()
        {
            string data = "==========\n<KEYBOARD>\n==========\n";

            data += "~: " + number_of_keyPress[192].ToString() + "\n";
            data += "1: " + number_of_keyPress[49].ToString() + "\n";
            data += "2: " + number_of_keyPress[50].ToString() + "\n";
            data += "3: " + number_of_keyPress[51].ToString() + "\n";
            data += "4: " + number_of_keyPress[52].ToString() + "\n";
            data += "5: " + number_of_keyPress[53].ToString() + "\n";
            data += "6: " + number_of_keyPress[54].ToString() + "\n";
            data += "7: " + number_of_keyPress[55].ToString() + "\n";
            data += "8: " + number_of_keyPress[56].ToString() + "\n";
            data += "9: " + number_of_keyPress[57].ToString() + "\n";
            data += "0: " + number_of_keyPress[48].ToString() + "\n";
            data += "-: " + number_of_keyPress[189].ToString() + "\n";
            data += "=: " + number_of_keyPress[187].ToString() + "\n";
            data += "bkpsp: " + number_of_keyPress[8].ToString() + "\n";

            data += "tab: " + number_of_keyPress[9].ToString() + "\n";
            data += "q: " + number_of_keyPress[81].ToString() + "\n";
            data += "w: " + number_of_keyPress[87].ToString() + "\n";
            data += "e: " + number_of_keyPress[69].ToString() + "\n";
            data += "r: " + number_of_keyPress[82].ToString() + "\n";
            data += "t: " + number_of_keyPress[84].ToString() + "\n";
            data += "y: " + number_of_keyPress[89].ToString() + "\n";
            data += "u: " + number_of_keyPress[85].ToString() + "\n";
            data += "i: " + number_of_keyPress[73].ToString() + "\n";
            data += "o: " + number_of_keyPress[79].ToString() + "\n";
            data += "p: " + number_of_keyPress[80].ToString() + "\n";
            data += "[: " + number_of_keyPress[219].ToString() + "\n";
            data += "]: " + number_of_keyPress[221].ToString() + "\n";
            data += "enter: " + number_of_keyPress[13].ToString() + "\n";

            data += "caps: " + number_of_keyPress[20].ToString() + "\n";
            data += "a: " + number_of_keyPress[65].ToString() + "\n";
            data += "s: " + number_of_keyPress[83].ToString() + "\n";
            data += "d: " + number_of_keyPress[68].ToString() + "\n";
            data += "f: " + number_of_keyPress[70].ToString() + "\n";
            data += "g: " + number_of_keyPress[71].ToString() + "\n";
            data += "h: " + number_of_keyPress[72].ToString() + "\n";
            data += "j: " + number_of_keyPress[74].ToString() + "\n";
            data += "k: " + number_of_keyPress[75].ToString() + "\n";
            data += "l: " + number_of_keyPress[76].ToString() + "\n";
            data += ";: " + number_of_keyPress[186].ToString() + "\n";
            data += "\': " + number_of_keyPress[222].ToString() + "\n";
            data += "\\: " + number_of_keyPress[220].ToString() + "\n";

            data += "lshift: " + number_of_keyPress[160].ToString() + "\n";
            data += "rshift: " + number_of_keyPress[161].ToString() + "\n";
            data += "z: " + number_of_keyPress[90].ToString() + "\n";
            data += "x: " + number_of_keyPress[88].ToString() + "\n";
            data += "c: " + number_of_keyPress[67].ToString() + "\n";
            data += "v: " + number_of_keyPress[86].ToString() + "\n";
            data += "b: " + number_of_keyPress[66].ToString() + "\n";
            data += "n: " + number_of_keyPress[78].ToString() + "\n";
            data += "m: " + number_of_keyPress[77].ToString() + "\n";
            data += ",: " + number_of_keyPress[188].ToString() + "\n";
            data += ".: " + number_of_keyPress[190].ToString() + "\n";
            data += "/: " + number_of_keyPress[191].ToString() + "\n";

            data += "lctrl: " + number_of_keyPress[162].ToString() + "\n";
            data += "rctrl: " + number_of_keyPress[163].ToString() + "\n";
            data += "lalt: " + number_of_keyPress[164].ToString() + "\n";
            data += "ralt: " + number_of_keyPress[165].ToString() + "\n";
            data += "space: " + number_of_keyPress[32].ToString() + "\n\n";

            data += "=======\n<MOUSE>\n=======\n";
            data += "LB: " + number_of_keyPress[1].ToString() + "\n";
            data += "RB: " + number_of_keyPress[2].ToString() + "\n";
            data += "MB: " + number_of_keyPress[4].ToString() + "\n\n";

            data += ("TOTAL OF KEYPRESSES: " + TOTAL_KEYPRESSES.ToString() + "\n");

            string LogFileName = @$"keypress_statistics_{DateTime.Now.ToString("ddMMyyyy_HHmmss")}.log";
            File.WriteAllText(SavedRecordsPath + LogFileName, data);
        }

        // Restart the program
        public void Reload()
        {
            TOTAL_KEYPRESSES = 0;
            _resetNumberOfKeyPresses();
            _resetKeyboardColors();
        }

        public void WriteLogFile()
        {
            if (TOTAL_KEYPRESSES <= 1)
                return;

            if (Directory.Exists(SavedRecordsPath) == false)
                Directory.CreateDirectory(SavedRecordsPath);

            _writeLogFile();
        }

        // Display On-Hover animation for a single key with the number of keypresses.
        private void DisplayCursorOverKeypresses(object sender, EventArgs e)
        {
            /*
                Find the button that the user is on-hover and display under it
                the number of keypresses (only if > 0).
             */
            foreach (var keyfound in keys_hashcodes)
            {
                if (keyfound.Value == sender.GetHashCode())
                {
                    if (number_of_keyPress[keyfound.Key] > 0)
                    {
                        panel_key_times_pressed.Controls[0].Text = number_of_keyPress[keyfound.Key].ToString();

                        // Set the location, visibility and the size of the panel.
                        panel_key_times_pressed.Location = new System.Drawing.Point(keys[keyfound.Key].Location.X + 5, keys[keyfound.Key].Location.Y + 38);
                        panel_key_times_pressed.Size = new System.Drawing.Size(panel_key_times_pressed.Controls[0].Width, panel_key_times_pressed.Controls[0].Height);
                        panel_key_times_pressed.Visible = true;

                        return;
                    }
                }
            }
        }

        // Hide the animation.
        private void HideCursorOverKeypresses(object sender, EventArgs e)
        {
            panel_key_times_pressed.Visible = false;
        }

        private void program_Status_Click(object sender, EventArgs e)
        {
            SendKeys.SendWait("{F2}");
        }

        private void BTN_Help_Click(object sender, EventArgs e)
        {
            SendKeys.SendWait("{F1}");
        }
    }
}
