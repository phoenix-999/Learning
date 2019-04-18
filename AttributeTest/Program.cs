using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


//Аттрибуты сборки хранятся в Prperies.AssemblyInfo.cs
//[assembly: AssemblyVersion("1.0.2000.0")]

namespace AttributeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClass myClass = new MyClass();

            Type type = typeof(MyClass);

            //Получить все аттрибуты типа
            object[] allAttributes = type.GetCustomAttributes(type, false);

            //Получить аттрибуты типа по указанному типу аттрибута
            IEnumerable<MyAttribute> attributes = type.GetCustomAttributes<MyAttribute>(false);

            foreach(MyAttribute attribute in attributes)
            {
                Console.WriteLine("Class Attribute {2}\n Date: {0}, Number: {1}", attribute.Date, attribute.Number, new string('-', 10));
            }
            Console.WriteLine();
            //Получить все аттрибуты указанного метода по типу аттрибута
            MethodInfo method = type.GetMethod("Method");
            if (method != null)
            {
                MyAttribute attribute = method.GetCustomAttribute<MyAttribute>(false);
                Console.WriteLine("Method Attribute {2}\n Date: {0}, Number: {1}", attribute.Date, attribute.Number, new string('-', 10));
                Console.WriteLine("Вызов методов аттрибута:");
                //Вызов метода аттрибута с аргументом экземпляра указанного класса
                attribute.Method(myClass);
                //Вызов статического метода аттрибута
                MyAttribute.StaticMethod();
                Console.WriteLine();
            }

            #region Инофрмация о исполняющейся сборке
            Assembly assembly = Assembly.GetExecutingAssembly();

            Console.WriteLine(assembly.FullName);

            //Аттрибуты сборки
            allAttributes = assembly.GetCustomAttributes(false);

            Console.WriteLine();

            foreach (Attribute attribute in allAttributes)
            {
                Console.WriteLine("Attribyte type: {0}, attribute name: {1}", attribute.GetType(), attribute.GetType().Name);
            }

            #endregion
        }
    }
}
