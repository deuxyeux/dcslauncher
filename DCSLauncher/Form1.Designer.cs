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
            this.groupBox_Utils.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_SimShaker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Helios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_VoiceAttack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_OpenTrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_TrackIR)).BeginInit();
            this.groupBox_Devices.SuspendLayout();
            this.SuspendLayout();
            // 
            // LogBox
            // 
            this.LogBox.Location = new System.Drawing.Point(8, 7);
            this.LogBox.Margin = new System.Windows.Forms.Padding(2);
            this.LogBox.Name = "LogBox";
            this.LogBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.LogBox.Size = new System.Drawing.Size(255, 231);
            this.LogBox.TabIndex = 0;
            this.LogBox.Text = "";
            this.LogBox.TextChanged += new System.EventHandler(this.LogBox_TextChanged);
            // 
            // radioButton_VRMode
            // 
            this.radioButton_VRMode.AutoSize = true;
            this.radioButton_VRMode.Location = new System.Drawing.Point(267, 193);
            this.radioButton_VRMode.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton_VRMode.Name = "radioButton_VRMode";
            this.radioButton_VRMode.Size = new System.Drawing.Size(73, 19);
            this.radioButton_VRMode.TabIndex = 9;
            this.radioButton_VRMode.TabStop = true;
            this.radioButton_VRMode.Text = "VR Mode";
            this.radioButton_VRMode.UseVisualStyleBackColor = true;
            this.radioButton_VRMode.CheckedChanged += new System.EventHandler(this.VRMode_CheckedChanged);
            // 
            // radioButton_FlatscreenMode
            // 
            this.radioButton_FlatscreenMode.AutoSize = true;
            this.radioButton_FlatscreenMode.Location = new System.Drawing.Point(267, 172);
            this.radioButton_FlatscreenMode.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton_FlatscreenMode.Name = "radioButton_FlatscreenMode";
            this.radioButton_FlatscreenMode.Size = new System.Drawing.Size(112, 19);
            this.radioButton_FlatscreenMode.TabIndex = 10;
            this.radioButton_FlatscreenMode.TabStop = true;
            this.radioButton_FlatscreenMode.Text = "Flatscreen Mode";
            this.radioButton_FlatscreenMode.UseVisualStyleBackColor = true;
            this.radioButton_FlatscreenMode.CheckedChanged += new System.EventHandler(this.FlatscreenMode_CheckedChanged);
            // 
            // button_Start
            // 
            this.button_Start.BackColor = System.Drawing.Color.LightGreen;
            this.button_Start.Location = new System.Drawing.Point(267, 241);
            this.button_Start.Margin = new System.Windows.Forms.Padding(2);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(59, 23);
            this.button_Start.TabIndex = 1;
            this.button_Start.Text = "Start";
            this.button_Start.UseVisualStyleBackColor = false;
            this.button_Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // button_Stop
            // 
            this.button_Stop.BackColor = System.Drawing.Color.IndianRed;
            this.button_Stop.Location = new System.Drawing.Point(267, 214);
            this.button_Stop.Margin = new System.Windows.Forms.Padding(2);
            this.button_Stop.Name = "button_Stop";
            this.button_Stop.Size = new System.Drawing.Size(59, 23);
            this.button_Stop.TabIndex = 6;
            this.button_Stop.Text = "Stop";
            this.button_Stop.UseVisualStyleBackColor = false;
            this.button_Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // button_Misc
            // 
            this.button_Misc.Location = new System.Drawing.Point(330, 214);
            this.button_Misc.Margin = new System.Windows.Forms.Padding(2);
            this.button_Misc.Name = "button_Misc";
            this.button_Misc.Size = new System.Drawing.Size(59, 23);
            this.button_Misc.TabIndex = 7;
            this.button_Misc.Text = "Misc";
            this.button_Misc.UseVisualStyleBackColor = true;
            this.button_Misc.Click += new System.EventHandler(this.Misc_Click);
            // 
            // button_Settings
            // 
            this.button_Settings.Location = new System.Drawing.Point(330, 241);
            this.button_Settings.Margin = new System.Windows.Forms.Padding(2);
            this.button_Settings.Name = "button_Settings";
            this.button_Settings.Size = new System.Drawing.Size(59, 23);
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
            this.groupBox_Utils.Location = new System.Drawing.Point(267, 7);
            this.groupBox_Utils.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox_Utils.Name = "groupBox_Utils";
            this.groupBox_Utils.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox_Utils.Size = new System.Drawing.Size(122, 94);
            this.groupBox_Utils.TabIndex = 11;
            this.groupBox_Utils.TabStop = false;
            this.groupBox_Utils.Text = "Utilities";
            // 
            // label_NoUtils
            // 
            this.label_NoUtils.AutoSize = true;
            this.label_NoUtils.Location = new System.Drawing.Point(6, 45);
            this.label_NoUtils.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_NoUtils.Name = "label_NoUtils";
            this.label_NoUtils.Size = new System.Drawing.Size(110, 15);
            this.label_NoUtils.TabIndex = 12;
            this.label_NoUtils.Text = "No utilities selected";
            this.label_NoUtils.Visible = false;
            // 
            // pictureBox_SimShaker
            // 
            this.pictureBox_SimShaker.Location = new System.Drawing.Point(76, 20);
            this.pictureBox_SimShaker.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox_SimShaker.Name = "pictureBox_SimShaker";
            this.pictureBox_SimShaker.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_SimShaker.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_SimShaker.TabIndex = 2;
            this.pictureBox_SimShaker.TabStop = false;
            this.pictureBox_SimShaker.Click += new System.EventHandler(this.pictureBox_SimShaker_Click);
            // 
            // pictureBox_Helios
            // 
            this.pictureBox_Helios.Location = new System.Drawing.Point(40, 56);
            this.pictureBox_Helios.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox_Helios.Name = "pictureBox_Helios";
            this.pictureBox_Helios.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_Helios.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_Helios.TabIndex = 1;
            this.pictureBox_Helios.TabStop = false;
            this.pictureBox_Helios.Click += new System.EventHandler(this.pictureBox_Helios_Click);
            // 
            // pictureBox_VoiceAttack
            // 
            this.pictureBox_VoiceAttack.Location = new System.Drawing.Point(40, 20);
            this.pictureBox_VoiceAttack.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox_VoiceAttack.Name = "pictureBox_VoiceAttack";
            this.pictureBox_VoiceAttack.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_VoiceAttack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_VoiceAttack.TabIndex = 1;
            this.pictureBox_VoiceAttack.TabStop = false;
            this.pictureBox_VoiceAttack.Click += new System.EventHandler(this.pictureBox_VoiceAttack_Click);
            // 
            // pictureBox_OpenTrack
            // 
            this.pictureBox_OpenTrack.Location = new System.Drawing.Point(4, 56);
            this.pictureBox_OpenTrack.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox_OpenTrack.Name = "pictureBox_OpenTrack";
            this.pictureBox_OpenTrack.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_OpenTrack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_OpenTrack.TabIndex = 0;
            this.pictureBox_OpenTrack.TabStop = false;
            this.pictureBox_OpenTrack.Click += new System.EventHandler(this.pictureBox_OpenTrack_Click);
            // 
            // pictureBox_TrackIR
            // 
            this.pictureBox_TrackIR.Location = new System.Drawing.Point(4, 20);
            this.pictureBox_TrackIR.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox_TrackIR.Name = "pictureBox_TrackIR";
            this.pictureBox_TrackIR.Size = new System.Drawing.Size(32, 32);
            this.pictureBox_TrackIR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_TrackIR.TabIndex = 0;
            this.pictureBox_TrackIR.TabStop = false;
            this.pictureBox_TrackIR.Click += new System.EventHandler(this.pictureBox_TrackIR_Click);
            // 
            // groupBox_Devices
            // 
            this.groupBox_Devices.Controls.Add(this.checkBox2);
            this.groupBox_Devices.Controls.Add(this.checkBox1);
            this.groupBox_Devices.Location = new System.Drawing.Point(267, 106);
            this.groupBox_Devices.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox_Devices.Name = "groupBox_Devices";
            this.groupBox_Devices.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox_Devices.Size = new System.Drawing.Size(122, 60);
            this.groupBox_Devices.TabIndex = 12;
            this.groupBox_Devices.TabStop = false;
            this.groupBox_Devices.Text = "Devices";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Enabled = false;
            this.checkBox2.Location = new System.Drawing.Point(4, 39);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(54, 19);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "HMD";
            this.checkBox2.UseVisualStyleBackColor = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(4, 18);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(84, 19);
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
            this.progressBar1.Location = new System.Drawing.Point(8, 244);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar1.Maximum = 31;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(254, 19);
            this.progressBar1.TabIndex = 13;
            // 
            // MinimizePiTool
            // 
            this.MinimizePiTool.DoWork += new System.ComponentModel.DoWorkEventHandler(this.MinimizePiTool_DoWork);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 271);
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
            this.Margin = new System.Windows.Forms.Padding(2);
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
    }
}