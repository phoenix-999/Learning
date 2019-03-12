using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StreamReadreWriterApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---Writer---");
            StreamWriter sw = File.CreateText(@"D:\TestDir\file4.dat");
            sw.WriteLine("First line to file");
            sw.Close();
            ReadFile();
        }
        static void ReadFile()
        {
            StreamReader sr = File.OpenText(@"D:\TestDir\file4.dat");
            string input = "";
            while((input = sr.ReadLine()) != null)
            {
                Console.WriteLine(input);
            }
            sr.Close();
        }
    }
}
