using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace DivisionBy9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Division By 9";
            var task = GetResultAsync();
            task.Wait();
            Console.WriteLine("The program has finished processing.");
        }

        static async Task GetResultAsync()
        {
            await Task.Run(() =>
            {
                Console.WriteLine("Working...");
                Parallel.For(10, int.MaxValue, (i) =>
                {
                    var digits = GetCharArray(i);
                    if (GetSumDigit(digits) == 9)
                    {
                        bool result = TryDivisionBy9(i);
                        if (!result)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"The number is not divisible by 9: {i}");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                });
            });

        }


        static bool TryDivisionBy9(long number)
        {
            return number % 9 == 0;
        }

        static char[] GetCharArray(long num)
        {
            List<char> result = new List<char>();

            foreach(var n in num.ToString())
            {
                result.Add(n);
            }
            return result.ToArray();
        }

        static int GetSumDigit(IEnumerable<char> digits)
        {
            int result = 0;

            foreach(var d in digits)
            {
                int tempResult;
                bool parseOk = int.TryParse(d.ToString(), out tempResult);
                if (parseOk)
                    result += tempResult;
            }

            return result;
        }
    }
}
