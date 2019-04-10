using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace IFormattableTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Temparature t = new Temparature(12m);
            string s = string.Format("{0}", t);
            Console.WriteLine(s);

            s = string.Format("{0:Celsius}", t); //Симовлы после {0: передаются в IFormattable.ToString
            Console.WriteLine(s);

            s = string.Format("{0:Fahrenheyt}", t);
            Console.WriteLine(s);

            s = string.Format("{0:Kelvin}", t);
            Console.WriteLine(s);


            s = t.ToString("kelvin", CultureInfo.CreateSpecificCulture("en-US"));
            Console.WriteLine(s);
        }
    }
}
