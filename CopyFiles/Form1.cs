using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CopyFiles
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            if (button2.Text != "overview" && button3.Text != "overview")
            {
                Copy(button2.Text, button3.Text);
            }
            else if (button2.Text == "overview") {
                MessageBox.Show("Please, select  source path");
            }
            else if (button3.Text == "overview") {
                MessageBox.Show("Please, select  execute path");
            }
            else
            {
                MessageBox.Show("Please, select  all pathes");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd1 = new FolderBrowserDialog();
            fbd1.Description = "Select the folder to copy";
            if(fbd1.ShowDialog()== System.Windows.Forms.DialogResult.OK)
            {
                //MessageBox.Show(fbd.SelectedPath);
                button2.Text = fbd1.SelectedPath;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd2 = new FolderBrowserDialog();
            fbd2.Description = "Select the folder to save files";
            if (fbd2.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
             //   MessageBox.Show(fbd.SelectedPath);
                button3.Text = fbd2.SelectedPath;
            }
        }
        public static void Copy(String source, String execute)
        {
            string sourceDir = @source;
            string backupDir = @execute;

            try
            {
                string[] picList = Directory.GetFiles(sourceDir, "*.jpg");
                string[] pngList = Directory.GetFiles(sourceDir, "*.png");
                string[] txtList = Directory.GetFiles(sourceDir, "*.txt");
                string[] pdfList = Directory.GetFiles(sourceDir, "*.pdf");

                // Copy picture files.
                foreach (string f in picList)
                {
                    // Remove path from the file name.
                    string fName = f.Substring(sourceDir.Length + 1);

                    // Use the Path.Combine method to safely append the file name to the path.
                    // Will overwrite if the destination file already exists.
                    File.Copy(Path.Combine(sourceDir, fName), Path.Combine(backupDir, fName), true);
                }
                foreach (string f in pngList)
                {
                    // Remove path from the file name.
                    string fName = f.Substring(sourceDir.Length + 1);

                    // Use the Path.Combine method to safely append the file name to the path.
                    // Will overwrite if the destination file already exists.
                    File.Copy(Path.Combine(sourceDir, fName), Path.Combine(backupDir, fName), true);
                }
                // Copy text files.
                foreach (string f in txtList)
                {

                    // Remove path from the file name.
                    string fName = f.Substring(sourceDir.Length + 1);

                    try
                    {
                        // Will not overwrite if the destination file already exists.
                        File.Copy(Path.Combine(sourceDir, fName), Path.Combine(backupDir, fName));
                    }

                    // Catch exception if the file was already copied.
                    catch (IOException copyError)
                    {
                        Console.WriteLine(copyError.Message);
                    }
                }
                foreach (string f in pdfList)
                {

                    // Remove path from the file name.
                    string fName = f.Substring(sourceDir.Length + 1);

                    try
                    {
                        // Will not overwrite if the destination file already exists.
                        File.Copy(Path.Combine(sourceDir, fName), Path.Combine(backupDir, fName));
                    }

                    // Catch exception if the file was already copied.
                    catch (IOException copyError)
                    {
                        Console.WriteLine(copyError.Message);
                    }
                }
                // Delete source files that were copied.
                foreach (string f in txtList)
                {
                    File.Delete(f);
                }
                foreach (string f in picList)
                {
                    File.Delete(f);
                }
                foreach (string f in pngList)
                {
                    File.Delete(f);
                }
                foreach (string f in pdfList)
                {
                    File.Delete(f);
                }


            }

            catch (DirectoryNotFoundException dirNotFound)
            {
                Console.WriteLine(dirNotFound.Message);
            }
        }
    }
}
