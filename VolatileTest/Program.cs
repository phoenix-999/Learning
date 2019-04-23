using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace VolatileTest
{
    class Program
    {
        //Пример работает только в режиме Release
        //В режиме Debug JIT оптимизация не производится


        //static int count;


            /// <summary>
            /// volatile стоит использовать когда поле главного потока учавствует в условии вторичных потоков
            /// или если переменная используется в методе, который работает в другом потоке и при этом не изменяется в этом методе
            /// для корректного выполнения ветвления программы
            /// volatile может быть только поле класса или структуры
            /// volatile может быть bool, <=int, char, float, enum
            /// Так же можно использвать Thread.VolatileWrite() и Thread.VolatileRead(). Они не работают с bool
            /// </summary>
        static volatile int count;
        static void Main(string[] args)
        {
            int availableWorkThreads, maxWorkThreads;
            int availableIOThreads, maxIOThreads;
            ThreadPool.GetAvailableThreads(out availableWorkThreads, out availableIOThreads);
            Console.WriteLine("Рабочих потоков в пуле: рабочих {0}, ввода-вывода {1}", availableWorkThreads, availableIOThreads);

            Thread thread = new Thread(Worker);
            //Мимо пула потоков
            //Thread.Start стоит использовать для постоянной фонововй работы на протяжения работы программы
            //Для выполнения отдельных задач в фоне использовать пул потоков
            thread.Start();

            ThreadPool.GetAvailableThreads(out availableWorkThreads, out availableIOThreads);
            Console.WriteLine("Рабочих потоков в пуле после ручного запуска Thread.Start(): рабочих {0}, ввода-вывода {1}", availableWorkThreads, availableIOThreads);

            //Запуск async метода с пула
            Program.Run();
            ThreadPool.GetAvailableThreads(out availableWorkThreads, out availableIOThreads);
            Console.WriteLine("Рабочих потоков в пуле после запуска async метода: рабочих {0}, ввода-вывода {1}", availableWorkThreads, availableIOThreads);

            Thread.Sleep(1000);

            count = 1;
            Console.WriteLine("Main: ожидание завершения вторичного потока");
            thread.Join();
            Console.WriteLine("Main завершился");
        }

        async static void Run()
        {
            Console.WriteLine("Run start");
            await Task.Run(new Action(Worker));
            Console.WriteLine("Run stop");
        }

        static void Worker()
        {
            //Thread.CurrentThread.IsBackground = false;
            Console.WriteLine("Method Worker Thread ID {0}, IsBackground {1}", Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.IsBackground);
            int i = 0;
            while(count == 0)
            {
                i++;
            }
            //Вторичный поток никогда не завершится через изменение кода JIT компилятором
            //JIT компилятор преобразует цикл с проврекой условия в следующий код:
            //if (count == 0)
            //{
            //  Label:
            //  i++;
            //  goto Label;
            //}
            //Если же переменная участующая в условии ветвления или цикла помечена как volatile - JIT опитимизация для используещего ее кода не производится
            Console.WriteLine("Поток {0} завершился. Значение инкрементируемой переменной = {1}", Thread.CurrentThread.ManagedThreadId, i);
        }
    }
}
