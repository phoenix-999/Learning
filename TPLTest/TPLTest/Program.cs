using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TPLTest
{
    class Program
    {
        static AutoResetEvent ae = new AutoResetEvent(false);
        static void Main(string[] args)
        {
            string[] str = new string[] { "one", "two", "there"};
            Parallel.ForEach<string>(str, (string s)=> { Console.WriteLine("String: {0}, thread: {1}", s.ToUpper(), Thread.CurrentThread.ManagedThreadId); });
            Task.Factory.StartNew(TestTask);
            ae.WaitOne();
        }
        static void TestTask()
        {
            string[] str = new string[] { "one", "two", "there" };
            foreach (string s in str)
            {
                Console.WriteLine("Task. String: {0}, Thread: {1}", s, Thread.CurrentThread.ManagedThreadId);
            }
            ae.Set();
        }
    }
}
