using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CollectionsTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nICollection{0}", new string('-', 32));
            ICollectionTest();
            Console.WriteLine("\nQueue{0}", new string('-', 32));
            QueueTest();
            Console.WriteLine("\nHashtable{0}", new string('-', 32));
            IEqualityCompareTest();
        }

        static void QueueTest()
        {
            Queue q = new Queue();
            q.Enqueue("First");
            q.Enqueue("Second");
            q.Enqueue("Third");

            //dynamic s = q.Dequeue();
            string s = q.Dequeue() as string; // Равносильно предыдущей строке
            Console.WriteLine("Dequeue: {0}", s);
            s = q.Peek() as string;
            Console.WriteLine("Peek: {0}", s);

            Queue<string> qg = new Queue<string>();

            qg.Enqueue("First");
            qg.Enqueue("Second");
            qg.Enqueue("Third");

            //dynamic s = q.Dequeue();
            s = qg.Dequeue(); // Равносильно предыдущей строке
            Console.WriteLine("Dequeue generic: {0}", s);
            s = qg.Peek();
            Console.WriteLine("Peek generic: {0}", s);
        }
        static void ICollectionTest()
        {
            MonthesCollection mc = new MonthesCollection();
            mc.InitializeCollection();
            Month m = new Month(Monthes.January);
            mc.Add(m);
            Month m2 = new Month(Monthes.February);
            mc.Add(m2);
            foreach (Month i in mc["January"])
            {
                Console.WriteLine("Count: {0}, data: {1}", mc.Count, i);
            }
            Console.WriteLine(new string('-', 32));
            mc.Remove(m);
            foreach (Month i in mc)
            {
                Console.WriteLine("Count: {0}, data: {1}", mc.Count, i);
            }
        }
        static void IEqualityCompareTest()
        {
            Hashtable hash = new Hashtable(new EqualityComparer());
            hash.Add(new A(), "A");
            //hash.Add(new B(), "B"); //Исключение см. реализацию класса EqualityComparer

            Console.WriteLine("hash.Count == {0}", hash.Count);
        }
    }
    #region Для IEqualityCompareTest()
    class A
    {
        int x = 1;
        public override int GetHashCode()
        {
            return x.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            A a = obj as A;
            if (a == null)
                return false;

            return this.x == a.x;
        }

        public override string ToString()
        {
            return x.ToString();
        }
    }

    class B
    {
        int x = 1;
        public override int GetHashCode()
        {
            return x.GetHashCode();
        }

        public override bool Equals(object obj)

        {
            if (obj == null)
                return false;
            B a = obj as B;
            if (a == null)
                return false;

            return this.x == a.x;
        }

        public override string ToString()
        {
            return x.ToString();
        }
    }

    class EqualityComparer : IEqualityComparer
    {
        /// <summary>
        /// Используется для возможности Hashtable определять одинаковые ключи для разных классов
        /// То есть, класс А может быть идентичен классу В для Hashtable если логика GetHashCode() и Equals() в классе реализующем IEqualityComparer вернет одинаковый результат.
        /// Для применения вышеизложеного необходимо в конструктор Hashtable передать экземпляр реализующий IEqualityComparer
        /// </summary>
        CaseInsensitiveComparer cic = new CaseInsensitiveComparer(); // Используется для сравнения строк без учета регистра. Исходя из документации - не рекомендован.
        public new bool Equals(object x, object y)
        {
            return cic.Compare(x.ToString(), y.ToString()) == 0;
        }

        public int GetHashCode(object obj)
        {
            return obj.ToString().ToLowerInvariant().GetHashCode();
        }
    }
    #endregion



}
