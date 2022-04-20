namespace DCSLauncher
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.LogBox = new System.Windows.Forms.RichTextBox();
            this.radioButton_VRMode = new System.Windows.Forms.RadioButton();
            this.radioButton_FlatscreenMode = new System.Windows.Forms.RadioButton();
            this.button_Start = new System.Windows.Forms.Button();
            this.button_Stop = new System.Windows.Forms.Button();
            this.button_Misc = new System.Windows.Forms.Button();
            this.button_Settings = new System.Windows.Forms.Button();
            this.WaitForDCSStart = new System.ComponentModel.BackgroundWorker();
            this.WaitForDCSStop = new System.ComponentModel.BackgroundWorker();
            this.AutoClose = new System.ComponentModel.BackgroundWorker();
            this.MinimizeJetSeatHandler = new System.ComponentModel.BackgroundWorker();
            this.WaitForSplash = new System.ComponentModel.BackgroundWorker();
            this.WaitForSteamVR = new System.ComponentModel.BackgroundWorker();
            this.groupBox_Utils = new System.Windows.Forms.GroupBox();
            this.label_NoUtils = new System.Windows.Forms.Label();
            this.pictureBox_SimShaker = new System.Windows.Forms.PictureBox();
            this.pictureBox_Helios = new System.Windows.Forms.PictureBox();
            this.pictureBox_VoiceAttack = new System.Windows.Forms.PictureBox();
            this.pictureBox_OpenTrack = new System.Windows.Forms.PictureBox();
            this.pictureBox_TrackIR = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox_Devices = new System.Windows.Forms.GroupBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.DeviceStatusCheck = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.MinimizePiTool = new System.ComponentModel.BackgroundWorker();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.startDCSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flatscreenModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vRModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopDCSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitLauncherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon2 = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyIcon3 = new System.Windows.Forms.NotifyIcon(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox_Utils.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_SimShaker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Helios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_VoiceAttack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_OpenTrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_TrackIR)).BeginInit();
            this.groupBox_Devices.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LogBox
            // 
            this.LogBox.Location = new System.Drawing.Point(12, 12);
            this.LogBox.Name = "LogBox";
            this.LogBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.LogBox.Size = new System.Drawing.Size(412, 377);
            this.LogBox.TabIndex = 0;
            this.LogBox.Text = "";
            this.LogBox.TextChanged += new System.EventHandler(this.LogBox_TextChanged);
            // 
            // radioButton_VRMode
            // 
            this.radioButton_VRMode.AutoSize = true;
            this.radioButton_VRMode.Location = new System.Drawing.Point(433, 316);
            this.radioButton_VRMode.Name = "radioButton_VRMode";
            this.radioButton_VRMode.Size = new System.Drawing.Size(111, 29);
            this.radioButton_VRMode.TabIndex = 9;
            this.radioButton_VRMode.TabStop = true;
            this.radioButton_VRMode.Text = "VR Mode";
            this.radioButton_VRMode.UseVisualStyleBackColor = true;
            this.radioButton_VRMode.CheckedChanged += new System.EventHandler(this.VRMode_CheckedChanged);
            // 
            // radioButton_FlatscreenMode
            // 
            this.radioButton_FlatscreenMode.AutoSize = true;
            this.radioButton_FlatscreenMode.Location = new System.Drawing.Point(433, 281);
            this.radioButton_FlatscreenMode.Name = "radioButton_FlatscreenMode";
            this.radioButton_FlatscreenMode.Size = new System.Drawing.Size(167, 29);
            this.radioButton_FlatscreenMode.TabIndex = 10;
            this.radioButton_FlatscreenMode.TabStop = true;
            this.radioButton_FlatscreenMode.Text = "Flatscreen Mode";
            this.radioButton_FlatscreenMode.UseVisualStyleBackColor = true;
            this.radioButton_FlatscreenMode.CheckedChanged += new System.EventHandler(this.FlatscreenMode_CheckedChanged);
            // 
            // button_Start
            // 
            this.button_Start.BackColor = System.Drawing.Color.LightGreen;
            this.button_Start.Location = new System.Drawing.Point(430, 395);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(84, 38);
            this.button_Start.TabIndex = 1;
            this.button_Start.Text = "Start";
            this.button_Start.UseVisualStyleBackColor = false;
            this.button_Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // button_Stop
            // 
            this.button_Stop.BackColor = System.Drawing.Color.IndianRed;
            this.button_Stop.Location = new System.Drawing.Point(430, 351);
            this.button_Stop.Name = "button_Stop";
            this.button_Stop.Size = new System.Drawing.Size(84, 38);
            this.button_Stop.TabIndex = 6;
            this.button_Stop.Text = "Stop";
            this.button_Stop.UseVisualStyleBackColor = false;
            this.button_Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // button_Misc
            // 
            this.button_Misc.Location = new System.Drawing.Point(520, 351);
            this.button_Misc.Name = "button_Misc";
            this.button_Misc.Size = new System.Drawing.Size(84, 38);
            this.button_Misc.TabIndex = 7;
            this.button_Misc.Text = "Misc";
            this.button_Misc.UseVisualStyleBackColor = true;
            this.button_Misc.Click += new System.EventHandler(this.Misc_Click);
            // 
            // button_Settings
            // 
            this.button_Settings.Location = new System.Drawing.Point(520, 395);
            this.button_Settings.Name = "button_Settings";
            this.button_Settings.Size = new System.Drawing.Size(84, 38);
            this.button_Settings.TabIndex = 2;
            this.button_Settings.Text = "Settings";
            this.button_Settings.UseVisualStyleBackColor = true;
            this.button_Settings.Click += new System.EventHandler(this.Settings_Click);
            // 
            // WaitForDCSStart
            // 
            this.WaitForDCSStart.WorkerReportsProgress = true;
            this.WaitForDCSStart.WorkerSupportsCancellation = true;
            this.WaitForDCSStart.DoWork += new System.ComponentModel.DoWorkEventHandler(this.WaitForDCSStart_DoWork);
            this.WaitForDCSStart.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.WaitForDCSStart_ProgressChanged);
            this.WaitForDCSStart.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.WaitForDCSStart_RunWorkerCompleted);
            // 
            // WaitForDCSStop
            // 
            this.WaitForDCSStop.DoWork += new System.ComponentModel.DoWorkEventHandler(this.WaitForDCSStop_DoWork);
            this.WaitForDCSStop.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.WaitForDCSStop_RunWorkerCompleted);
            // 
            // AutoClose
            // 
            this.AutoClose.WorkerReportsProgress = true;
            this.AutoClose.DoWork += new System.ComponentModel.DoWorkEventHandler(this.AutoClose_DoWork);
            this.AutoClose.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.AutoClose_ProgressChanged);
            this.AutoClose.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.AutoClose_RunWorkerCompleted);
            // 
            // MinimizeJetSeatHandler
            // 
            this.MinimizeJetSeatHandler.DoWork += new System.ComponentModel.DoWorkEventHandler(this.MinimizeJetSeatHandler_DoWork);
            // 
            // WaitForSplash
            // 
            this.WaitForSplash.DoWork += new System.ComponentModel.DoWorkEventHandler(this.WaitForSplash_DoWork);
            this.WaitForSplash.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.WaitForSplash_RunWorkerCompleted);
            // 
            // WaitForSteamVR
            // 
            this.WaitForSteamVR.DoWork += new System.ComponentModel.DoWorkEventHandler(this.WaitForSteamVR_DoWork);
            // 
            // groupBox_Utils
            // 
            this.groupBox_Utils.Controls.Add(this.label_NoUtils);
            this.groupBox_Utils.Controls.Add(this.pictureBox_SimShaker);
            this.groupBox_Utils.Controls.Add(this.pictureBox_Helios);
            this.groupBox_Utils.Controls.Add(this.pictureBox_VoiceAttack);
            this.groupBox_Utils.Controls.Add(this.pictureBox_OpenTrack);
            this.groupBox_Utils.Controls.Add(this.pictureBox_TrackIR);
            this.groupBox_Utils.Location = new System.Drawing.Point(430, 12);
            this.groupBox_Utils.Name = "groupBox_Utils";
            this.groupBox_Utils.Size = new System.Drawing.Size(174, 157);
            this.groupBox_Utils.TabIndex = 11;
            this.groupBox_Utils.TabStop = false;
            this.groupBox_Utils.Text = "Utilities";
            // 
            // label_NoUtils
            // 
            this.label_NoUtils.AutoSize = true;
            this.label_NoUtils.Location = new System.Drawing.Point(5, 74);
            this.label_NoUtils.Name = "label_NoUtils";
            this.label_NoUtils.Size = new System.Drawing.Size(165, 25);
            this.label_NoUtils.TabIndex = 12;
            this.label_NoUtils.Text = "No utilities selected";
            this.label_NoUtils.Visible = false;
            // 
            // pictureBox_SimShaker
            // 
            this.pictureBox_SimShaker.Location = new System.Drawing.Point(109, 33);
            this.pictureBox_SimShaker.Name = "pictureBox_SimShaker";
            this.pictureBox_SimShaker.Size = new System.Drawing.Size(46, 53);
            this.pictureBox_SimShaker.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_SimShaker.TabIndex = 2;
            this.pictureBox_SimShaker.TabStop = false;
            this.pictureBox_SimShaker.Click += new System.EventHandler(this.pictureBox_SimShaker_Click);
            // 
            // pictureBox_Helios
            // 
            this.pictureBox_Helios.Location = new System.Drawing.Point(57, 93);
            this.pictureBox_Helios.Name = "pictureBox_Helios";
            this.pictureBox_Helios.Size = new System.Drawing.Size(46, 53);
            this.pictureBox_Helios.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_Helios.TabIndex = 1;
            this.pictureBox_Helios.TabStop = false;
            this.pictureBox_Helios.Click += new System.EventHandler(this.pictureBox_Helios_Click);
            // 
            // pictureBox_VoiceAttack
            // 
            this.pictureBox_VoiceAttack.Location = new System.Drawing.Point(57, 33);
            this.pictureBox_VoiceAttack.Name = "pictureBox_VoiceAttack";
            this.pictureBox_VoiceAttack.Size = new System.Drawing.Size(46, 53);
            this.pictureBox_VoiceAttack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_VoiceAttack.TabIndex = 1;
            this.pictureBox_VoiceAttack.TabStop = false;
            this.pictureBox_VoiceAttack.Click += new System.EventHandler(this.pictureBox_VoiceAttack_Click);
            // 
            // pictureBox_OpenTrack
            // 
            this.pictureBox_OpenTrack.Location = new System.Drawing.Point(6, 93);
            this.pictureBox_OpenTrack.Name = "pictureBox_OpenTrack";
            this.pictureBox_OpenTrack.Size = new System.Drawing.Size(46, 53);
            this.pictureBox_OpenTrack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_OpenTrack.TabIndex = 0;
            this.pictureBox_OpenTrack.TabStop = false;
            this.pictureBox_OpenTrack.Click += new System.EventHandler(this.pictureBox_OpenTrack_Click);
            // 
            // pictureBox_TrackIR
            // 
            this.pictureBox_TrackIR.Location = new System.Drawing.Point(6, 33);
            this.pictureBox_TrackIR.Name = "pictureBox_TrackIR";
            this.pictureBox_TrackIR.Size = new System.Drawing.Size(46, 53);
            this.pictureBox_TrackIR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_TrackIR.TabIndex = 0;
            this.pictureBox_TrackIR.TabStop = false;
            this.pictureBox_TrackIR.Click += new System.EventHandler(this.pictureBox_TrackIR_Click);
            // 
            // groupBox_Devices
            // 
            this.groupBox_Devices.Controls.Add(this.checkBox2);
            this.groupBox_Devices.Controls.Add(this.checkBox1);
            this.groupBox_Devices.Location = new System.Drawing.Point(430, 175);
            this.groupBox_Devices.Name = "groupBox_Devices";
            this.groupBox_Devices.Size = new System.Drawing.Size(174, 100);
            this.groupBox_Devices.TabIndex = 12;
            this.groupBox_Devices.TabStop = false;
            this.groupBox_Devices.Text = "Devices";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Enabled = false;
            this.checkBox2.Location = new System.Drawing.Point(6, 65);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(80, 29);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "HMD";
            this.checkBox2.UseVisualStyleBackColor = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(6, 30);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(124, 29);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Controllers";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // DeviceStatusCheck
            // 
            this.DeviceStatusCheck.WorkerReportsProgress = true;
            this.DeviceStatusCheck.WorkerSupportsCancellation = true;
            this.DeviceStatusCheck.DoWork += new System.ComponentModel.DoWorkEventHandler(this.DeviceStatusCheck_DoWork);
            this.DeviceStatusCheck.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.DeviceStatusCheck_ProgressChanged);
            this.DeviceStatusCheck.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.DeviceStatusCheck_RunWorkerCompleted);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 398);
            this.progressBar1.Maximum = 31;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(412, 33);
            this.progressBar1.TabIndex = 13;
            // 
            // MinimizePiTool
            // 
            this.MinimizePiTool.DoWork += new System.ComponentModel.DoWorkEventHandler(this.MinimizePiTool_DoWork);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = global::DCSLauncher.Properties.Resources.DCSLauncher;
            this.notifyIcon1.Text = "DCS Launcher";
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startDCSToolStripMenuItem,
            this.stopDCSToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitLauncherToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(195, 106);
            // 
            // startDCSToolStripMenuItem
            // 
            this.startDCSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.flatscreenModeToolStripMenuItem,
            this.vRModeToolStripMenuItem});
            this.startDCSToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("startDCSToolStripMenuItem.Image")));
            this.startDCSToolStripMenuItem.Name = "startDCSToolStripMenuItem";
            this.startDCSToolStripMenuItem.Size = new System.Drawing.Size(194, 32);
            this.startDCSToolStripMenuItem.Text = "Start DCS";
            // 
            // flatscreenModeToolStripMenuItem
            // 
            this.flatscreenModeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("flatscreenModeToolStripMenuItem.Image")));
            this.flatscreenModeToolStripMenuItem.Name = "flatscreenModeToolStripMenuItem";
            this.flatscreenModeToolStripMenuItem.Size = new System.Drawing.Size(244, 34);
            this.flatscreenModeToolStripMenuItem.Text = "Flatscreen Mode";
            this.flatscreenModeToolStripMenuItem.Click += new System.EventHandler(this.flatscreenModeToolStripMenuItem_Click);
            // 
            // vRModeToolStripMenuItem
            // 
            this.vRModeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("vRModeToolStripMenuItem.Image")));
            this.vRModeToolStripMenuItem.Name = "vRModeToolStripMenuItem";
            this.vRModeToolStripMenuItem.Size = new System.Drawing.Size(244, 34);
            this.vRModeToolStripMenuItem.Text = "VR Mode";
            this.vRModeToolStripMenuItem.Click += new System.EventHandler(this.vRModeToolStripMenuItem_Click);
            // 
            // stopDCSToolStripMenuItem
            // 
            this.stopDCSToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("stopDCSToolStripMenuItem.Image")));
            this.stopDCSToolStripMenuItem.Name = "stopDCSToolStripMenuItem";
            this.stopDCSToolStripMenuItem.Size = new System.Drawing.Size(194, 32);
            this.stopDCSToolStripMenuItem.Text = "Stop DCS";
            this.stopDCSToolStripMenuItem.Click += new System.EventHandler(this.stopDCSToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(191, 6);
            // 
            // exitLauncherToolStripMenuItem
            // 
            this.exitLauncherToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitLauncherToolStripMenuItem.Image")));
            this.exitLauncherToolStripMenuItem.Name = "exitLauncherToolStripMenuItem";
            this.exitLauncherToolStripMenuItem.Size = new System.Drawing.Size(194, 32);
            this.exitLauncherToolStripMenuItem.Text = "Exit Launcher";
            this.exitLauncherToolStripMenuItem.Click += new System.EventHandler(this.exitLauncherToolStripMenuItem_Click);
            // 
            // notifyIcon2
            // 
            this.notifyIcon2.Icon = global::DCSLauncher.Properties.Resources.Joystick_White;
            this.notifyIcon2.Text = "Controller Status";
            this.notifyIcon2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon2_MouseDoubleClick);
            // 
            // notifyIcon3
            // 
            this.notifyIcon3.Icon = global::DCSLauncher.Properties.Resources.HMD_White;
            this.notifyIcon3.Text = "HMD Status";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 452);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(616, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 15);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(0, 15);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(616, 474);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox_Devices);
            this.Controls.Add(this.groupBox_Utils);
            this.Controls.Add(this.LogBox);
            this.Controls.Add(this.radioButton_VRMode);
            this.Controls.Add(this.radioButton_FlatscreenMode);
            this.Controls.Add(this.button_Start);
            this.Controls.Add(this.button_Stop);
            this.Controls.Add(this.button_Misc);
            this.Controls.Add(this.button_Settings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::DCSLauncher.Properties.Resources.DCSLauncher;
            this.Name = "Form1";
            this.Text = "DCS Launcher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox_Utils.ResumeLayout(false);
            this.groupBox_Utils.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_SimShaker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Helios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_VoiceAttack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_OpenTrack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_TrackIR)).EndInit();
            this.groupBox_Devices.ResumeLayout(false);
            this.groupBox_Devices.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox LogBox;
        private System.Windows.Forms.RadioButton radioButton_VRMode;
        private System.Windows.Forms.RadioButton radioButton_FlatscreenMode;
        private System.Windows.Forms.Button button_Start;
        private System.Windows.Forms.Button button_Stop;
        private System.Windows.Forms.Button button_Misc;
        private System.Windows.Forms.Button button_Settings;
        private System.ComponentModel.BackgroundWorker WaitForDCSStart;
        private System.ComponentModel.BackgroundWorker WaitForDCSStop;
        private System.ComponentModel.BackgroundWorker WaitForSplash;
        private System.ComponentModel.BackgroundWorker WaitForSteamVR;
        private System.ComponentModel.BackgroundWorker AutoClose;
        private System.ComponentModel.BackgroundWorker MinimizeJetSeatHandler;
        private System.Windows.Forms.GroupBox groupBox_Utils;
        private System.Windows.Forms.PictureBox pictureBox_TrackIR;
        private System.Windows.Forms.PictureBox pictureBox_SimShaker;
        private System.Windows.Forms.PictureBox pictureBox_VoiceAttack;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox pictureBox_Helios;
        private System.Windows.Forms.PictureBox pictureBox_OpenTrack;
        private System.Windows.Forms.Label label_NoUtils;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.GroupBox groupBox_Devices;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.ComponentModel.BackgroundWorker DeviceStatusCheck;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker MinimizePiTool;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem startDCSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopDCSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flatscreenModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vRModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitLauncherToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.NotifyIcon notifyIcon2;
        private System.Windows.Forms.NotifyIcon notifyIcon3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
    }
}