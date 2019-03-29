using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace SizeExcelFiles
{
    class Program
    {
        static double size = 0;
        static long countDirs = 0;
        static object directoryBlock = new object();
        static object fileBlock = new object();
        static object listBlock = new object();
        static List<Thread> ths = new List<Thread>();
        static List<string> extensions = new List<string>();

        static void Main(string[] args)
        {
            extensions.AddRange(new string[] { ".xlsx", ".xlsm", ".xlsb", ".xls" });

            new Thread(() => { _GetDirectories(@"D:\"); }).Start();
            Thread.Sleep(100);

            //lock (listBlock)
            //{
            //    foreach (Thread thread in ths)
            //    {
            //        if (thread.IsAlive) thread.Join();
            //    }
            //}


            
            Console.ReadKey();
        }

        static void _GetDirectories(string path)
        {
            //lock (listBlock)
            //{
            //    ths.Add(Thread.CurrentThread);
            //}
            DirectoryInfo dirInfo = new DirectoryInfo(path);

            new Thread(() => { _GetFiles(dirInfo, extensions.ToArray<string>()); }).Start();

            DirectoryInfo[] dirs = null;

            try
            {
                dirs = dirInfo.GetDirectories();
            }
            catch (UnauthorizedAccessException uae)
            {
                Console.WriteLine("DIR: {0}, access denied", dirInfo.FullName);
                return;
            }


            foreach (DirectoryInfo dir in dirs)
            {
                lock (directoryBlock)
                {
                    countDirs++;
                }
                new Thread(() => { _GetFiles(dir, extensions.ToArray<string>()); }).Start();
                new Thread(() => { _GetDirectories(dir.FullName); }).Start();
            }
        }

        static void _GetFiles(DirectoryInfo dir, params string[] extensions)
        {
            FileInfo[] files = null;
            try
            {
                files = dir.GetFiles();
            }
            catch (UnauthorizedAccessException uae)
            {
                Console.WriteLine("DIR: {0}, access denied", dir.FullName);
                return;
            }

            //lock (listBlock)
            //{
            //    ths.Add(Thread.CurrentThread);
            //}

            foreach (FileInfo file in files)
            {
                
                if(extensions != null && extensions.Length > 0)
                {
                    if(extensions.Contains<string>(file.Extension))
                    {
                        GetFilesSize(file);
                    }
                }
                else
                {
                    GetFilesSize(file);
                }
            }
        }

        static void GetFilesSize(FileInfo file)
        {
            lock (fileBlock)
            {
                Console.WriteLine("FILE: {0} => SIZE: {1}", file.FullName, file.Length);
                Console.WriteLine("Count dirs: {0}, size files: {1} GB.", countDirs, Math.Round(size, 2));
                size += ((double)file.Length) / 1024 / 1024 / 1024;
            }
        }


    }
}
