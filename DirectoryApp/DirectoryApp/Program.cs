using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DirectoryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //DisplayFiles();
            //MkDir();
            //FunWithDirectoryType();
            FunWithDrives();
        }
        static void DisplayFiles()
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Windows\Web\Wallpaper");
            FileInfo[] files = dir.GetFiles("*.jpg", SearchOption.AllDirectories);
            Console.WriteLine("Dir: {0}, count files: {1}", dir.Name, files.Length);
            foreach(FileInfo file in files)
            {
                Console.WriteLine("File name: {0}", file.Name);
                Console.WriteLine("File size: {0}", file.Length);
                Console.WriteLine("Creation time: {0}", file.CreationTime);
                Console.WriteLine("Attributes: {0}", file.Attributes);
            }
        }
        static void MkDir()
        {
            DirectoryInfo dir = new DirectoryInfo(@"D:\TestDir");
            dir.Create();
            DirectoryInfo subDir = dir.CreateSubdirectory("Test1");
            Console.WriteLine(subDir);
        }
        static void FunWithDirectoryType()
        {
            string[] drivers = Directory.GetLogicalDrives();
            foreach(string drive in drivers)
            {
                Console.WriteLine("Drive: {0}", drive);
            }
            try
            {
                Directory.Delete(@"D:\TestDir", true);
            }
            catch(IOException)
            {
                Console.WriteLine("Directory not found");
            }
        }
        static void FunWithDrives()
        {
            DriveInfo[] di = DriveInfo.GetDrives();
            foreach(DriveInfo d in di)
            {
                Console.WriteLine("Name: {0}", d.Name);
                Console.WriteLine("Type: {0}", d.DriveType);
                if(d.IsReady)
                {
                    Console.WriteLine("Free space: {0}", d.TotalFreeSpace);
                    Console.WriteLine("Format: {0}", d.DriveFormat);
                    Console.WriteLine("Label: {0}", d.VolumeLabel);
                }
            }
        }
    }
}
