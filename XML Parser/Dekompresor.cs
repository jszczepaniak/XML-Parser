using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Ionic.Zip;

namespace XML_Parser
{
    /// <summary>
    /// Pozwala dekompresować pliki txt z archiwum ZIP
    /// </summary>
    class Dekompresor
    {
        ZipFile zip;
        //string filePath;
        private String sourcePath;
        string DestinationPath { get;  set; }
        List<string> unzippedFileList = new List<string>();

        String SourcePath
        {
            set
            {
                if (ZipFile.IsZipFile(value))
                {
                    sourcePath = value;
                }
                else
                {
                    sourcePath = null;
                }
            }
        }

        public List<string> FileList
        {
            get { return unzippedFileList; }
        }



        public Dekompresor(string sourcePath, string destinationPath)
        {
            SourcePath = sourcePath;
            DestinationPath = destinationPath;
        }

        /// <summary>
        /// Ustawia ścieżkę pliku i zwraca prawdę, jeśli plik jest ZIP-em.
        /// </summary>
        /// <param name="path">Ścieżka pliku.</param>
        /// <returns></returns>
        //public Boolean setFilePath(string path)
        //{
        //    if (ZipFile.IsZipFile(path))
        //    {

        //        filePath = path;
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        public List<string> uncompress()
        {
            if (sourcePath == null)
            {
                return null;
            }
            string unpackedFolder;
            zip = ZipFile.Read(sourcePath);
            foreach (var file in zip)

            {
                if (file.FileName.Substring(file.FileName.Length - 4).ToUpper() == ".TXT")
                {
                    unpackedFolder = Path.Combine(DestinationPath, Path.GetFileName(zip.Name));

                    Directory.CreateDirectory(unpackedFolder);
                    file.Extract(unpackedFolder);
                    unzippedFileList.Add(Path.Combine(unpackedFolder, file.FileName));
                }
            }
            return unzippedFileList;
        }

        //public string getTempFolder()
        //{
        //    string dest;
        //    dest = Environment.GetEnvironmentVariable("TEMP") + @"\parserxml";
        //    if (Directory.Exists(dest))
        //    {
        //        Directory.Delete(dest, true);
        //    }
        //    Directory.CreateDirectory(dest);
        //    return dest;

        //}
    }
}

