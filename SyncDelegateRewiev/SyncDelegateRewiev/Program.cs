using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.Remoting.Messaging;

namespace SyncDelegateRewiev
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main thread: {0}", Thread.CurrentThread.ManagedThreadId);
            BinnaryOp bo = new BinnaryOp(Add);
            //bo += Add2;
            //bo(10,10);
            bo.BeginInvoke(10,10,(IAsyncResult tempIar)=> {
                Console.WriteLine("BeginInvoke thread: {0}", Thread.CurrentThread.ManagedThreadId);
                BinnaryOp tempBo = (BinnaryOp)((AsyncResult)tempIar).AsyncDelegate;
                Console.WriteLine((string)tempIar.AsyncState);
                Console.WriteLine(tempBo.EndInvoke(tempIar));
            },"State argument");
            for (int i=0; i<5; i++)
            {
                Thread.Sleep(500);
                Console.WriteLine("Hello from Main");
            }
           // Console.WriteLine(bo.EndInvoke(iar));
        }
        public delegate int BinnaryOp(int x, int y);
        static int Add(int x, int y)
        {
            Console.WriteLine("Add thread: {0}", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(2000);
            Console.WriteLine("Add");
            return x + y;
        }
        static int Add2(int x, int y)
        {
            Thread.Sleep(1000);
            Console.WriteLine("Add2");
            return x + y + x + y;
        }
    }
}
