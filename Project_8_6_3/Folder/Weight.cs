using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_8_6_3.Folder
{
    internal class Weight
    {
        private static System.IO.FileInfo fileInfo;

        public Weight() { }

        private static long fileWeight { get; set; }
        private static bool chekDirectory { get; set; }
        private static string[] getDirectories { get; set; }
        private static string[] getFiles { get; set; }

        public static long Get(string MainDirectoryPath)
        {
            fileWeight = 0;
            chekDirectory = System.IO.Directory.Exists(MainDirectoryPath); // Directory Exists
            getDirectories = System.IO.Directory.GetDirectories(MainDirectoryPath);
            getFiles = System.IO.Directory.GetFiles(MainDirectoryPath);

            if (chekDirectory == true) // Directory Exists
            {
                foreach (string file in getFiles)
                {
                    fileInfo = new System.IO.FileInfo(file);
                    fileWeight += fileInfo.Length;
                }

                foreach (string secondaryDirectory in getDirectories)
                {
                    fileWeight += Get(secondaryDirectory);
                }
            }
            else
            {
                Console.WriteLine($"Директория {MainDirectoryPath} не найдена.");
            }

            return fileWeight;
        }
    }
}
