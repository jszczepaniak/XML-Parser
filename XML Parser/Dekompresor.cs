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
    /// Pozwala dekompresować pliki txt z archiwum ZIP i szukać plików txt w folderze
    /// </summary>
    class Dekompresor
    {
        ZipFile zip;
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
                if (Path.GetExtension(file.FileName).ToUpper() == ".TXT")
                {
                    unpackedFolder = Path.Combine(DestinationPath, Path.GetFileName(zip.Name));

                    Directory.CreateDirectory(unpackedFolder);
                    file.Extract(unpackedFolder);
                    unzippedFileList.Add(Path.Combine(unpackedFolder, file.FileName));
                }
            }
            return unzippedFileList;
        }
    }
}

