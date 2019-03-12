using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileStreamApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---Fun with File Stream---");
            FileStream fs = File.Open(@"D:\TestDir\file3.dat",FileMode.Create);
            string msg = "Hello";
            byte[] msgByte = Encoding.Default.GetBytes(msg);
            fs.Write(msgByte, 0, msgByte.Length);
            fs.Position = 0;
            for(long i =0; i<fs.Length; i++)
            {
                msgByte[i] = (byte)fs.ReadByte();
            }
            Console.WriteLine(Encoding.Default.GetString(msgByte));
            fs.Close();
        }
    }
}
