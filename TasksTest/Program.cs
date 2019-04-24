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

            Task<long> task = new Task<long>(Method, token, TaskCreationOptions.LongRunning);
            //Выполнения в случае необработанного исключения - НЕ СРАБОТАЛ
            task.ContinueWith((t) => { Console.WriteLine("Continue with OnlyOnCanceled, result =  {0}, Status = {1}", t.Result, t.Status); }, TaskContinuationOptions.OnlyOnCanceled);
            //Выполнение в случае отсутсвия необработанного исключени (отмена не произошла)
            Task secondTask = task.ContinueWith((t) => { Console.WriteLine("Continue with, result =  {0}, Status = {1}", t.Result, t.Status); });
            task.Start();

            Thread.Sleep(1000);

            cancelation.Cancel(); //Отмена выполнения задачи. Исключения не появляется. Оно будет выброшено в случае вызова Task.Wait()
            //Task.Factory.StartNew(CancelTask, new CancelationArguments(task, cancelation), token); //отмена задачи с использваонием задачи обработки

            Thread.Sleep(2000);
        }

        static long Method()
        {
            Console.WriteLine("MainTask: Thread Id = {0}, task id = {1}, is background = {2}", Thread.CurrentThread.ManagedThreadId, Task.CurrentId, Thread.CurrentThread.IsBackground);
            long result = 0;

            foreach (int i in Enumerable.Range(0, 100000))
            {
                Thread.Sleep(100);
                Console.Write("+");
                token.ThrowIfCancellationRequested();

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
                cancelationArguments.Task.Wait(); //Если закоментировать - исключение ThrowIfCancellationRequested распостранятся не будет. Task.Status = Running 
                Thread.Sleep(1000);//Статус задачи менятеся - Task.Status = Canceled
                
            }
            catch (InvalidCastException ex)
            {
                throw new ArgumentException(ex.Message);
            }
            catch (AggregateException ex)
            {
                Console.WriteLine("Отмена задачи с Id = {0}, статус задачи = {1}", cancelationArguments.Task.Id, cancelationArguments.Task.Status);
                Console.WriteLine("Вывод всех исключений на экран:");
                //Вывод всех исключений на экран
                
                foreach (var e in ex.Flatten().InnerExceptions)//Flatten - сборка все InnerExceptions  у всех AggregateException в один AggregateException
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.WriteLine("Задача {0} отменена, статус = {1}", cancelationArguments.Task.Id, cancelationArguments.Task.Status);
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
