using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace CancelationTest
{
    class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource cancellation = new CancellationTokenSource();
            CancellationToken token = cancellation.Token;

            Arguments arguments = new Arguments(1,2);
            arguments.CancellationToken = token;

            Task<int> task = new Task<int>(Sum, arguments);

            //Запуск следующего метода по условии корректности завершения первого метода
            
            task.ContinueWith((Task<int> t) => { Console.WriteLine("Задача {0} выполнена успешно!", t.Id); }, TaskContinuationOptions.OnlyOnRanToCompletion );

            task.ContinueWith((Task<int> t) => { Console.WriteLine("Задача {0} отменена!", t.Id); }, TaskContinuationOptions.OnlyOnFaulted);

            try
            {
                task.Start();

                Thread.Sleep(1500);

                cancellation.Cancel();

                Console.WriteLine("Task result = {0}", task.Result); //Будет вызван task.Wait()
            }
            catch(AggregateException ex)
            {
                Console.WriteLine(ex.InnerException.Message);
            }

            

            Console.WriteLine("Main is over!!!!");
        }

        static int Sum(object state)
        {
            Console.WriteLine("Вторичный поток {0} начал работу, задача № {1}", Thread.CurrentThread.ManagedThreadId, Task.CurrentId);
            Arguments arguments = state as Arguments;

            int result = 0;

            if (arguments == null || arguments.CancellationToken.IsCancellationRequested)
            {
                Console.WriteLine("Вторичный поток {0} закончил работу. Ошибка в аргументе или опреация была отменена!", Thread.CurrentThread.ManagedThreadId);
                return result;
            }

            for (int i = 0; i <= 1000; i++)
            {
                Thread.Sleep(100);
                result += arguments.X + arguments.Y;
                if (arguments.CancellationToken.IsCancellationRequested)
                {
                    arguments.CancellationToken.ThrowIfCancellationRequested(); //Будет выброшено исключение AggregatableException (обертка над реальным исключением, см. свойство InnerException).
                    //Thread.CurrentThread.Abort();//Будет выброшено исключение AggregatableException (обертка над реальным исключением, см. свойство InnerException).
                    Console.WriteLine("Вторичный поток {0} закончил работу. Отмена при расчете!", Thread.CurrentThread.ManagedThreadId);
                    return result;
                }
            }
            Console.WriteLine("Вторичный поток {0} закончил работу", Thread.CurrentThread.ManagedThreadId);
            return result;
        }
    }

    class Arguments
    {
        public CancellationToken CancellationToken { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        public Arguments(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
