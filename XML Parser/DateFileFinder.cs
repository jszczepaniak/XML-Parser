using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace XML_Parser
{
    class DateFileFinder
    {
        List<string> filesPaths = new List<string>();

        string folderName;
        public DateTime Date { get; set; }
        public string DateRRMMDD { get; set; }

        public List<string> FilesPaths 
        {
            get { return filesPaths; }
        }

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="date">Data do przekszałcenia</param>
        public DateFileFinder(DateTime date, string path)
        {
            Date = date;
            folderName = path;
            Date = date;
            DateRRMMDD = dateToStringRRMMDD(date);

            filesPaths = findFileByDate(date, path);
        }

        string dateToStringRRMMDD(DateTime date)
        {
            string year, month, day;
            year = date.Year.ToString().Substring(2);
            month = date.Month.ToString("00");
            day = date.Day.ToString("00");

            return year + month + day;
        }

        List<string> findFileByDate (DateTime date, string path)
        {
            string fileNameBeginning = dateToStringRRMMDD(date);
            List<string> paths = new List<string>();
            string fileName;
            foreach (string filePath in Directory.EnumerateFiles(path))
            {
                fileName = Path.GetFileName(filePath);
                if (fileName.Substring(4).ToUpper() == ".ZIP" | fileName.Substring(0,6) == fileNameBeginning)
                {
                    paths.Add(filePath);
                }
            }
            if(Directory.EnumerateDirectories(path).Count() !=0)
            {


                foreach (string folderPath in Directory.EnumerateDirectories(path))
                {

                    paths.AddRange(findFileByDate(date, folderPath));
                }
            }
            return paths;
            
        }
    }
}
