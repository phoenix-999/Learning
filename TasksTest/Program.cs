using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TasksTest
{
    class Program
    {
        /// <summary>
        /// 
        /// Шаблон отмены задачи
        /// </summary>
        static CancellationTokenSource cancelation;
        static CancellationToken token;
        static void Main(string[] args)
        {
            cancelation = new CancellationTokenSource();
            token = cancelation.Token;

            Task<long> task = new Task<long>(Method, token);
            Task secondTask = task.ContinueWith((t) => { Console.WriteLine("Continue with, result =  {0}, Status = {1}", t.Result, t.Status); });
            task.Start();

            Thread.Sleep(1000);

            Task.Factory.StartNew(CancelTask, new CancelationArguments(task, cancelation), token);

            Thread.Sleep(2000);
        }

        static long Method()
        {
            Console.WriteLine("MainTask: Thread Id = {0}, task id = {1}, is background = {2}", Thread.CurrentThread.ManagedThreadId, Task.CurrentId, Thread.CurrentThread.IsBackground);
            long result = 0;

            foreach (int i in Enumerable.Range(0, 100000))
            {
                try
                {
                    token.ThrowIfCancellationRequested();
                }
                catch (OperationCanceledException ex) { return result; }

                Thread.Sleep(10);
                result += i;
            }
            Console.WriteLine("Конец задачи");
            return result;
        }

        static void CancelTask(object arguments)
        {
            Console.WriteLine("Cancel Task: Thread Id = {0}, task id = {1}, is background = {2}", Thread.CurrentThread.ManagedThreadId, Task.CurrentId, Thread.CurrentThread.IsBackground);
            CancelationArguments cancelationArguments = null;
            try
            {
                cancelationArguments = (CancelationArguments)arguments;
                cancelationArguments.Cancelation.Cancel();
                cancelationArguments.Task.Wait();
                Console.WriteLine("Задача {0} отменена, статус = {1}", cancelationArguments.Task.Id, cancelationArguments.Task.Status);
            }
            catch (InvalidCastException ex)
            {
                throw new ArgumentException(ex.Message);
            }
            catch (AggregateException ex)
            {
                Console.WriteLine("Отмена задачи с Id = {0}, статус задачи = {1}", cancelationArguments.Task.Id, cancelationArguments.Task.Status);
            }
        }

    }

    class CancelationArguments
    {
        public Task Task { get; private set; }
        public CancellationTokenSource Cancelation { get; private set; }

        public CancelationArguments(Task task, CancellationTokenSource cancellation)
        {
            this.Task = task;
            this.Cancelation = cancellation;
        }
    }
}
