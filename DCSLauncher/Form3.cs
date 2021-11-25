using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DCSLauncher
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            SettingsLoad();
            ToolTip toolTip1 = new();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 250;
            toolTip1.ReshowDelay = 5000;
            toolTip1.ShowAlways = false;
            toolTip1.SetToolTip(button_Browse, (ConfigurationManager.AppSettings["LighthouseManagerPath"]));
            toolTip1.SetToolTip(textBox_LHB1MacAddress, "Lighthouse 1 MAC address");
            toolTip1.SetToolTip(textBox_LHB2MacAddress, "Lighthouse 2 MAC address");
            toolTip1.SetToolTip(checkBox_LHB1Enabled, "Enable lighthouse 1");
            toolTip1.SetToolTip(checkBox_LHB1Enabled, "Enable lighthouse 2");
            toolTip1.SetToolTip(button_Save, "Save Settings");
            toolTip1.SetToolTip(button_Browse, "Browse for lighthouse-v2-manager executable");
            toolTip1.SetToolTip(button_Start, "Manually start lighthouses");
            toolTip1.SetToolTip(button_Start, "Manually stop lighthouses");
            toolTip1.SetToolTip(button_Discover, "Discover lighthouses");

            if (Convert.ToString(ConfigurationManager.AppSettings["LighthouseManagerPath"]) == "")
            {
                var result = MessageBox.Show(new Form { TopMost = true }, "You need to select lighthouse-v2-manager executable" +"\n" + "https://github.com/nouser2013/lighthouse-v2-manager/", "Select lighthouse-v2-manager.exe", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    button_Browse_Click(new object(), new EventArgs());
                }
            }

        }
        public static class Globals
        {
            public static string LighthouseManagerPath { get; set; }
            public static bool LHB1Enabled { get; set; }
            public static bool LHB2Enabled { get; set; }
            public static string LHB1MacAddress { get; set; }
            public static string LHB2MacAddress { get; set; }
        }

        private void SettingsLoad()
        {
            Globals.LighthouseManagerPath = (ConfigurationManager.AppSettings["LighthouseManagerPath"]);
            Globals.LHB1MacAddress = (ConfigurationManager.AppSettings["LHB1MacAddress"]);
            Globals.LHB2MacAddress = (ConfigurationManager.AppSettings["LHB2MacAddress"]);
            Globals.LHB1Enabled = Convert.ToBoolean(ConfigurationManager.AppSettings["LHB1Enabled"]);
            Globals.LHB2Enabled = Convert.ToBoolean(ConfigurationManager.AppSettings["LHB2Enabled"]);
            this.textBox_LHB1MacAddress.Text = Globals.LHB1MacAddress;
            this.textBox_LHB2MacAddress.Text = Globals.LHB2MacAddress;
            this.checkBox_LHB1Enabled.Checked = Globals.LHB1Enabled;
            this.checkBox_LHB2Enabled.Checked = Globals.LHB2Enabled;
            if (Globals.LighthouseManagerPath == "")
            {
                this.textBox_LHB1MacAddress.Enabled = false;
                this.textBox_LHB2MacAddress.Enabled = false;
                this.checkBox_LHB1Enabled.Enabled = false;
                this.checkBox_LHB2Enabled.Enabled = false;
                this.button_Discover.Enabled = false;
                this.button_Start.Enabled = false;
                this.button_Stop.Enabled = false;
            }
        }
        public static void LHBControl(string action)
        {
            string[] lighthouses = { "", "" };
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["LHB1Enabled"]))
            {
                lighthouses[0] = (ConfigurationManager.AppSettings["LHB1MacAddress"]);
            }
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["LHB2Enabled"]))
            {
                lighthouses[1] = (ConfigurationManager.AppSettings["LHB2MacAddress"]);
            }
            ProcessStartInfo startInfo = new();
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.FileName = (ConfigurationManager.AppSettings["LighthouseManagerPath"]);
            startInfo.Arguments = action+" "+lighthouses[0]+" "+lighthouses[1];
            try
                {
                Process.Start(startInfo);
            }
            catch (Exception err)
                {
                Console.WriteLine("Lighthouse operation failed!");
                Console.WriteLine(err.Message);
                }
        }

        private void button_Start_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Manually turning on lighthouses...");
            LHBControl("on");
        }

        private void button_Stop_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Manually turning off lighthouses...");
            LHBControl("off");
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            Utils.AddOrUpdateAppSettings("LHB1Enabled", Convert.ToString(checkBox_LHB1Enabled.Checked));
            Utils.AddOrUpdateAppSettings("LHB2Enabled", Convert.ToString(checkBox_LHB2Enabled.Checked));
            Utils.AddOrUpdateAppSettings("LHB1MacAddress", textBox_LHB1MacAddress.Text);
            Utils.AddOrUpdateAppSettings("LHB2MacAddress", textBox_LHB2MacAddress.Text);
            this.Close();
        }

        private void checkBox_LHB1Enabled_CheckedChanged(object sender, EventArgs e)
        {
            Globals.LHB1Enabled = true;
        }

        private void checkBox_LHB2Enabled_CheckedChanged(object sender, EventArgs e)
        {
            Globals.LHB2Enabled = true;
        }

        private void textBox_LHB1MacAddress_TextChanged(object sender, EventArgs e)
        {
            Globals.LHB1MacAddress = textBox_LHB1MacAddress.Text;
        }

        private void textBox_LHB2MacAddress_TextChanged(object sender, EventArgs e)
        {
            Globals.LHB2MacAddress = textBox_LHB2MacAddress.Text;
        }
        private void button_Discover_Click(object sender, EventArgs e)
        {
            ProcessStartInfo startInfo = new();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.FileName = "CMD.EXE";
            startInfo.Arguments = @"/K" +"\"" + Globals.LighthouseManagerPath + "\"" + " discover";
            try
            {
                Process.Start(startInfo);
            }
            catch
            {
                Console.WriteLine("Error!");
            }
        }

        private void button_Browse_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Select Lighthouse V2 Manager executable";
            openFileDialog1.Filter = "Lighthouse V2 Manager Executable|lighthouse-v2-manager.exe";
            openFileDialog1.FileName = "lighthouse-v2-manager.exe";
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + @"\";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string LighthouseManagerPath = openFileDialog1.FileName;
                Utils.AddOrUpdateAppSettings("LighthouseManagerPath", Convert.ToString(LighthouseManagerPath));
            }
        }
    }
}
