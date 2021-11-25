
namespace DCSLauncher
{
    partial class Form6
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
            this.label1 = new System.Windows.Forms.Label();
            this.numeric_BaseClockOffset = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numeric_MemoryClockOffset = new System.Windows.Forms.NumericUpDown();
            this.numeric_LockVoltagePoint = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numeric_PowerTarget = new System.Windows.Forms.NumericUpDown();
            this.button_Save = new System.Windows.Forms.Button();
            this.button_Browse = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.numeric_TempTarget = new System.Windows.Forms.NumericUpDown();
            this.checkBox_LockVoltagePoint = new System.Windows.Forms.CheckBox();
            this.checkBox_TempTarget = new System.Windows.Forms.CheckBox();
            this.checkBox_TempPrioritize = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_BaseClockOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_MemoryClockOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_LockVoltagePoint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_PowerTarget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_TempTarget)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Base Clock Offset";
            // 
            // numeric_BaseClockOffset
            // 
            this.numeric_BaseClockOffset.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numeric_BaseClockOffset.Location = new System.Drawing.Point(156, 8);
            this.numeric_BaseClockOffset.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numeric_BaseClockOffset.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numeric_BaseClockOffset.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numeric_BaseClockOffset.Name = "numeric_BaseClockOffset";
            this.numeric_BaseClockOffset.Size = new System.Drawing.Size(51, 22);
            this.numeric_BaseClockOffset.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(211, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Memory Clock Offset";
            // 
            // numeric_MemoryClockOffset
            // 
            this.numeric_MemoryClockOffset.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numeric_MemoryClockOffset.Location = new System.Drawing.Point(342, 8);
            this.numeric_MemoryClockOffset.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numeric_MemoryClockOffset.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.numeric_MemoryClockOffset.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numeric_MemoryClockOffset.Name = "numeric_MemoryClockOffset";
            this.numeric_MemoryClockOffset.Size = new System.Drawing.Size(51, 22);
            this.numeric_MemoryClockOffset.TabIndex = 3;
            // 
            // numeric_LockVoltagePoint
            // 
            this.numeric_LockVoltagePoint.DecimalPlaces = 6;
            this.numeric_LockVoltagePoint.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numeric_LockVoltagePoint.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numeric_LockVoltagePoint.Location = new System.Drawing.Point(140, 31);
            this.numeric_LockVoltagePoint.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numeric_LockVoltagePoint.Maximum = new decimal(new int[] {
            3000000,
            0,
            0,
            393216});
            this.numeric_LockVoltagePoint.Minimum = new decimal(new int[] {
            500000,
            0,
            0,
            393216});
            this.numeric_LockVoltagePoint.Name = "numeric_LockVoltagePoint";
            this.numeric_LockVoltagePoint.Size = new System.Drawing.Size(67, 22);
            this.numeric_LockVoltagePoint.TabIndex = 5;
            this.numeric_LockVoltagePoint.Value = new decimal(new int[] {
            8500000,
            0,
            0,
            458752});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(211, 35);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Power Target";
            // 
            // numeric_PowerTarget
            // 
            this.numeric_PowerTarget.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numeric_PowerTarget.Location = new System.Drawing.Point(342, 31);
            this.numeric_PowerTarget.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numeric_PowerTarget.Maximum = new decimal(new int[] {
            140,
            0,
            0,
            0});
            this.numeric_PowerTarget.Minimum = new decimal(new int[] {
            29,
            0,
            0,
            0});
            this.numeric_PowerTarget.Name = "numeric_PowerTarget";
            this.numeric_PowerTarget.Size = new System.Drawing.Size(51, 22);
            this.numeric_PowerTarget.TabIndex = 7;
            this.numeric_PowerTarget.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(315, 75);
            this.button_Save.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(78, 24);
            this.button_Save.TabIndex = 8;
            this.button_Save.Text = "Save";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // button_Browse
            // 
            this.button_Browse.Location = new System.Drawing.Point(233, 75);
            this.button_Browse.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_Browse.Name = "button_Browse";
            this.button_Browse.Size = new System.Drawing.Size(78, 24);
            this.button_Browse.TabIndex = 9;
            this.button_Browse.Text = "Browse...";
            this.button_Browse.UseVisualStyleBackColor = true;
            this.button_Browse.Click += new System.EventHandler(this.button_Browse_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // numeric_TempTarget
            // 
            this.numeric_TempTarget.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numeric_TempTarget.Location = new System.Drawing.Point(156, 54);
            this.numeric_TempTarget.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numeric_TempTarget.Name = "numeric_TempTarget";
            this.numeric_TempTarget.Size = new System.Drawing.Size(51, 22);
            this.numeric_TempTarget.TabIndex = 11;
            // 
            // checkBox_LockVoltagePoint
            // 
            this.checkBox_LockVoltagePoint.AutoSize = true;
            this.checkBox_LockVoltagePoint.Location = new System.Drawing.Point(9, 34);
            this.checkBox_LockVoltagePoint.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBox_LockVoltagePoint.Name = "checkBox_LockVoltagePoint";
            this.checkBox_LockVoltagePoint.Size = new System.Drawing.Size(124, 19);
            this.checkBox_LockVoltagePoint.TabIndex = 12;
            this.checkBox_LockVoltagePoint.Text = "Lock Voltage Point";
            this.checkBox_LockVoltagePoint.UseVisualStyleBackColor = true;
            // 
            // checkBox_TempTarget
            // 
            this.checkBox_TempTarget.AutoSize = true;
            this.checkBox_TempTarget.Location = new System.Drawing.Point(9, 57);
            this.checkBox_TempTarget.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBox_TempTarget.Name = "checkBox_TempTarget";
            this.checkBox_TempTarget.Size = new System.Drawing.Size(90, 19);
            this.checkBox_TempTarget.TabIndex = 13;
            this.checkBox_TempTarget.Text = "Temp Target";
            this.checkBox_TempTarget.UseVisualStyleBackColor = true;
            this.checkBox_TempTarget.CheckedChanged += new System.EventHandler(this.checkBox_TempTarget_CheckedChanged);
            // 
            // checkBox_TempPrioritize
            // 
            this.checkBox_TempPrioritize.AutoSize = true;
            this.checkBox_TempPrioritize.Enabled = false;
            this.checkBox_TempPrioritize.Location = new System.Drawing.Point(9, 80);
            this.checkBox_TempPrioritize.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBox_TempPrioritize.Name = "checkBox_TempPrioritize";
            this.checkBox_TempPrioritize.Size = new System.Drawing.Size(141, 19);
            this.checkBox_TempPrioritize.TabIndex = 14;
            this.checkBox_TempPrioritize.Text = "Prioritize Temperature";
            this.checkBox_TempPrioritize.UseVisualStyleBackColor = true;
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 108);
            this.Controls.Add(this.checkBox_TempPrioritize);
            this.Controls.Add(this.checkBox_TempTarget);
            this.Controls.Add(this.checkBox_LockVoltagePoint);
            this.Controls.Add(this.numeric_TempTarget);
            this.Controls.Add(this.button_Browse);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.numeric_PowerTarget);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numeric_LockVoltagePoint);
            this.Controls.Add(this.numeric_MemoryClockOffset);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numeric_BaseClockOffset);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::DCSLauncher.Properties.Resources.DCSLauncher;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form6";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "GPU Overclocking Setup";
            ((System.ComponentModel.ISupportInitialize)(this.numeric_BaseClockOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_MemoryClockOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_LockVoltagePoint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_PowerTarget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_TempTarget)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numeric_BaseClockOffset;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numeric_MemoryClockOffset;
        private System.Windows.Forms.NumericUpDown numeric_LockVoltagePoint;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numeric_PowerTarget;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Button button_Browse;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.NumericUpDown numeric_TempTarget;
        private System.Windows.Forms.CheckBox checkBox_LockVoltagePoint;
        private System.Windows.Forms.CheckBox checkBox_TempTarget;
        private System.Windows.Forms.CheckBox checkBox_TempPrioritize;
    }
}