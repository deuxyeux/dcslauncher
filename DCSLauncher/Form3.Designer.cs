namespace DCSLauncher
{
    partial class Form3
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.textBox_LHB1MacAddress = new System.Windows.Forms.TextBox();
            this.checkBox_LHB1Enabled = new System.Windows.Forms.CheckBox();
            this.textBox_LHB2MacAddress = new System.Windows.Forms.TextBox();
            this.checkBox_LHB2Enabled = new System.Windows.Forms.CheckBox();
            this.button_Start = new System.Windows.Forms.Button();
            this.button_Stop = new System.Windows.Forms.Button();
            this.button_Save = new System.Windows.Forms.Button();
            this.button_Discover = new System.Windows.Forms.Button();
            this.button_Browse = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // textBox_LHB1MacAddress
            // 
            this.textBox_LHB1MacAddress.Location = new System.Drawing.Point(9, 10);
            this.textBox_LHB1MacAddress.Name = "textBox_LHB1MacAddress";
            this.textBox_LHB1MacAddress.Size = new System.Drawing.Size(190, 31);
            this.textBox_LHB1MacAddress.TabIndex = 0;
            this.textBox_LHB1MacAddress.TextChanged += new System.EventHandler(this.textBox_LHB1MacAddress_TextChanged);
            // 
            // checkBox_LHB1Enabled
            // 
            this.checkBox_LHB1Enabled.AutoSize = true;
            this.checkBox_LHB1Enabled.Location = new System.Drawing.Point(206, 13);
            this.checkBox_LHB1Enabled.Name = "checkBox_LHB1Enabled";
            this.checkBox_LHB1Enabled.Size = new System.Drawing.Size(101, 29);
            this.checkBox_LHB1Enabled.TabIndex = 1;
            this.checkBox_LHB1Enabled.Text = "Enabled";
            this.checkBox_LHB1Enabled.UseVisualStyleBackColor = true;
            this.checkBox_LHB1Enabled.CheckedChanged += new System.EventHandler(this.checkBox_LHB1Enabled_CheckedChanged);
            // 
            // textBox_LHB2MacAddress
            // 
            this.textBox_LHB2MacAddress.Location = new System.Drawing.Point(9, 55);
            this.textBox_LHB2MacAddress.Name = "textBox_LHB2MacAddress";
            this.textBox_LHB2MacAddress.Size = new System.Drawing.Size(190, 31);
            this.textBox_LHB2MacAddress.TabIndex = 0;
            this.textBox_LHB2MacAddress.TextChanged += new System.EventHandler(this.textBox_LHB2MacAddress_TextChanged);
            // 
            // checkBox_LHB2Enabled
            // 
            this.checkBox_LHB2Enabled.AutoSize = true;
            this.checkBox_LHB2Enabled.Location = new System.Drawing.Point(206, 58);
            this.checkBox_LHB2Enabled.Name = "checkBox_LHB2Enabled";
            this.checkBox_LHB2Enabled.Size = new System.Drawing.Size(101, 29);
            this.checkBox_LHB2Enabled.TabIndex = 1;
            this.checkBox_LHB2Enabled.Text = "Enabled";
            this.checkBox_LHB2Enabled.UseVisualStyleBackColor = true;
            this.checkBox_LHB2Enabled.CheckedChanged += new System.EventHandler(this.checkBox_LHB2Enabled_CheckedChanged);
            // 
            // button_Start
            // 
            this.button_Start.BackColor = System.Drawing.Color.LightGreen;
            this.button_Start.Location = new System.Drawing.Point(9, 100);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(93, 38);
            this.button_Start.TabIndex = 2;
            this.button_Start.Text = "Start LHB";
            this.button_Start.UseVisualStyleBackColor = false;
            this.button_Start.Click += new System.EventHandler(this.button_Start_Click);
            // 
            // button_Stop
            // 
            this.button_Stop.BackColor = System.Drawing.Color.IndianRed;
            this.button_Stop.Location = new System.Drawing.Point(107, 100);
            this.button_Stop.Name = "button_Stop";
            this.button_Stop.Size = new System.Drawing.Size(93, 38);
            this.button_Stop.TabIndex = 2;
            this.button_Stop.Text = "Stop LHB";
            this.button_Stop.UseVisualStyleBackColor = false;
            this.button_Stop.Click += new System.EventHandler(this.button_Stop_Click);
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(206, 100);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(106, 38);
            this.button_Save.TabIndex = 3;
            this.button_Save.Text = "Save";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // button_Discover
            // 
            this.button_Discover.BackColor = System.Drawing.Color.CornflowerBlue;
            this.button_Discover.Location = new System.Drawing.Point(9, 145);
            this.button_Discover.Name = "button_Discover";
            this.button_Discover.Size = new System.Drawing.Size(191, 38);
            this.button_Discover.TabIndex = 4;
            this.button_Discover.Text = "Discover";
            this.button_Discover.UseVisualStyleBackColor = false;
            this.button_Discover.Click += new System.EventHandler(this.button_Discover_Click);
            // 
            // button_Browse
            // 
            this.button_Browse.Location = new System.Drawing.Point(206, 145);
            this.button_Browse.Name = "button_Browse";
            this.button_Browse.Size = new System.Drawing.Size(106, 38);
            this.button_Browse.TabIndex = 5;
            this.button_Browse.Text = "Browse...";
            this.button_Browse.UseVisualStyleBackColor = true;
            this.button_Browse.Click += new System.EventHandler(this.button_Browse_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 192);
            this.Controls.Add(this.button_Browse);
            this.Controls.Add(this.button_Discover);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.button_Stop);
            this.Controls.Add(this.button_Start);
            this.Controls.Add(this.checkBox_LHB2Enabled);
            this.Controls.Add(this.checkBox_LHB1Enabled);
            this.Controls.Add(this.textBox_LHB2MacAddress);
            this.Controls.Add(this.textBox_LHB1MacAddress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = Properties.Resources.DCSLauncher;
            this.Name = "Form3";
            this.Text = "LHB Setup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_LHB1MacAddress;
        private System.Windows.Forms.CheckBox checkBox_LHB1Enabled;
        private System.Windows.Forms.TextBox textBox_LHB2MacAddress;
        private System.Windows.Forms.CheckBox checkBox_LHB2Enabled;
        private System.Windows.Forms.Button button_Start;
        private System.Windows.Forms.Button button_Stop;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Button button_Discover;
        private System.Windows.Forms.Button button_Browse;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}