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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dekompresor decomp = new Dekompresor();
            string file;
            OpenFileDialog fdial = new OpenFileDialog();

            fdial.ShowDialog();
            file = fdial.FileName;

            if (decomp.setFilePath(file))
            {
                decomp.uncompress();
                MessageBox.Show("done.");
            }
            else
            {
                MessageBox.Show("To nie jest plik ZIP");
            }

            decomp = null;
            fdial = null;
        }
    }
}
