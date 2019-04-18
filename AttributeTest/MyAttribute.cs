using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace AttributeTest
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    class MyAttribute : System.Attribute
    {
        private string date;
        public string Date { get { return date; } }

        public MyAttribute(string date)
        {
            this.date = date;
        }

        public int Number { get; set; }

        public void Method(object instance)
        {
            Console.WriteLine("MyAttribute.Method() для экземпляра {0}", instance.GetType());

            Console.WriteLine("Атрибуты класса {0}", instance.GetType());
            foreach(var attribute in instance.GetType().GetCustomAttributesData())
            {
                Console.WriteLine(attribute);
            }
        }

        public static void StaticMethod()
        {
            Console.WriteLine("MyAttribute.StaticMethod()");
        }
    }
}
