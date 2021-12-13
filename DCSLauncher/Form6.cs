using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DCSLauncher
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            SettingsLoad();

            if (Convert.ToString(ConfigurationManager.AppSettings["NvidiaInspectorPath"]) == "")
            {
                var result = MessageBox.Show(new Form { TopMost = true }, "You need to select NVIDIA Inspector executable" + "\n" + "https://www.techpowerup.com/download/nvidia-inspector/", "Select nvidiaInspector.exe", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    button_Browse_Click(new object(), new EventArgs());
                }
            }
        }

        private void SettingsLoad()
        {
            int BaseClockOffset = Convert.ToInt32(ConfigurationManager.AppSettings["BaseClockOffset"]);
            int MemoryClockOffset = Convert.ToInt32(ConfigurationManager.AppSettings["MemoryClockOffset"]);
            decimal LockVoltagePoint = Convert.ToDecimal(ConfigurationManager.AppSettings["LockVoltagePoint"]);
            bool LockVoltagePointEnable = Convert.ToBoolean(ConfigurationManager.AppSettings["LockVoltagePointEnable"]);
            int PowerTarget = Convert.ToInt32(ConfigurationManager.AppSettings["PowerTarget"]);
            int TempTarget = Convert.ToInt32(ConfigurationManager.AppSettings["TempTarget"]);
            bool TempTargetEnable = Convert.ToBoolean(ConfigurationManager.AppSettings["TempTargetEnable"]);
            bool TempPrioritize = Convert.ToBoolean(ConfigurationManager.AppSettings["TempPrioritize"]);
            numeric_BaseClockOffset.Value = BaseClockOffset;
            numeric_MemoryClockOffset.Value = MemoryClockOffset;
            numeric_LockVoltagePoint.Value = LockVoltagePoint;
            checkBox_LockVoltagePoint.Checked = LockVoltagePointEnable;
            numeric_PowerTarget.Value = PowerTarget;
            numeric_TempTarget.Value = TempTarget;
            checkBox_TempTarget.Checked = TempTargetEnable;
            checkBox_TempPrioritize.Checked = TempPrioritize;
            string NvidiaInspectorPath = (ConfigurationManager.AppSettings["NvidiaInspectorPath"]);
            if (Convert.ToString(ConfigurationManager.AppSettings["NvidiaInspectorPath"]) != "")
            {
                this.numeric_BaseClockOffset.Enabled = true;
                this.numeric_MemoryClockOffset.Enabled = true;
                this.numeric_LockVoltagePoint.Enabled = true;
                this.checkBox_LockVoltagePoint.Enabled = true;
                this.numeric_PowerTarget.Enabled = true;
                this.numeric_TempTarget.Enabled = true;
                this.checkBox_TempTarget.Enabled = true;
            }
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            Utils.AddOrUpdateAppSettings("BaseClockOffset", Convert.ToString(numeric_BaseClockOffset.Value));
            Utils.AddOrUpdateAppSettings("MemoryClockOffset", Convert.ToString(numeric_MemoryClockOffset.Value));
            Utils.AddOrUpdateAppSettings("LockVoltagePoint", Convert.ToString(numeric_LockVoltagePoint.Value));
            Utils.AddOrUpdateAppSettings("LockVoltagePointEnable", Convert.ToString(checkBox_LockVoltagePoint.Checked));
            Utils.AddOrUpdateAppSettings("PowerTarget", Convert.ToString(numeric_PowerTarget.Value));
            Utils.AddOrUpdateAppSettings("TempTarget", Convert.ToString(numeric_TempTarget.Value));
            Utils.AddOrUpdateAppSettings("TempTargetEnable", Convert.ToString(checkBox_TempTarget.Checked));
            Utils.AddOrUpdateAppSettings("TempPrioritize", Convert.ToString(checkBox_TempPrioritize.Checked));
            this.Close();
        }

        private void button_Browse_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Select NVIDIA Inspector executable";
            openFileDialog1.Filter = "NVIDIA Inspector Executable|nvidiaInspector.exe";
            openFileDialog1.FileName = "nvidiaInspector.exe";
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + @"\";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string NvidiaInspectorPath = openFileDialog1.FileName;
                Utils.AddOrUpdateAppSettings("NvidiaInspectorPath", Convert.ToString(NvidiaInspectorPath));
            }
            SettingsLoad();
        }

        private void checkBox_TempTarget_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_TempTarget.Checked)
            {
                checkBox_TempPrioritize.Enabled = true;
            }
            else
            {
                checkBox_TempPrioritize.Enabled = false;
            }
        }
    }
}
