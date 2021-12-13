using DCSLauncher.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using System.Threading;
using System.Windows.Forms;

namespace DCSLauncher
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        internal static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int y, int cx, int cy, int wFlags);
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        internal static extern IntPtr SendMessage(IntPtr hWnd, uint msg, int wParam, int lParam);
        public Form1()
        {
            InitializeComponent();
            Console.SetOut(new Utils.ControlWriter(LogBox));
            DCSPathCheck();
            SavedGamesPathCheck();
            SettingsLoad();
            FolderDetect();
            NoUtilsDetect();
            Utils.DeleteTracks();
            Utils.DeleteTacview();
            Utils.DCSVersion();
            FSRDetect();
            DCSRunningCheck();
            StartDeviceCheck();
        }
        public void SettingsLoad()
        {
            Globals.SavedGamesPath = KnownFolders.GetPath(KnownFolder.SavedGames) + @"\";
            bool TrackIR = Convert.ToBoolean(ConfigurationManager.AppSettings["TrackIR"]);
            bool VoiceAttack = Convert.ToBoolean(ConfigurationManager.AppSettings["VoiceAttack"]);
            bool SimShaker = Convert.ToBoolean(ConfigurationManager.AppSettings["SimShaker"]);
            bool OpenTrack = Convert.ToBoolean(ConfigurationManager.AppSettings["OpenTrack"]);
            bool Helios = Convert.ToBoolean(ConfigurationManager.AppSettings["Helios"]);
            bool VRMode = Convert.ToBoolean(ConfigurationManager.AppSettings["VRMode"]);
            int DCSStartTime = Convert.ToInt32(ConfigurationManager.AppSettings["DCSStartTime"]);
            progressBar1.Maximum = DCSStartTime;
            if (Convert.ToString(ConfigurationManager.AppSettings["TrackIRPath"]) == "")
            {
                pictureBox_TrackIR.Visible = false;
            }
            else
            {
                pictureBox_TrackIR.Visible = true;
            }
            if (Convert.ToString(ConfigurationManager.AppSettings["VoiceAttackPath"]) == "")
            {
                pictureBox_VoiceAttack.Visible = false;
            }
            else
            {
                pictureBox_VoiceAttack.Visible = true;
            }
            if (Convert.ToString(ConfigurationManager.AppSettings["SimShakerPath"]) == "")
            {
                pictureBox_SimShaker.Visible = false;
            }
            else
            {
                pictureBox_SimShaker.Visible = true;
            }
            if (Convert.ToString(ConfigurationManager.AppSettings["OpenTrackPath"]) == "")
            {
                pictureBox_OpenTrack.Visible = false;
            }
            else
            {
                pictureBox_OpenTrack.Visible = true;
            }
            if (Convert.ToString(ConfigurationManager.AppSettings["HeliosPath"]) == "")
            {
                pictureBox_Helios.Visible = false;
            }
            else
            {
                pictureBox_Helios.Visible = true;
            }
            if (TrackIR)
            {
                pictureBox_TrackIR.Image = Bitmap.FromHicon(new Icon(Properties.Resources.TrackIR_Enabled, new Size(48, 48)).Handle);
            }
            else
            {
                pictureBox_TrackIR.Image = Bitmap.FromHicon(new Icon(Properties.Resources.TrackIR_Disabled, new Size(48, 48)).Handle);
            }

            if (VoiceAttack)
            {
                pictureBox_VoiceAttack.Image = Bitmap.FromHicon(new Icon(Properties.Resources.VoiceAttack_Enabled, new Size(48, 48)).Handle);
            }
            else
            {
                pictureBox_VoiceAttack.Image = Bitmap.FromHicon(new Icon(Properties.Resources.VoiceAttack_Disabled, new Size(48, 48)).Handle);
            }

            if (SimShaker)
            {
                pictureBox_SimShaker.Image = Bitmap.FromHicon(new Icon(Properties.Resources.SimShaker_Enabled, new Size(48, 48)).Handle);
            }
            else
            {
                pictureBox_SimShaker.Image = Bitmap.FromHicon(new Icon(Properties.Resources.SimShaker_Disabled, new Size(48, 48)).Handle);
            }
            if (OpenTrack)
            {
                pictureBox_OpenTrack.Image = Bitmap.FromHicon(new Icon(Properties.Resources.OpenTrack_Enabled, new Size(48, 48)).Handle);
            }
            else
            {
                pictureBox_OpenTrack.Image = Bitmap.FromHicon(new Icon(Properties.Resources.OpenTrack_Disabled, new Size(48, 48)).Handle);
            }
            if (Helios)
            {
                pictureBox_Helios.Image = Bitmap.FromHicon(new Icon(Properties.Resources.Helios_Enabled, new Size(48, 48)).Handle);
            }
            else
            {
                pictureBox_Helios.Image = Bitmap.FromHicon(new Icon(Properties.Resources.Helios_Disabled, new Size(48, 48)).Handle);
            }
            if (Convert.ToString(ConfigurationManager.AppSettings["DCSSavedGamesPathBase"]) == "")
            {
                this.radioButton_FlatscreenMode.Enabled = false;
            }
            else
            {
                this.radioButton_FlatscreenMode.Enabled = true;
            }
            if (Convert.ToString(ConfigurationManager.AppSettings["DCSSavedGamesPathVR"]) == "")
            {
                this.radioButton_VRMode.Enabled = false;
                radioButton_FlatscreenMode.Checked = true;
            }
            else
            {
                this.radioButton_VRMode.Enabled = true;
            }
            if (VRMode)
            {
                this.radioButton_VRMode.Checked = true;
            }
            else
            {
                radioButton_FlatscreenMode.Checked = true;
            }
        }
        public void DCSPathCheck()
        {
            if (Convert.ToString(ConfigurationManager.AppSettings["DCSPath"]) == "")
            {
                MessageBox.Show(new Form { TopMost = true }, "You need to select DCS Main Installation folder", "DCS Main Installation folder", MessageBoxButtons.OK, MessageBoxIcon.Question);
                folderBrowserDialog1.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\";
                folderBrowserDialog1.Description = "Select main DCS World Installation Folder";
                DialogResult result = folderBrowserDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Utils.AddOrUpdateAppSettings("DCSPath", folderBrowserDialog1.SelectedPath);
                }
            }
        }
        public void SavedGamesPathCheck()
        {
            if (Convert.ToString(ConfigurationManager.AppSettings["DCSSavedGamesPathBase"]) == "")
            {
                MessageBox.Show(new Form { TopMost = true }, "You need to select DCS Base Saved Games folder", "DCS Base Saved Games folder", MessageBoxButtons.OK, MessageBoxIcon.Question);
                folderBrowserDialog1.SelectedPath = KnownFolders.GetPath(KnownFolder.SavedGames) + @"\";
                folderBrowserDialog1.Description = "Select DCS Base Saved Games folder";
                DialogResult result = folderBrowserDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Utils.AddOrUpdateAppSettings("DCSSavedGamesPathBase", folderBrowserDialog1.SelectedPath);
                }
            }
        }
        public static class Globals
        {
            public static bool FSRDetected { get; set; }
            public static bool ControllersDetected { get; set; }
            public static bool HMDDetected { get; set; }
            public static string SavedGamesPath { get; set; }
        }
        public void FSRDetect()
        {
            string DCSPath = Convert.ToString(ConfigurationManager.AppSettings["DCSPath"]);
            string FSRConfigFile = DCSPath + "\\bin\\openvr_mod.cfg";
            try
            {
                FileVersionInfo OpenVRVersionInfo = FileVersionInfo.GetVersionInfo(DCSPath + "\\bin\\openvr_api.dll");
                if (OpenVRVersionInfo.ProductName == null && File.Exists(FSRConfigFile))
                {
                    Console.WriteLine("OpenVR FSR mod detected...");
                    Globals.FSRDetected = true;
                }
                else
                {
                    Globals.FSRDetected = false;
                }
            }
            catch
            {

            }
        }
        public void NoUtilsDetect()
        {
            if (Convert.ToString(ConfigurationManager.AppSettings["TrackIRPath"]) == "" &&
                Convert.ToString(ConfigurationManager.AppSettings["VoiceAttackPath"]) == "" &&
                Convert.ToString(ConfigurationManager.AppSettings["SimShakerPath"]) == "" &&
                Convert.ToString(ConfigurationManager.AppSettings["OpenTrackPath"]) == "" &&
                Convert.ToString(ConfigurationManager.AppSettings["HeliosPath"]) == "")
            {
                label_NoUtils.Visible = true;
            }
            else
            {
                label_NoUtils.Visible = false;
            }
        }
        public void FolderDetect()
        {
            if (Convert.ToString(ConfigurationManager.AppSettings["DCSPath"]) == "")
            {
                Console.WriteLine("DCS Main folder not specified!");
                button_Start.Enabled = false;
            }
            if (Convert.ToString(ConfigurationManager.AppSettings["DCSSavedGamesPathBase"]) == "")
            {
                Console.WriteLine("DCS Saved Games folder not specified!");
                button_Start.Enabled = false;
            }
            else
            {
                button_Start.Enabled = true;
            }
        }
        public void DCSRunningCheck()
        {
            Process[] dcs = Process.GetProcessesByName("DCS");
            if (dcs.Length != 0)
            {
                Console.WriteLine("DCS already running...");
                button_Start.Enabled = false;
                if (WaitForDCSStop.IsBusy != true)
                {
                    WaitForDCSStop.RunWorkerAsync();
                }
            }
        }
        public void StartDeviceCheck()
        {
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["DeviceStatusCheck"]))
            {
                if (!File.Exists("Controllers.txt"))
                {
                    File.Create("Controllers.txt").Dispose();
                }
                if (!File.Exists("HMD.txt"))
                {
                    File.Create("HMD.txt").Dispose();
                }
                if (new FileInfo("Controllers.txt").Length != 0 || new FileInfo("HMD.txt").Length != 0)
                {
                    Console.WriteLine("Starting background device checking...");
                    groupBox_Devices.Visible = true;
                    if (DeviceStatusCheck.IsBusy != true)
                    {
                        DeviceStatusCheck.RunWorkerAsync();
                    }
                }
            }
            else
            {
                groupBox_Devices.Visible = false;
            }
        }
        public void StopDeviceCheck()
        {
            DeviceStatusCheck.CancelAsync();
            checkBox1.Text = "Controllers";
            checkBox1.ForeColor = Color.Gray;
            checkBox1.Checked = false;
            checkBox1.Enabled = false;
            checkBox2.Text = "HMD";
            checkBox2.ForeColor = Color.Gray;
            checkBox2.Checked = false;
            checkBox2.Enabled = false;
        }
        public void StartApplications()
        {
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["TrackIR"]) == true)
            {
                if (this.radioButton_FlatscreenMode.Checked)
                {
                    Starters.StartTrackIR();
                }
            }
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["VoiceAttack"]) == true)
            {
                Starters.StartVoiceAttack();
            }
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["SimShaker"]) == true)
            {
                Starters.StartSimShaker();
                if (Convert.ToBoolean(ConfigurationManager.AppSettings["MinimizeJetseat"]))
                {
                    if (MinimizeJetSeatHandler.IsBusy != true)
                    {
                        MinimizeJetSeatHandler.RunWorkerAsync();
                    }
                }
            }
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["OpenTrack"]) == true)
            {
                if (this.radioButton_FlatscreenMode.Checked)
                {
                    Starters.StartOpenTrack();
                }
            }
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["Helios"]) == true)
            {
                if (this.radioButton_FlatscreenMode.Checked)
                {
                    Starters.StartHelios();
                }
            }
            if (this.radioButton_VRMode.Checked)
            {
                Starters.StartSteamVR();
                if (Convert.ToBoolean(ConfigurationManager.AppSettings["PiTool"]) == true)
                {
                    if (MinimizePiTool.IsBusy != true)
                    {
                        MinimizePiTool.RunWorkerAsync();
                    }
                }
            }
        }
        public static void StopApplications()
        {
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["TrackIR"]) == true)
            {
                Starters.StopTrackIR();
            }
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["VoiceAttack"]) == true)
            {
                Starters.StopVoiceAttack();
            }
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["SimShaker"]) == true)
            {
                Starters.StopSimShaker();
            }
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["Helios"]) == true)
            {
                Starters.StopHelios();
            }
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["AutoCloseSRS"]) == true)
            {
                Starters.StopSRS();
            }
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["VRMode"]) == true)
            {
                StopSteamVR();
            }
        }
        public void StartDCS_Flatscreen()
        {
            string DCSPath = Convert.ToString(ConfigurationManager.AppSettings["DCSPath"]);
            ProcessStartInfo startInfo = new();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.FileName = DCSPath + @"\bin\DCS.exe";
            startInfo.WindowStyle = ProcessWindowStyle.Normal;
            try
            {
                Console.WriteLine("Starting DCS World in Flatscreen Mode...");
                Process.Start(startInfo);
                if (WaitForDCSStart.IsBusy != true)
                {
                    WaitForDCSStart.RunWorkerAsync();
                }
            }
            catch
            {
                Console.WriteLine("Error starting DCS World!");
            }
        }
        public void StartDCS_VR()
        {
            string DCSPath = Convert.ToString(ConfigurationManager.AppSettings["DCSPath"]);
            string DCSSavedGamesPathVR = Convert.ToString(ConfigurationManager.AppSettings["DCSSavedGamesPathVR"]);
            var dirName = new DirectoryInfo(DCSSavedGamesPathVR).Name;
            string VRType = "";
            if (Convert.ToString(ConfigurationManager.AppSettings["VRType"]) == "Automatic")
                VRType = "";
            if (Convert.ToString(ConfigurationManager.AppSettings["VRType"]) == "SteamVR")
                VRType = " --force_steam_VR";
            if (Convert.ToString(ConfigurationManager.AppSettings["VRType"]) == "Varjo")
                VRType = " --force_varjo_VR";
            ProcessStartInfo startInfo = new();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.FileName = DCSPath + @"\bin\DCS.exe";
            startInfo.Arguments = "-w \""+dirName+"\""+VRType;
            startInfo.WindowStyle = ProcessWindowStyle.Normal;
            try
            {
                Console.WriteLine("Starting DCS World in VR Mode...");
                Process.Start(startInfo);
                if (WaitForDCSStart.IsBusy != true)
                {
                    WaitForDCSStart.RunWorkerAsync();
                }
            }
            catch
            {
                Console.WriteLine("Error starting DCS World!");
            }
        }
        public void MoveDCS()
        {
            Process[] workers = Process.GetProcessesByName("DCS");
            foreach (Process worker in workers)
            {
                int DCSPosX = Convert.ToInt32(ConfigurationManager.AppSettings["DCSPosX"]);
                int DCSPosY = Convert.ToInt32(ConfigurationManager.AppSettings["DCSPosY"]);
                int DCSWidth = Convert.ToInt32(ConfigurationManager.AppSettings["DCSWidth"]);
                int DCSHeight = Convert.ToInt32(ConfigurationManager.AppSettings["DCSHeight"]);
                bool DCSReposition = Convert.ToBoolean(ConfigurationManager.AppSettings["DCSReposition"]);
                bool DCSResize = Convert.ToBoolean(ConfigurationManager.AppSettings["DCSResize"]);
                bool ApplyToFlatscreen = Convert.ToBoolean(ConfigurationManager.AppSettings["ApplyToFlatscreen"]);
                bool ApplyToVR = Convert.ToBoolean(ConfigurationManager.AppSettings["ApplyToVR"]);
                const int SWP_SHOWWINDOW = 0x0040;
                const short SWP_NOMOVE = 0X2;
                const short SWP_NOSIZE = 1;
                const short SWP_NOZORDER = 0X4;
                if (radioButton_FlatscreenMode.Checked && ApplyToFlatscreen)
                {
                    if (DCSReposition && worker.MainWindowTitle.Equals("Digital Combat Simulator"))
                    {
                        Console.WriteLine("Repositioning DCS window...");
                        Form1.SetWindowPos(worker.MainWindowHandle, 0, DCSPosX, DCSPosY, DCSWidth, DCSHeight, SWP_SHOWWINDOW | SWP_NOSIZE | SWP_NOZORDER);
                    }
                    if (DCSResize && worker.MainWindowTitle.Equals("Digital Combat Simulator"))
                    {
                        Console.WriteLine("Resizing DCS window...");
                        Form1.SetWindowPos(worker.MainWindowHandle, 0, DCSPosX, DCSPosY, DCSWidth, DCSHeight, SWP_SHOWWINDOW | SWP_NOMOVE | SWP_NOZORDER);
                    }
                }
                if (radioButton_VRMode.Checked && ApplyToVR)
                {
                    if (DCSReposition && worker.MainWindowTitle.Equals("Digital Combat Simulator"))
                    {
                        Console.WriteLine("Repositioning DCS window...");
                        Form1.SetWindowPos(worker.MainWindowHandle, 0, DCSPosX, DCSPosY, DCSWidth, DCSHeight, SWP_SHOWWINDOW | SWP_NOSIZE | SWP_NOZORDER);
                    }
                    if (DCSResize && worker.MainWindowTitle.Equals("Digital Combat Simulator"))
                    {
                        Console.WriteLine("Resizing DCS window...");
                        Form1.SetWindowPos(worker.MainWindowHandle, 0, DCSPosX, DCSPosY, DCSWidth, DCSHeight, SWP_SHOWWINDOW | SWP_NOMOVE | SWP_NOZORDER);
                    }
                }
            }
        }
        public static void MoveSteamVR()
        {
            Process[] workers = Process.GetProcessesByName("vrmonitor");
            foreach (Process worker in workers)
            {
                int SteamVRPosX = Convert.ToInt32(ConfigurationManager.AppSettings["SteamVRPosX"]);
                int SteamVRPosY = Convert.ToInt32(ConfigurationManager.AppSettings["SteamVRPosY"]);
                bool SteamVRReposition = Convert.ToBoolean(ConfigurationManager.AppSettings["SteamVRReposition"]);
                const int SWP_SHOWWINDOW = 0x0040;
                const short SWP_NOSIZE = 1;
                const short SWP_NOZORDER = 0X4;
                if (SteamVRReposition)
                {
                    Form1.SetWindowPos(worker.MainWindowHandle, 0, SteamVRPosX, SteamVRPosY, 0, 0, SWP_SHOWWINDOW | SWP_NOSIZE | SWP_NOZORDER);
                }
            }
        }
        public static void MoveOnStart()
        {
            Process[] steamvrprocs = Process.GetProcessesByName("vrmonitor");
            foreach (Process steamvrproc in steamvrprocs)
            {
                int SteamVRStartupPosX = Convert.ToInt32(ConfigurationManager.AppSettings["SteamVRPosX"]);
                int SteamVRStartupPosY = Convert.ToInt32(ConfigurationManager.AppSettings["SteamVRPosY"]);
                const int SWP_SHOWWINDOW = 0x0040;
                const short SWP_NOSIZE = 1;
                const short SWP_NOZORDER = 0X4;
                Form1.SetWindowPos(steamvrproc.MainWindowHandle, 0, SteamVRStartupPosX, SteamVRStartupPosY, 0, 0, SWP_SHOWWINDOW | SWP_NOSIZE | SWP_NOZORDER);
            }
        }
        public void MoveSplash()
        {
            Process[] dcsprocs = Process.GetProcessesByName("DCS");
            foreach (Process dcsproc in dcsprocs)
            {
                int SplashPosX = Convert.ToInt32(ConfigurationManager.AppSettings["SplashPosX"]);
                int SplashPosY = Convert.ToInt32(ConfigurationManager.AppSettings["SplashPosY"]);
                int SplashWidth = Convert.ToInt32(ConfigurationManager.AppSettings["SplashWidth"]);
                int SplashHeight = Convert.ToInt32(ConfigurationManager.AppSettings["SplashHeight"]);
                bool SplashReposition = Convert.ToBoolean(ConfigurationManager.AppSettings["SplashReposition"]);
                bool ApplyToFlatscreen = Convert.ToBoolean(ConfigurationManager.AppSettings["ApplyToFlatscreen"]);
                bool ApplyToVR = Convert.ToBoolean(ConfigurationManager.AppSettings["ApplyToVR"]);
                const int SWP_SHOWWINDOW = 0x0040;
                const short SWP_NOSIZE = 1;
                const short SWP_NOZORDER = 0X4;
                if (radioButton_FlatscreenMode.Checked && ApplyToFlatscreen)
                {
                    if (SplashReposition && dcsproc.MainWindowTitle.Equals("Loading..."))
                    {
                        Console.WriteLine("Repositioning splash window...");
                        Form1.SetWindowPos(dcsproc.MainWindowHandle, 0, SplashPosX, SplashPosY, SplashWidth, SplashHeight, SWP_SHOWWINDOW | SWP_NOSIZE | SWP_NOZORDER);
                    }
                }
                if (radioButton_VRMode.Checked && ApplyToVR)
                {
                    if (SplashReposition && dcsproc.MainWindowTitle.Equals("Loading..."))
                    {
                        Console.WriteLine("Repositioning splash window...");
                        Form1.SetWindowPos(dcsproc.MainWindowHandle, 0, SplashPosX, SplashPosY, SplashWidth, SplashHeight, SWP_SHOWWINDOW | SWP_NOSIZE | SWP_NOZORDER);
                    }
                }
            }
        }
        public static void StopSteamVR()
        {
            bool LighthouseControl = Convert.ToBoolean(ConfigurationManager.AppSettings["LighthouseControl"]);
            bool PiTool = Convert.ToBoolean(ConfigurationManager.AppSettings["PiTool"]);
            bool PiServiceControl = Convert.ToBoolean(ConfigurationManager.AppSettings["PiServiceControl"]);
            Process[] workers = Process.GetProcessesByName("vrmonitor");
            foreach (Process worker in workers)
            {
                worker.CloseMainWindow();
                worker.WaitForExit(1000 * 10);
                worker.Dispose();
                Utils.RefreshTrayArea();
                if ((Process.GetProcessesByName("vrmonitor")).Length != 0)
                {
                    Process[] vrmonitors = Process.GetProcessesByName("vrmonitor");
                    foreach (Process vrmonitor in vrmonitors)
                    {
                        vrmonitor.Kill();
                        Console.WriteLine("SteamVR monitor killed...");
                        Utils.RefreshTrayArea();
                    }
                }
                if ((Process.GetProcessesByName("vrserver")).Length != 0)
                {
                    Process[] vrservers = Process.GetProcessesByName("vrserver");
                    foreach (Process vrserver in vrservers)
                    {
                        vrserver.Kill();
                        Console.WriteLine("SteamVR server killed...");
                        Utils.RefreshTrayArea();
                    }
                }
                if ((Process.GetProcessesByName("steamtours")).Length != 0)
                {
                    Process[] steamtours = Process.GetProcessesByName("steamtours");
                    foreach (Process steamtour in steamtours)
                    {
                        steamtour.Kill();
                        Console.WriteLine("SteamVR tours killed...");
                        Utils.RefreshTrayArea();
                    }
                }
                else
                {
                    Console.WriteLine("SteamVR stopped...");
                }
                if (LighthouseControl)
                {
                    Console.WriteLine("Turning off lighthouses...");
                    Form3.LHBControl("off");
                }
                if (PiTool)
                {
                    Process[] pitoolworkers = Process.GetProcessesByName("PiTool");
                    foreach (Process pitoolworker in pitoolworkers)
                    {
                        pitoolworker.Kill();
                        pitoolworker.WaitForExit(1000 * 2);
                        pitoolworker.Dispose();
                        Utils.RefreshTrayArea();
                        Console.WriteLine("PiTool stopped...");
                    }
                    if ((Process.GetProcessesByName("PiService")).Length != 0)
                    {
                        Process[] piservices = Process.GetProcessesByName("PiService");
                        foreach (Process piservice in piservices)
                        {
                            piservice.Kill();
                            Console.WriteLine("PiService killed...");
                        }
                    }
                    if ((Process.GetProcessesByName("pi_server")).Length != 0)
                    {
                        Process[] piservers = Process.GetProcessesByName("pi_server");
                        foreach (Process piserver in piservers)
                        {
                            piserver.Kill();
                            Console.WriteLine("pi_server killed...");
                        }
                    }
                    if ((Process.GetProcessesByName("pi_overlay")).Length != 0)
                    {
                        Process[] pioverlays = Process.GetProcessesByName("pi_overlay");
                        foreach (Process pioverlay in pioverlays)
                        {
                            pioverlay.Kill();
                            Console.WriteLine("pi_overlay killed...");
                        }
                    }
                }
                if (PiServiceControl)
                {
                    ServiceController sc = new ServiceController();
                    sc.ServiceName = "PiServiceLauncher";

                    if (sc.Status == ServiceControllerStatus.Running)
                    {
                        Console.WriteLine("Stopping PiServiceLauncher service...");
                        try
                        {
                            sc.Stop();
                            sc.WaitForStatus(ServiceControllerStatus.Stopped);
                        }
                        catch (InvalidOperationException)
                        {
                            Console.WriteLine("Could not stop PiServiceLauncher service!");
                        }
                    }
                }
            }
        }
        public void StopDCS()
        {
            Console.WriteLine("Stopping DCS World...");
            Process[] workers = Process.GetProcessesByName("DCS");
            foreach (Process worker in workers)
            {
                worker.Kill();
                worker.WaitForExit(1000 * 2);
                worker.Dispose();
                Console.WriteLine("DCS World stopped...");
                this.Text = ("DCS Launcher [DCS stopped]");
            }
        }
        private void VRMode_CheckedChanged(object sender, EventArgs e)
        {
            Utils.AddOrUpdateAppSettings("VRMode", "true");
        }
        private void FlatscreenMode_CheckedChanged(object sender, EventArgs e)
        {
            Utils.AddOrUpdateAppSettings("VRMode", "false");
        }
        private void LogBox_TextChanged(object sender, EventArgs e)
        {
            LogBox.SelectionStart = LogBox.Text.Length;
            LogBox.ScrollToCaret();
        }
        private void Start_Click(object sender, EventArgs e)
        {
            bool TrackIR = Convert.ToBoolean(ConfigurationManager.AppSettings["TrackIR"]);
            bool VoiceAttack = Convert.ToBoolean(ConfigurationManager.AppSettings["VoiceAttack"]);
            bool SimShaker = Convert.ToBoolean(ConfigurationManager.AppSettings["SimShaker"]);
            bool Helios = Convert.ToBoolean(ConfigurationManager.AppSettings["Helios"]);
            bool VRMode = Convert.ToBoolean(ConfigurationManager.AppSettings["VRMode"]);
            bool FlatscreenMode = Convert.ToBoolean(ConfigurationManager.AppSettings["FlatscreenMode"]);
            bool MinimizeJetSeat = Convert.ToBoolean(ConfigurationManager.AppSettings["MinimizeJetSeat"]);
            Utils.DCSCpuPriority();
            Utils.DCSPowerPlanHighPerformance();
            Utils.GPUOverclock();
            StartApplications();
            if (this.radioButton_FlatscreenMode.Checked)
            {
                StartDCS_Flatscreen();
            }
            if (this.radioButton_VRMode.Checked)
            {
                if (WaitForSteamVR.IsBusy != true)
                {
                    WaitForSteamVR.RunWorkerAsync();
                }
                StartDCS_VR();
            }
            if (WaitForSplash.IsBusy != true)
            {
                WaitForSplash.RunWorkerAsync();
            }
            StopDeviceCheck();
            button_Start.Enabled = false;
        }
        private void Stop_Click(object sender, EventArgs e)
        {
            Process[] pname = Process.GetProcessesByName("DCS");
            if (pname.Length == 0)
            {
                StopApplications();
                Utils.DCSPowerPlanBalanced();
                Utils.GPUOverclockReset();
                StopDeviceCheck();
                WaitForDCSStart.CancelAsync();
                button_Stop.Enabled = false;
            }
            else
            {
                string box_msg = "DCS World is still running! Are you sure you want to close everything?";
                string box_title = "Confirmation";
                var selectedOption = MessageBox.Show(box_msg, box_title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (selectedOption == DialogResult.Yes)
                {
                    StopApplications();
                    Utils.DCSPowerPlanBalanced();
                    Utils.GPUOverclockReset();
                    StopDCS();
                    button_Start.Enabled = true;
                    button_Stop.Enabled = false;
                }
            }
        }
        private void Misc_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f is Form4)
                {
                    f.Focus();
                    return;
                }
            }
            Form4 f4 = new();
            f4.FormClosing += new FormClosingEventHandler(ChildFormClosing);
            f4.Show();
        }
        private void Settings_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f is Form2)
                {
                    f.Focus();
                    return;
                }
            }
            Form2 f2 = new();
            f2.FormClosing += new FormClosingEventHandler(ChildFormClosing);
            f2.Show();
        }
        private void ChildFormClosing(object sender, FormClosingEventArgs e)
        {
            SettingsLoad();
            FolderDetect();
            NoUtilsDetect();
            StartDeviceCheck();
        }
        private void WaitForDCSStart_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            int i = 0;
            int p = 0;
            while (i == 0)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    Thread.Sleep(1000);
                    p++;
                    worker.ReportProgress(p);
                    Process[] procs = Process.GetProcessesByName("DCS");
                    foreach (Process proc in procs)
                    {
                        if (proc.MainWindowTitle.Equals("Digital Combat Simulator"))
                        {
                            i = 1;
                            break;
                        }
                    }
                }
            }
        }
        private void WaitForDCSStart_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.Text = ("DCS Launcher [Starting: " + e.ProgressPercentage.ToString() + " seconds]");
            Form1.DCSTime = (e.ProgressPercentage);
            if (e.ProgressPercentage <= progressBar1.Maximum)
            {
                progressBar1.Value = (e.ProgressPercentage);
            }
            else
            {
                progressBar1.Value = progressBar1.Maximum;
            }
        }
        public static int DCSTime { get; set; }
        private void WaitForDCSStart_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                this.Text = "Canceled!";
            }
            else if (e.Error != null)
            {
                this.Text = "Error: " + e.Error.Message;
            }
            else
            {
                this.Text = ("DCS Launcher [DCS started]");
                Console.WriteLine("DCS World has started in " + Form1.DCSTime + " seconds...");
                Utils.AddOrUpdateAppSettings("DCSStartTime", Convert.ToString(Form1.DCSTime));
                progressBar1.Value = progressBar1.Maximum;
                button_Stop.Enabled = true;
                MoveDCS();
                MoveSteamVR();
                WaitForDCSStop.RunWorkerAsync();
            }
        }
        private void WaitForDCSStop_DoWork(object sender, DoWorkEventArgs e)
        {
            int i = 0;
            while (i == 0)
            {
                System.Threading.Thread.Sleep(1000);
                Process[] pname = Process.GetProcessesByName("DCS");
                if (pname.Length == 0)
                {
                    break;
                }
            }
        }
        private void WaitForDCSStop_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Console.WriteLine("DCS World has exited...");
            this.Text = ("DCS Launcher [DCS stopped]");
            progressBar1.Value = 0;
            StopApplications();
            Utils.DCSPowerPlanBalanced();
            Utils.GPUOverclockReset();
            button_Start.Enabled = true;
            button_Stop.Enabled = false;
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["DeviceStatusCheck"]))
            {
                if (!File.Exists("Controllers.txt"))
                {
                    File.Create("Controllers.txt").Dispose();
                }
                if (!File.Exists("HMD.txt"))
                {
                    File.Create("HMD.txt").Dispose();
                }
                StartDeviceCheck();
            }
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["AutoClose"]) == true)
            {
                Console.WriteLine("Closing in 10 seconds...");
                    if (AutoClose.IsBusy != true)
                    {
                    AutoClose.RunWorkerAsync();
                    }
            }
        }
        private void AutoClose_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            for (int i = 10; i >= 1; i--)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    Thread.Sleep(1000);
                    worker.ReportProgress(i);
                }
            }
        }
        private void AutoClose_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.Text = ("DCS Launcher [Closing in: "+e.ProgressPercentage.ToString() + " seconds]");
        }
        private void AutoClose_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Application.Exit();
        }
        private void MinimizeJetSeatHandler_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            int i = 0;
            while (i == 0)
            {
                Thread.Sleep(1000);
                Process[] procs = Process.GetProcessesByName("ibaJetSeatHandler");
                foreach (Process proc in procs)
                {
                    if (proc.MainWindowTitle.Contains("Seat Handler"))
                    {
                        i = 1;
                        IntPtr hwnd = proc.MainWindowHandle;
                        ShowWindow(hwnd, 6);
                        break;
                    }
                }
            }
        }
        private void MinimizePiTool_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            int i = 0;
            int max = Convert.ToInt32(ConfigurationManager.AppSettings["DCSStartTime"]);
            while (i <= max)
            {
                Thread.Sleep(1000);
                Process[] procs = Process.GetProcessesByName("PiTool");
                foreach (Process proc in procs)
                {
                    if (proc.MainWindowTitle.Contains("PiTool"))
                    {
                        i++;
                        IntPtr hwnd = proc.MainWindowHandle;
                        ShowWindow(hwnd, 6);
                    }
                }
            }
        }
        private void WaitForSplash_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            int i = 0;
            while (i == 0)
            {
                Thread.Sleep(50);
                Process[] procs = Process.GetProcessesByName("DCS");
                foreach (Process proc in procs)
                {
                    if (proc.MainWindowTitle.Equals("Loading..."))
                    {
                        i = 1;
                        break;
                    }
                }
            }
        }
        private void WaitForSplash_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Thread.Sleep(100);
            MoveSplash();
        }

        private void WaitForSteamVR_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            int i = 0;
            while (i == 0)
            {
                Thread.Sleep(50);
                Process[] procs = Process.GetProcessesByName("vrmonitor");
                foreach (Process proc in procs)
                {
                    if (proc.MainWindowTitle.Equals("SteamVR Status"))
                    {
                        i = 1;
                        MoveSteamVR();
                        break;
                    }
                }
            }
        }

        private void pictureBox_TrackIR_Click(object sender, EventArgs e)
        {
            bool TrackIR = Convert.ToBoolean(ConfigurationManager.AppSettings["TrackIR"]);
            if (TrackIR)
            {
                Utils.AddOrUpdateAppSettings("TrackIR", "false");
                Console.WriteLine("TrackIR startup disabled...");
                pictureBox_TrackIR.Image = Bitmap.FromHicon(new Icon(Properties.Resources.TrackIR_Disabled, new Size(48, 48)).Handle);
            }
            else
            {
                Utils.AddOrUpdateAppSettings("TrackIR", "true");
                Console.WriteLine("TrackIR startup enabled...");
                pictureBox_TrackIR.Image = Bitmap.FromHicon(new Icon(Properties.Resources.TrackIR_Enabled, new Size(48, 48)).Handle);
                if (Convert.ToBoolean(ConfigurationManager.AppSettings["OpenTrack"]))
                {
                    Console.WriteLine("OpenTrack startup disabled...");
                    Utils.AddOrUpdateAppSettings("OpenTrack", "false");
                    pictureBox_OpenTrack.Image = Bitmap.FromHicon(new Icon(Properties.Resources.OpenTrack_Disabled, new Size(48, 48)).Handle);
                }
            }
        }

        private void pictureBox_VoiceAttack_Click(object sender, EventArgs e)
        {
            bool VoiceAttack = Convert.ToBoolean(ConfigurationManager.AppSettings["VoiceAttack"]);
            if (VoiceAttack)
            {
                Utils.AddOrUpdateAppSettings("VoiceAttack", "false");
                Console.WriteLine("VoiceAttack startup disabled...");
                pictureBox_VoiceAttack.Image = Bitmap.FromHicon(new Icon(Properties.Resources.VoiceAttack_Disabled, new Size(48, 48)).Handle);
            }
            else
            {
                Utils.AddOrUpdateAppSettings("VoiceAttack", "true");
                Console.WriteLine("VoiceAttack startup enabled...");
                pictureBox_VoiceAttack.Image = Bitmap.FromHicon(new Icon(Properties.Resources.VoiceAttack_Enabled, new Size(48, 48)).Handle);
            }
        }

        private void pictureBox_SimShaker_Click(object sender, EventArgs e)
        {
            bool SimShaker = Convert.ToBoolean(ConfigurationManager.AppSettings["SimShaker"]);
            if (SimShaker)
            {
                Utils.AddOrUpdateAppSettings("SimShaker", "false");
                Console.WriteLine("SimShaker startup disabled...");
                pictureBox_SimShaker.Image = Bitmap.FromHicon(new Icon(Properties.Resources.SimShaker_Disabled, new Size(48, 48)).Handle);
            }
            else
            {
                Utils.AddOrUpdateAppSettings("SimShaker", "true");
                Console.WriteLine("SimShaker startup enabled...");
                pictureBox_SimShaker.Image = Bitmap.FromHicon(new Icon(Properties.Resources.SimShaker_Enabled, new Size(48, 48)).Handle);
            }
        }

        private void pictureBox_OpenTrack_Click(object sender, EventArgs e)
        {
            bool OpenTrack = Convert.ToBoolean(ConfigurationManager.AppSettings["OpenTrack"]);
            if (OpenTrack)
            {
                Utils.AddOrUpdateAppSettings("OpenTrack", "false");
                Console.WriteLine("OpenTrack startup disabled...");
                pictureBox_OpenTrack.Image = Bitmap.FromHicon(new Icon(Properties.Resources.OpenTrack_Disabled, new Size(48, 48)).Handle);
            }
            else
            {
                Utils.AddOrUpdateAppSettings("OpenTrack", "true");
                Console.WriteLine("OpenTrack startup enabled...");
                pictureBox_OpenTrack.Image = Bitmap.FromHicon(new Icon(Properties.Resources.OpenTrack_Enabled, new Size(48, 48)).Handle);
                if (Convert.ToBoolean(ConfigurationManager.AppSettings["TrackIR"]))
                {
                    Console.WriteLine("TrackIR startup disabled...");
                    Utils.AddOrUpdateAppSettings("TrackIR", "false");
                    pictureBox_TrackIR.Image = Bitmap.FromHicon(new Icon(Properties.Resources.TrackIR_Disabled, new Size(48, 48)).Handle);
                }
            }
        }

        private void pictureBox_Helios_Click(object sender, EventArgs e)
        {
            bool Helios = Convert.ToBoolean(ConfigurationManager.AppSettings["Helios"]);
            if (Helios)
            {
                Utils.AddOrUpdateAppSettings("Helios", "false");
                Console.WriteLine("Helios startup disabled...");
                pictureBox_Helios.Image = Bitmap.FromHicon(new Icon(Properties.Resources.Helios_Disabled, new Size(48, 48)).Handle);
            }
            else
            {
                Utils.AddOrUpdateAppSettings("Helios", "true");
                Console.WriteLine("Helios startup enabled...");
                pictureBox_Helios.Image = Bitmap.FromHicon(new Icon(Properties.Resources.Helios_Enabled, new Size(48, 48)).Handle);
            }
        }

        private void DeviceStatusCheck_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            int i = 0;
            int p = 0;
            while (i == 0)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    Thread.Sleep(1000);
                    p++;
                    worker.ReportProgress(p);
                }
            }
        }

        private void DeviceStatusCheck_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            TestDevices();
            ButtonLock();
        }

        private void DeviceStatusCheck_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                checkBox1.Text = "Controllers";
                checkBox1.ForeColor = Color.Gray;
                checkBox1.Checked = false;
                checkBox1.Enabled = false;
                checkBox2.Text = "HMD";
                checkBox2.ForeColor = Color.Gray;
                checkBox2.Checked = false;
                checkBox2.Enabled = false;
            }
        }
        public void ButtonLock()
        {
            if (radioButton_FlatscreenMode.Checked)
            {
                if (Globals.ControllersDetected)
                {
                    button_Start.Enabled = true;
                }
                else
                {
                    button_Start.Enabled = false;
                }
            }
            if (radioButton_VRMode.Checked)
            {
                if (Globals.ControllersDetected && Globals.HMDDetected)
                {
                    button_Start.Enabled = true;
                }
                else
                {
                    button_Start.Enabled = false;
                }
            }
        }
        public void TestDevices()
        {
            var list = DeviceCheck.GetUSBDevices();

            string[] Controllers = File.ReadAllLines("Controllers.txt");
            List<object> ControllerList = new List<object>(Controllers);
            var ControllerAvailable = new List<string>();

            string[] HMD = File.ReadAllLines("HMD.txt");
            List<object> HMDList = new List<object>(HMD);
            var HMDAvailable = new List<string>();

            if (new FileInfo("Controllers.txt").Length != 0)
            {
                foreach (var device in list)
                {
                    if (ControllerList.Contains(device.PnpDeviceID))
                    {
                        ControllerAvailable.Add("Exists");
                    }
                }
                if (ControllerAvailable.Count == ControllerList.Count)
                {
                    checkBox1.Enabled = true;
                    checkBox1.Text = "Controllers OK";
                    checkBox1.ForeColor = Color.Green;
                    checkBox1.Checked = true;
                    ControllerAvailable.Clear();
                    Globals.ControllersDetected = true;
                }
                else
                {
                    checkBox1.Enabled = true;
                    checkBox1.Text = "Controllers FAIL";
                    checkBox1.ForeColor = Color.Red;
                    checkBox1.Checked = false;
                    ControllerAvailable.Clear();
                    Globals.ControllersDetected = false;
                }
            }

            if (new FileInfo("HMD.txt").Length != 0)
            {
                foreach (var device in list)
                {
                    if (HMDList.Contains(device.PnpDeviceID))
                    {
                        HMDAvailable.Add("Exists");
                    }
                }
                if (HMDAvailable.Count == HMDList.Count)
                {
                    checkBox2.Enabled = true;
                    checkBox2.Text = "HMD OK";
                    checkBox2.ForeColor = Color.Green;
                    checkBox2.Checked = true;
                    HMDAvailable.Clear();
                    Globals.HMDDetected = true;
                }
                else
                {
                    checkBox2.Enabled = true;
                    checkBox2.Text = "HMD FAIL";
                    checkBox2.ForeColor = Color.Red;
                    checkBox2.Checked = false;
                    HMDAvailable.Clear();
                    Globals.HMDDetected = false;
                }
            }
            else
            {
                Globals.HMDDetected = true;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.RestoreWindowPosition();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.SaveWindowPosition();
        }
        private void RestoreWindowPosition()
        {
            if (Settings.Default.HasSetDefaults)
            {
                this.WindowState = Settings.Default.WindowState;
                this.Location = Settings.Default.Location;
                this.Size = Settings.Default.Size;
            }
        }
        private void SaveWindowPosition()
        {
            Settings.Default.WindowState = this.WindowState;

            if (this.WindowState == FormWindowState.Normal)
            {
                Settings.Default.Location = this.Location;
                Settings.Default.Size = this.Size;
            }
            else
            {
                Settings.Default.Location = this.RestoreBounds.Location;
                Settings.Default.Size = this.RestoreBounds.Size;
            }

            Settings.Default.HasSetDefaults = true;

            Settings.Default.Save();
        }
    }
}