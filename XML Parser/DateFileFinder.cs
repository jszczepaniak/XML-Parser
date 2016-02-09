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

            filesPaths = findFiles(date, path);
        }

        string dateToStringRRMMDD(DateTime date)
        {
            string year, month, day;
            year = date.Year.ToString().Substring(2);
            month = date.Month.ToString("00");
            day = date.Day.ToString("00");

            return year + month + day;
        }
        /// <summary>
        /// Zwraca pliki z nazwą RRMMDD w zależności od podanej daty
        /// </summary>
        /// <param name="date">Dta, której trzeba użyć do szukania nazwy</param>
        /// <param name="path">Scieżka do szukania</param>
        /// <returns>Lista wyszukanych ścieżek do plików</returns>
        List<string> findFiles (DateTime date, string path)
        {
            string fileNameBeginning = dateToStringRRMMDD(date);
            List<string> paths = new List<string>();
            string fileName;
            foreach (string filePath in Directory.EnumerateFiles(path))
            {
                fileName = Path.GetFileName(filePath);
				if (Path.GetExtension(fileName).ToUpper() == ".ZIP" & fileName.Substring(0,6) == fileNameBeginning)
                {
                    paths.Add(filePath);
                }
            }
            if(Directory.EnumerateDirectories(path).Count() !=0)
            {


                foreach (string folderPath in Directory.EnumerateDirectories(path))
                {

                    paths.AddRange(findFiles(date, folderPath));
                }
            }
            return paths;
            
        }
        /// <summary>
        /// Zwraca pliki txt z katalogu i podkatalogów
        /// </summary>
        /// <param name="path">Katalog do przeszukania</param>
        /// <returns>Lista wyszukanych ścieżek do plików</returns>
        public List<string> findFiles(string path)
        {

            List<string> paths = new List<string>();
            string fileName;
            foreach (string filePath in Directory.EnumerateFiles(path))
            {
                fileName = Path.GetFileName(filePath);
                if (Path.GetExtension(fileName).ToUpper() == ".TXT")
                {
                    paths.Add(filePath);
                }
            }
            if (Directory.EnumerateDirectories(path).Count() != 0)
            {


                foreach (string folderPath in Directory.EnumerateDirectories(path))
                {

                    paths.AddRange(findFiles(folderPath));
                }
            }
            return paths;

        }
    }
}
