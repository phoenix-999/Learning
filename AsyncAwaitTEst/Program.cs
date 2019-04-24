using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AsyncAwaitTEst
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main start, Threaid ID = {0}\n", Thread.CurrentThread.ManagedThreadId);

            Task<int> task = AsyncMethod(3);

            Console.WriteLine("\nMain finish, Threaid ID = {0}", Thread.CurrentThread.ManagedThreadId);

            Console.WriteLine("Task.Result = {0}", task.Result);

            Console.ReadKey();
        }

        //await выполняет команду return в зависимости от возвращаемого значения метода помеченного async.
        //Возвращаемое значение может быть либо void либо Task
        static async Task<int> AsyncMethod(int argument) //Для получения значения int надо смотреть в Task<int>.Result. В этом случае будет вызван Task<int>.Wait() и вызывающий поток будет ожидать завершение всех задач.
        {
            int x = await Task<int>.Factory.StartNew(Method1); //Присвоение значения x будет выполнено в вызывающем потоке. 
            int y = await Task.Run(new Func<int>(Method2));//Значения y будет призвоено во вторичном потоке
            //await Task.Run(Method3, 3); //Ошибка! Не возможно передать параметры.
            int z = await Task<int>.Factory.StartNew(Method3, argument);//Значения z будет призвоено во вторичном потоке
            return x + y + z; //Результат будет обернут в Task<int>. Скорее всего способом Task.FromResult<T>()
        }

        static int Method1()
        {
            Console.WriteLine("Method1, Threaid ID = {0}", Thread.CurrentThread.ManagedThreadId);
            return 1;
        }

        static int Method2()
        {
            Console.WriteLine("Method2, Threaid ID = {0}", Thread.CurrentThread.ManagedThreadId);
            return 2;
        }

        static int Method3(object x)
        {
            Console.WriteLine("Method3, Threaid ID = {0}", Thread.CurrentThread.ManagedThreadId);
            return (int)x;
        }
    }
}
