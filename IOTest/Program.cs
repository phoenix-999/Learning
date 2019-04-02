using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace IOTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nDirectoryInfo {0} ", new string('-', 40));
            DirectoryInfoTest();

            Console.WriteLine("\nMemory IO {0} ", new string('-', 40));
            MemotyIOTest();
        }

        static void DirectoryInfoTest()
        {
            DirectoryInfo dir = new DirectoryInfo(@".");
            GetDirInfo(dir);
            DirectoryInfo subdir = dir.CreateSubdirectory(@"SUBDIR");
            GetDirInfo(subdir);
            Directory.Delete(subdir.FullName, true);
            GetDirInfo(dir);
            GetDrives();
        }

        static void GetDirInfo(DirectoryInfo dir)
        {
            Console.WriteLine(new string('-', 20));
            if (dir.Exists)
            {
                Console.WriteLine("Name: {0}", dir.Name);
                Console.WriteLine("Full name: {0}", dir.FullName);
                Console.WriteLine("Parent: {0}", dir.Parent);
                Console.WriteLine("Root: {0}", dir.Root);
                Console.WriteLine("Create time: {0}", dir.CreationTime);
                Console.WriteLine("LastWriteTime: {0}", dir.LastWriteTime);
                Console.WriteLine("Last access time: {0}", dir.LastAccessTime);
                Console.WriteLine("Extension: {0}", dir.Extension);

                foreach(DirectoryInfo d in dir.GetDirectories())
                {
                    GetDirInfo(d);
                }
            }
            else
            {
                Console.WriteLine("Directory {0} does not exists!", dir.Name);
            }
        }

        static void GetDrives()
        {
            Console.WriteLine("Drives {0}", new string('-', 20));

            string[] drives = Directory.GetLogicalDrives();
            foreach(var drive in drives)
            {
                Console.WriteLine();
            }
        }

        static void MemotyIOTest()
        {
            Console.WriteLine("Запись в MemoryStream");
            MemoryStream memory = new MemoryStream(); //позволяет работать с памятью через интерфейс файла
            for (int i = 0; i < 256; i++)
            {
                memory.WriteByte((byte) i);
            }

            FileStream file = new FileStream(@"test.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read); //Файл открыт в блокирующем режиме, но чтение файла разрешно
            using (file as IDisposable)
            {
                memory.WriteTo(file);
                memory.Flush();
                memory.Close();
                file.Flush();
            }

            using (file = File.OpenRead(file.Name))
            {
                Console.WriteLine("Чтение с файла");
                for (long i = 0; i < file.Length; i++)
                {
                    Console.Write(Convert.ToChar(file.ReadByte(), new CultureInfo("en-US")));
                }
            }   
        }
    }
}
