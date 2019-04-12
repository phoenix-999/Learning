using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace RegulareExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            //SearchDigital();
            ReplaceDateWithVariable(DateTime.Now);
            SearchSubString();
        }

        static void SearchDigital()
        {
            string pattern = @"\d";

            Regex regex = new Regex(pattern);

            string stringToSearch = Console.ReadLine();
            bool found = regex.IsMatch(stringToSearch);

            Console.WriteLine(found ? "Found digital" : "Not found digital");
        }

        static void ReplaceDateWithVariable(DateTime date)
        {
            string pattern = @"(?<день>\d{1,2})\.(?<месяц>\d{1,2})\.(?<год>\d{2,4})";//Переменные обозначаются <>,а используются {}
            //Regex.Replace возвращает измененную строку
            string result = Regex.Replace(date.ToShortDateString(), pattern, @"${год}.${месяц}.${день}");//Если $ используется перед выражением - означает взятие переменной
            Console.WriteLine(result);

            //Замена через лямбда-выражение
            //Возвращаемое значения поиска по регулярному выражению возвращает экземпляр Match, свойство Value которого соответсвует найденному значению
            //Экземпляр Match передается в лямбда-выражение
            result = Regex.Replace(
                "sdfsdfd123sdfsdfd",
                @"\d+",
                (Match m) => { return (decimal.Parse(m.Value)+1m).ToString(); }
                );

            Console.WriteLine(result);
        }

        static void SearchSubString()
        {
            string pattern = @"\d+";

            Regex regex = new Regex(pattern);

            string str = "sfdskflsdlkf123f;gdf;lbjmk4578gmb";

            //Ищет первое вхождение
            string result = regex.Match(str).Value;

            Console.WriteLine(result);

            //Поиск всех вхождений
            for (Match m = regex.Match(str); m.Success; m = m.NextMatch())
            {
                Console.WriteLine(m.Value);
            }
        }
    }
}
