using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TimerThreadingTest
{
    class Program
    {
        static AutoResetEvent ae = new AutoResetEvent(false);
        static void Main(string[] args)
        {
            Console.WriteLine("Thread: {0}", Thread.CurrentThread.ManagedThreadId);
            Timer tm = new Timer(TimerTest, "Tets for Timer", 0, 1000);
            //ae.WaitOne();
            //new Thread(ThreadTest).Start();
            Console.ReadLine();
        }
        static void TimerTest(object state)
        {
            Console.WriteLine("Thread: {0}", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Time: {0}, State: {1}", DateTime.Now.ToLongTimeString(), state.ToString());
            ae.Set();
        }
        static void ThreadTest()
        {
            Timer tm = new Timer(TimerTest, "Test for Timer", 0, 1000);
        }
    }
}
