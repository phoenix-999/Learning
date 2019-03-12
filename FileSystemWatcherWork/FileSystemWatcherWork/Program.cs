using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileSystemWatcherWork
{
    class Program
    {
        static void Main(string[] args)
        {
            FileSystemWatcher fsw = new FileSystemWatcher();
            fsw.Path = @"D:\TestDir";
            fsw.Filter = "*.dat";
            fsw.NotifyFilter = NotifyFilters.CreationTime | NotifyFilters.FileName | NotifyFilters.LastAccess;
            FileSystemEventHandler changeFilesFun =  (object sender, FileSystemEventArgs ea) => { Console.WriteLine("File: {0}, Type: {1}", ea.FullPath, ea.ChangeType); };
            RenamedEventHandler renameFilesFun = (object sender, RenamedEventArgs ea) => { Console.WriteLine("Type: {0}, Old name: {1}, New name {2}", ea.ChangeType, ea.OldName, ea.Name); };
            fsw.Changed += changeFilesFun;
            fsw.Created += changeFilesFun;
            fsw.Deleted += changeFilesFun;
            fsw.Renamed += renameFilesFun;
            fsw.EnableRaisingEvents = true;
            while (true)
            {
                if (Console.ReadLine() == "q") break;
            }
        }
    }
}
