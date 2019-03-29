using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NestedClassesTest
{
    class Program
    {
        static void Main(string[] args)
        {

            OuterClass.NestedClass nestedClass = new OuterClass.NestedClass();
            nestedClass.Method();
        }
    }

    class OuterClass
    {
        private string privateField = "private field";
        protected string protectedField = "protected field";
        public string publicField = "public field";

        
        public void Method()
        {
            Console.WriteLine("Outer class{0}", new string('-', 40));
            NestedClass nestedClass = new NestedClass();
            //Console.WriteLine(nestedClass.privateField); // не видит вложенного класса
        }

        public class NestedClass //по умолчанию - private
        {
            private string privateField = "private field Nested Class";
            public void Method()
            {
                Console.WriteLine("Nested class{0}", new string('-', 40));
                OuterClass outerClass = new OuterClass();
                Console.WriteLine(outerClass.privateField); // видит все поля внешнего класса независимо от модификатора доступа
                Console.WriteLine(outerClass.protectedField);
                Console.WriteLine(outerClass.publicField);
            }
        }
    }
}
