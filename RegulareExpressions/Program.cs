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
            string result = Regex.Replace(date.ToShortDateString(), pattern, @"${год}.${месяц}.${день}");//Если $ используется перед выражением - означает взятие переменной
            Console.WriteLine(result);
        }
    }
}
