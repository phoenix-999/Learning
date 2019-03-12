using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace AddWithThreads
{
    class Program
    {
        public static AutoResetEvent waitHandle = new AutoResetEvent(false);
        static void Main(string[] args)
        {
            Console.WriteLine("Main thread id: {0}", Thread.CurrentThread.ManagedThreadId);
            AddParams ap = new AddParams(10,10);
            new Thread(new ParameterizedThreadStart(Add)).Start(ap);
            waitHandle.WaitOne();
            MessageBox.Show("Main");
        }
        static void Add(object addParams)
        {
            Console.WriteLine("Method: Add, Thread id: {0}", Thread.CurrentThread.ManagedThreadId);
            if (addParams is AddParams)
            {
                Thread.Sleep(2000);
                AddParams data = (AddParams)addParams;
                Console.WriteLine("Add result: {0}", data.X + data.Y);
                waitHandle.Set();
            }
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
