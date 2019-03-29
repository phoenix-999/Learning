using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyambdaExpressionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClass myClass = new MyClass();
            myClass.Method();
        }
    }

    class MyClass
    {
        private string privateField = "private field";
        public string publicField = "public Field";
        public void Method()
        {
            string innerVar = "inner var";

            //dynamic m = () => { }; // Ошибка! dynamic не работает с делегатами.

            Action a = new Action(() => { });
            a += () => {
                        Console.WriteLine(privateField); //лябда выражение имеет доступ к всем полям класса и локальным переменным методов 
                        Console.WriteLine(publicField);
                        Console.WriteLine(innerVar);
            };

            a();
        }
    }
}
