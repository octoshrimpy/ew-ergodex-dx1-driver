﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using DX1Interface;

namespace DX1Utility
{
    public partial class Form1 : Form
    {

        [Serializable]
        public class UsedToSaveProgramSet
        {
            const int VERSION = 1;

            public Byte[] keyMap;
            public String[] macroMap;
            //public KeyMap[] keyMaps;
            public UsedToSaveProgramSet(Byte[] keys, String[] macros)
            {
                keyMap = keys;
                macroMap = macros;            
            }

            public static UsedToSaveProgramSet Read(System.IO.Stream stream)
            {

                IFormatter formatter = new BinaryFormatter();
                int version = (Int32)formatter.Deserialize(stream);
                
                UsedToSaveProgramSet programSet = (UsedToSaveProgramSet)formatter.Deserialize(stream);
                return programSet;

            }

            public static void Write(System.IO.Stream stream, UsedToSaveProgramSet programSet)
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, VERSION);
                formatter.Serialize(stream, programSet);
            }

        }

        [Serializable]
        public class UsedToSaveProgramSetv2
        {
            const int VERSION = 2;

            public String[] macroMap;
            public List<KeyMap> keyMaps;
            public UsedToSaveProgramSetv2(List<KeyMap> keys)
            {
                keyMaps = keys;
            }

            public static UsedToSaveProgramSetv2 Read(System.IO.Stream stream)
            {

                IFormatter formatter = new BinaryFormatter();
                int version = (Int32)formatter.Deserialize(stream);

                if (version == 1) {
                    //This is a version 1 file Convert it to a Version 2 file
                    UsedToSaveProgramSet prgramsetv1 = (UsedToSaveProgramSet)formatter.Deserialize(stream);
                    List<KeyMap> TempKeys = new List<KeyMap>();
                    String[] TempMacros = new String[kMaxKeys];
                    UsedToSaveProgramSetv2 programset = new UsedToSaveProgramSetv2(TempKeys);

                    for (int i = 0; i < kMaxKeys; i++)
                    {
                        //process each of the keys
                        int offset = (i) * 3;
                        
                        KeyMap NewKey = new KeyMap();
                        NewKey.Dx1Key = (byte)(i+1);
                        offset++;
                        NewKey.Type = prgramsetv1.keyMap[offset++];
                        NewKey.Action = prgramsetv1.keyMap[offset++];
                        if (NewKey.Action == (byte)0)
                        {
                            NewKey.Description = "Unassigned";
                        }
                        else
                        {
                            NewKey.Description = "Keycode-" + NewKey.Action.ToString();
                        }
                        programset.keyMaps.Add(NewKey);

                    }

                    TempMacros = prgramsetv1.macroMap;

                    for (int i = 0; i < kMaxKeys; i++)
                    {
                        //Process each of the Macros into the corresponding key
                        if (TempMacros[i] != null)
                        {
                            programset.keyMaps[i].MacroName = TempMacros[i];
                        }
                    }



                    return programset;
                    
                }
                
                UsedToSaveProgramSetv2 programSet = (UsedToSaveProgramSetv2)formatter.Deserialize(stream);
                return programSet;
            }

            public static void Write(System.IO.Stream stream, UsedToSaveProgramSetv2 programSet)
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, VERSION);
                formatter.Serialize(stream, programSet);
            }

        }


        private string[] sKeyBindings = new string[] { "", "Single Key", "Modifier Key", "Macro" };

        private const int kMaxKeys = 50;
        private const string DefCreateProf = "(Create New Profile)";
        private const string DefGlobalProf = "(Global)";
        //private Byte[] mKeyMap = new Byte[3 * kMaxKeys];
        private List<KeyMap> KeyMaps = new List<KeyMap>();
        //private String[] mMacroMap = new String [kMaxKeys];
        private Dictionary<String, MacroPlayer.MacroDefinition> mMacros = new Dictionary<String, MacroPlayer.MacroDefinition>();
        private MacroPlayer.MacroDefinition[] mKeyMacroSequenceMapping = new MacroPlayer.MacroDefinition[kMaxKeys];
        private String mFileName = "";
        private Profiles CurrentProfile = new Profiles();
        private List<Profiles> ProfileList;
        private bool RealClose = false;
        private bool HideMinimized = false;
        private SpecialKeyPlayer SpecialKeyPlayer = new SpecialKeyPlayer();
        private bool DX1UtilityActive = true;

        
        // QuickKey programming state manager.
        private KeyProgrammer mKeyProgrammer;

        // DX1 hardware interface
        HardwareInterface mDX1Hardware = null;
        IntPtr mDevHandle = IntPtr.Zero;

        // Timer for Macro Playback
        System.DateTime initialTime = System.DateTime.Now;
        System.Timers.Timer macroTimer = new System.Timers.Timer();
        System.Timers.Timer appFocusCheckTimer = new System.Timers.Timer();

        MacroPlayer mMacroPlayer = new MacroPlayer();
        
        private System.Windows.Forms.NotifyIcon notifyIcon1;

        //Removed for version 1.2 where we want the close button re-enabled
        //private const int CP_NOCLOSE_BUTTON = 0x200;

        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams myCp = base.CreateParams;
        //        myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
        //        return myCp;
        //    }
        //}

        [DllImport("user32.dll")]
        static public extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Ansi)]
        static extern uint GetWindowModuleFileName(IntPtr hwnd, [Out] StringBuilder lpszFileName, uint cchFileNameMax);

        public Form1()
        {

            mKeyProgrammer = new KeyProgrammer(ref KeyMaps);
            SpecialKeyPlayer.InitPlayer();

            notifyIcon1 = new System.Windows.Forms.NotifyIcon();
            notifyIcon1.Icon = this.Icon;
            notifyIcon1.Text = "DX1 Utility";
            notifyIcon1.MouseDoubleClick += new MouseEventHandler(notifyIcon1_MouseDoubleClick);
            notifyIcon1.Visible = true;
            
            InitializeComponent();

            mDX1Hardware = new HardwareInterface();
            mDevHandle = mDX1Hardware.OpenDevice(true);
            
            mDX1Hardware.RegisterWindowForEvents(mDevHandle, Handle);

            macroTimer.AutoReset = false;
            macroTimer.Elapsed += new System.Timers.ElapsedEventHandler(macroTimer_Elapsed);

            RebuildMacroList();
            ControlBox = true;

            //Add the (Create new Profile) option to the Profile Combobox
            V_Profiles.Items.Add(DefCreateProf);

            //Create the Quick-Menu for Right-Click on NotifyIcon
            ContextMenu ContextMenu1 = new ContextMenu();
            MenuItem ProfileMenu = new MenuItem();
            
            ProfileMenu.Text = "Profiles";
            ProfileMenu.RadioCheck = true;
            MenuItem ProfileSub;

            //Check for DX1Profiles folder if it doesn't exist, create it
            if (!System.IO.Directory.Exists(Globals.ProfileSavePath))
                System.IO.Directory.CreateDirectory(Globals.ProfileSavePath);

            //Load Profile List
            ProfileList = (List<Profiles>)LoadProfiles(Globals.ProfileSavePath + "Dx1Profiles.dat");

            //Add list of profiles to V_Profiles Combo Box and Context Menu
            foreach (Profiles Profile in ProfileList)
            {
                V_Profiles.Items.Add(Profile.ProfName);

                ProfileSub = new MenuItem();
                if (Profile.QuickMenu & Profile.ProfEnabled)
                {
                    ProfileSub.Text = Profile.ProfName;
                    ProfileSub.RadioCheck = true;
                    ProfileSub.Click += new EventHandler(ProfileSelected);
                    ProfileMenu.MenuItems.Add(ProfileSub);
                }
            }
            V_Profiles.Sorted = true;

            //AutoSelect Global Profile
            //If one doesn't exist create it (For users that have run 1.1 or earlier)
            if (!V_Profiles.Items.Contains(DefGlobalProf))
            {
                //No Global Profile, Create it
                InitKeyMap(ref KeyMaps);
                CurrentProfile = new Profiles();
                CurrentProfile.ProfName = DefGlobalProf;
                ProfileList.Add(CurrentProfile);
                SaveButtonstoProfile(CurrentProfile.ProfName);
                SaveProfiles();
            }
            SelectGlobalProfile();


            //Initialize the DataGrid and KeyMap List
            G_KeyMap.AutoGenerateColumns = false;
            G_KeyMap.DataSource = KeyMaps;
            G_KeyMap.AllowUserToResizeRows = false;
            G_KeyMap.AllowUserToResizeColumns = false;
            //G_KeyMap.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            //G_KeyMap.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;


            //Add Dx1Key Column
            DataGridViewTextBoxColumn DxColumn = new DataGridViewTextBoxColumn();
            DxColumn.Width = 30;
            DxColumn.DataPropertyName = "Dx1Key";
            DxColumn.HeaderText = "Key";
            DxColumn.ReadOnly = true;
            DxColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            G_KeyMap.Columns.Add(DxColumn);

            //Add Description Column
            DataGridViewTextBoxColumn DescColumn = new DataGridViewTextBoxColumn();
            DescColumn.Width = 120;
            DescColumn.DataPropertyName = "Description";
            DescColumn.HeaderText = "Description";
            DescColumn.ReadOnly = true;
            G_KeyMap.Columns.Add(DescColumn);


            //Finialize Quick-Menu Options for the Notify Icon
            ProfileMenu.Popup += new EventHandler(QuickMenuPopup);
            ContextMenu1.MenuItems.Add(ProfileMenu);
            ContextMenu1.MenuItems.Add("-");
            ContextMenu1.MenuItems.Add("O&pen", new EventHandler(notifyIcon1_MouseDoubleClick));
            ContextMenu1.MenuItems.Add("E&xit", new EventHandler(CloseApp));

            notifyIcon1.ContextMenu = ContextMenu1;

            appFocusCheckTimer.AutoReset = true;
            appFocusCheckTimer.Interval = 1000;
            appFocusCheckTimer.Elapsed += new System.Timers.ElapsedEventHandler(appFocusCheckTimer_Elapsed);
            appFocusCheckTimer.Start();

        }

        void RebuildMacroList()
        {
            mMacros.Clear();
            MacroList.Items.Clear();
            MacroList.Items.Add("NEW MACRO");

            // Add the files from the directory
            if (!System.IO.Directory.Exists(Globals.macroDir))
                System.IO.Directory.CreateDirectory(Globals.macroDir);

            String[] files = System.IO.Directory.GetFiles(Globals.macroDir, "*.mac");
            foreach(String name in files)
            {
                System.IO.FileStream stream = new System.IO.FileStream(name, System.IO.FileMode.Open);
                MacroPlayer.MacroDefinition macro = MacroPlayer.MacroDefinition.Read(stream);
                stream.Close();

                String[] pathComponents = name.Split('\\');
                pathComponents = pathComponents.Last().Split('.');
                macro.name = pathComponents.First();

                MacroList.Items.Add(macro.name);
                if (macro != null)
                    mMacros.Add(macro.name, macro);
            }

        }

        const uint kMacroPacketLength = 6;
        byte[] mLastMacroKeyState = new byte[kMacroPacketLength];

        private void DoSomethingWithMacroKeys(byte[] data)
        {
            // need to sort the data by key number
            Array.Sort(data);
            Array.Reverse(data);

            int lastKeyIndex = 0;
            // for each of the possible keys
            int curIndex = 0;
            while (curIndex < kMacroPacketLength || lastKeyIndex < kMacroPacketLength)
            {
                byte last = (lastKeyIndex < kMacroPacketLength) ? mLastMacroKeyState[lastKeyIndex] : (byte)0;
                byte curr = (curIndex < kMacroPacketLength) ? data[curIndex] : (byte)0;

                // No more data
                if (last == 0 && curr == 0)
                    break;

                if (last == curr)       // No change
                {
                    lastKeyIndex++;
                    curIndex++;
                }
                else if (last > curr)       // Key Up
                {
                    lastKeyIndex++;
                    
                    //Check to see if this is a Macro Key or a "Special Function"
                    if (KeyMaps[last - 1].Type > 3)
                    {
                        //New Special Key Function
                        SpecialKeyPlayer.KeyUp(KeyMaps[last - 1]);

                    }
                    else
                    {
                        //Standard Macro, use original Macro Player by Rob
                        MacroPlayer.MacroDefinition macroDef = mKeyMacroSequenceMapping[last - 1];
                        if (macroDef != null && (macroDef.macroType & MacroPlayer.MacroDefinition.MacroType.kMacroMultiKey) != 0)
                        {
                            macroDef.AllMacroKeysUp();
                        }
                    }
                }
                else                  // Key down
                {
                    //Check to see if this is a Macro Key or a "Special Function"
                    if (KeyMaps[curr - 1].Type > 3)
                    {
                        //New Special Key Function
                        SpecialKeyPlayer.KeyDown(KeyMaps[curr - 1]);
                        
                    }
                    else
                    {
                        //Standard Macro, use original Macro Player by Rob

                        MacroPlayer.MacroDefinition macroDef = mKeyMacroSequenceMapping[curr - 1];
                        if (macroDef != null)
                        {
                            if ((macroDef.macroType & MacroPlayer.MacroDefinition.MacroType.kMacroMultiKey) == 0)
                            {
                                macroTimer.Stop();
                                System.DateTime time = System.DateTime.Now;
                                TimeSpan totalTime = time - initialTime;
                                UInt64 curTimeMS = (UInt64)totalTime.TotalMilliseconds;
                                // Create the new Macro instance

                                MacroPlayer.Macro macro = new MacroPlayer.Macro(macroDef);
                                UInt64 timeToNextEvent = macro.InitMacroAtTime(curTimeMS);

                                // If the macro isn't instantaneous add it to the list.
                                if (timeToNextEvent != MacroPlayer.kForever)
                                    mMacroPlayer.Add(macro);

                                // process the rest of the running macros to this point.
                                UInt64 nextExistingMacroEventTime = mMacroPlayer.Tick(curTimeMS);

                                // And if any are still waiting start a timer
                                if (nextExistingMacroEventTime != MacroPlayer.kForever)
                                {
                                    macroTimer.AutoReset = false;
                                    macroTimer.Interval = (UInt32)(nextExistingMacroEventTime - curTimeMS);
                                    macroTimer.Start();
                                }
                            }
                            else
                            {
                                macroDef.AllMacroKeysDown();
                            }
                        }

                    }


                    curIndex++;
                }

            }

            Array.Copy(data, mLastMacroKeyState, kMacroPacketLength);
        }
        
        void macroTimer_Elapsed(Object sender, System.Timers.ElapsedEventArgs e)
        {
            macroTimer.Stop();
            System.DateTime time = System.DateTime.Now;
            TimeSpan totalTime = time - initialTime;
            UInt64 curTimeMS = (UInt64)totalTime.TotalMilliseconds;
            // Create the new Macro instance

            // process the rest of the running macros to this point.
            UInt64 nextExistingMacroEventTime = mMacroPlayer.Tick(curTimeMS);

            // And if any are still waiting start a timer
            if (nextExistingMacroEventTime != MacroPlayer.kForever)
            {
                macroTimer.AutoReset = false;
                macroTimer.Interval = (UInt32)(nextExistingMacroEventTime - curTimeMS);
                macroTimer.Start();
            }
        }

        IntPtr lastHandle = IntPtr.Zero;
        IntPtr SelfHandle = IntPtr.Zero;

        void appFocusCheckTimer_Elapsed(Object sender, System.Timers.ElapsedEventArgs e)
        {

            IntPtr handle = GetForegroundWindow();

            //Do not run excesive code if App has not changed from last tick, or App is DX1Utility
            if (handle != lastHandle && handle != SelfHandle)
            {
                DebugLog.Instance.writeLog("New Active App detected: ", true);
                lastHandle = handle;
                String processName = "";
                String exeName = "";
                ProfileSearcher Searcher = new ProfileSearcher();

                DebugLog.Instance.writeLog("   Handle: " + handle.ToString(), true);

                System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcesses();


                foreach (System.Diagnostics.Process process in processes)
                {
                    if (process.MainWindowHandle == handle)
                    {
                        try
                        {
                            //This works on some apps not others
                            exeName = process.MainModule.FileName;
                            DebugLog.Instance.writeLog("   FileName: " + exeName.ToLower());
                        }
                        catch (Exception)
                        {
                            DebugLog.Instance.writeLog("   FileName could not be found");
                        }
                        finally
                        {
                            //Get ProcessName, although currently not used for anything.
                            processName = process.ProcessName;
                            DebugLog.Instance.writeLog("   processName: " + processName.ToLower());
                            if (processName.ToLower().Contains("dx1utility"))
                            {
                                SelfHandle = handle;
                            }
                        }
                        break;
                    }
                }


                String newExeName = "";
                if (exeName != "")
                {
                    newExeName = exeName.ToLower();
                }
                
                //Search the Profile List for any profile with this Path
                if (Searcher.ProfileSearchByPath(ProfileList, newExeName) != null)
                {
                    //Profile was found, load that profile and apply Keymap
                    CurrentProfile = Searcher.ProfileSearchByPath(ProfileList, newExeName);
                    DebugLog.Instance.writeLog("   Profile Found: " + CurrentProfile.ProfName);
                    LoadButtonsfromProfile(CurrentProfile.ProfName);
                    ApplyKeySet();
                }
                else
                {
                    //Profile Path not found, Select the Global Profile if current Profile wasn't manually selected
                    if (!ProfileManuallySelected)
                    {
                        DebugLog.Instance.writeLog("   No Profile Found Loading " + DefGlobalProf + " Prfoile");
                        SelectGlobalProfile();
                    }
                }

            }
        }
        
        protected override void OnActivated(System.EventArgs e)
        {
            if (mDevHandle != IntPtr.Zero)
                mDX1Hardware.TestMode(mDevHandle);

            //RebuildMacroList();
            //ReBuildKeyMap();
            V_Profiles.Text = CurrentProfile.ProfName;
            B_QuickPrg.Text = "Quick Program";
            DX1UtilityActive = true;
        }
        
        void MapMacroKeys()
        {

            foreach (KeyMap DxKey in KeyMaps)
            {
                if(DxKey.Type == 0x3)
                {
                    if (mMacros.ContainsKey(DxKey.MacroName))
                    {
                        MacroPlayer.MacroDefinition macro = mMacros[DxKey.MacroName];
                        mKeyMacroSequenceMapping[DxKey.Dx1Key - 1] = macro;
                    }
                    else
                    {
                        //Macro not found
                        DebugLog.Instance.writeLog("Error Macro listed wasn't found: " + DxKey.MacroName, true);
                    }
                }

            }
        }

        private void ApplyKeySet()
        {
            MapMacroKeys();
            mKeyProgrammer.Active = false;
            if (mDevHandle != IntPtr.Zero)
            {
                mDX1Hardware.SendProgramPacket(mDevHandle, mKeyProgrammer.GetKeyMap(KeyMaps));
            }
        }

        protected override void OnDeactivate(System.EventArgs e)
        {
            ApplyKeySet();
            DX1UtilityActive = false;
        }

        protected override void OnResize(System.EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized & HideMinimized)
            {
                Hide();
            }
            else if (WindowState == FormWindowState.Normal)
            {
                HideMinimized = false;
            }

        }

        // Allows us to get current keyboard state.
        [DllImport("user32.dll")]
        public static extern int GetKeyboardState(byte[] lpKeyState);

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (mKeyProgrammer.Active & mKeyProgrammer.KeyToProgram > 0)
            {
                int keyCode = (int)e.KeyCode;
                // Seperate left and right shift/ctrl/alt
                if (keyCode >= 0x10 && keyCode <= 0x12)
                {
                    Byte[] state = new Byte[256];
                    GetKeyboardState(state);
                    keyCode = 0xa0 + 2 * (keyCode - 0x10);
                    if ((state[keyCode + 1] & 0x80) != 0)
                        keyCode++;          // RHS version
                }

                if (!KeyMaps[mKeyProgrammer.KeyToProgram - 1].AssignSingleKey(keyCode))
                {
                    //Error converting key
                    KeyMaps[mKeyProgrammer.KeyToProgram - 1].Description = "Error converting Key";
                }
                else
                {
                    KeyMaps[mKeyProgrammer.KeyToProgram - 1].Description = e.KeyCode.ToString();
                }

                B_QuickPrg.Text = "Programming";
                ReBuildKeyMap();
                
            }
            else
            {
                if (e.KeyCode == System.Windows.Forms.Keys.Delete)
                {
                    if (MacroList.Focused && MacroList.SelectedIndex !=0)
                    {
                        System.IO.File.Delete(Globals.macroDir + MacroList.SelectedItem.ToString() + ".mac");
                        RebuildMacroList();
                    }
                }


            }
            base.OnKeyDown(e);
        }

        //Used to capture Tab, return, ESC and arrow keys
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (mKeyProgrammer.Active)
                return false;
            return base.ProcessDialogKey(keyData);
        }

        const int DBT_CUSTOMEVENT = 0x8006;
        const int WM_DEVICECHANGE = 0x219;
        
        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")]
        protected override void WndProc(ref Message m)
        {

            // Listen for device driver messages
            switch (m.Msg)
            {
                case WM_DEVICECHANGE:
                {
                    switch(m.WParam.ToInt32())
                    {
                        case DBT_CUSTOMEVENT:
                        {
                            DEV_BROADCAST_DEVICEHANDLE vol;
                            vol = (DEV_BROADCAST_DEVICEHANDLE) Marshal.PtrToStructure(m.LParam, typeof(DEV_BROADCAST_DEVICEHANDLE));
                            int key = (int)vol.dbch_data[0];

                            if (DX1UtilityActive & key > 0)
                            {
                                        //IF Utility is active then Highlight DX1 Key that was pressed in G_KeyMap to make 
                                        //finding and programming keys easier.  Don't play the macro.
                                        DebugLog.Instance.writeLog("Detected DX1 Key Press Key Number: " + key.ToString() + "was pressed.");

                                G_KeyMap.CurrentCell = G_KeyMap.Rows[key - 1].Cells[0];
                                if (mKeyProgrammer.DX1KeyDown(key))
                                {
                                    MacroList.ClearSelected();
                                    if (mKeyProgrammer.Active)
                                    {
                                        //Currently Quick Programming
                                        B_QuickPrg.Text = "Key - " + mKeyProgrammer.KeyToProgram;
                                    }
                                }
                            }
                            else
                            {
                                DoSomethingWithMacroKeys(vol.dbch_data);
                            }
                            break;
                        }

                    }
                    break;
                }
            }
            base.WndProc(ref m);
        }
        
        //New Functions by Earthworm
        bool ProfileManuallySelected = false;
        private void SelectGlobalProfile()
        {
            //Function to specifically select the Global Profile
            ProfileSearcher Searcher = new ProfileSearcher();

            CurrentProfile = Searcher.ProfileSearchByName(ProfileList, DefGlobalProf);
            LoadButtonsfromProfile(CurrentProfile.ProfName);

        }
        private void QuickMenuPopup(object sender, EventArgs e)
        {
            //Populate Sub Menu with current Profiles when it is right-clicked on
            MenuItem QuickMenu = ((MenuItem)sender);
            MenuItem ProfileSub;

            //Clear current Menu
            QuickMenu.MenuItems.Clear();
            List<string> SortedList = new List<string>();

            //Find all Profiles to be in the Quick Menu and store for sorting
            foreach (Profiles Profile in ProfileList)
            {

                if (Profile.QuickMenu)
                {
                    SortedList.Add(Profile.ProfName);
                }
            }

            //Add the sorted lsit and check the current profile
            SortedList.Sort();
            foreach (string ProfileName in SortedList)
            {
                ProfileSub = new MenuItem();
                ProfileSub.Text = ProfileName;
                ProfileSub.RadioCheck = true;
                if (CurrentProfile.ProfName == ProfileName) ProfileSub.Checked = true;
                ProfileSub.Click += new EventHandler(ProfileSelected);
                QuickMenu.MenuItems.Add(ProfileSub);

            }

        }

        private void CloseApp(object sender, EventArgs e)
        {
            
            RealClose = true;
            Application.Exit();
        }

        private void ProfileSelected(object sender, EventArgs e)
        {
            //Runs when a new Profile is selected in the Context menu
            MenuItem QuickSelected = ((MenuItem)sender);
            string SelectedItem = QuickSelected.Text;
            ProfileSearcher Searcher = new ProfileSearcher();

            //Set the Menu Item Checked.
            QuickSelected.Checked = true;

            //Find the selected Profile and load its Keymap
            SelectProfile(SelectedItem);
            //Moved code to a central function for 1.4
            //CurrentProfile = Searcher.ProfileSearchByName(ProfileList, SelectedItem);
            //LoadButtonsfromProfile(CurrentProfile.ProfName);
            //ProfileManuallySelected = true;
            //ApplyKeySet();

        }

        private void SaveButtonstoProfile(string ProfileName)
        {
            //Save the Keymap to .pgm in the Profile folder
            System.IO.FileStream fs = new System.IO.FileStream(Globals.ProfileSavePath + ProfileName + ".pgm", System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);
            UsedToSaveProgramSetv2 temp = new UsedToSaveProgramSetv2(KeyMaps);
            UsedToSaveProgramSetv2.Write(fs, temp);
            fs.Close();
        }

        private void LoadButtonsfromProfile(string ProfileName)
        {
            //Check for currently Toggled Keys, if any, KeyUp them before changing profiles
            if(Bags.CheckForToggle())
            {
                DebugLog.Instance.writeLog("Found Keys currently pressed, Upping those keys", true);
                Bags.UpAllKeys();
            }
            
            //Load the Keymap from the .pgm file for this profile
            if (System.IO.File.Exists(Globals.ProfileSavePath + ProfileName + ".pgm"))
            {
                System.IO.FileStream fs = new System.IO.FileStream(Globals.ProfileSavePath + ProfileName + ".pgm", System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Read);
                LoadFromStream(fs);
                mFileName = fs.Name;
                fs.Close();
                DebugLog.Instance.writeLog("Profile Keyset Loaded from profile: " + ProfileName, true);
            }
            else
            {
                //File doesn't exist, If application Active, Error to user, if not error to log file
                FormWindowState CurrentState = WindowState;
                if (CurrentState != FormWindowState.Minimized)
                {
                    //Form isn't minimized, popup message
                    if (ProfileName != DefGlobalProf) { MessageBox.Show("Error loading Key Mappings for profile " + ProfileName + ". Loading Defaults.", "", MessageBoxButtons.OK); }
                    SaveButtonstoProfile(ProfileName);
                }
                else
                {
                    //Form is minimized, log error
                    DebugLog.Instance.writeLog("Error loading Key Mappings for profile " + ProfileName + ". Loading Defaults.", true);
                }

            }
        }

        private void SaveProfiles()
        {
            //Save the current Profile List to the Dx1Profiles.dat
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(ms, ProfileList);
            byte[] ba = ms.ToArray();
            System.IO.FileStream fs = new System.IO.FileStream(Globals.ProfileSavePath + "Dx1Profiles.dat", System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);
            fs.Write(ba.ToArray(), 0, ba.Length);
            fs.Close();
            ms.Close();
            ba = null;
        }

        private List<Profiles> LoadProfiles(string fileName)
        {
            //Load the Profile List from the Dx1Profiles.dat
            if (System.IO.File.Exists(fileName))
            {
                System.IO.FileStream fs = new System.IO.FileStream(fileName, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Read);
                System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
                long TotalBytes = new System.IO.FileInfo(fileName).Length;
                byte[] ba = br.ReadBytes((Int32)TotalBytes);
                fs.Close();
                br.Close();

                System.IO.MemoryStream ms = new System.IO.MemoryStream(ba);
                IFormatter formatter = new BinaryFormatter();
                ms.Position = 0;

                List<Profiles> programSet = (List<Profiles>)formatter.Deserialize(ms);

                ms.Close();

                return programSet;
            }
            else
            {
                //File doesn't exist, create a new Profile List
                List<Profiles> programset = new List<Profiles>();

                //Add Default Global Profile
                InitKeyMap(ref KeyMaps);
                CurrentProfile = new Profiles();
                CurrentProfile.ProfName = DefGlobalProf;
                SaveButtonstoProfile(CurrentProfile.ProfName);

                programset.Add(CurrentProfile);
                return programset;
            }

        }

        private void ReBuildKeyMap()
        {
            //Refresh the DataGridView
            if (!this.G_KeyMap.InvokeRequired)
            {
                G_KeyMap.AutoGenerateColumns = false;
                G_KeyMap.DataSource = null;
                G_KeyMap.DataSource = KeyMaps;
            }

        }

        // Various Click things
        private void button1_Click(object sender, EventArgs e)
        {          
            //Turn on Quick Programming
            mKeyProgrammer.Active = !mKeyProgrammer.Active;
            B_QuickPrg.Text = "Programming";
            if (!mKeyProgrammer.Active) 
            {
                StopQuickProgram();
            }
        }

        private void StopQuickProgram()
        {
            //Code to stop Quick programming when something else occurs outside of Quick programming
            mKeyProgrammer.Active = false;
            B_QuickPrg.Text = "Quick Program";
            SaveButtonstoProfile(CurrentProfile.ProfName);
        }

        private void LoadFromStream(System.IO.Stream inStream)
        {
            UsedToSaveProgramSetv2 temp = UsedToSaveProgramSetv2.Read(inStream);
            
            KeyMaps = temp.keyMaps;
            ReBuildKeyMap();
            mKeyProgrammer = new KeyProgrammer(ref KeyMaps);
        }

        String GetUniqueMacroName()
        {
            int index = 1;
            String name = "Macro" + index;
            while (mMacros.ContainsKey(name))
            {
                name = "Macro" + (++index);
            }
            return name;
        }

        private void InitKeyMap(ref List<KeyMap> KeyMaps)
        {
            //Default Key Map
            int TempKey;
            
            //Clear current KeyMap if any
            KeyMaps = new List<KeyMap>();

            for (int i = 0; i < kMaxKeys; i++ )
            {
                TempKey = i+1;
                KeyMap NewKey = new KeyMap();
                NewKey.Dx1Key = (byte)(TempKey);
                NewKey.Action = 0;
                NewKey.Action = 0;
                NewKey.Description = "Unassigned";
                KeyMaps.Add(NewKey);
            }

        }

        private void EditMacros_Click(object sender, EventArgs e)
        {

            MacroPlayer.MacroDefinition macroEdited = null;

            int item = MacroList.SelectedIndex;
            if (item == -1)
                return;

            String name = MacroList.SelectedItem.ToString();
            if (item != 0)
                macroEdited = mMacros[name];
            else
            {
                macroEdited = new MacroPlayer.MacroDefinition(null);
                macroEdited.name = GetUniqueMacroName();
            }
            MacroEditor edit = new MacroEditor();
            edit.RebuildFromMacroDefinition(macroEdited);
            if (edit.ShowDialog() == DialogResult.OK)
            {
                macroEdited = edit.GetMacroDefinition();
                if (macroEdited.name.Length > 0)
                {
                    System.IO.FileStream stream = new System.IO.FileStream(Globals.macroDir + macroEdited.name + ".mac", System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);
                    MacroPlayer.MacroDefinition.Write(stream, macroEdited);
                    stream.Close();
                }

            }
            RebuildMacroList();
        }

        private void MacroList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mKeyProgrammer.Active)
            {
                int index = MacroList.SelectedIndex;
                if (index != 0 && index != -1)
                {
                    mKeyProgrammer.AssignMacro(MacroList.SelectedItem.ToString(), ref KeyMaps);
                    B_QuickPrg.Text = "Programming";
                    G_KeyMap.Invalidate();
                }

            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            Activate();
        }

        private void EditProfile(string ProfiletoEdit)
        {
            DialogResult PPropAnswer;
            bool bNewProfile = false;
            bool clearProfile = false;
            ProfileSearcher Searcher = new ProfileSearcher();

            //Disable App Change timer, so CurrentProfile doesn't get edited
            appFocusCheckTimer.Enabled = false;

            //Cannot Edit (Global) Profile
            if (ProfiletoEdit == DefGlobalProf)
            {
                MessageBox.Show("Cannot Edit the Global Profile's properties", "", MessageBoxButtons.OK);
                return;
            }

            //Determine if creating a new Profile or editing an existing profile
            ProfileProperties PProp = new ProfileProperties();
            if (ProfiletoEdit == DefCreateProf)
            {
                bNewProfile = true;
                CurrentProfile.ProfName = "New";
                PProp.EditProfile(CurrentProfile);
            }
            else
            {
                //Find the Selected profile and pass its options to the PProp Dialog
                CurrentProfile = Searcher.ProfileSearchByName(ProfileList, V_Profiles.Text);

                PProp.EditProfile(CurrentProfile);
            }
            
            //Determine return and either creat a new Prifile in the list, or edit the existing
            PPropAnswer = PProp.ShowDialog();
            if (PPropAnswer == DialogResult.OK)
            {
                //Select the recently edited profile
                if (bNewProfile)
                {
                    //Check to ensure profile name doesn't already exist
                    if (Searcher.ProfileSearchByName(ProfileList, PProp.GetProfileNameOnly()) != null)
                    {
                        //Profile already exists, do not create this profile
                        MessageBox.Show("This Profile Name already exists, please edit that profile.  Changes cancelled.", "", MessageBoxButtons.OK);
                        V_Profiles.Text = DefCreateProf;
                    }
                    else
                    {
                        //Create a new Profile of the detail in the PProp dialog
                        V_Profiles.Items.Add(PProp.GetEditedProfile(ref CurrentProfile, ref clearProfile));
                        V_Profiles.Text = CurrentProfile.ProfName;
                        ProfileList.Add(CurrentProfile);
                        if (clearProfile)
                        {
                            //Create all keys as Unassigned
                            InitKeyMap(ref KeyMaps);
                            SaveButtonstoProfile(CurrentProfile.ProfName);
                            ReBuildKeyMap();
                        }
                        else
                        {
                            //Save current keyset to new profile
                            SaveButtonstoProfile(CurrentProfile.ProfName);
                        }
                    }

                }
                else
                {
                    //Update the Profile that was selected already
                    PProp.GetEditedProfile(ref CurrentProfile, ref clearProfile);
                    if (clearProfile)
                    {
                        //Clear all the currently programmed keys on this profile
                        InitKeyMap(ref KeyMaps);
                        SaveButtonstoProfile(CurrentProfile.ProfName);
                    }
                }

            }
            else
            {
                //Cancel was pressed, check to see if we were creating a new profile
                //If so, switch to the Global Profile
                if (bNewProfile) { SelectProfile(DefGlobalProf); }
            }
            

            //Save Profile List
            SaveProfiles();

            //reenable App Change timer
            appFocusCheckTimer.Enabled = true;

        }


        private void B_EditProfile_Click(object sender, EventArgs e)
        {
            EditProfile(V_Profiles.Text);
        }


        private void V_Profiles_SelectionChangeCommitted(object sender, EventArgs e)
        {
            StopQuickProgram();
            //ProfileSearcher Searcher = new ProfileSearcher();
            if (V_Profiles.SelectedItem.ToString() != DefCreateProf)
            {
                SelectProfile(V_Profiles.SelectedItem.ToString());
                G_KeyMap.Invalidate();
            }
            else
            {
                //Set Current Profile to Blank
                CurrentProfile = new Profiles();
                EditProfile(V_Profiles.SelectedItem.ToString());
            }
            ProfileManuallySelected = true;

            //Set Focus to Grid
            G_KeyMap.Focus();
        }

        private bool SelectProfile(string profileName)
        {
            //Find the specified Profile and load its Keymap
            ProfileSearcher Searcher = new ProfileSearcher();

            CurrentProfile = Searcher.ProfileSearchByName(ProfileList, profileName);
            LoadButtonsfromProfile(CurrentProfile.ProfName);
            ProfileManuallySelected = true;
            ReBuildKeyMap();
            if (DX1UtilityActive)
            { V_Profiles.Text = CurrentProfile.ProfName; }
            else
            { ApplyKeySet(); }
            return true;

        }

        private void C_Debug_CheckedChanged(object sender, EventArgs e)
        {
            Globals.debugLog = C_Debug.Checked;
            if (C_Debug.Checked)
            {
                //Add Header detail to log file
                DebugLog.Instance.writeLog("*******************");
                DebugLog.Instance.writeLog("Debug Logging initialized");
                DebugLog.Instance.writeLog("*******************");
                DebugLog.Instance.writeLog("", true);
            }

        }

        private void B_Delete_Click(object sender, EventArgs e)
        {
            //Delete Profile
            DialogResult ProfConfirm;

            //Cannot Edit (Global) Profile
            if (V_Profiles.Text == DefGlobalProf)
            {
                MessageBox.Show("Cannot Delete the Global Profile", "", MessageBoxButtons.OK);
                return;
            }

            ProfConfirm = MessageBox.Show("Are you sure you want to delete this profile and its related Keymap (" + V_Profiles.Text + ".pgm)?", "", MessageBoxButtons.YesNo);
            if (ProfConfirm == DialogResult.Yes)
            {
                //Delete the file if it exists
                if (System.IO.File.Exists(Globals.ProfileSavePath + V_Profiles.Text + ".pgm"))
                {
                    System.IO.File.Delete(Globals.ProfileSavePath + V_Profiles.Text + ".pgm");
                }

                ProfileList.RemoveAll((x) => x.ProfName == V_Profiles.Text);
                V_Profiles.Items.Remove(V_Profiles.Text);
                SaveProfiles();
                SelectProfile(DefGlobalProf);
                G_KeyMap.Invalidate();

            }

        }

        private void G_KeyMap_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Force selection of the row that was clicked on no matter which mouse button
            if (e.RowIndex >= 0)
            {
                G_KeyMap.CurrentCell = G_KeyMap.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void G_KeyMap_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //Sets Differing formatting based on Cell contents
            if (e.Value == "Unassigned")
            {
                //Grey out text if unnassigned
                e.CellStyle.ForeColor = Color.Gray;
            }
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Used to override the Close control box to minimize the form instead
            if (!RealClose)
            {
                e.Cancel = true;
                HideMinimized = true;
                this.WindowState = FormWindowState.Minimized;
            }
            else
            {
                //Check for currently Toggled Keys, if any, KeyUp them before changing profiles
                if (Bags.CheckForToggle())
                {
                    DebugLog.Instance.writeLog("Found Keys currently pressed, Upping those keys", true);
                    Bags.UpAllKeys();
                }
                DebugLog.Instance.closeFile();
            }

        }

        //ToolStrip Menu controls for DataGrid
        private void programToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Run Key Programming Wizard
            DialogResult KeyWizardAnswer;
            byte CurrentKey = (byte)(G_KeyMap.CurrentRow.Index + 1);

            StopQuickProgram();

            //Right-Click Menu of DataGrid, Program
            ProgramWizard KeyWizard = new ProgramWizard();
            KeyWizard.InitProgramWizard(SpecialKeyPlayer, (byte)CurrentKey);
            KeyWizardAnswer = KeyWizard.ShowDialog();

            if (KeyWizardAnswer == DialogResult.OK)
            {
                //Wizard completed with "Finish", reprogram this key
                KeyMaps[CurrentKey - 1] = KeyWizard.WizardResult();
                
                //Not needed with new GetKeyMap code
                //DX1 Single Key Program
                //int offset = (CurrentKey - 1) * 3;
                //mKeyMap[offset++] = CurrentKey;
                //mKeyMap[offset++] = KeyMaps[CurrentKey].Type;
                //mKeyMap[offset++] = KeyMaps[CurrentKey].Action;

                SaveButtonstoProfile(CurrentProfile.ProfName);
                ReBuildKeyMap();
            }


        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Clearing Dx1Key programming
            byte CurrentKey = (byte)(G_KeyMap.CurrentRow.Index);

            StopQuickProgram();

            KeyMaps[CurrentKey].Action = 0;
            KeyMaps[CurrentKey].Type = 0;
            KeyMaps[CurrentKey].Description = "Unassigned";
            KeyMaps[CurrentKey].MacroName = "";
            KeyMaps[CurrentKey].KeyName = "";
            KeyMaps[CurrentKey].CustomData = "";
            SaveButtonstoProfile(CurrentProfile.ProfName);
            ReBuildKeyMap();
        }

        private void PropertiesStripMenuItem_Click(object sender, EventArgs e)
        {
            //Directly displaying the properties of the key
            DialogResult KeyWizardAnswer;
            byte CurrentKey = (byte)(G_KeyMap.CurrentRow.Index);

            StopQuickProgram();

            ProgramWizard KeyWizard = new ProgramWizard();
            KeyWizard.InitKeyProperties(KeyMaps[CurrentKey]);
            KeyWizardAnswer = KeyWizard.ShowDialog();

            if (KeyWizardAnswer == DialogResult.OK)
            {
                //For now, only Description can be changed using the Properties, so only get that change
                KeyMaps[CurrentKey].Description = KeyWizard.WizardResult().Description;
                SaveButtonstoProfile(CurrentProfile.ProfName);
                ReBuildKeyMap();

            }

        }

    }
}
