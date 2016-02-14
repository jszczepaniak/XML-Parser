using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XML_Parser
{
    public partial class StatusWindow : Form
    {
        public string tempDir;
        DateTime fileNameDate;
        string ARN;
        private string[] delimiter;
        string incomingFilesPath = Properties.Settings.Default.IncomingFilesPath;

        public StatusWindow(string tempDir, string[] delimiter, DateTime fileNameDate, string ARN)
        {
            InitializeComponent();
            this.tempDir = tempDir;
            this.delimiter = delimiter;
            this.fileNameDate = fileNameDate;
            this.ARN = ARN;

        }

        private void backgroundWorkerErrorSearching_DoWork(object sender, DoWorkEventArgs e)
        {
            DateFileFinder finder = new DateFileFinder(fileNameDate, incomingFilesPath);
            
        }
    }
}
