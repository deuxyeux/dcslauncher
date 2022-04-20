using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DCSLauncher
{
    class Utils
    {
        public static void AddOrUpdateAppSettings(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing settings!");
            }
        }
        public static void DeleteTracks()
        {
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["DeleteTracks"]))
            {
                string DCSSavedGamesPathBase = (ConfigurationManager.AppSettings["DCSSavedGamesPathBase"]);
                int DeleteTracksDays = Convert.ToInt32(ConfigurationManager.AppSettings["DeleteTracksDays"]);
                try
                {
                    string TrackDirectory = DCSSavedGamesPathBase + @"\Tracks";
                    string[] files = Directory.GetFiles(TrackDirectory);
                    foreach (string file in files)
                    {
                        FileInfo fi = new FileInfo(file);
                        if (fi.LastWriteTime < DateTime.Now.AddDays(-DeleteTracksDays))
                        {
                            Console.WriteLine("Deleted " + Path.GetFileName(file));
                            fi.Delete();
                        }
                    }
                }
                catch 
                {
                    Console.WriteLine("Can't find Tracks directory!");                
                }
            }
        }
        public static void DeleteTacview()
        {
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["DeleteTacview"]))
            {
                int DeleteTracksDays = Convert.ToInt32(ConfigurationManager.AppSettings["DeleteTracksDays"]);
                try
                {
                    string TacviewPath = KnownFolders.GetPath(KnownFolder.Documents) + @"\Tacview\";
                    string[] files = Directory.GetFiles(TacviewPath);
                    foreach (string file in files)
                    {
                        FileInfo fi = new FileInfo(file);
                        if (fi.LastWriteTime < DateTime.Now.AddDays(-DeleteTracksDays))
                        {
                            Console.WriteLine("Deleted " + Path.GetFileName(file));
                            fi.Delete();
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("Can't find Tacview directory!");
                }
            }
        }
        public static void DCSLocalVersion()
        {
            try
            {
                string DCSPath = Convert.ToString(ConfigurationManager.AppSettings["DCSPath"]);
                string VariantFile = DCSPath + "\\dcs_variant.txt";
                Regex Build = new Regex("\\d\\d\\d\\d\\d+", RegexOptions.IgnoreCase);
                FileVersionInfo DCSVersionInfo = FileVersionInfo.GetVersionInfo(Convert.ToString(ConfigurationManager.AppSettings["DCSPath"]) + "\\bin\\DCS.exe");
                Form1.Globals.DCSLocalVersion = DCSVersionInfo.ProductVersion;
                string DCSLocalVersionBuild = Convert.ToString(Build.Match(Form1.Globals.DCSLocalVersion));
                Form1.Globals.DCSLocalVersionBuild = DCSLocalVersionBuild;
                if (File.Exists(VariantFile))
                {
                    string DCSVariant = File.ReadAllText(VariantFile);
                    Form1.Globals.DCSLocalVariant = DCSVariant;
                    //Console.WriteLine("Local DCS version: "+DCSVersionInfo.ProductVersion+" "+DCSVariant);
                }
                else
                {
                    Form1.Globals.DCSLocalVariant = "";
                    //Console.WriteLine("Local DCS version: " + DCSVersionInfo.ProductVersion+");
                }
            }
            catch
            {
                Form1.Globals.DCSLocalVersion = "";
                Console.WriteLine("Error getting local DCS version!");
            }
        }
        public static void DCSRemoteVersion()
        {
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["UpdateCheck"]))
            {
                var url = "http://updates.digitalcombatsimulator.com/";
                var client = new WebClient();
                using (var stream = client.OpenRead(url))
                using (var reader = new StreamReader(stream))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (ConfigurationManager.AppSettings["DCSVersion"] == "openbeta")
                        {
                            var OBReg = new Regex("<h2>Current openbeta is <a href='https://www\\.digitalcombatsimulator\\.com/en/news/changelog/openbeta/([0-9]+(\\.[0-9]+)+)/'>([0-9]+(\\.[0-9]+)+)</a></h2>", RegexOptions.IgnoreCase | RegexOptions.Multiline);
                            string OBVersion = OBReg.Match(line).Groups[1].Value;
                            if (OBVersion != "")
                            {
                                string dcs_ob_version = OBVersion;
                                Regex Build = new Regex("\\d\\d\\d\\d\\d+", RegexOptions.IgnoreCase);
                                Form1.Globals.DCSRemoteVersion = dcs_ob_version;
                                Form1.Globals.DCSRemoteVersionBuild = Convert.ToString(Build.Match(Form1.Globals.DCSRemoteVersion));
                                Form1.Globals.DCSRemoteVariant = "openbeta";
                                //Console.WriteLine("Latest DCS version: " + dcs_ob_version + " openbeta");
                            }
                        }
                        if (ConfigurationManager.AppSettings["DCSVersion"] == "release")
                        {
                            var RelReg = new Regex("<h2>Latest stable version is <a href='https://www\\.digitalcombatsimulator\\.com/en/news/changelog/openbeta/([0-9]+(\\.[0-9]+)+)/'>([0-9]+(\\.[0-9]+)+)</a></h2>", RegexOptions.IgnoreCase | RegexOptions.Multiline);
                            string RelVersion = RelReg.Match(line).Groups[1].Value;
                            if (RelVersion != "")
                            {
                                string dcs_rel_version = RelVersion;
                                Regex Build = new Regex("\\d\\d\\d\\d\\d+", RegexOptions.IgnoreCase);
                                Form1.Globals.DCSRemoteVersion = dcs_rel_version;
                                Form1.Globals.DCSRemoteVersionBuild = Convert.ToString(Build.Match(Form1.Globals.DCSRemoteVersion));
                                Form1.Globals.DCSRemoteVariant = "release";
                                //Console.WriteLine("Latest DCS version: " + dcs_rel_version + " release");
                            }
                        }
                    }
                }
            }
        }
        public static void DCSCpuPriority()
        {
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["CpuPriority"]))
            {
                string keyName = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\DCS.exe\PerfOptions";
                RegistryKey key = Registry.LocalMachine.CreateSubKey(keyName);
                key.SetValue("CpuPriorityClass", "00000003", RegistryValueKind.DWord);
                Console.WriteLine("Setting DCS CPU Priority to High...");
            }
            else
            {
                string keyName = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\";
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(keyName, true))
                {
                    key.DeleteSubKeyTree("DCS.exe", false);
                }
            }
        }
        public static void DCSPowerPlanHighPerformance()
        {
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["PowerPlan"]))
            {
                PowerPlan.SetHighPerformancePowerPlan();
                Console.WriteLine("Setting Power Plan to High Performance...");
            }
        }
        public static void DCSPowerPlanBalanced()
        {
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["PowerPlan"]))
            {
                PowerPlan.SetBalancedPowerPlan();
                Console.WriteLine("Setting Power Plan to Balanced...");
            }
        }
        public static void GPUOverclock()
        {
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["GPUOverclock"]))
            {
                string NvidiaInspectorPath = (ConfigurationManager.AppSettings["NvidiaInspectorPath"]);

                int BaseClockOffset = Convert.ToInt32(ConfigurationManager.AppSettings["BaseClockOffset"]);
                int MemoryClockOffset = Convert.ToInt32(ConfigurationManager.AppSettings["MemoryClockOffset"]);
                int PowerTarget = Convert.ToInt32(ConfigurationManager.AppSettings["PowerTarget"]);
                decimal LockVoltagePoint = Convert.ToDecimal(ConfigurationManager.AppSettings["LockVoltagePoint"]);
                bool LockVoltagePointEnable = Convert.ToBoolean(ConfigurationManager.AppSettings["LockVoltagePointEnable"]);
                int TempTarget = Convert.ToInt32(ConfigurationManager.AppSettings["TempTarget"]);
                bool TempTargetEnable = Convert.ToBoolean(ConfigurationManager.AppSettings["TempTargetEnable"]);
                bool TempPrioritize = Convert.ToBoolean(ConfigurationManager.AppSettings["TempPrioritize"]);

                string BaseClockOffsetArg = " -setBaseClockOffset:0,0," + BaseClockOffset;
                string MemoryClockOffsetArg = " -setMemoryClockOffset:0,0," + MemoryClockOffset;
                string LockVoltagePointArg = " -lockVoltagePoint:" + LockVoltagePoint;
                string PowerTargetArg = " -setPowerTarget:0," + PowerTarget;
                string TempTargetArg = "";

                if (TempPrioritize && TempTargetEnable)
                {
                    TempTargetArg = " -setTempTarget:0,1," + TempTarget;
                }
                if (!TempPrioritize && TempTargetEnable)
                {
                    TempTargetArg = " -setTempTarget:0,0," + TempTarget;
                }
                if (!LockVoltagePointEnable)
                {
                    LockVoltagePointArg = "";
                }
                ProcessStartInfo startInfo = new();
                startInfo.CreateNoWindow = false;
                startInfo.UseShellExecute = false;
                startInfo.FileName = NvidiaInspectorPath;
                startInfo.Arguments = BaseClockOffsetArg + MemoryClockOffsetArg + LockVoltagePointArg + PowerTargetArg + TempTargetArg;
                startInfo.WindowStyle = ProcessWindowStyle.Normal;
                try
                {
                    Console.WriteLine("Applying GPU overclocks...");
                    Process.Start(startInfo);
                }
                catch
                {
                    Console.WriteLine("Error applying GPU overclocks!");
                }
            }
        }
        public static void GPUOverclockReset()
        {
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["GPUOverclock"]))
            {
                string NvidiaInspectorPath = (ConfigurationManager.AppSettings["NvidiaInspectorPath"]);

                ProcessStartInfo startInfo = new();
                startInfo.CreateNoWindow = false;
                startInfo.UseShellExecute = false;
                startInfo.FileName = NvidiaInspectorPath;
                startInfo.Arguments = "-restoreAllPStates:0 -setBaseClockOffset:0,0,0 -setMemoryClockOffset:0,0,0 -setPowerTarget:0,100";
                startInfo.WindowStyle = ProcessWindowStyle.Normal;
                try
                {
                    Console.WriteLine("Resetting GPU overclocks...");
                    Process.Start(startInfo);
                }
                catch
                {
                    Console.WriteLine("Error resetting GPU overclocks!");
                }
            }
        }
        public class ControlWriter : TextWriter
        {
            private readonly Control textbox;
            public ControlWriter(Control textbox)
            {
                this.textbox = textbox;
            }

            public override void Write(char value)
            {
                textbox.Text += value;
            }

            public override void Write(string value)
            {
                textbox.Text += value;
            }

            public override Encoding Encoding
            {
                get { return Encoding.ASCII; }
            }
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        internal static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int y, int cx, int cy, int wFlags);
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        internal static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        internal static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        [DllImport("user32.dll")]
        internal static extern bool GetClientRect(IntPtr hWnd, out RECT lpRect);
        [DllImport("user32.dll")]
        internal static extern IntPtr SendMessage(IntPtr hWnd, uint msg, int wParam, int lParam);
        public static void RefreshTrayArea()
        {
            IntPtr systemTrayContainerHandle = FindWindow("Shell_TrayWnd", null);
            IntPtr systemTrayHandle = FindWindowEx(systemTrayContainerHandle, IntPtr.Zero, "TrayNotifyWnd", null);
            IntPtr sysPagerHandle = FindWindowEx(systemTrayHandle, IntPtr.Zero, "SysPager", null);
            IntPtr notificationAreaHandle = FindWindowEx(sysPagerHandle, IntPtr.Zero, "ToolbarWindow32", "Notification Area");
            if (notificationAreaHandle == IntPtr.Zero)
            {
                notificationAreaHandle = FindWindowEx(sysPagerHandle, IntPtr.Zero, "ToolbarWindow32", "User Promoted Notification Area");
                IntPtr notifyIconOverflowWindowHandle = FindWindow("NotifyIconOverflowWindow", null);
                IntPtr overflowNotificationAreaHandle = FindWindowEx(notifyIconOverflowWindowHandle, IntPtr.Zero, "ToolbarWindow32", "Overflow Notification Area");
                RefreshTrayArea(overflowNotificationAreaHandle);
            }
            RefreshTrayArea(notificationAreaHandle);
        }
        public static void RefreshTrayArea(IntPtr windowHandle)
        {
            const uint wmMousemove = 0x0200;
            GetClientRect(windowHandle, out RECT rect);
            for (var x = 0; x < rect.right; x += 5)
                for (var y = 0; y < rect.bottom; y += 5)
                    SendMessage(windowHandle, wmMousemove, 0, (y << 16) + x);
        }
    }
}
