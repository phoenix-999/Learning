using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileWork
{
    class Program
    {
        static void Main(string[] args)
        {
            FileInfo file = new FileInfo(@"D:\TestDir\file2.dat");
            using (FileStream fs = file.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
            {

            }
            
        }
    }
}
