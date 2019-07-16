using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AsyncAwaitCancel
{
    class Program
    {
        static CancellationTokenSource cts;
        static void Main(string[] args)
        {
            Console.WriteLine("Main Thread ID {0}", Thread.CurrentThread.ManagedThreadId);
            var t = Invoke();
            t.Wait();
        }

        static int M(object state)
        {
            CancellationToken? token = state as CancellationToken?; //Метод, который отменяется должен знать об этом
            for (int i = 0; i < 3000; i++)
            {
                if (token != null)
                    token.Value.ThrowIfCancellationRequested();

                Thread.Sleep(1);
            }

            Console.WriteLine("M Thread ID {0}", Thread.CurrentThread.ManagedThreadId);

            return 1;
        }

        static Task<int> MAsync(CancellationToken token)
        {
            var nulableToken = (CancellationToken?)token;
            Task<int> task = new Task<int>(new Func<object, int>(M), token);
            task.Start();
            return task;
        }

        static async Task Invoke()
        {
            cts = new CancellationTokenSource();
            cts.CancelAfter(1000);

            Console.WriteLine("Invoke Thread ID {0}", Thread.CurrentThread.ManagedThreadId);
            int result = 0;

            try
            {
                var task = MAsync(cts.Token);
                result = await task;
            }
            catch (OperationCanceledException) //Метод, в которм вызывается асинхронно другой метод также должен знать о том, что задача может быть отменена.
            {
                Console.WriteLine("Операция была отменена");
            }

            Console.WriteLine(result);
        }
    }
}
