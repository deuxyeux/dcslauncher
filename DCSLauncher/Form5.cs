using System;
using System.Collections.Generic;
using System.Management;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DCSLauncher
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            CreateFiles();
            RefreshDevices();
            LoadDevices();
        }
        public void RefreshDevices()
        {
            listBox3.Items.Clear();
            var list = DeviceCheck.GetUSBDevices();
            foreach (var device in list)
            {
                listBox3.Items.Add(device.PnpDeviceID);
            }
        }
        public void CreateFiles()
        {
            if (!File.Exists("Controllers.txt"))
            {
                File.Create("Controllers.txt").Dispose();
            }
            if (!File.Exists("HMD.txt"))
            {
                File.Create("HMD.txt").Dispose();
            }
        }
        public void LoadDevices()
        {
            string[] Controllers = File.ReadAllLines("Controllers.txt");
            string[] HMD = File.ReadAllLines("HMD.txt");
            listBox1.Items.AddRange(Controllers);
            listBox2.Items.AddRange(HMD);
        }

        private void button_AddToControllers_Click(object sender, EventArgs e)
        {
            if (textBox_DeviceID.Text == "")
            {
                listBox1.Items.Add(listBox3.SelectedItem);
            }
            else
            {
                listBox1.Items.Add(textBox_DeviceID.Text);
            }
        }

        private void button_AddToHMD_Click(object sender, EventArgs e)
        {
            if (textBox_DeviceID.Text == "")
            {
                listBox2.Items.Add(listBox3.SelectedItem);
            }
            else
            {
                listBox2.Items.Add(textBox_DeviceID.Text);
            }
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            const string ControllerListPath = "Controllers.txt";
            const string HMDListPath = "HMD.txt";

            System.IO.StreamWriter SaveFile1 = new System.IO.StreamWriter(ControllerListPath);
            foreach (var item in listBox1.Items)
            {
                SaveFile1.WriteLine(item);
            }
            SaveFile1.Close();

            System.IO.StreamWriter SaveFile2 = new System.IO.StreamWriter(HMDListPath);
            foreach (var item in listBox2.Items)
            {
                SaveFile2.WriteLine(item);
            }
            SaveFile2.Close();
            this.Close();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button_Refresh_Click(object sender, EventArgs e)
        {
            RefreshDevices();
        }
    }
}
