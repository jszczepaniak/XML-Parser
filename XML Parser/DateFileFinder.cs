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
        string folderName;
        List<string> ZipFilesPaths = new List<string>();
        DateTime Date { get; set; }
        string DateRRMMDD { get; set; }

        public List<string> FilesPaths
        {
            get { return ZipFilesPaths; }
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

            ZipFilesPaths = findFiles(date, path);
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
        /// Zwraca pliki zip z nazwą RRMMDD w zależności od podanej daty
        /// </summary>
        /// <param name="date">Dta, której trzeba użyć do szukania nazwy</param>
        /// <param name="path">Scieżka do szukania</param>
        /// <returns>Lista wyszukanych ścieżek do plików</returns>
        List<string> findFiles (DateTime date, string path)
        {
            string fileNameBeginning = DateRRMMDD;
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
