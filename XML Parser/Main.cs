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

namespace CSV_Parser
{
    public partial class Main : Form
    {
        string tempDir;
        private string[] delimiter = { "\t", "\"\t\"", "\"\t", "\t\"" };
        public string SetErrorReason
        {
            set { ctlErrorReason.Text = value; }
        }
        public string setErrorCode
        {
            set { ctlErrorCode.Text = value; }
        }

        public Main()
        {
            InitializeComponent();
            tempDir = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(tempDir);

            ctlArn.TextChanged += clearTextBoxes;
            ctlChbDate.ValueChanged += clearTextBoxes;

        }


        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (tempDir != "" && Properties.Settings.Default.DeleteFIle == true)
            {
                Directory.Delete(tempDir, true);
            }
        }

        private void ctlCheck_Click(object sender, EventArgs e)
        {
            StatusWindow statuswin;
            statuswin = new StatusWindow(this, tempDir, delimiter, 
                ctlChbDate.Value.AddDays(Properties.Settings.Default.AddDays), ctlArn.Text);
            statuswin.ShowDialog();
        }

        private void clearTextBoxes(object sender, EventArgs e)
        {
            ctlErrorCode.Text = "";
            ctlErrorReason.Text = "";
        }
    }
}
