using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Ionic.Zip;

namespace XML_Parser
{
    class Dekompresor
    {
        ZipFile zip;
        string filePath;
        string destination;


        public Dekompresor()
        {
            destination = getTempFolder();
        }

        /// <summary>
        /// Ustawia ścieżkę pliku i zwraca prawdę, jeśli plik jest ZIP-em.
        /// </summary>
        /// <param name="path">Ścieżka pliku.</param>
        /// <returns></returns>
        public Boolean setFilePath(string path)
        {
            if (ZipFile.IsZipFile(path))
            {

                filePath = path;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void uncompress()
        {


            zip = ZipFile.Read(filePath);
            foreach (var file in zip)
            {
                if (file.FileName.Substring(file.FileName.Length-4) == "txt")
                {
                    file.Extract(destination);
                }
            }
        }

        string getTempFolder()
        {
            string dest;
            dest = Environment.GetEnvironmentVariable("TEMP") + "parserxml";
            if (Directory.Exists(dest))
            {
                Directory.Delete(dest);
            }
            Directory.CreateDirectory(dest);
            return dest;
        }
    }
}

