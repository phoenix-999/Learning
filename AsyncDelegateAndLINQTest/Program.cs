using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Collections;

namespace AsyncDelegateAndLINQTest
{
    class Program
    {
        delegate void MyDelegate2<out T>();
        event MyDelegate2<object> myEvent;
        static void Main(string[] args)
        {
            Console.WriteLine("Main thread Id: {0}, is background: {1}", Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.IsBackground);
            Program p = new Program();
            MyEvent += (string s) => { Console.WriteLine(s); };

            MyInvoke("1");

            //AsyncMethod();
            Thread t = new Thread(() => { Console.WriteLine("Thread constract thread Id: {0}, is background: {1}", Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.IsBackground); while (true) { } });
            t.IsBackground = true;
            //t.Start();
            ExcepionTest();

            MyDelegate2<object> myDelegate = new MyDelegate2<string>(() => { });
            //myDelegate += () => { };

            Program prog = new Program();
            prog.myEvent += () => { Console.WriteLine("myEvent"); };
            prog.myEvent();


            ArrayList al = new ArrayList();
            al.Add(new { One = 1, Two = 2 });
            al.Add(new { One = 3, Two = 2 });

            //var query = from i in al select i; // Не сработает, не может определить тип для i. С коллекциями анонимных типов работать не может.
            LINQTest();

            Console.ReadKey();
        }

        class LINQTestClass
        {
            public string Name { get; set; }
            public string LastName { get; set; }
            public string Country { get; set; }
        }

        static void LINQTest()
        {
            Console.WriteLine("LINQTest method {0}", new string('-', 40));
            LINQTestClass[] ar =
                {
                    new LINQTestClass() { Name = "Yurii", LastName = "Kalinichenko", Country = "Russia"},
                    new LINQTestClass() { Name = "Liubov", LastName = "Murarova", Country = "Russia"},
                    new LINQTestClass() { Name = "Myroslaw", LastName = "Vasilashko", Country = "Ukraine"}
                };

            var query = from i in ar
                        let j = new { Name = i.Name, LastName = i.LastName }
                        where i.Country == "Russia"
                        group j by i.Country into p //без into where не существует. В данном контексте where выполняет роль having SQL. p хранит в себе значения i  и ключ после указан в by
                        //where p.Key == "Russia" 
                        select new { MyArray = p, Country = p.Key }; //Работать возможно только с результатом group by


            foreach (var i in query)
            {
                Console.WriteLine(i.Country);
                foreach (var j in i.MyArray)
                {
                    Console.WriteLine("{0}, {1}", j.Name, j.LastName);
                }
            }

        }

        static void ExcepionTest()
        {
            try
            {
                throw new Exception();
            }
            catch (Exception e)
            {
                Console.WriteLine("catch");
                //throw e; //В случае необратонанного исключения в cacth Finnaly выполнится перед завршением процесса
                //while (true) { }
            }
            finally //Finnaly не выполнится с лучае StackOverflowException и бесконечного цикла в блоке catch
            {
                Console.WriteLine("Finnaly");
            }
        }

        //Async запакует возвращаемое значение типа T в Task<T>, await распакует обратно
        async static Task<T> Method<T>() where T : new() //Async надо помечать метод который будет вызван через await Task<T>.Run() для возврата значения типа T
        {
            Console.WriteLine("Await method thread Id: {0}, is background: {1}", Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.IsBackground);
            while (true)
            {
                return new T();
            }
        }
        async static void AsyncMethod()
        {
            Console.WriteLine("Async method thread Id: {0}, is background: {1}", Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.IsBackground);
            int i = await Task<int>.Run(Method<int>); // Запуск во вторичном потоке происходит только через Task<T>.Run()
            int j = Task<int>.Run(Method<int>).GetAwaiter().GetResult();//Равносильно предыдущей строке
        }

        public delegate void MyDelegate<T>(T s);
        private static MyDelegate<string> myDelegate;
        //public static event MyDelegate MyEvent;
        public static event MyDelegate<string> MyEvent
        {
            add { myDelegate += value; }
            remove { myDelegate -= value; }
        }

        public static void MyInvoke(string s)
        {
            myDelegate(s);
        }
    }

    abstract class IInterface
    {
        //public abstract static void Method(); //Ошибка
    }
}
