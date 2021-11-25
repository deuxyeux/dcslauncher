namespace DCSLauncher
{
    partial class Form4
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            this.button_DeleteFxo = new System.Windows.Forms.Button();
            this.button_DeleteMetashaders2 = new System.Windows.Forms.Button();
            this.button_Populate = new System.Windows.Forms.Button();
            this.textBox_TargetFolder = new System.Windows.Forms.TextBox();
            this.button_PopulateBrowse = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.button_DisableDynTicks = new System.Windows.Forms.Button();
            this.button_EnableDynTicks = new System.Windows.Forms.Button();
            this.textBox_CustomSplashPath = new System.Windows.Forms.TextBox();
            this.button_CustomSplashPath = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox_SplashResize = new System.Windows.Forms.CheckBox();
            this.button_SplashApply = new System.Windows.Forms.Button();
            this.numeric_SplashWidth = new System.Windows.Forms.NumericUpDown();
            this.numeric_SplashHeight = new System.Windows.Forms.NumericUpDown();
            this.pictureBox_CustomSplash = new System.Windows.Forms.PictureBox();
            this.comboBox_CustomSplash = new System.Windows.Forms.ComboBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_SplashWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_SplashHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_CustomSplash)).BeginInit();
            this.SuspendLayout();
            // 
            // button_DeleteFxo
            // 
            this.button_DeleteFxo.Location = new System.Drawing.Point(6, 33);
            this.button_DeleteFxo.Name = "button_DeleteFxo";
            this.button_DeleteFxo.Size = new System.Drawing.Size(260, 37);
            this.button_DeleteFxo.TabIndex = 0;
            this.button_DeleteFxo.Text = "Delete fxo";
            this.button_DeleteFxo.UseVisualStyleBackColor = true;
            this.button_DeleteFxo.Click += new System.EventHandler(this.button_DeleteFxo_Click);
            // 
            // button_DeleteMetashaders2
            // 
            this.button_DeleteMetashaders2.Location = new System.Drawing.Point(271, 33);
            this.button_DeleteMetashaders2.Name = "button_DeleteMetashaders2";
            this.button_DeleteMetashaders2.Size = new System.Drawing.Size(260, 37);
            this.button_DeleteMetashaders2.TabIndex = 0;
            this.button_DeleteMetashaders2.Text = "Delete metashaders2";
            this.button_DeleteMetashaders2.UseVisualStyleBackColor = true;
            this.button_DeleteMetashaders2.Click += new System.EventHandler(this.button_DeleteMetashaders2_Click);
            // 
            // button_Populate
            // 
            this.button_Populate.Location = new System.Drawing.Point(6, 120);
            this.button_Populate.Name = "button_Populate";
            this.button_Populate.Size = new System.Drawing.Size(214, 37);
            this.button_Populate.TabIndex = 0;
            this.button_Populate.Text = "Populate Settings Folder";
            this.button_Populate.UseVisualStyleBackColor = true;
            this.button_Populate.Click += new System.EventHandler(this.button_Populate_Click);
            // 
            // textBox_TargetFolder
            // 
            this.textBox_TargetFolder.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_TargetFolder.Location = new System.Drawing.Point(226, 122);
            this.textBox_TargetFolder.Name = "textBox_TargetFolder";
            this.textBox_TargetFolder.Size = new System.Drawing.Size(210, 26);
            this.textBox_TargetFolder.TabIndex = 1;
            this.textBox_TargetFolder.TextChanged += new System.EventHandler(this.textBox_TargetFolder_TextChanged);
            // 
            // button_PopulateBrowse
            // 
            this.button_PopulateBrowse.Location = new System.Drawing.Point(443, 120);
            this.button_PopulateBrowse.Name = "button_PopulateBrowse";
            this.button_PopulateBrowse.Size = new System.Drawing.Size(89, 37);
            this.button_PopulateBrowse.TabIndex = 0;
            this.button_PopulateBrowse.Text = "Browse...";
            this.button_PopulateBrowse.UseVisualStyleBackColor = true;
            this.button_PopulateBrowse.Click += new System.EventHandler(this.button_PopulateBrowse_Click);
            // 
            // button_DisableDynTicks
            // 
            this.button_DisableDynTicks.Location = new System.Drawing.Point(6, 77);
            this.button_DisableDynTicks.Name = "button_DisableDynTicks";
            this.button_DisableDynTicks.Size = new System.Drawing.Size(260, 37);
            this.button_DisableDynTicks.TabIndex = 2;
            this.button_DisableDynTicks.Text = "Disable Dynamic Ticks && HPET";
            this.button_DisableDynTicks.UseVisualStyleBackColor = true;
            this.button_DisableDynTicks.Click += new System.EventHandler(this.button_DisableDynTicks_Click);
            // 
            // button_EnableDynTicks
            // 
            this.button_EnableDynTicks.Location = new System.Drawing.Point(271, 77);
            this.button_EnableDynTicks.Name = "button_EnableDynTicks";
            this.button_EnableDynTicks.Size = new System.Drawing.Size(260, 37);
            this.button_EnableDynTicks.TabIndex = 2;
            this.button_EnableDynTicks.Text = "Enable Dynticks && HPET";
            this.button_EnableDynTicks.UseVisualStyleBackColor = true;
            this.button_EnableDynTicks.Click += new System.EventHandler(this.button_DisableDynTicks_Click);
            // 
            // textBox_CustomSplashPath
            // 
            this.textBox_CustomSplashPath.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_CustomSplashPath.Location = new System.Drawing.Point(226, 30);
            this.textBox_CustomSplashPath.Name = "textBox_CustomSplashPath";
            this.textBox_CustomSplashPath.Size = new System.Drawing.Size(210, 29);
            this.textBox_CustomSplashPath.TabIndex = 20;
            // 
            // button_CustomSplashPath
            // 
            this.button_CustomSplashPath.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_CustomSplashPath.Location = new System.Drawing.Point(443, 30);
            this.button_CustomSplashPath.Name = "button_CustomSplashPath";
            this.button_CustomSplashPath.Size = new System.Drawing.Size(89, 37);
            this.button_CustomSplashPath.TabIndex = 21;
            this.button_CustomSplashPath.Text = "Browse...";
            this.button_CustomSplashPath.UseVisualStyleBackColor = true;
            this.button_CustomSplashPath.Click += new System.EventHandler(this.CustomSplashPath_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_PopulateBrowse);
            this.groupBox1.Controls.Add(this.button_Populate);
            this.groupBox1.Controls.Add(this.textBox_TargetFolder);
            this.groupBox1.Controls.Add(this.button_DeleteFxo);
            this.groupBox1.Controls.Add(this.button_DeleteMetashaders2);
            this.groupBox1.Controls.Add(this.button_DisableDynTicks);
            this.groupBox1.Controls.Add(this.button_EnableDynTicks);
            this.groupBox1.Location = new System.Drawing.Point(11, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(541, 173);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Miscellaneous Functions";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox_SplashResize);
            this.groupBox2.Controls.Add(this.button_SplashApply);
            this.groupBox2.Controls.Add(this.numeric_SplashWidth);
            this.groupBox2.Controls.Add(this.numeric_SplashHeight);
            this.groupBox2.Controls.Add(this.pictureBox_CustomSplash);
            this.groupBox2.Controls.Add(this.comboBox_CustomSplash);
            this.groupBox2.Controls.Add(this.textBox_CustomSplashPath);
            this.groupBox2.Controls.Add(this.button_CustomSplashPath);
            this.groupBox2.Location = new System.Drawing.Point(11, 192);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(541, 172);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Splash Image Functions";
            // 
            // checkBox_SplashResize
            // 
            this.checkBox_SplashResize.AutoSize = true;
            this.checkBox_SplashResize.Location = new System.Drawing.Point(286, 120);
            this.checkBox_SplashResize.Name = "checkBox_SplashResize";
            this.checkBox_SplashResize.Size = new System.Drawing.Size(86, 29);
            this.checkBox_SplashResize.TabIndex = 28;
            this.checkBox_SplashResize.Text = "Resize";
            this.checkBox_SplashResize.UseVisualStyleBackColor = true;
            // 
            // button_SplashApply
            // 
            this.button_SplashApply.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_SplashApply.Location = new System.Drawing.Point(443, 73);
            this.button_SplashApply.Name = "button_SplashApply";
            this.button_SplashApply.Size = new System.Drawing.Size(89, 37);
            this.button_SplashApply.TabIndex = 27;
            this.button_SplashApply.Text = "Apply";
            this.button_SplashApply.UseVisualStyleBackColor = true;
            this.button_SplashApply.Click += new System.EventHandler(this.button_SplashApply_Click);
            // 
            // numeric_SplashWidth
            // 
            this.numeric_SplashWidth.Location = new System.Drawing.Point(374, 117);
            this.numeric_SplashWidth.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
            this.numeric_SplashWidth.Name = "numeric_SplashWidth";
            this.numeric_SplashWidth.Size = new System.Drawing.Size(76, 31);
            this.numeric_SplashWidth.TabIndex = 24;
            this.numeric_SplashWidth.Value = new decimal(new int[] {
            356,
            0,
            0,
            0});
            // 
            // numeric_SplashHeight
            // 
            this.numeric_SplashHeight.Location = new System.Drawing.Point(456, 117);
            this.numeric_SplashHeight.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
            this.numeric_SplashHeight.Name = "numeric_SplashHeight";
            this.numeric_SplashHeight.Size = new System.Drawing.Size(76, 31);
            this.numeric_SplashHeight.TabIndex = 25;
            this.numeric_SplashHeight.Value = new decimal(new int[] {
            191,
            0,
            0,
            0});
            // 
            // pictureBox_CustomSplash
            // 
            this.pictureBox_CustomSplash.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_CustomSplash.Location = new System.Drawing.Point(7, 30);
            this.pictureBox_CustomSplash.Name = "pictureBox_CustomSplash";
            this.pictureBox_CustomSplash.Size = new System.Drawing.Size(212, 129);
            this.pictureBox_CustomSplash.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_CustomSplash.TabIndex = 23;
            this.pictureBox_CustomSplash.TabStop = false;
            this.pictureBox_CustomSplash.Click += new System.EventHandler(this.pictureBox_CustomSplash_Click);
            // 
            // comboBox_CustomSplash
            // 
            this.comboBox_CustomSplash.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBox_CustomSplash.FormattingEnabled = true;
            this.comboBox_CustomSplash.Items.AddRange(new object[] {
            "None",
            "Default Splash",
            "VR Splash"});
            this.comboBox_CustomSplash.Location = new System.Drawing.Point(226, 75);
            this.comboBox_CustomSplash.Name = "comboBox_CustomSplash";
            this.comboBox_CustomSplash.Size = new System.Drawing.Size(210, 29);
            this.comboBox_CustomSplash.TabIndex = 22;
            this.comboBox_CustomSplash.SelectedIndexChanged += new System.EventHandler(this.comboBox_CustomSplash_SelectedIndexChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 378);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form4";
            this.Icon = Properties.Resources.DCSLauncher;
            this.Text = "Miscellaneous";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_SplashWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_SplashHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_CustomSplash)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_DeleteFxo;
        private System.Windows.Forms.Button button_DeleteMetashaders2;
        private System.Windows.Forms.Button button_Populate;
        private System.Windows.Forms.TextBox textBox_TargetFolder;
        private System.Windows.Forms.Button button_PopulateBrowse;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button button_DisableDynTicks;
        private System.Windows.Forms.Button button_EnableDynTicks;
        private System.Windows.Forms.TextBox textBox_CustomSplashPath;
        private System.Windows.Forms.Button button_CustomSplashPath;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBox_CustomSplash;
        private System.Windows.Forms.PictureBox pictureBox_CustomSplash;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.NumericUpDown numeric_SplashWidth;
        private System.Windows.Forms.NumericUpDown numeric_SplashHeight;
        private System.Windows.Forms.Button button_SplashApply;
        private System.Windows.Forms.CheckBox checkBox_SplashResize;
    }
}