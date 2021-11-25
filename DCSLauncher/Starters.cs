using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace DCSLauncher
{
    class Starters
    {
        public static void StartTrackIR()
        {
            if ((Process.GetProcessesByName("TrackIR5")).Length != 0)
            {
                Console.WriteLine("TrackIR already started...");
            }
            else
            {
                string TrackIRPath = Convert.ToString(ConfigurationManager.AppSettings["TrackIRPath"]);
                ProcessStartInfo startInfo = new();
                startInfo.CreateNoWindow = false;
                startInfo.UseShellExecute = true;
                startInfo.FileName = TrackIRPath;
                startInfo.WindowStyle = ProcessWindowStyle.Normal;
                try
                {
                    using Process exeProcess = Process.Start(startInfo);
                    Console.WriteLine("Starting TrackIR...");
                }
                catch
                {
                    Console.WriteLine("Error starting TrackIR!");
                }
            }
        }
        public static void StartVoiceAttack()
        {
            if ((Process.GetProcessesByName("VoiceAttack")).Length != 0)
            {
                Console.WriteLine("VoiceAttack already started...");
            }
            else
            {
                string VoiceAttackPath = Convert.ToString(ConfigurationManager.AppSettings["VoiceAttackPath"]);
                string VoiceAttackExecutable = Path.GetFileName(VoiceAttackPath);
                ProcessStartInfo startInfo = new();
                startInfo.CreateNoWindow = false;
                startInfo.UseShellExecute = false;
                startInfo.FileName = VoiceAttackPath;
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                try
                {
                    using Process exeProcess = Process.Start(startInfo);
                    if (VoiceAttackExecutable == "VAICOMPRO.exe")
                    {
                        Console.WriteLine("Starting VAICOM PRO...");
                    }
                    else
                    {
                        Console.WriteLine("Starting VoiceAttack...");
                    }
                }
                catch
                {
                    Console.WriteLine("Error starting VoiceAttack!");
                }
            }
        }
        public static void StartSimShaker()
        {
            if ((Process.GetProcessesByName("SimShaker for Aviators")).Length != 0)
            {
                Console.WriteLine("SimShaker already started...");
            }
            else if ((Process.GetProcessesByName("SimShaker for Aviators beta")).Length != 0)
            {
                Console.WriteLine("SimShaker beta already started...");
            }
            else
            {
                ProcessStartInfo startInfo = new();
                startInfo.CreateNoWindow = false;
                startInfo.UseShellExecute = true;
                var fname = Convert.ToString(ConfigurationManager.AppSettings["SimShakerPath"]);
                startInfo.FileName = fname;
                startInfo.WorkingDirectory = Path.GetDirectoryName(fname);
                startInfo.WindowStyle = ProcessWindowStyle.Minimized;
                try
                {
                    using Process exeProcess = Process.Start(startInfo);
                    Console.WriteLine("Starting SimShaker...");
                }
                catch
                {
                    Console.WriteLine("Error starting SimShaker!");
                }
            }
        }
        public static void StartOpenTrack()
        {
            if ((Process.GetProcessesByName("opentrack")).Length != 0)
            {
                Console.WriteLine("Opentrack already started...");
            }
            else
            {
                string HeliosPath = Convert.ToString(ConfigurationManager.AppSettings["OpenTrackPath"]);
                ProcessStartInfo startInfo = new();
                startInfo.CreateNoWindow = false;
                startInfo.UseShellExecute = true;
                startInfo.FileName = HeliosPath;
                startInfo.WindowStyle = ProcessWindowStyle.Normal;
                try
                {
                    using Process exeProcess = Process.Start(startInfo);
                    Console.WriteLine("Starting Opentrack...");
                }
                catch
                {
                    Console.WriteLine("Error starting Opentrack!");
                }
            }
        }
        public static void StartHelios()
        {
            if ((Process.GetProcessesByName("Control Center")).Length != 0)
            {
                Console.WriteLine("Helios already started...");
            }
            else
            {
                string HeliosPath = Convert.ToString(ConfigurationManager.AppSettings["HeliosPath"]);
                ProcessStartInfo startInfo = new();
                startInfo.CreateNoWindow = false;
                startInfo.UseShellExecute = true;
                startInfo.FileName = HeliosPath;
                startInfo.WindowStyle = ProcessWindowStyle.Normal;
                try
                {
                    using Process exeProcess = Process.Start(startInfo);
                    Console.WriteLine("Starting Helios...");
                }
                catch
                {
                    Console.WriteLine("Error starting Helios!");
                }
            }
        }
        public static void StartSteamVR()
        {
            bool PiTool = Convert.ToBoolean(ConfigurationManager.AppSettings["PiTool"]);
            if (PiTool)
            {
                ProcessStartInfo PiToolStartInfo = new();
                PiToolStartInfo.CreateNoWindow = false;
                PiToolStartInfo.UseShellExecute = true;
                PiToolStartInfo.FileName = @"C:\Program Files\Pimax\Runtime\PiTool.exe";
                PiToolStartInfo.WindowStyle = ProcessWindowStyle.Minimized;
                try
                {
                    using Process exeProcess = Process.Start(PiToolStartInfo);
                    Console.WriteLine("Starting PiTool...");
                }
                catch
                {
                    Console.WriteLine("Error starting PiTool!");
                }
            }
            bool PiServiceControl = Convert.ToBoolean(ConfigurationManager.AppSettings["PiServiceControl"]);
            if (PiServiceControl)
            {
                ServiceController sc = new ServiceController();
                sc.ServiceName = "PiServiceLauncher";

                if (sc.Status == ServiceControllerStatus.Stopped)
                {
                    Console.WriteLine("Starting PiServiceLauncher service...");
                    try
                    {
                        sc.Start();
                        sc.WaitForStatus(ServiceControllerStatus.Running);
                    }
                    catch (InvalidOperationException)
                    {
                        Console.WriteLine("Could not start PiServiceLauncher service!");
                    }
                }
            }
            if ((Process.GetProcessesByName("vrmonitor")).Length != 0)
            {
                Console.WriteLine("SteamVR already started...");
            }
            else
            {
                string SteamVRPath = Convert.ToString(ConfigurationManager.AppSettings["SteamVRPath"]);
                ProcessStartInfo startInfo = new();
                startInfo.CreateNoWindow = false;
                startInfo.UseShellExecute = true;
                startInfo.FileName = SteamVRPath + @"\bin\win64\vrstartup.exe";
                startInfo.WindowStyle = ProcessWindowStyle.Minimized;
                try
                {
                    using Process exeProcess = Process.Start(startInfo);
                    Console.WriteLine("Starting SteamVR...");
                }
                catch
                {
                    Console.WriteLine("Error starting SteamVR!");
                }
            }
            bool LighthouseControl = Convert.ToBoolean(ConfigurationManager.AppSettings["LighthouseControl"]);
            if (LighthouseControl)
            {
                Console.WriteLine("Turning on lighthouses...");
                Form3.LHBControl("on");
            }
        }
        public static void StopTrackIR()
        {
            Process[] workers = Process.GetProcessesByName("TrackIR5");
            foreach (Process worker in workers)
            {
                worker.Kill();
                worker.WaitForExit(1000 * 2);
                worker.Dispose();
                Utils.RefreshTrayArea();
                Console.WriteLine("TrackIR stopped...");
            }
        }
        public static void StopVoiceAttack()
        {
            Process[] workers1 = Process.GetProcessesByName("VoiceAttack");
            foreach (Process worker in workers1)
            {
                worker.Kill();
                worker.WaitForExit(1000 * 2);
                worker.Dispose();
                Utils.RefreshTrayArea();
                Console.WriteLine("VoiceAttack stopped...");
            }
            Process[] workers2 = Process.GetProcessesByName("VAICOMPRO");
            foreach (Process worker in workers2)
            {
                worker.Kill();
                worker.WaitForExit(1000 * 2);
                worker.Dispose();
                Utils.RefreshTrayArea();
                Console.WriteLine("VAICOM PRO stopped...");
            }
        }
        public static void StopSimShaker()
        {
            Process[] workers1 = Process.GetProcessesByName("SimShaker for Aviators");
            foreach (Process worker1 in workers1)
            {
                worker1.Kill();
                worker1.WaitForExit(1000 * 2);
                worker1.Dispose();
                Utils.RefreshTrayArea();
                Console.WriteLine("SimShaker stopped...");
            }
            Process[] workers2 = Process.GetProcessesByName("SimShaker for Aviators beta");
            foreach (Process worker2 in workers2)
            {
                worker2.Kill();
                worker2.WaitForExit(1000 * 2);
                worker2.Dispose();
                Utils.RefreshTrayArea();
                Console.WriteLine("SimShaker stopped...");
            }
            Process[] workers3 = Process.GetProcessesByName("ibaJetseatHandler");
            foreach (Process worker3 in workers3)
            {
                worker3.Kill();
                worker3.WaitForExit(1000 * 2);
                worker3.Dispose();
                Console.WriteLine("ibaJetseatHandler stopped...");
            }
        }
        public static void StopHelios()
        {
            Process[] workers = Process.GetProcessesByName("Control Center");
            foreach (Process worker in workers)
            {
                worker.Kill();
                worker.WaitForExit(1000 * 2);
                worker.Dispose();
                Utils.RefreshTrayArea();
                Console.WriteLine("Helios stopped...");
            }
        }
        public static void StopSRS()
        {
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["AutoCloseSRS"]))
            {
                Process[] workers = Process.GetProcessesByName("SR-ClientRadio");
                foreach (Process worker in workers)
                {
                    worker.Kill();
                    worker.WaitForExit(1000 * 2);
                    worker.Dispose();
                    Utils.RefreshTrayArea();
                    Console.WriteLine("SimpleRadio stopped...");
                }
            }
        }
    }
}
