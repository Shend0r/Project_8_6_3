using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_8_6_3.Folder
{
    internal class Directory
    {
        private static DateTime autoClearTime { get; set; }
        private static DateTime lastWriteTime { get; set; }
        private static string directoryPath { get; set; }
        private static int filesCount { get; set; }
        private static int filesDeleteCount { get; set; }
        private static long deleteFilesWeight { get; set; }

        public Directory(in string DirectoryPath)
        {
            directoryPath = DirectoryPath;
        }

        public int FilesCount()
        {
            return filesCount;
        }

        public int FilesDeleteCount()
        {
            return filesDeleteCount;
        }

        public long DeleteFilesWeight()
        {
            return deleteFilesWeight;
        }

        public void Clear()
        {
            autoClearTime = DateTime.Now - TimeSpan.FromMinutes(30);

            var chekDirectory = System.IO.Directory.Exists(directoryPath); // Directory Exists

            if (chekDirectory == true) // Directory Exists
            {
                var derictories = System.IO.Directory.GetDirectories(directoryPath);

                var files = new string[] { };

                #region Delete Files in Directory

                files = System.IO.Directory.GetFiles(directoryPath);

                foreach (string file in files)
                {
                    System.IO.FileInfo fileInfo = new System.IO.FileInfo(file);
                    lastWriteTime = fileInfo.LastWriteTime;

                    var result = DateTime.Compare(autoClearTime, lastWriteTime);

                    filesCount += 1;

                    if (result > 0)
                    {
                        try
                        {
                            System.IO.File.Delete($"{file}");
                            deleteFilesWeight += fileInfo.Length;
                            filesDeleteCount += 1;
                        }
                        catch
                        {
                            Console.WriteLine($"Отказано в доступе к файлу {file}");
                        }
                    }
                }

                #endregion

                #region Delete Directories in Directory

                foreach (string directory in derictories)
                {
                    Directory currentDirectory = new Directory(directory);
                    currentDirectory.Clear();

                    var chekFiles = System.IO.Directory.GetFiles(directory);
                    long filesWeight = 0;

                    foreach (string file in chekFiles)
                    {
                        System.IO.FileInfo fileInfo = new System.IO.FileInfo(file);
                        filesWeight += fileInfo.Length;
                    }

                    if (filesWeight == 0)
                    {
                        try
                        {
                            System.IO.Directory.Delete($"{directory}");
                        }
                        catch
                        {
                            Console.WriteLine($"Отказано в доступе к папке {directory}");
                        }
                    }
                }

                #endregion
            }
            else
            {
                Console.WriteLine($"Директория {directoryPath} не найдена.");
            }
        }
    }
}
