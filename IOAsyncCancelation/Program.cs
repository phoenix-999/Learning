using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IOAsyncCancelation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main thread id = {0}", Thread.CurrentThread.ManagedThreadId);
            Go();

            Console.ReadKey();
        }

        static async Task Go()
        {
            var cts = new CancellationTokenSource(5000);
            var ct = cts.Token;

            try
            {
                await Task.Run(() => {
                    Console.WriteLine("Task Run. thread id = {0}", Thread.CurrentThread.ManagedThreadId); //Выполняеться во вторичном потоке
                    Thread.Sleep(10000);
                    }).WithCancelation(ct);//Выполняеться в вызывающем потоке
                Console.WriteLine("Task completed. thread id = {0}", Thread.CurrentThread.ManagedThreadId);
            }
            catch(OperationCanceledException)
            {
                Console.WriteLine("Task canceled. thread id = {0}", Thread.CurrentThread.ManagedThreadId);//обрабатываеться в потоке возникновения исключения
            }
        }
    }

    struct Void { }

    static class Extension
    {
        public static async Task<TResult> WithCancelation<TResult>(this Task<TResult> originalTask, CancellationToken ct)
        {
            Console.WriteLine("WithCancelation thread id = {0}", Thread.CurrentThread.ManagedThreadId);
            var cancelTask = new TaskCompletionSource<Void>();

            using (ct.Register(t => ((TaskCompletionSource<Void>)t).TrySetResult(new Void()), cancelTask))
            {
                Task any = await Task.WhenAny(originalTask, cancelTask.Task);

                if (any == cancelTask.Task) ct.ThrowIfCancellationRequested();
            }

            return await originalTask; //Для получения истинного исключения в случае ошибки в исходном задании
        }

        public static async Task WithCancelation(this Task originalTask, CancellationToken ct)
        {
            Console.WriteLine("WithCancelation thread id = {0}", Thread.CurrentThread.ManagedThreadId);
            var cancelTask = new TaskCompletionSource<Void>();

            using (ct.Register(t => {
                ((TaskCompletionSource<Void>)t).TrySetResult(new Void());//Выполняеться во вторичном потоке отличном от потока задачи
                Console.WriteLine("Cancelation thread id = {0}", Thread.CurrentThread.ManagedThreadId);
            }, cancelTask))
            {
                Task any = await Task.WhenAny(originalTask, cancelTask.Task);

                if (any == cancelTask.Task) ct.ThrowIfCancellationRequested();
            }

            await originalTask; //Для получения истинного исключения в случае ошибки в исходном задании
        }
    }
}
