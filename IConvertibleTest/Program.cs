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

            int integralValue = 12534;
            decimal decimalValue = Convert.ToDecimal(integralValue);
            Console.WriteLine("Converted the {0} value {1} to " +
                                              "the {2} value {3:N2}.",
                                              integralValue.GetType().Name,
                                              integralValue,
                                              decimalValue.GetType().Name,
                                              decimalValue);
            double doubleValue = 1.242354;
            int intValue;
            try
            {
                intValue = Convert.ToInt32(doubleValue);
                Console.WriteLine("Converted the {0} value {1} to " +
                                              "the {2} value {3:N2}.",
                                              doubleValue.GetType().Name,
                                              doubleValue,
                                              intValue.GetType().Name,
                                              intValue);
            }
            catch(OverflowException)
            {
                Console.WriteLine("Unable to convert the {0:E} value {1}.",
                                     doubleValue.GetType().Name, doubleValue);
            }

            decimalValue = 13956810.96702888123451471211m;
            doubleValue = Convert.ToDouble(decimalValue);
            Console.WriteLine("{0} converted to {1}.", decimalValue, doubleValue);
        }
    }
}
