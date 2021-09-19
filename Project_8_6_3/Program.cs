using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_8_6_3
{
    internal class Program
    {
        private static Folder.Directory directory;

        static void Main(string[] args)
        {
            const string targetDirectory = "Test";

            Console.WriteLine("Исходный размер папки : {0}", Folder.Weight.Get(targetDirectory));

            directory = new Folder.Directory(targetDirectory);
            directory.Clear();

            Console.WriteLine("Исходное количество файлов : {0}", directory.FilesCount());

            Console.WriteLine("Освобождено : {0}", directory.DeleteFilesWeight());
            Console.WriteLine("Удалено файлов : {0}", directory.FilesDeleteCount());

            Console.WriteLine("Текущее количество файлов : {0}", directory.FilesCount() - directory.FilesDeleteCount());
            Console.WriteLine("Текущий размер папки : {0}", Folder.Weight.Get(targetDirectory));

            Console.ReadKey();
        }
    }
}
