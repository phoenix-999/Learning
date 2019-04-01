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
            //Hashtable хранит элементы в неотсортированном порядке. SortedList - Hashtable с учетом сортировки, можно передавать реализацию IComparer
            //Hashtable стоит использоавать при большом кол-ве элементов.
            //Для небольшого кол-ва элемнтов (до 10) лучше использовать ListDictionary или гибридный вариант HybridDictionary - если кол-во элементов заранее неизвестно
            //OrderedDictionary - Hashtable, элементы которого хранятся в порядке их добавления.
            IEqualityCompareTest();
            Console.WriteLine("\nBitArray{0}", new string('-', 32));
            BitArrayTest();
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
      
        #region Hashtable
        static void IEqualityCompareTest()
        {
            ///<summary>
            ///Ключ Hashtable не может быть продублирован, возникает исключение времени выполнения System.ArgumentException
            ///Hashtable сначала вызывает метод GetHashCode обьктов ключа. Если хешкод разный - обьекты разные. 
            ///Если хешкод идентичен - вызывается метод Equals для подтверждения  разности обьектов.
            ///Для хранение значений в словаре с одинаковыми ключами использовать NameValueCollection
            ///</summary>
            Hashtable hash = new Hashtable(new EqualityComparer());
            hash.Add(new A(), "A");
            //hash.Add(new B(), "B"); //Исключение см. реализацию класса EqualityComparer

            Console.WriteLine("hash.Count == {0}", hash.Count);
        }
        #endregion
        
        #region BitArray
        static void BitArrayTest()
        {
            BitArray bits = new BitArray(3);
            bits[0] = true;
            bits[1] = true;
            bits[2] = false;

            bits.Length = 4; //Размер коллекции увеличивается через getter свойства Length
            bits[3] = false;

            BitArray bits2 = new BitArray(4);
            bits2[0] = true;
            bits2[1] = false;
            bits2[2] = false;
            bits2[3] = true;
            //BitArray поддерживает логические битовые операции. Размеры коллекций должны быть одинаковы, иначе - System.ArgumentException

            BitArray bitsResult = bits.Xor(bits2);
            foreach (bool bit in bitsResult)
                Console.WriteLine("XOR: {0}", bit);

            //Для работы с битами Int32 использовать BitVector32. Можно создавать несколько секций (static BitVector32.Section BitVector32.CreateSection()) для хранения нескольких чисел в 32 битах.
        }
        #endregion


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
