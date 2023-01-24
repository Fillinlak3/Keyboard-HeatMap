using System.IO;
using System.Text.RegularExpressions;

namespace Keyboard_HeatMap
{
    public partial class Keyboard_Layout : UserControl
    {
        public readonly static string SavedRecordsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + $@"\Keyboard HeatMap\Saves\";

        // Store the keys panel.
        public  Dictionary<int, Panel> keys;
        // Store the number of keypresses of each key.
        public  Dictionary<int, long> number_of_keyPress;
        // Store the hashes for finding the mouse-hover object.
        private Dictionary<int, int> keys_hashcodes;
        private Dictionary<int, int> symbols_hashcodes;
        // Store the total number of keypresses.
        public long TOTAL_KEYPRESSES = 0;
        
        // Dark/Light Mode Settings.
        private Color Dark_Mode_Keys_Background = Color.FromArgb(67, 67, 67);
        private Color Light_Mode_Keys_Background = Color.FromArgb(242, 243, 245);
        private bool DarkMode = false;

        public Keyboard_Layout()
        {
            InitializeComponent();

            keys = new Dictionary<int, Panel>();
            number_of_keyPress = new Dictionary<int, long>();
            keys_hashcodes = new Dictionary<int, int>();
            symbols_hashcodes = new Dictionary<int, int>();

            _assignKeysToDict();
            _centerKeysSymbolInParentPanel();
            _assignHashCodes();
            _resetNumberOfKeyPresses();
            _resetKeyboardColors();

            if (Directory.Exists(SavedRecordsPath) == false)
                Directory.CreateDirectory(SavedRecordsPath);
        }

        // Center the symbol of the key in it's parent panel.
        private void _centerKeysSymbolInParentPanel()
        {
            foreach (var key in keys)
            {
                key.Value.Controls[0].Location = new Point((int)Math.Ceiling((key.Value.Size.Width - key.Value.Controls[0].Width) / 2.0), (int)Math.Ceiling((key.Value.Size.Height - key.Value.Controls[0].Height) / 2.0));
            }
        }

        #region Dictionary Assignments
        // Assign keys panels.
        private void _assignKeysToDict()
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

            // Empty key
            keys.Add(-1, EMPTY_key);
        }

        // Assign/Reset number of keypresses.
        private void _resetNumberOfKeyPresses()
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

        // To get the on-hover animation to work.
        // Assign keys and symbols hashcodes.
        private void _assignHashCodes()
        {
            if (keys_hashcodes.Count != 0)
                keys_hashcodes.Clear();

            // Keys
            keys_hashcodes.Add(192, TILDA_key.GetHashCode());
            keys_hashcodes.Add(49, NUMBER_1_key.GetHashCode());
            keys_hashcodes.Add(50, NUMBER_2_key.GetHashCode());
            keys_hashcodes.Add(51, NUMBER_3_key.GetHashCode());
            keys_hashcodes.Add(52, NUMBER_4_key.GetHashCode());
            keys_hashcodes.Add(53, NUMBER_5_key.GetHashCode());
            keys_hashcodes.Add(54, NUMBER_6_key.GetHashCode());
            keys_hashcodes.Add(55, NUMBER_7_key.GetHashCode());
            keys_hashcodes.Add(56, NUMBER_8_key.GetHashCode());
            keys_hashcodes.Add(57, NUMBER_9_key.GetHashCode());
            keys_hashcodes.Add(48, NUMBER_0_key.GetHashCode());
            keys_hashcodes.Add(189, MINUS_key.GetHashCode());
            keys_hashcodes.Add(187, EQUAL_key.GetHashCode());
            keys_hashcodes.Add(8, BKSPC_key.GetHashCode());

            keys_hashcodes.Add(9, TAB_key.GetHashCode());
            keys_hashcodes.Add(81, Q_key.GetHashCode());
            keys_hashcodes.Add(87, W_key.GetHashCode());
            keys_hashcodes.Add(69, E_key.GetHashCode());
            keys_hashcodes.Add(82, R_key.GetHashCode());
            keys_hashcodes.Add(84, T_key.GetHashCode());
            keys_hashcodes.Add(89, Y_key.GetHashCode());
            keys_hashcodes.Add(85, U_key.GetHashCode());
            keys_hashcodes.Add(73, I_key.GetHashCode());
            keys_hashcodes.Add(79, O_key.GetHashCode());
            keys_hashcodes.Add(80, P_key.GetHashCode());
            keys_hashcodes.Add(219, BRACKET_OPEN_key.GetHashCode());
            keys_hashcodes.Add(221, BRACKET_CLOSE_key.GetHashCode());
            keys_hashcodes.Add(13, ENTER_key.GetHashCode());

            keys_hashcodes.Add(20, CAPS_key.GetHashCode());
            keys_hashcodes.Add(65, A_key.GetHashCode());
            keys_hashcodes.Add(83, S_key.GetHashCode());
            keys_hashcodes.Add(68, D_key.GetHashCode());
            keys_hashcodes.Add(70, F_key.GetHashCode());
            keys_hashcodes.Add(71, G_key.GetHashCode());
            keys_hashcodes.Add(72, H_key.GetHashCode());
            keys_hashcodes.Add(74, J_key.GetHashCode());
            keys_hashcodes.Add(75, K_key.GetHashCode());
            keys_hashcodes.Add(76, L_key.GetHashCode());
            keys_hashcodes.Add(186, SEMICOLON_key.GetHashCode());
            keys_hashcodes.Add(222, QUOTATION_MARK_key.GetHashCode());
            keys_hashcodes.Add(220, BACKSLASH_key.GetHashCode());

            keys_hashcodes.Add(160, LSHIFT_key.GetHashCode());
            keys_hashcodes.Add(161, RSHIFT_key.GetHashCode());
            keys_hashcodes.Add(90, Z_key.GetHashCode());
            keys_hashcodes.Add(88, X_key.GetHashCode());
            keys_hashcodes.Add(67, C_key.GetHashCode());
            keys_hashcodes.Add(86, V_key.GetHashCode());
            keys_hashcodes.Add(66, B_key.GetHashCode());
            keys_hashcodes.Add(78, N_key.GetHashCode());
            keys_hashcodes.Add(77, M_key.GetHashCode());
            keys_hashcodes.Add(188, COMMA_key.GetHashCode());
            keys_hashcodes.Add(190, DOT_key.GetHashCode());
            keys_hashcodes.Add(191, SLASH_key.GetHashCode());

            keys_hashcodes.Add(162, LCTRL_key.GetHashCode());
            keys_hashcodes.Add(163, RCTRL_key.GetHashCode());
            keys_hashcodes.Add(164, LALT_key.GetHashCode());
            keys_hashcodes.Add(165, RALT_key.GetHashCode());
            keys_hashcodes.Add(32, SPACE_key.GetHashCode());

            keys_hashcodes.Add(1, LB_key.GetHashCode());
            keys_hashcodes.Add(2, RB_key.GetHashCode());

            // Symbols
            symbols_hashcodes.Add(192, SYMBOL_TILDA.GetHashCode());
            symbols_hashcodes.Add(49, NUM1.GetHashCode());
            symbols_hashcodes.Add(50, NUM2.GetHashCode());
            symbols_hashcodes.Add(51, NUM3.GetHashCode());
            symbols_hashcodes.Add(52, NUM4.GetHashCode());
            symbols_hashcodes.Add(53, NUM5.GetHashCode());
            symbols_hashcodes.Add(54, NUM6.GetHashCode());
            symbols_hashcodes.Add(55, NUM7.GetHashCode());
            symbols_hashcodes.Add(56, NUM8.GetHashCode());
            symbols_hashcodes.Add(57, NUM9.GetHashCode());
            symbols_hashcodes.Add(48, NUM0.GetHashCode());
            symbols_hashcodes.Add(189, SYMBOL_MINUS.GetHashCode());
            symbols_hashcodes.Add(187, SYMBOL_EQUAL.GetHashCode());
            symbols_hashcodes.Add(8, FUNC_BKSPC.GetHashCode());

            symbols_hashcodes.Add(9, FUNC_TAB.GetHashCode());
            symbols_hashcodes.Add(81, LETTER_Q.GetHashCode());
            symbols_hashcodes.Add(87, LETTER_W.GetHashCode());
            symbols_hashcodes.Add(69, LETTER_E.GetHashCode());
            symbols_hashcodes.Add(82, LETTER_R.GetHashCode());
            symbols_hashcodes.Add(84, LETTER_T.GetHashCode());
            symbols_hashcodes.Add(89, LETTER_Y.GetHashCode());
            symbols_hashcodes.Add(85, LETTER_U.GetHashCode());
            symbols_hashcodes.Add(73, LETTER_I.GetHashCode());
            symbols_hashcodes.Add(79, LETTER_O.GetHashCode());
            symbols_hashcodes.Add(80, LETTER_P.GetHashCode());
            symbols_hashcodes.Add(219, SYMBOL_BRACKET_OPEN.GetHashCode());
            symbols_hashcodes.Add(221, SYMBOL_BRACKET_CLOSE.GetHashCode());
            symbols_hashcodes.Add(13, FUNC_ENTER.GetHashCode());

            symbols_hashcodes.Add(20, FUNC_CAPSLK.GetHashCode());
            symbols_hashcodes.Add(65, LETTER_A.GetHashCode());
            symbols_hashcodes.Add(83, LETTER_S.GetHashCode());
            symbols_hashcodes.Add(68, LETTER_D.GetHashCode());
            symbols_hashcodes.Add(70, LETTER_F.GetHashCode());
            symbols_hashcodes.Add(71, LETTER_G.GetHashCode());
            symbols_hashcodes.Add(72, LETTER_H.GetHashCode());
            symbols_hashcodes.Add(74, LETTER_J.GetHashCode());
            symbols_hashcodes.Add(75, LETTER_K.GetHashCode());
            symbols_hashcodes.Add(76, LETTER_L.GetHashCode());
            symbols_hashcodes.Add(186, SYMBOL_SEMICOLON.GetHashCode());
            symbols_hashcodes.Add(222, SYMBOL_QUOTATION_MARK.GetHashCode());
            symbols_hashcodes.Add(220, SYMBOL_BACKSLASH.GetHashCode());

            symbols_hashcodes.Add(160, FUNC_LSHIFT.GetHashCode());
            symbols_hashcodes.Add(161, FUNC_RSHIFT.GetHashCode());
            symbols_hashcodes.Add(90, LETTER_Z.GetHashCode());
            symbols_hashcodes.Add(88, LETTER_X.GetHashCode());
            symbols_hashcodes.Add(67, LETTER_C.GetHashCode());
            symbols_hashcodes.Add(86, LETTER_V.GetHashCode());
            symbols_hashcodes.Add(66, LETTER_B.GetHashCode());
            symbols_hashcodes.Add(78, LETTER_N.GetHashCode());
            symbols_hashcodes.Add(77, LETTER_M.GetHashCode());
            symbols_hashcodes.Add(188, SYMBOL_COMMA.GetHashCode());
            symbols_hashcodes.Add(190, SYMBOL_DOT.GetHashCode());
            symbols_hashcodes.Add(191, SYMBOL_SLASH.GetHashCode());

            symbols_hashcodes.Add(162, FUNC_LCTRL.GetHashCode());
            symbols_hashcodes.Add(163, FUNC_RCTRL.GetHashCode());
            symbols_hashcodes.Add(164, FUNC_LALT.GetHashCode());
            symbols_hashcodes.Add(165, FUNC_RALT.GetHashCode());
            symbols_hashcodes.Add(32, FUNC_SPACE.GetHashCode());

            symbols_hashcodes.Add(1, MOUSE_LB.GetHashCode());
            symbols_hashcodes.Add(2, MOUSE_RB.GetHashCode());
        }
        #endregion

        // Reset keypresses progress.
        private void _resetKeyboardColors()
        {
            foreach (var key in keys)
            {
                if (DarkMode) { key.Value.Controls[0].ForeColor = Color.White; key.Value.BackColor = Dark_Mode_Keys_Background; }
                else { key.Value.Controls[0].ForeColor = Color.Black; key.Value.BackColor = Light_Mode_Keys_Background; }
            }
        }

        // Restart the program.
        public void Reload()
        {
            TOTAL_KEYPRESSES = 0;
            _resetNumberOfKeyPresses();
            _resetKeyboardColors();
        }

        #region Read/Write Log File
        private void _writeLogFile()
        {
            string data = "#========== <KEYBOARD> ==========#\n";

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

            data += "#======= <MOUSE> =======#\n";
            data += "LB: " + number_of_keyPress[1].ToString() + "\n";
            data += "RB: " + number_of_keyPress[2].ToString() + "\n";
            data += "MB: " + number_of_keyPress[4].ToString() + "\n\n";

            data += ("TOTAL OF KEYPRESSES: " + TOTAL_KEYPRESSES.ToString() + "\n");

            string LogFileName = @$"keypress_statistics_{DateTime.Now.ToString("ddMMyyyy_HHmmss")}.log";
            File.WriteAllText(SavedRecordsPath + LogFileName, data);
        }

        // Write Log File.
        public void WriteLogFile()
        {
            // If accidentally the program registers only 1 press which means the closing,
            // it will be ignored and no new log file will be written.
            if (TOTAL_KEYPRESSES <= 1)
            {
                LABEL_total_number_of_keypresses.Text = "No keypresses yet";
                _resetKeyboardColors();
                return;
            }

            // If first-time use and the saved records folder doesn't exist, create it.
            if (Directory.Exists(SavedRecordsPath) == false)
                Directory.CreateDirectory(SavedRecordsPath);

            // Write the log file itself and save in the saved records folder.
            _writeLogFile();
        }

        private bool _readLogFile(string filepath)
        {
            try
            {
                List<string>? data_scraped = new List<string>(System.IO.File.ReadAllText(filepath).Split('\n', StringSplitOptions.TrimEntries).ToArray());

                // Remove comments and blank lines and add to list the values.
                Regex sWhitespace = new Regex(@"\s+");
                for (int i = 0; i < data_scraped.Count; i++)
                {
                    // Remove comments and blank lines.
                    if (data_scraped[i].StartsWith('#') || String.IsNullOrWhiteSpace(data_scraped[i]))
                        data_scraped.Remove(data_scraped[i--]);
                    // Add to the list the corespondent values.
                    else data_scraped[i] = sWhitespace.Replace(data_scraped[i], "").Split(':')[1];
                }

                // Check if the file is corrupted: it doesn't have all the 61 keys + the total keypresses number.
                if (data_scraped.Count != 62)
                    throw new Exception("Record file is corrupted.");

                // If the file is ok, then assign the values to number_of_keyPress list.
                #region Assign Values
                if (number_of_keyPress.Count != 0)
                    number_of_keyPress.Clear();

                number_of_keyPress.Add(192, Int32.Parse(data_scraped[0]));
                number_of_keyPress.Add(49, Int32.Parse(data_scraped[1]));
                number_of_keyPress.Add(50, Int32.Parse(data_scraped[2]));
                number_of_keyPress.Add(51, Int32.Parse(data_scraped[3]));
                number_of_keyPress.Add(52, Int32.Parse(data_scraped[4]));
                number_of_keyPress.Add(53, Int32.Parse(data_scraped[5]));
                number_of_keyPress.Add(54, Int32.Parse(data_scraped[6]));
                number_of_keyPress.Add(55, Int32.Parse(data_scraped[7]));
                number_of_keyPress.Add(56, Int32.Parse(data_scraped[8]));
                number_of_keyPress.Add(57, Int32.Parse(data_scraped[9]));
                number_of_keyPress.Add(48, Int32.Parse(data_scraped[10]));
                number_of_keyPress.Add(189, Int32.Parse(data_scraped[11]));
                number_of_keyPress.Add(187, Int32.Parse(data_scraped[12]));
                number_of_keyPress.Add(8, Int32.Parse(data_scraped[13]));

                number_of_keyPress.Add(9, Int32.Parse(data_scraped[14]));
                number_of_keyPress.Add(81, Int32.Parse(data_scraped[15]));
                number_of_keyPress.Add(87, Int32.Parse(data_scraped[16]));
                number_of_keyPress.Add(69, Int32.Parse(data_scraped[17]));
                number_of_keyPress.Add(82, Int32.Parse(data_scraped[18]));
                number_of_keyPress.Add(84, Int32.Parse(data_scraped[19]));
                number_of_keyPress.Add(89, Int32.Parse(data_scraped[20]));
                number_of_keyPress.Add(85, Int32.Parse(data_scraped[21]));
                number_of_keyPress.Add(73, Int32.Parse(data_scraped[22]));
                number_of_keyPress.Add(79, Int32.Parse(data_scraped[23]));
                number_of_keyPress.Add(80, Int32.Parse(data_scraped[24]));
                number_of_keyPress.Add(219, Int32.Parse(data_scraped[25]));
                number_of_keyPress.Add(221, Int32.Parse(data_scraped[26]));
                number_of_keyPress.Add(13, Int32.Parse(data_scraped[27]));

                number_of_keyPress.Add(20, Int32.Parse(data_scraped[28]));
                number_of_keyPress.Add(65, Int32.Parse(data_scraped[29]));
                number_of_keyPress.Add(83, Int32.Parse(data_scraped[30]));
                number_of_keyPress.Add(68, Int32.Parse(data_scraped[31]));
                number_of_keyPress.Add(70, Int32.Parse(data_scraped[32]));
                number_of_keyPress.Add(71, Int32.Parse(data_scraped[33]));
                number_of_keyPress.Add(72, Int32.Parse(data_scraped[34]));
                number_of_keyPress.Add(74, Int32.Parse(data_scraped[35]));
                number_of_keyPress.Add(75, Int32.Parse(data_scraped[36]));
                number_of_keyPress.Add(76, Int32.Parse(data_scraped[37]));
                number_of_keyPress.Add(186, Int32.Parse(data_scraped[38]));
                number_of_keyPress.Add(222, Int32.Parse(data_scraped[39]));
                number_of_keyPress.Add(220, Int32.Parse(data_scraped[40]));

                number_of_keyPress.Add(160, Int32.Parse(data_scraped[41]));
                number_of_keyPress.Add(161, Int32.Parse(data_scraped[42]));
                number_of_keyPress.Add(90, Int32.Parse(data_scraped[43]));
                number_of_keyPress.Add(88, Int32.Parse(data_scraped[44]));
                number_of_keyPress.Add(67, Int32.Parse(data_scraped[45]));
                number_of_keyPress.Add(86, Int32.Parse(data_scraped[46]));
                number_of_keyPress.Add(66, Int32.Parse(data_scraped[47]));
                number_of_keyPress.Add(78, Int32.Parse(data_scraped[48]));
                number_of_keyPress.Add(77, Int32.Parse(data_scraped[49]));
                number_of_keyPress.Add(188, Int32.Parse(data_scraped[50]));
                number_of_keyPress.Add(190, Int32.Parse(data_scraped[51]));
                number_of_keyPress.Add(191, Int32.Parse(data_scraped[52]));

                number_of_keyPress.Add(162, Int32.Parse(data_scraped[53]));
                number_of_keyPress.Add(163, Int32.Parse(data_scraped[54]));
                number_of_keyPress.Add(164, Int32.Parse(data_scraped[55]));
                number_of_keyPress.Add(165, Int32.Parse(data_scraped[56]));
                number_of_keyPress.Add(32, Int32.Parse(data_scraped[57]));

                number_of_keyPress.Add(1, Int32.Parse(data_scraped[58]));
                number_of_keyPress.Add(2, Int32.Parse(data_scraped[59]));
                number_of_keyPress.Add(4, Int32.Parse(data_scraped[60]));

                TOTAL_KEYPRESSES = Int32.Parse(data_scraped[61]);
                #endregion

                // Finally clean the mem.
                data_scraped = null;
            }
            catch(Exception ex)
            {
                LABEL_total_number_of_keypresses.Text = "No keypresses yet";
                MessageBox.Show($"Failed to open record file: {ex.Message}", "Operation Failed!", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }

        // Read Log File.
        public bool ReadLogFile(string file)
        {
            return _readLogFile(file);
        }
        #endregion

        #region Hover Animation
        // Display On-Hover animation for a single key with the number of keypresses.
        private Point Hovered_Key_Location;
        private void DisplayCursorOverKeypresses(object sender, EventArgs e)
        {
            /*
                Find the button that the user is on-hover and display under it
                the number of keypresses (only if > 0).
             */
            foreach (var keyfound in keys_hashcodes)
            {
                if (keyfound.Value == sender.GetHashCode() && number_of_keyPress[keyfound.Key] > 0)
                {
                    panel_key_times_pressed.Controls[0].Text = $"{number_of_keyPress[keyfound.Key]} - {(int)Math.Ceiling((number_of_keyPress[keyfound.Key] * 100.0) / TOTAL_KEYPRESSES)}%";

                    // Set the location, visibility and the size of the panel.
                    Hovered_Key_Location = keys[keyfound.Key].Location;
                    panel_key_times_pressed.Size = new System.Drawing.Size(panel_key_times_pressed.Controls[0].Width + 1, panel_key_times_pressed.Controls[0].Height + 1);
                    panel_key_times_pressed.Visible = true;

                    return;
                }
            }

            foreach (var symbolfound in symbols_hashcodes)
            {
                if (symbolfound.Value == sender.GetHashCode() && number_of_keyPress[symbolfound.Key] > 0)
                {
                    panel_key_times_pressed.Controls[0].Text = $"{number_of_keyPress[symbolfound.Key]} - {(int)Math.Ceiling((number_of_keyPress[symbolfound.Key] * 100.0) / TOTAL_KEYPRESSES)}%";

                    // Set the location, visibility and the size of the panel.
                    Hovered_Key_Location = keys[symbolfound.Key].Location;
                    panel_key_times_pressed.Size = new System.Drawing.Size(panel_key_times_pressed.Controls[0].Width + 1, panel_key_times_pressed.Controls[0].Height + 1);
                    panel_key_times_pressed.Visible = true;

                    return;
                }
            }
        }
        // Move along the mouse cursor.
        private void UpdateCursorLocation(object sender, MouseEventArgs e)
        {
            int x = 0, y = 0;

            if(keys_hashcodes.ContainsValue(sender.GetHashCode()))
            {
                x = Hovered_Key_Location.X + e.Location.X - panel_key_times_pressed.Width;
                y = Hovered_Key_Location.Y + e.Location.Y - panel_key_times_pressed.Height;       
            }
            else
            {
                foreach (var symbolfound in symbols_hashcodes)
                {
                    if (symbolfound.Value == sender.GetHashCode())
                    {
                        x = Hovered_Key_Location.X + e.Location.X - panel_key_times_pressed.Width + keys[symbolfound.Key].Controls[0].Location.X;
                        y = Hovered_Key_Location.Y + e.Location.Y - panel_key_times_pressed.Height + keys[symbolfound.Key].Controls[0].Location.Y;
                    }
                }   
            }

            if (x <= 0) x += panel_key_times_pressed.Width + 5;
            if (y <= 0) { y = 15; x -= 5; }
            panel_key_times_pressed.Location = new Point(x, y);
        }
        // Hide the animation.
        private void HideCursorOverKeypresses(object sender, EventArgs e)
        {
            panel_key_times_pressed.Visible = false;
        }
        #endregion

        private void program_Status_Click(object sender, EventArgs e)
        {
            SendKeys.SendWait("{F2}");
        }

        private void BTN_Help_Click(object sender, EventArgs e)
        {
            SendKeys.SendWait("{F1}");
        }
    
        // Switch from Light-Mode to Dark-Mode.
        public void SwitchToDarkMode(bool mode)
        {
            if (mode)
            {
                this.BackColor = keys_panel.BackColor = Color.FromArgb(45, 45, 45);
                LABEL_total_number_of_keypresses.ForeColor = Color.White;

                foreach (var key in keys)
                {
                    if (key.Value.BackColor == Light_Mode_Keys_Background)
                    { key.Value.BackColor = Dark_Mode_Keys_Background; key.Value.Controls[0].ForeColor = Color.White; }
                }
            }
            else
            {
                this.BackColor = keys_panel.BackColor = Color.FromArgb(167, 173, 186);
                LABEL_total_number_of_keypresses.ForeColor = Color.Black;

                foreach (var key in keys)
                {
                    if (key.Value.BackColor == Dark_Mode_Keys_Background)
                        key.Value.BackColor = Light_Mode_Keys_Background;
                    key.Value.Controls[0].ForeColor = Color.Black;
                }
            }
            this.Invalidate();
            DarkMode = mode;
        }
    }
}
