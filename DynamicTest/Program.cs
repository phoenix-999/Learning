using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DynamicTest
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //foreach(var i in Generate()) //Ошибка! Тип i будет object, так как IEnumerable вернет колекцию object на этапе компиляции
            foreach(dynamic i in Generate()) //Тип будет опознан средой DLR и произойдет DownCast от object к нужному типу на этапе выполнения
            {
                Console.WriteLine("Type: {0}, Name: {1}, Age: {2}", i.GetType(), i.Name, i.Age);
            }
        }

        static IEnumerable Generate()
        {
            yield return new { Name = "Alex", Age = 18 };
            yield return new { Name = "Yurii", Age = 20 };
            yield return new { Name = "Myroslav", Age = 23 };
        }
    }
}
