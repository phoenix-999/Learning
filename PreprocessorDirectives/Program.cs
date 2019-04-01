using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreprocessorDirectives
{
    class Program
    {
        static void Main(string[] args)
        {
            #region
            Console.WriteLine("region");
            #endregion

#if DEBUG //проверка условия препроцессором
            Console.WriteLine("DEBUG");
#endif

#line hidden //Скрыто от отладчика
            Console.WriteLine("Скрыто от отладчика");
#line default

#warning Пользовательские предупреждения

//#error Ошибка опрделенная пользователем, не откомпилируется
        }
    }
}
