using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsTest
{
    class Program
    {
        static void Main(string[] args)
        {
            MonthesCollection mc = new MonthesCollection();
            mc.InitializeCollection();
            Month m = new Month(Monthes.January);
            mc.Add(m);
            //mc.Remove(m);
            foreach (Month i in mc["January"])
            {
                Console.WriteLine(i);
            }
        }
    }
}
