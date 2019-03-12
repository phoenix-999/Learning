using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace SimpleMultiThreadApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Primary thread id: {0}", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("How many threads?");
            string countThreads = Console.ReadLine();
            switch(countThreads)
            {
                case "2":
                    new Thread(new ThreadStart(Printer.PrintNumbers)).Start();
                    break;
                case "1":
                    Printer.PrintNumbers();
                    break;
                default:
                    goto case "1";
            }
            MessageBox.Show("I am busy!", "Main thread");
        }
    }
    class Printer
    {
        public static void PrintNumbers()
        {
            Console.WriteLine("Method: PrintNumbers, Thread Id: {0}", Thread.CurrentThread.ManagedThreadId);
            for (int i = 0; i < 10; i++)
            {
                Console.Write("{0}, ", i);
                Thread.Sleep(2000);
            }
            Console.WriteLine();
        }
    }
}
