using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace XML_Parser
{
    public partial class Main : Form
    {
        string tempDir;

        public Main()
        {
            InitializeComponent();
            tempDir = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Dekompresor decomp = new Dekompresor();
            //string file;
            //OpenFileDialog fdial = new OpenFileDialog();

            //fdial.ShowDialog();
            //file = fdial.FileName;

            //if (decomp.setFilePath(file))
            //{
            //    decomp.uncompress();
            //    MessageBox.Show("done.");
            //}
            //else
            //{
            //    MessageBox.Show("To nie jest plik ZIP");
            //}

            //decomp = null;
            //fdial = null;
        }





        private void button2_Click(object sender, EventArgs e)
        {
            DateTime date = dateTimePicker1.Value;
            Dekompresor dekomp;

            //DateFileFinder finder = new DateFileFinder(date, @"D:\OneDrive\Dev\Temp\daty");

            //foreach (String STR in finder.FilesPaths)
            //{
            //    Debug.Print(STR);
            //}
            //Debug.Print(finder.FilesPaths.ToString());

            string dir;
            FolderBrowserDialog fdial = new FolderBrowserDialog();

            fdial.ShowDialog();
            dir = fdial.SelectedPath;

            DateFileFinder finder = new DateFileFinder(date, dir);

            Directory.CreateDirectory(tempDir);


            foreach (string filePath in finder.FilesPaths)
            {
                dekomp = new Dekompresor(filePath, tempDir);
                dekomp.uncompress();
                //dekomp.setFilePath(filePath);
                //dekomp.uncompress();
                //Debug.Print(filePath);
            }

            List<string> filesPaths ;
            filesPaths = finder.findFiles(tempDir);
            Debug.Print(tempDir);
            Directory.Delete(tempDir, true);
        }
    }
}
