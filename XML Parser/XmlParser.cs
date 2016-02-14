using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace XML_Parser
{
    class XmlParser
    {
        public List<string[]> ErrorLineList { get; private set; }
        public List<string[]> TransactionLineList { get; private set; }
        public string[] CsvHeadlines { get; private set; }
        //private char delimiter;
        private string[] delimiter;
        private string fileBeginning;

        //public XmlParser(char delimiter, string fileBeginning)
        public XmlParser(string[] Delimiter, string fileBeginning)
        {
            this.delimiter = Delimiter;
            this.fileBeginning = fileBeginning;
            CsvHeadlines = null;
            ErrorLineList = new List<string[]>();
            TransactionLineList = new List<string[]>();
        }

        public void addFile(string csvFilePath)
        {
            string[] parsedCsvLine;
            string textLine;
            StreamReader stream = new StreamReader(csvFilePath);

            textLine = stream.ReadLine();
            //parsedCsvLine = textLine.Split(delimiter);
            parsedCsvLine = textLine.Split(delimiter, StringSplitOptions.None);
            if (CsvHeadlines == null)
            {
                CsvHeadlines = parsedCsvLine;
            }

            while (!stream.EndOfStream)
            {
                textLine = stream.ReadLine();
                if (textLine.StartsWith(fileBeginning))
                {
                    // Dodanie wiersza do ErrorLineList
                    parsedCsvLine = textLine.Split(delimiter, StringSplitOptions.None);
                    ErrorLineList.Add(parsedCsvLine);

                    // Dodanie kolejnego wiersza do TransactionLineList
                    textLine = stream.ReadLine();
                    parsedCsvLine = textLine.Split(delimiter, StringSplitOptions.None);
                    TransactionLineList.Add(parsedCsvLine);
                }


            }
            stream.Close();
            stream = null;
        }



    }
}
