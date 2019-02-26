using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SecurityServiceClient
{
    class MainClient
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Доступ по HTTPS");
            //new ClientRunner().Run("https");
            //Console.WriteLine("Доступ по TCP");
            //new ClientRunner().Run("tcp");
            Console.WriteLine("Доступ по TCP");
            new ClientRunner().Run("tcp");
            Console.ReadKey();
        }
    }
}
