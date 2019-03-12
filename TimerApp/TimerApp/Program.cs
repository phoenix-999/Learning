using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TimerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            new Timer(new TimerCallback(PrintTime), "Hello from Main", 0, 1000);
            Console.WriteLine("Hit key to exit...");
            Console.ReadLine();
        }
        static void PrintTime(object state)
        {
            Console.WriteLine("Method: PrintTime, Thread id: {0}", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Time: {0}, Parameter: {1}", DateTime.Now.ToLongTimeString(), state);
        }
    }
}
