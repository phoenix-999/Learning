using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IConvertibleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 97;
            IConvertible convX = x as IConvertible;
            char c = convX.ToChar(null);
            Console.WriteLine("IConvertible 97 to char: {0}", c);
        }
    }
}
