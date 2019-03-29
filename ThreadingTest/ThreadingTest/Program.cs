using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadingTest
{
    class Program
    {
        private static AutoResetEvent are = new AutoResetEvent(false);
        static void Main(string[] args)
        {
            Console.WriteLine("Start");
            AddParams ap = new AddParams(1,2);
            Thread[] th = new Thread[10];
            //th.IsBackground = true;
            for(int i=0; i<th.Length; i++)
            {
                th[i] = new Thread(TestParams);
                th[i].Start(ap);
            }
            
            are.WaitOne();
            Console.WriteLine("Finish");
        }

        static void Test()
        {
             for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(1000);
            }
        }
        static void TestParams(object ob)
        {
            lock (ob)
            {
                AddParams ap = (AddParams)ob;
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine(ap.X + ap.Y + i);
                    Thread.Sleep(1 * new Random().Next(5));
                }
            }
            //are.Set();
        }
    }
    class AddParams
    {
        public int X { get; set; }
        public int Y { get; set; }
        public AddParams(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

}
