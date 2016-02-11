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
        public List<string[]>CsvFieldsList { get; private set; }
        public string[] CsvHeadlines { get; private set; }
        private char delimiter;

        public XmlParser(char delimiter)
        {
            this.delimiter = delimiter;
            CsvHeadlines = null;
            CsvFieldsList = new List<string[]>();
        }

        public void addFile(string csvFilePath)
        {
            string[] parsedCsvLine;
            string textLine;
            StreamReader stream = new StreamReader(csvFilePath);

            textLine = stream.ReadLine();
            parsedCsvLine = textLine.Split(delimiter);
            if (CsvHeadlines == null)
            {
                CsvHeadlines = parsedCsvLine;
            }

            while (!stream.EndOfStream)
            {
                textLine = stream.ReadLine();
                parsedCsvLine = textLine.Split();
                CsvFieldsList.Add(parsedCsvLine);
            }
            
        }



    }
}
