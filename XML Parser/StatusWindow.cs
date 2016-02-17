using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CSV_Parser
{
    public partial class StatusWindow : Form
    {
        public string tempDir;
        DateTime fileNameDate;
        string ARN;
        private string[] delimiter;
        string incomingFilesPath = Properties.Settings.Default.IncomingFilesPath;
        Main main;

        public StatusWindow(Main main, string tempDir, string[] delimiter, DateTime fileNameDate, string ARN)
        {
            InitializeComponent();
            // this.tempDir = tempDir;
            this.tempDir = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(tempDir);
            this.delimiter = delimiter;
            this.fileNameDate = fileNameDate;
            this.ARN = ARN;
            backgroundWorkerErrorSearching.RunWorkerAsync();
            this.main = main;

        }

        private void backgroundWorkerErrorSearching_DoWork(object sender, DoWorkEventArgs e)
        {
            List<string> zipfilesPaths;
            List<string> txtfilesPaths;
            DateFileFinder finder = new DateFileFinder(fileNameDate, incomingFilesPath);
            Dekompresor dekomp;
            CsvParser parser;
            BackgroundWorker bw = sender as BackgroundWorker;
            int progress;

            progress = 0;
            bw.ReportProgress(progress, "Szukam plików..." + Environment.NewLine);

            zipfilesPaths = finder.FilesPaths;
            if (zipfilesPaths.Count() == 0)
            {
                progress = 99;
                bw.ReportProgress(progress, "Nie znaleziono plików." + Environment.NewLine);
                MessageBox.Show(
                        "W folderze " + incomingFilesPath + " nie znaleziono pliku rozliczeniowego z potencjalną datą wpłynięcia błędu.", "Nie znaleziono",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            for (int i = 0; i < zipfilesPaths.Count(); i++)
            {
                progress = 10 + (int)(40 / zipfilesPaths.Count()) * i+1; 
                bw.ReportProgress(progress, "Wypakowuję plik (" + (i+1).ToString() + " z " + zipfilesPaths.Count().ToString() + ")..." + Environment.NewLine);

                dekomp = new Dekompresor(zipfilesPaths.ElementAt(i), tempDir);
                dekomp.uncompress();
                //todo: Zwracanie progresu
            }

            txtfilesPaths = finder.findFiles(tempDir);

            parser = new CsvParser(delimiter, Properties.Settings.Default.ErrorLineCode);
            for (int i = 0; i < txtfilesPaths.Count; i++)
            {
                progress = 50 + (int)(45 / txtfilesPaths.Count()) * i + 1;
                bw.ReportProgress(
                    progress, "Przetwarzam plik (" + (i + 1).ToString() + " z " + txtfilesPaths.Count.ToString() + ")..." + Environment.NewLine);
                parser.addFile(txtfilesPaths.ElementAt(i));
            }
            progress = 95;
            bw.ReportProgress(progress, "Szukam ARN..." + Environment.NewLine);
            progress = 100;
            bw.ReportProgress(progress, getChbErrorParameters(parser, ARN));

        }

        private void backgroundWorkerErrorSearching_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            string logLine;
            string[] result;
            progressBar1.Value = e.ProgressPercentage;
            if (e.ProgressPercentage == 100)
            {
                if (e.UserState == null)
                {
                    MessageBox.Show(
                        "Brak takiego ARN w plikach incoming. Sprawdź inną datę.", "Nie znaleziono",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    logLine = "Nie znaleziono ARN." + Environment.NewLine;
                }
                else
                {
                    logLine = "Koniec." + Environment.NewLine;
                    result = (string[])e.UserState;
                    main.SetErrorReason = result[0];
                    main.setErrorCode = result[1];

                    this.Hide();
                }

            }
            else
            {
                logLine = (string)e.UserState;
            }
            ctlLogBox.Text += logLine;
        }

        /// <summary>
        /// Zwraca tablicę {messageText, errorCode}
        /// </summary>
        /// <param name="parser">Obiekt typu CsvParser</param>
        /// <param name="arn">Szukany ARN</param>
        /// <returns></returns>
        private string[] getChbErrorParameters (CsvParser parser, string arn)
        {
            int arnPosition = Properties.Settings.Default.ArnFieldPosition;
            int messageTextPosition = Properties.Settings.Default.MessageTextPosition;
            int errorCodePosition = Properties.Settings.Default.ErrorCodePosition;
            string messageText, errorCode;
            string[] result = new string[2];

            for (int i = 0; i < parser.TransactionLineList.Count(); i++)
            {
                if (parser.TransactionLineList.ElementAt(i)[arnPosition].Replace("\"", "") == arn)
                {
                    messageText = parser.ErrorLineList.ElementAt(i)[messageTextPosition].Replace("\"", "");
                    errorCode = parser.ErrorLineList.ElementAt(i)[errorCodePosition].Replace("\"", "");
                    result[0] = messageText;
                    result[1] = errorCode;
                    return result;

                }
            }
            return null;
        }

        private void backgroundWorkerErrorSearching_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Hide();
            if (Directory.Exists(tempDir) && Properties.Settings.Default.DeleteFIle == true)
            {
                Directory.Delete(tempDir, true);
            }
        }

        private void ctlLogBox_TextChanged(object sender, EventArgs e)
        {
            ctlLogBox.SelectionStart = ctlLogBox.TextLength;
            ctlLogBox.ScrollToCaret();
        }
    }
}
