using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DCSLauncher
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            Globals.SourceFolder = (ConfigurationManager.AppSettings["DCSSavedGamesPathBase"]);
            comboBox_CustomSplash.SelectedIndex = 0;
        }
        public static class Globals
        {
            public static string SourceFolder { get; set; }
            public static string TargetFolder { get; set; }
            public static string TargetFolderFullPath { get; set; }
        }
        [DllImport("Kernel32.dll", CharSet = CharSet.Unicode)]
        static extern bool CreateHardLink(
        string lpFileName,
        string lpExistingFileName,
        IntPtr lpSecurityAttributes
        );
        public static class SpecialFolder
        {
            public static string SavedGames => _SavedGames ??= GetSavedGames();
            private static string GetSavedGames()
            {
                if (Environment.OSVersion.Version.Major < 6)
                    throw new NotSupportedException();

                var pathPtr = IntPtr.Zero;
                try
                {
                    if (SHGetKnownFolderPath(ref _folderSavedGames, 0, IntPtr.Zero, out pathPtr) != 0)
                        throw new DirectoryNotFoundException();
                    return Marshal.PtrToStringUni(pathPtr);
                }
                finally
                {
                    Marshal.FreeCoTaskMem(pathPtr);
                }
            }

            [DllImport("shell32.dll", CharSet = CharSet.Auto)]
            private static extern int SHGetKnownFolderPath(ref Guid id, int flags, IntPtr token, out IntPtr path);

            private static Guid _folderSavedGames = new Guid("4C5C32FF-BB9D-43B0-B5B4-2D72E54EAAA4");
            private static string _SavedGames;
        }
        public bool DirectoryNotEmpty(string path)
        {
            return Directory.EnumerateFileSystemEntries(path).Any();
        }
        public bool DirectoryEmpty(string path)
        {
            return !Directory.EnumerateFileSystemEntries(path).Any();
        }
        private void button_PopulateBrowse_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.Description = "Select Target Saved Games Folder";
            folderBrowserDialog1.SelectedPath = Form1.Globals.SavedGamesPath;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                Globals.TargetFolderFullPath = folderBrowserDialog1.SelectedPath;
                Globals.TargetFolder = Path.GetFileName(folderBrowserDialog1.SelectedPath);
                textBox_TargetFolder.Text = Globals.TargetFolder;
            }
        }
        public void DisableDynTicks()
        {
            Console.WriteLine("Disabling dynamic ticks & HPET...");
            Process.Start("bcdedit.exe", "/deletevalue useplatformclock");
            Process.Start("bcdedit.exe", "/set disabledynamictick yes");
        }
        public void EnableDynTicks()
        {
            Console.WriteLine("Enabling dynamic ticks & HPET...");
            Process.Start("bcdedit.exe", "/set useplatformclock true");
            Process.Start("bcdedit.exe", "/set disabledynamictick no");
        }
        private void button_Populate_Click(object sender, EventArgs e)
        {
            if (Globals.SourceFolder == "")
            {
                MessageBox.Show("Source folder not specified! Please specify your default settings folder in Launcher Settings", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (Globals.TargetFolder == null)
            {
                MessageBox.Show("Target folder not specified!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (Directory.Exists(Globals.TargetFolderFullPath) && DirectoryNotEmpty(Globals.TargetFolderFullPath))
            {
                MessageBox.Show("Target folder already exists and is not empty! Please review and empty it manually.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var populatequery = MessageBox.Show("Source folder: " + Globals.SourceFolder + "\n" + "Target folder: " + Globals.TargetFolderFullPath + "\n\n" + "Proceed with operation?",
                    "Populating new settings folder",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (populatequery == DialogResult.Yes)
                {
                    Directory.CreateDirectory(Globals.TargetFolderFullPath);
                    Directory.CreateDirectory(Globals.TargetFolderFullPath + @"\Config");
                    CreateMaps.JunctionPoint.Create(Globals.TargetFolderFullPath + @"\Config\Input", Globals.SourceFolder + @"\Config\Input", false);
                    CreateMaps.JunctionPoint.Create(Globals.TargetFolderFullPath + @"\ImagesShop", Globals.SourceFolder + @"\ImagesShop", false);
                    CreateMaps.JunctionPoint.Create(Globals.TargetFolderFullPath + @"\MissionEditor", Globals.SourceFolder + @"\MissionEditor", false);
                    CreateMaps.JunctionPoint.Create(Globals.TargetFolderFullPath + @"\Missions", Globals.SourceFolder + @"\Missions", false);
                    CreateMaps.JunctionPoint.Create(Globals.TargetFolderFullPath + @"\Movies", Globals.SourceFolder + @"\Movies", false);
                    CreateMaps.JunctionPoint.Create(Globals.TargetFolderFullPath + @"\Scripts", Globals.SourceFolder + @"\Scripts", false);
                    CreateMaps.JunctionPoint.Create(Globals.TargetFolderFullPath + @"\Tracks", Globals.SourceFolder + @"\Tracks", false);
                    CreateHardLink(Globals.TargetFolderFullPath + @"\Config\authdata.bin", Globals.SourceFolder + @"\Config\authdata.bin", IntPtr.Zero);
                    CreateHardLink(Globals.TargetFolderFullPath + @"\Config\imgui.ini", Globals.SourceFolder + @"\Config\imgui.ini", IntPtr.Zero);
                    CreateHardLink(Globals.TargetFolderFullPath + @"\Config\network.vault", Globals.SourceFolder + @"\Config\network.vault", IntPtr.Zero);
                    MessageBox.Show("New DCS settings folder \""+Globals.TargetFolder+"\" created successfully!");
                    textBox_TargetFolder.Text = null;
                }
            }
        }

        /*                    if (checkBox_UseCustomSplash.Checked)
                    {
                        string CustomSplashFileName = Convert.ToString(textBox_CustomSplashPath.Text);
                string DestFileName = "StartImage.bmp";
                string DCSPath = (ConfigurationManager.AppSettings["DCSPath"]);
                string FullPath = Path.Combine(DCSPath, "FUI\\Common");
                string Destination = Path.Combine(FullPath, DestFileName);
                File.Copy(CustomSplashFileName, Destination, true);
                        MessageBox.Show("Splash image replaced", "Settings applied");
                    }
                    if (checkBox_SplashResize.Checked)
                    {
                        string DestFileName = "StartImage.bmp";
            string DCSPath = (ConfigurationManager.AppSettings["DCSPath"]);
            string FullPath = Path.Combine(DCSPath, "FUI\\Common");
            string Destination = Path.Combine(FullPath, DestFileName);
            int SplashWidth = Convert.ToInt32(numeric_SplashWidth.Value);
            int SplashHeight = Convert.ToInt32(numeric_SplashHeight.Value);
            var SplashFile = Image.FromFile(Destination);
            var resized = ResizeWithSameRatio(SplashFile, SplashWidth, SplashHeight);
            var ms = new MemoryStream();
            resized.Save(ms, ImageFormat.Bmp);
                        SplashFile.Dispose();
                        using (FileStream fs = new FileStream(Destination, FileMode.Create, FileAccess.ReadWrite))
                        {
                            resized.Save(ms, ImageFormat.Bmp);
                            byte[] bytes = ms.ToArray();
            fs.Write(bytes, 0, bytes.Length);
                        }
        MessageBox.Show("Splash image resized", "Settings applied");
                    }*/

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


        private void textBox_TargetFolder_TextChanged(object sender, EventArgs e)
        {
            Globals.TargetFolder = textBox_TargetFolder.Text;
            Globals.TargetFolderFullPath = SpecialFolder.SavedGames + @"\" + Globals.TargetFolder;
        }

        private void button_DeleteFxo_Click(object sender, EventArgs e)
        {
            var fxoPath = Globals.TargetFolderFullPath + "/fxo";
            DirectoryInfo di = new DirectoryInfo(fxoPath);
            if (Globals.TargetFolder == null)
            {
                MessageBox.Show("Target folder not specified!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (DirectoryEmpty(fxoPath))
            {
                MessageBox.Show("Specified fxo folder is empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (Directory.Exists(Globals.TargetFolderFullPath) && DirectoryNotEmpty(fxoPath))
            {
                int fCount = Directory.GetFiles(fxoPath, "*", SearchOption.AllDirectories).Length;
                var deletequery = MessageBox.Show(fCount + " files in directory will be deleted. Are you sure?", "Delete " + fCount + " files?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (deletequery == DialogResult.Yes)
                {
                    foreach (FileInfo file in di.GetFiles())
                    {
                        file.Delete();
                    }
                }
            }
        }

        private void button_DeleteMetashaders2_Click(object sender, EventArgs e)
        {
            var metashaders2Path = Globals.TargetFolderFullPath + "/metashaders2";
            DirectoryInfo di = new DirectoryInfo(metashaders2Path);
            if (Globals.TargetFolder == null)
            {
                MessageBox.Show("Target folder not specified!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (DirectoryEmpty(metashaders2Path))
            {
                MessageBox.Show("Specified metashaders2 folder is empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (Directory.Exists(Globals.TargetFolderFullPath) && DirectoryNotEmpty(metashaders2Path))
            {
                int fCount = Directory.GetFiles(metashaders2Path, "*", SearchOption.AllDirectories).Length;
                var deletequery = MessageBox.Show(fCount + " files in directory will be deleted. Are you sure?", "Delete " + fCount + " files?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (deletequery == DialogResult.Yes)
                {
                    foreach (FileInfo file in di.GetFiles())
                    {
                        file.Delete();
                    }
                }
            }
        }

        private void button_DisableDynTicks_Click(object sender, EventArgs e)
        {
            DisableDynTicks();
        }
        private void CustomSplashPath_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Select custom splash";
            openFileDialog1.Filter = "Bitmap images|*.bmp";
            //openFileDialog1.FileName = "";
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\";
            DialogResult result = openFileDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string CustomSplashPath = openFileDialog1.FileName;
                    textBox_CustomSplashPath.Text = CustomSplashPath;
                    pictureBox_CustomSplash.Image = Image.FromFile(openFileDialog1.FileName);
                    Utils.AddOrUpdateAppSettings("CustomSplashPath", Convert.ToString(CustomSplashPath));
                }
        }
        private void pictureBox_CustomSplash_Click(object sender, EventArgs e)
        {

        }

        private void comboBox_CustomSplash_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_CustomSplash.SelectedIndex == 0)
            {
                pictureBox_CustomSplash.Image = null;
            }
            if (comboBox_CustomSplash.SelectedIndex == 1)
            {
                pictureBox_CustomSplash.Image = Properties.Resources.StartImage_default;
            }
            if (comboBox_CustomSplash.SelectedIndex == 2)
            {
                pictureBox_CustomSplash.Image = Properties.Resources.StartImage_VR;
            }
        }

        private void button_SplashApply_Click(object sender, EventArgs e)
        {
            //string CustomSplashFileName = Convert.ToString(textBox_CustomSplashPath.Text);
            string DestFileName = "StartImage.bmp";
            string DCSPath = (ConfigurationManager.AppSettings["DCSPath"]);
            string FullPath = Path.Combine(DCSPath, "FUI\\Common");
            string Destination = Path.Combine(FullPath, DestFileName);

            //File.Copy(CustomSplashFileName, Destination, true);

            //System.IO.MemoryStream ms = new System.IO.MemoryStream();
            //pictureBox_CustomSplash.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            //byte[] ar = new byte[ms.Length];
            //ms.Write(ar, 0, ar.Length);

            pictureBox_CustomSplash.Image.Save(Destination, System.Drawing.Imaging.ImageFormat.Bmp);
            MessageBox.Show("Splash image replaced", "Settings applied");

            if (checkBox_SplashResize.Checked)
            {
                int SplashWidth = Convert.ToInt32(numeric_SplashWidth.Value);
                int SplashHeight = Convert.ToInt32(numeric_SplashHeight.Value);
                var SplashFile = Image.FromFile(Destination);
                var resized = ResizeWithSameRatio(SplashFile, SplashWidth, SplashHeight);
                var ms = new MemoryStream();
                resized.Save(ms, ImageFormat.Bmp);
                SplashFile.Dispose();
                using (FileStream fs = new FileStream(Destination, FileMode.Create, FileAccess.ReadWrite))
                {
                    resized.Save(ms, ImageFormat.Bmp);
                    byte[] bytes = ms.ToArray();
                    fs.Write(bytes, 0, bytes.Length);
                }
                MessageBox.Show("Splash image resized", "Settings applied");
            }
        }
    }
}
