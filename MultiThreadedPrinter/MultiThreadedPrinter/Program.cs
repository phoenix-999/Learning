using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.Remoting.Contexts;

namespace MultiThreadedPrinter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Method: Main, Thread Id: {0}", Thread.CurrentThread.ManagedThreadId);
            
            for (int i = 0; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(Printer.PrintNumbers), new Printer());
            }
            Console.ReadLine();
        }
    }
    
    class Printer
    {
        static object threadLocker = new object();
        public static void PrintNumbers(object state)
        {
            lock (threadLocker)
            {
                Console.WriteLine("Method: PrintNumbers, Thread Id: {0}, IsBackground: {1}", Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.IsBackground);
                for (int i = 0; i < 10; i++)
                {
                    Console.Write("Data: {0}", i);
                    Random rand = new Random();
                    Thread.Sleep(rand.Next(5));
                }
                Console.WriteLine();
            }
        }
    }
}
