using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace DCSLauncher
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, System.EventArgs e)
        {
            SettingsLoad();

            ToolTip toolTip1 = new();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 250;
            toolTip1.ReshowDelay = 5000;
            toolTip1.ShowAlways = false;
            toolTip1.SetToolTip(checkBox_DCSReposition, "Enable repositioning of DCS main window");
            toolTip1.SetToolTip(numeric_DCSPosX, "Horizontal window position");
            toolTip1.SetToolTip(numeric_DCSPosY, "Vertical window position");
            toolTip1.SetToolTip(checkBox_DCSResize, "Enable resizing of DCS main window");
            toolTip1.SetToolTip(numeric_DCSWidth, "Window width");
            toolTip1.SetToolTip(numeric_DCSHeight, "Window height");
            toolTip1.SetToolTip(checkBox_FSREnable, "[FSR] Enable OpenVR FSR");
            toolTip1.SetToolTip(numeric_FSRRenderScale, "[FSR] Render Scale");
            toolTip1.SetToolTip(numeric_FSRSharpness, "[FSR] Sharpness");
            toolTip1.SetToolTip(numeric_FSRRadius, "[FSR] Radius");
            toolTip1.SetToolTip(checkBox_FSRNIS, "[FSR] Enable NVIDIA Image Scaling instead of AMD FidelityFX");
            toolTip1.SetToolTip(checkBox_FSRMIPBias, "[FSR] Apply negative LOD bias to texture MIP levels");
            toolTip1.SetToolTip(checkBox_FSRDebug, "[FSR] Visualize radius to which FSR is applied");
            toolTip1.SetToolTip(checkBox_SteamVRReposition, "Enable repositioning of SteamVR monitor window");
            toolTip1.SetToolTip(button_TrackIRPath, (ConfigurationManager.AppSettings["TrackIRPath"]));
            toolTip1.SetToolTip(button_VoiceAttackPath, (ConfigurationManager.AppSettings["VoiceAttackPath"]));
            toolTip1.SetToolTip(button_SimShakerPath, (ConfigurationManager.AppSettings["SimShakerPath"]));
            toolTip1.SetToolTip(button_OpenTrackPath, (ConfigurationManager.AppSettings["OpenTrackPath"]));
            toolTip1.SetToolTip(button_HeliosPath, (ConfigurationManager.AppSettings["HeliosPath"]));
        }
        public void SettingsLoad()
        {
            string DCSPath = (ConfigurationManager.AppSettings["DCSPath"]);
            string DCSSavedGamesPathBase = (ConfigurationManager.AppSettings["DCSSavedGamesPathBase"]);
            string DCSSavedGamesPathVR = (ConfigurationManager.AppSettings["DCSSavedGamesPathVR"]);
            bool TrackIR = Convert.ToBoolean(ConfigurationManager.AppSettings["TrackIR"]);
            bool VoiceAttack = Convert.ToBoolean(ConfigurationManager.AppSettings["VoiceAttack"]);
            bool SimShaker = Convert.ToBoolean(ConfigurationManager.AppSettings["SimShaker"]);
            bool OpenTrack = Convert.ToBoolean(ConfigurationManager.AppSettings["OpenTrack"]);
            bool Helios = Convert.ToBoolean(ConfigurationManager.AppSettings["Helios"]);
            bool AutoClose = Convert.ToBoolean(ConfigurationManager.AppSettings["AutoClose"]);
            bool DCSReposition = Convert.ToBoolean(ConfigurationManager.AppSettings["DCSReposition"]);
            bool DCSResize = Convert.ToBoolean(ConfigurationManager.AppSettings["DCSResize"]);
            bool DCSCustomResolution = Convert.ToBoolean(ConfigurationManager.AppSettings["DCSCustomResolution"]);
            int DCSPosX = Convert.ToInt32(ConfigurationManager.AppSettings["DCSPosX"]);
            int DCSPosY = Convert.ToInt32(ConfigurationManager.AppSettings["DCSPosY"]);
            int DCSWidth = Convert.ToInt32(ConfigurationManager.AppSettings["DCSWidth"]);
            int DCSHeight = Convert.ToInt32(ConfigurationManager.AppSettings["DCSHeight"]);
            int CustomResolutionWidth = Convert.ToInt32(ConfigurationManager.AppSettings["CustomResolutionWidth"]);
            int CustomResolutionHeight = Convert.ToInt32(ConfigurationManager.AppSettings["CustomResolutionHeight"]);
            bool SplashReposition = Convert.ToBoolean(ConfigurationManager.AppSettings["SplashReposition"]);
            int SplashPosX = Convert.ToInt32(ConfigurationManager.AppSettings["SplashPosX"]);
            int SplashPosY = Convert.ToInt32(ConfigurationManager.AppSettings["SplashPosY"]);
            int SplashWidth = Convert.ToInt32(ConfigurationManager.AppSettings["SplashWidth"]);
            int SplashHeight = Convert.ToInt32(ConfigurationManager.AppSettings["SplashHeight"]);
            bool ApplyToFlatscreen = Convert.ToBoolean(ConfigurationManager.AppSettings["ApplyToFlatscreen"]);
            bool ApplyToVR = Convert.ToBoolean(ConfigurationManager.AppSettings["ApplyToVR"]);
            bool UseCustomSplash = Convert.ToBoolean(ConfigurationManager.AppSettings["UseCustomSplash"]);
            string CustomSplashPath = (ConfigurationManager.AppSettings["CustomSplashPath"]);
            bool SteamVRReposition = Convert.ToBoolean(ConfigurationManager.AppSettings["SteamVRReposition"]);
            int SteamVRPosX = Convert.ToInt32(ConfigurationManager.AppSettings["SteamVRPosX"]);
            int SteamVRPosY = Convert.ToInt32(ConfigurationManager.AppSettings["SteamVRPosY"]);
            bool FSREnable = Convert.ToBoolean(ConfigurationManager.AppSettings["FSREnable"]);

            decimal FSRRenderScale = Convert.ToDecimal(ConfigurationManager.AppSettings["FSRRenderScale"], new CultureInfo("en-US"));
            decimal FSRSharpness = Convert.ToDecimal(ConfigurationManager.AppSettings["FSRSharpness"], new CultureInfo("en-US"));
            decimal FSRRadius = Convert.ToDecimal(ConfigurationManager.AppSettings["FSRRadius"], new CultureInfo("en-US"));

            bool FSRNIS = Convert.ToBoolean(ConfigurationManager.AppSettings["FSRNIS"]);
            bool FSRMIPBias = Convert.ToBoolean(ConfigurationManager.AppSettings["FSRMIPBias"]);
            bool FSRDebug = Convert.ToBoolean(ConfigurationManager.AppSettings["FSRDebug"]);
            bool MinimizeJetSeat = Convert.ToBoolean(ConfigurationManager.AppSettings["MinimizeJetSeat"]);
            bool DeleteTracks = Convert.ToBoolean(ConfigurationManager.AppSettings["DeleteTracks"]);
            int DeleteTracksDays = Convert.ToInt32(ConfigurationManager.AppSettings["DeleteTracksDays"]);
            bool DeleteTacview = Convert.ToBoolean(ConfigurationManager.AppSettings["DeleteTacview"]);
            bool CpuPriority = Convert.ToBoolean(ConfigurationManager.AppSettings["CpuPriority"]);
            bool PowerPlan = Convert.ToBoolean(ConfigurationManager.AppSettings["PowerPlan"]);
            bool AutoCloseSRS = Convert.ToBoolean(ConfigurationManager.AppSettings["AutoCloseSRS"]);
            bool PiTool = Convert.ToBoolean(ConfigurationManager.AppSettings["PiTool"]);
            bool PiServiceControl = Convert.ToBoolean(ConfigurationManager.AppSettings["PiServiceControl"]);
            bool LighthouseControl = Convert.ToBoolean(ConfigurationManager.AppSettings["LighthouseControl"]);
            bool DeviceStatusCheck = Convert.ToBoolean(ConfigurationManager.AppSettings["DeviceStatusCheck"]);
            bool GPUOverclock = Convert.ToBoolean(ConfigurationManager.AppSettings["GPUOverclock"]);
            string VRType = Convert.ToString(ConfigurationManager.AppSettings["VRType"]);
            textBox_DCSPath.Text = DCSPath;
            textBox_DCSSavedGamesPathBase.Text = DCSSavedGamesPathBase;
            textBox_DCSSavedGamesPathBase.SelectionStart = textBox_DCSSavedGamesPathBase.Text.Length;
            textBox_DCSSavedGamesPathBase.ScrollToCaret();
            textBox_DCSSavedGamesPathVR.Text = DCSSavedGamesPathVR;
            textBox_DCSSavedGamesPathVR.SelectionStart = textBox_DCSSavedGamesPathVR.Text.Length;
            textBox_DCSSavedGamesPathVR.ScrollToCaret();
            checkBox_TrackIR.Checked = TrackIR;
            checkBox_VoiceAttack.Checked = VoiceAttack;
            checkBox_SimShaker.Checked = SimShaker;
            checkBox_OpenTrack.Checked = OpenTrack;
            checkBox_Helios.Checked = Helios;
            checkBox_AutoClose.Checked = AutoClose;
            checkBox_DCSReposition.Checked = DCSReposition;
            checkBox_DCSResize.Checked = DCSResize;
            checkBox_DCSCustomResolution.Checked = DCSCustomResolution;
            checkBox_SplashReposition.Checked = SplashReposition;
            checkBox_FSREnable.Checked = FSREnable;
            checkBox_FSRNIS.Checked = FSRNIS;
            checkBox_FSRMIPBias.Checked = FSRMIPBias;
            checkBox_FSRDebug.Checked = FSRDebug;
            checkBox_ApplyToFlatscreen.Checked = ApplyToFlatscreen;
            checkBox_ApplyToVR.Checked = ApplyToVR;
            numeric_FSRRenderScale.Value = FSRRenderScale;
            numeric_FSRSharpness.Value = FSRSharpness;
            numeric_FSRRadius.Value = FSRRadius;
            checkBox_SteamVRReposition.Checked = SteamVRReposition;
            this.MinimizeJetSeat.Checked = MinimizeJetSeat;
            this.DeleteTracks.Checked = DeleteTracks;
            numeric_DeleteTracksDays.Value = DeleteTracksDays;
            this.DeleteTacview.Checked = DeleteTacview;
            this.CpuPriority.Checked = CpuPriority;
            this.PowerPlan.Checked = PowerPlan;
            this.AutoCloseSRS.Checked = AutoCloseSRS;
            this.PiTool.Checked = PiTool;
            this.PiServiceControl.Checked = PiServiceControl;
            this.LighthouseControl.Checked = LighthouseControl;
            this.DeviceStatusCheck.Checked = DeviceStatusCheck;
            checkBox_GPUOverclock.Checked = GPUOverclock;
            numeric_DCSPosX.Value = DCSPosX;
            numeric_DCSPosY.Value = DCSPosY;
            numeric_DCSWidth.Value = DCSWidth;
            numeric_DCSHeight.Value = DCSHeight;
            numeric_CustomResolutionWidth.Value = CustomResolutionWidth;
            numeric_CustomResolutionHeight.Value = CustomResolutionHeight;
            numeric_SplashPosX.Value = SplashPosX;
            numeric_SplashPosY.Value = SplashPosY;
            numeric_SteamVRPosX.Value = SteamVRPosX;
            numeric_SteamVRPosY.Value = SteamVRPosY;
            if (SimShaker)
            {
                this.MinimizeJetSeat.Enabled = true;
            }
            else
            {
                this.MinimizeJetSeat.Enabled = false;
            }
            if (ConfigurationManager.AppSettings["TrackIRPath"] == "")
            {
                checkBox_TrackIR.Enabled = false;
            }
            if (ConfigurationManager.AppSettings["VoiceAttackPath"] == "")
            {
                checkBox_VoiceAttack.Enabled = false;
            }
            if (ConfigurationManager.AppSettings["SimShakerPath"] == "")
            {
                checkBox_SimShaker.Enabled = false;
            }
            if (ConfigurationManager.AppSettings["OpenTrackPath"] == "")
            {
                checkBox_OpenTrack.Enabled = false;
            }
            if (ConfigurationManager.AppSettings["HeliosPath"] == "")
            {
                checkBox_Helios.Enabled = false;
            }
            if (ConfigurationManager.AppSettings["LighthouseManagerPath"] == "")
            {
                this.LighthouseControl.Enabled = false;
            }
            if (ConfigurationManager.AppSettings["DeviceStatusCheck"] == "")
            {
                this.DeviceStatusCheck.Enabled = false;
            }
            if (ConfigurationManager.AppSettings["GPUOverclock"] == "")
            {
                checkBox_GPUOverclock.Enabled = false;
            }
            if (!DeleteTracks)
            {
                numeric_DeleteTracksDays.Enabled = false;
            }
            if (VRType == "Automatic")
            {
                this.VRTypeAuto.Checked = true;
            }
            else if (VRType == "SteamVR")
            {
                this.VRTypeSteamVR.Checked = true;
            }
            else if (VRType == "WMR")
            {
                this.VRTypeWMR.Checked = true;
            }
            else if (VRType == "Varjo")
            {
                this.VRTypeVarjo.Checked = true;
            }
            if (Form1.Globals.FSRDetected)
            {
                this.checkBox_FSREnable.Enabled = true;
                this.numeric_FSRRenderScale.Enabled = true;
                this.numeric_FSRSharpness.Enabled = true;
                this.numeric_FSRRadius.Enabled = true;
                this.checkBox_FSRNIS.Enabled = true;
                this.checkBox_FSRMIPBias.Enabled = true;
                this.checkBox_FSRDebug.Enabled = true;
            }
        }
        public void FSRConfigUpdate()
        {
            string DCSPath = (ConfigurationManager.AppSettings["DCSPath"]);
            string FSREnable = Convert.ToString(ConfigurationManager.AppSettings["FSREnable"]);
            decimal FSRRenderScale = Convert.ToDecimal(ConfigurationManager.AppSettings["FSRRenderScale"], new CultureInfo("en-US"));
            decimal FSRSharpness = Convert.ToDecimal(ConfigurationManager.AppSettings["FSRSharpness"], new CultureInfo("en-US"));
            decimal FSRRadius = Convert.ToDecimal(ConfigurationManager.AppSettings["FSRRadius"], new CultureInfo("en-US"));
            string FSRNIS = Convert.ToString(ConfigurationManager.AppSettings["FSRNIS"]);
            string FSRMIPBias = Convert.ToString(ConfigurationManager.AppSettings["FSRMIPBias"]);
            string FSRDebug = Convert.ToString(ConfigurationManager.AppSettings["FSRDebug"]);

            string FSRRenderScaleStr = Convert.ToString(FSRRenderScale, System.Globalization.CultureInfo.InvariantCulture);
            string FSRSharpnessStr = Convert.ToString(FSRSharpness, System.Globalization.CultureInfo.InvariantCulture);
            string FSRRadiusStr = Convert.ToString(FSRRadius, System.Globalization.CultureInfo.InvariantCulture);

            StreamWriter writer = null;
            Dictionary<string, string> replacements = new Dictionary<string, string>();
            replacements.Add("\"enabled\":", FSREnable.ToLower());
            replacements.Add("\"useNIS\":", FSRNIS.ToLower());
            replacements.Add("\"renderScale\":", FSRRenderScaleStr);
            replacements.Add("\"sharpness\":", FSRSharpnessStr);
            replacements.Add("\"radius\":", FSRRadiusStr);
            //replacements.Add("\"renderScale\":", FSRRenderScaleStr.Replace(",", "."));
            //replacements.Add("\"sharpness\":", FSRSharpness.Replace(",", "."));
            //replacements.Add("\"radius\":", FSRRadius.Replace(",", "."));
            replacements.Add("\"applyMIPBias\":", FSRMIPBias.ToLower());
            replacements.Add("\"debugMode\":", FSRDebug.ToLower());

            using (writer = File.CreateText(DCSPath+@"\bin\openvr_mod.cfg.tmp"))
            {
                foreach (string line in File.ReadLines(DCSPath + @"\bin\openvr_mod.cfg"))
                {
                    bool replacementMade = false;
                    foreach (var replacement in replacements)
                    {
                        if (line.Contains(replacement.Key))
                        {
                            writer.WriteLine(string.Format("    {0} {1},",
                                replacement.Key, replacement.Value));
                            replacementMade = true;
                            break;
                        }
                    }
                    if (!replacementMade)
                    {
                        writer.WriteLine(line);
                    }
                }
            }
            File.Replace(DCSPath + @"\bin\openvr_mod.cfg.tmp", DCSPath + @"\bin\openvr_mod.cfg", DCSPath + @"\bin\openvr_mod.cfg.bak");
        }
        public void DCSCustomResolutionConfigUpdate()
        {
            string DCSSavedGamesPathBase = ConfigurationManager.AppSettings["DCSSavedGamesPathBase"];
            string DCSSavedGamesPathVR = ConfigurationManager.AppSettings["DCSSavedGamesPathVR"];
            string CustomResolutionWidth = Convert.ToString(ConfigurationManager.AppSettings["CustomResolutionWidth"]);
            string CustomResolutionHeight = Convert.ToString(ConfigurationManager.AppSettings["CustomResolutionHeight"]);

            StreamWriter writer = null;
            Dictionary<string, string> replacements = new Dictionary<string, string>();
            replacements.Add("[\"width\"] =", CustomResolutionWidth);
            replacements.Add("[\"height\"] =", CustomResolutionHeight);

            if (Convert.ToBoolean(ConfigurationManager.AppSettings["ApplyToFlatscreen"]))
            {
                using (writer = File.CreateText(DCSSavedGamesPathBase + @"\Config\options.lua.tmp"))
                {
                    foreach (string line in File.ReadLines(DCSSavedGamesPathBase + @"\Config\options.lua"))
                    {
                        bool replacementMade = false;
                        foreach (var replacement in replacements)
                        {
                            if (line.Contains(replacement.Key))
                            {
                                writer.WriteLine(string.Format("    {0} {1},",
                                    replacement.Key, replacement.Value));
                                replacementMade = true;
                                break;
                            }
                        }
                        if (!replacementMade)
                        {
                            writer.WriteLine(line);
                        }
                    }
                }
                File.Replace(DCSSavedGamesPathBase + @"\Config\options.lua.tmp", DCSSavedGamesPathBase + @"\Config\options.lua", DCSSavedGamesPathBase + @"\Config\options.lua.bak");
            }

            if (Convert.ToBoolean(ConfigurationManager.AppSettings["ApplyToVR"]))
            {
                using (writer = File.CreateText(DCSSavedGamesPathVR + @"\Config\options.lua.tmp"))
                {
                    foreach (string line in File.ReadLines(DCSSavedGamesPathVR + @"\Config\options.lua"))
                    {
                        bool replacementMade = false;
                        foreach (var replacement in replacements)
                        {
                            if (line.Contains(replacement.Key))
                            {
                                writer.WriteLine(string.Format("    {0} {1},",
                                    replacement.Key, replacement.Value));
                                replacementMade = true;
                                break;
                            }
                        }
                        if (!replacementMade)
                        {
                            writer.WriteLine(line);
                        }
                    }
                }
                File.Replace(DCSSavedGamesPathVR + @"\Config\options.lua.tmp", DCSSavedGamesPathVR + @"\Config\options.lua", DCSSavedGamesPathVR + @"\Config\options.lua.bak");
            }
        }
        public void SettingsSave()
        {
            Utils.AddOrUpdateAppSettings("DCSPath", Convert.ToString(textBox_DCSPath.Text));
            Utils.AddOrUpdateAppSettings("DCSSavedGamesPathBase", Convert.ToString(textBox_DCSSavedGamesPathBase.Text));
            Utils.AddOrUpdateAppSettings("DCSSavedGamesPathVR", Convert.ToString(textBox_DCSSavedGamesPathVR.Text));
            Utils.AddOrUpdateAppSettings("TrackIR", Convert.ToString(checkBox_TrackIR.Checked));
            Utils.AddOrUpdateAppSettings("VoiceAttack", Convert.ToString(checkBox_VoiceAttack.Checked));
            Utils.AddOrUpdateAppSettings("SimShaker", Convert.ToString(checkBox_SimShaker.Checked));
            Utils.AddOrUpdateAppSettings("OpenTrack", Convert.ToString(checkBox_OpenTrack.Checked));
            Utils.AddOrUpdateAppSettings("Helios", Convert.ToString(checkBox_Helios.Checked));
            Utils.AddOrUpdateAppSettings("AutoClose", Convert.ToString(checkBox_AutoClose.Checked));
            Utils.AddOrUpdateAppSettings("DCSReposition", Convert.ToString(checkBox_DCSReposition.Checked));
            Utils.AddOrUpdateAppSettings("DCSResize", Convert.ToString(checkBox_DCSResize.Checked));
            Utils.AddOrUpdateAppSettings("DCSCustomResolution", Convert.ToString(checkBox_DCSCustomResolution.Checked));
            Utils.AddOrUpdateAppSettings("DCSPosX", Convert.ToString(numeric_DCSPosX.Value));
            Utils.AddOrUpdateAppSettings("DCSPosY", Convert.ToString(numeric_DCSPosY.Value));
            Utils.AddOrUpdateAppSettings("DCSWidth", Convert.ToString(numeric_DCSWidth.Value));
            Utils.AddOrUpdateAppSettings("DCSHeight", Convert.ToString(numeric_DCSHeight.Value));
            Utils.AddOrUpdateAppSettings("CustomResolutionWidth", Convert.ToString(numeric_CustomResolutionWidth.Value));
            Utils.AddOrUpdateAppSettings("CustomResolutionHeight", Convert.ToString(numeric_CustomResolutionHeight.Value));
            Utils.AddOrUpdateAppSettings("SplashReposition", Convert.ToString(checkBox_SplashReposition.Checked));
            Utils.AddOrUpdateAppSettings("SplashPosX", Convert.ToString(numeric_SplashPosX.Value));
            Utils.AddOrUpdateAppSettings("SplashPosY", Convert.ToString(numeric_SplashPosY.Value));
            Utils.AddOrUpdateAppSettings("SteamVRReposition", Convert.ToString(checkBox_SteamVRReposition.Checked));
            Utils.AddOrUpdateAppSettings("SteamVRPosX", Convert.ToString(numeric_SteamVRPosX.Value));
            Utils.AddOrUpdateAppSettings("SteamVRPosY", Convert.ToString(numeric_SteamVRPosY.Value));
            Utils.AddOrUpdateAppSettings("ApplyToFlatscreen", Convert.ToString(checkBox_ApplyToFlatscreen.Checked));
            Utils.AddOrUpdateAppSettings("ApplyToVR", Convert.ToString(checkBox_ApplyToVR.Checked));
            Utils.AddOrUpdateAppSettings("FSREnable", Convert.ToString(checkBox_FSREnable.Checked));

            string FSRRenderScaleStr = Convert.ToString(numeric_FSRRenderScale.Value, new CultureInfo("en-US"));
            string FSRSharpnessStr = Convert.ToString(numeric_FSRSharpness.Value, new CultureInfo("en-US"));
            string FSRRadiusStr = Convert.ToString(numeric_FSRRadius.Value, new CultureInfo("en-US"));

            Utils.AddOrUpdateAppSettings("FSRRenderScale", FSRRenderScaleStr);
            Utils.AddOrUpdateAppSettings("FSRSharpness", FSRSharpnessStr);
            Utils.AddOrUpdateAppSettings("FSRRadius", FSRRadiusStr);

            Utils.AddOrUpdateAppSettings("FSRNIS", Convert.ToString(checkBox_FSRNIS.Checked));
            Utils.AddOrUpdateAppSettings("FSRMIPBias", Convert.ToString(checkBox_FSRMIPBias.Checked));
            Utils.AddOrUpdateAppSettings("FSRDebug", Convert.ToString(checkBox_FSRDebug.Checked));
            Utils.AddOrUpdateAppSettings("MinimizeJetSeat", Convert.ToString(this.MinimizeJetSeat.Checked));
            Utils.AddOrUpdateAppSettings("DeleteTracks", Convert.ToString(this.DeleteTracks.Checked));
            Utils.AddOrUpdateAppSettings("DeleteTracksDays", Convert.ToString(numeric_DeleteTracksDays.Value));
            Utils.AddOrUpdateAppSettings("DeleteTacview", Convert.ToString(this.DeleteTacview.Checked));
            Utils.AddOrUpdateAppSettings("CpuPriority", Convert.ToString(this.CpuPriority.Checked));
            Utils.AddOrUpdateAppSettings("PowerPlan", Convert.ToString(this.PowerPlan.Checked));
            Utils.AddOrUpdateAppSettings("AutoCloseSRS", Convert.ToString(this.AutoCloseSRS.Checked));
            Utils.AddOrUpdateAppSettings("PiTool", Convert.ToString(this.PiTool.Checked));
            Utils.AddOrUpdateAppSettings("PiServiceControl", Convert.ToString(this.PiServiceControl.Checked));
            Utils.AddOrUpdateAppSettings("LighthouseControl", Convert.ToString(this.LighthouseControl.Checked));
            Utils.AddOrUpdateAppSettings("DeviceStatusCheck", Convert.ToString(this.DeviceStatusCheck.Checked));
            Utils.AddOrUpdateAppSettings("GPUOverclock", Convert.ToString(checkBox_GPUOverclock.Checked));

            if (checkBox_DCSCustomResolution.Checked)
            {
                DCSCustomResolutionConfigUpdate();
            }
            if (VRTypeAuto.Checked)
            {
                Utils.AddOrUpdateAppSettings("VRType", Convert.ToString("Automatic"));
            }
            else if (VRTypeSteamVR.Checked)
            {
                Utils.AddOrUpdateAppSettings("VRType", Convert.ToString("SteamVR"));
            }
            else if (VRTypeWMR.Checked)
            {
                Utils.AddOrUpdateAppSettings("VRType", Convert.ToString("WMR"));
            }
            else if (VRTypeVarjo.Checked)
            {
                Utils.AddOrUpdateAppSettings("VRType", Convert.ToString("Varjo"));
            }
            if (Form1.Globals.FSRDetected)
            {
                FSRConfigUpdate();
            }
        }
        private void DCSPath_Click(object sender, EventArgs e)
        {
            folderBrowserDialog_DCSPath.Description = "Select main DCS World Installation Folder";
            DialogResult result = folderBrowserDialog_DCSPath.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox_DCSPath.Text = folderBrowserDialog_DCSPath.SelectedPath;
            }
        }
        public void Save_Click(object sender, EventArgs e)
        {
            SettingsSave();
            this.Close();
        }
        public void Apply_Click(object sender, EventArgs e)
        {
            SettingsSave();
            if (Form1.Globals.FSRDetected)
            {
                FSRConfigUpdate();
            }

        }
        public Image ResizeWithSameRatio(Image image, float width, float height)
        {
            // the colour for letter boxing, can be a parameter
            var brush = new SolidBrush(Color.Black);

            // target scaling factor
            float scale = Math.Min(width / image.Width, height / image.Height);

            // target image
            var bmp = new Bitmap((int)width, (int)height);
            var graph = Graphics.FromImage(bmp);

            var scaleWidth = (int)(image.Width * scale);
            var scaleHeight = (int)(image.Height * scale);

            // fill the background and then draw the image in the 'centre'
            graph.FillRectangle(brush, new RectangleF(0, 0, width, height));
            graph.DrawImage(image, new Rectangle(((int)width - scaleWidth) / 2, ((int)height - scaleHeight) / 2, scaleWidth, scaleHeight));

            return bmp;
        }
        private void TrackIRPath_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Select TrackIR executable";
            openFileDialog1.Filter = "TrackIR Executable|TrackIR5.exe";
            openFileDialog1.FileName = "TrackIR5.exe";
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + @"\";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string TrackIRPath = openFileDialog1.FileName;
                Utils.AddOrUpdateAppSettings("TrackIRPath", Convert.ToString(TrackIRPath));
                if (openFileDialog1.FileName != "")
                {
                    checkBox_TrackIR.Enabled = true;
                }
            }
        }

        private void VoiceAttackPath_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Select VoiceAttack or VAICOM PRO executable";
            openFileDialog1.Filter = "VoiceAttack Executable|VoiceAttack.exe|VAICOM PRO Executable|VAICOMPRO.exe";
            openFileDialog1.FileName = "VoiceAttack.exe";
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string VoiceAttackPath = openFileDialog1.FileName;
                Utils.AddOrUpdateAppSettings("VoiceAttackPath", Convert.ToString(VoiceAttackPath));
                if (openFileDialog1.FileName != "")
                {
                    checkBox_VoiceAttack.Enabled = true;
                }
            }
        }

        private void SimShakerPath_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Select SimShaker executable";
            openFileDialog1.Filter = "SimShaker Executable|SimShaker for Aviators*.exe";
            openFileDialog1.FileName = "";
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + @"\";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string SimShakerPath = openFileDialog1.FileName;
                Utils.AddOrUpdateAppSettings("SimShakerPath", Convert.ToString(SimShakerPath));
                if (openFileDialog1.FileName != "")
                {
                    checkBox_SimShaker.Enabled = true;
                }
            }
        }
        private void OpenTrackPath_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Select opentrack executable";
            openFileDialog1.Filter = "opentrack Executable|opentrack.exe";
            openFileDialog1.FileName = "opentrack.exe";
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + @"\";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string OpenTrackPath = openFileDialog1.FileName;
                Utils.AddOrUpdateAppSettings("OpenTrackPath", Convert.ToString(OpenTrackPath));
                if (openFileDialog1.FileName != "")
                {
                    checkBox_OpenTrack.Enabled = true;
                }
            }
        }
        private void HeliosPath_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Select Helios Installation Folder";
            openFileDialog1.Filter = "Helios Control Center|Control Center.exe";
            openFileDialog1.FileName = "Control Center.exe";
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string HeliosPath = openFileDialog1.FileName;
                Utils.AddOrUpdateAppSettings("HeliosPath", Convert.ToString(HeliosPath));
                if (openFileDialog1.FileName != "")
                {
                    checkBox_Helios.Enabled = true;
                }
            }
        }
        private void DeleteTracks_CheckedChanged(object sender, EventArgs e)
        {
            if (this.DeleteTracks.Checked)
            {
                this.numeric_DeleteTracksDays.Enabled = true;
            }
            else
            {
                this.numeric_DeleteTracksDays.Enabled = false;
            }
        }
        private void PiTool_CheckedChanged(object sender, EventArgs e)
        {
            if (this.PiTool.Checked)
            {
                this.PiServiceControl.Enabled = false;
                this.PiServiceControl.Checked = false;
            }
            else
            {
                this.PiServiceControl.Enabled = true;
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void ChildFormClosing(object sender, FormClosingEventArgs e)
        {
            SettingsLoad();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f is Form3)
                {
                    f.Focus();
                    return;
                }
            }
            Form3 f3 = new();
            f3.FormClosing += new FormClosingEventHandler(ChildFormClosing);
            f3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            SettingsSave();
            frm1.MoveSplash();
            frm1.MoveDCS();
            Form1.MoveSteamVR();
        }

        private void numeric_SteamVRPosX_ValueChanged(object sender, EventArgs e)
        {

        }
        private void checkBox_TrackIR_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_TrackIR.Checked)
            {
                checkBox_OpenTrack.Checked = false;
                checkBox_OpenTrack.Enabled = false;
            }
            else
            {
                if (ConfigurationManager.AppSettings["OpenTrackPath"] != "")
                {
                checkBox_OpenTrack.Enabled = true;
                }
            }
        }

        private void checkBox_OpenTrack_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_OpenTrack.Checked)
            {
                checkBox_TrackIR.Checked = false;
                checkBox_TrackIR.Enabled = false;
            }
            else
            {
                if (ConfigurationManager.AppSettings["TrackIRPath"] != "")
                {
                    checkBox_TrackIR.Enabled = true;
                }
            }
        }
        private void checkBox_SimShaker_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_SimShaker.Checked)
            {
                this.MinimizeJetSeat.Enabled = true;
            }
            else
            {
                this.MinimizeJetSeat.Enabled = false;
            }
        }

        private void button_DCSSavedGamesPathBaseOpen_Click(object sender, EventArgs e)
        {
            folderBrowserDialog_DCSPath.Description = "Select DCS Base Saved Games Folder";
            folderBrowserDialog_DCSPath.SelectedPath = Form1.Globals.SavedGamesPath;
            DialogResult result = folderBrowserDialog_DCSPath.ShowDialog();
            if (result == DialogResult.OK)
            {
                //var folder = Path.GetFileName(folderBrowserDialog_DCSPath.SelectedPath);
                //textBox_DCSSavedGamesPathBase.Text = folder;
                textBox_DCSSavedGamesPathBase.Text = folderBrowserDialog_DCSPath.SelectedPath;
                textBox_DCSSavedGamesPathBase.SelectionStart = textBox_DCSSavedGamesPathBase.Text.Length;
                textBox_DCSSavedGamesPathBase.ScrollToCaret();
            }
        }
        private void button_DCSSavedGamesPathVROpen_Click(object sender, EventArgs e)
        {
            folderBrowserDialog_DCSPath.Description = "Select DCS VR Saved Games Folder";
            folderBrowserDialog_DCSPath.SelectedPath = Form1.Globals.SavedGamesPath;
            DialogResult result = folderBrowserDialog_DCSPath.ShowDialog();
            if (result == DialogResult.OK)
            {
                //var folder = Path.GetFileName(folderBrowserDialog_DCSPath.SelectedPath);
                //textBox_DCSSavedGamesPathVR.Text = folder;
                textBox_DCSSavedGamesPathVR.Text = folderBrowserDialog_DCSPath.SelectedPath;
                textBox_DCSSavedGamesPathVR.SelectionStart = textBox_DCSSavedGamesPathVR.Text.Length;
                textBox_DCSSavedGamesPathVR.ScrollToCaret();
            }
        }
        private void button_DeviceSetup_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f is Form5)
                {
                    f.Focus();
                    return;
                }
            }
            Form5 f5 = new();
            f5.FormClosing += new FormClosingEventHandler(ChildFormClosing);
            f5.Show();
        }

        private void button_GPUOverclock_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f is Form6)
                {
                    f.Focus();
                    return;
                }
            }
            Form6 f6 = new();
            f6.FormClosing += new FormClosingEventHandler(ChildFormClosing);
            f6.Show();
        }

        private void checkBox_CustomResolution_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_DCSCustomResolution.Checked)
            {
                numeric_CustomResolutionHeight.Enabled = true;
                numeric_CustomResolutionWidth.Enabled = true;
            }
            else
            {
                numeric_CustomResolutionHeight.Enabled = false;
                numeric_CustomResolutionWidth.Enabled = false;
            }
        }

        private void checkBox_DCSReposition_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_DCSReposition.Checked)
            {
                numeric_DCSPosX.Enabled = true;
                numeric_DCSPosY.Enabled = true;
            }
            else
            {
                numeric_DCSPosX.Enabled = false;
                numeric_DCSPosY.Enabled = false;
            }
        }

        private void checkBox_SplashReposition_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_SplashReposition.Checked)
            {
                numeric_SplashPosX.Enabled = true;
                numeric_SplashPosY.Enabled = true;
            }
            else
            {
                numeric_SplashPosX.Enabled = false;
                numeric_SplashPosY.Enabled = false;
            }
        }

        private void checkBox_DCSResize_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_DCSResize.Checked)
            {
                numeric_DCSWidth.Enabled = true;
                numeric_DCSHeight.Enabled = true;
            }
            else
            {
                numeric_DCSWidth.Enabled = false;
                numeric_DCSHeight.Enabled = false;
            }
        }

        private void checkBox_SteamVRReposition_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_SteamVRReposition.Checked)
            {
                numeric_SteamVRPosX.Enabled = true;
                numeric_SteamVRPosY.Enabled = true;
            }
            else
            {
                numeric_SteamVRPosX.Enabled = false;
                numeric_SteamVRPosY.Enabled = false;
            }
        }
    }
}