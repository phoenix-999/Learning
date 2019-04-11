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
            Console.WriteLine("Culture: {0}", CultureInfo.CurrentCulture.NativeName);
            Console.WriteLine("Region: {0}", RegionInfo.CurrentRegion.NativeName);

            Temparature t = new Temparature(12m);
            string s = string.Format("{0}", t);
            Console.WriteLine(s);

            s = string.Format("{0:Celsius}", t); //Симовлы после {0: передаются в IFormattable.ToString
            Console.WriteLine(s);

            s = string.Format("{0:Fahrenheyt}", t);
            Console.WriteLine(s);

            s = string.Format("{0:Kelvin}", t);
            Console.WriteLine(s);


            s = t.ToString("kelvin", new CultureInfo("en-US"));
            Console.WriteLine(s);

            Console.WriteLine("Все культуры определенные в системе:");
            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
            foreach(var culture in cultures)
            {
                //Console.WriteLine("{0} : {1} - {2}", culture, culture.DisplayName, culture.NativeName);//Для корректного NativeName должны быть установлены языковые пакеты в ОС
            }
            
        }
    }
}
