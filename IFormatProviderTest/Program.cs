using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace IFormatProviderTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Complex complexNumber = new Complex(123.456, 123.789);
            Console.WriteLine("Реализация IFormatter: {0}", complexNumber);
            string formatString = string.Format(new ComplexTestFormater(), "{0:test}", complexNumber);
            Console.WriteLine("Реализация IFormatProvider и ICustomFormatter: {0}", formatString);
        }
    }
}
