using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Client.StockService;
//Клиент
namespace Client
{
    class MainClient
    {
        static void Main(string[] args)
        {
            StockServiceClient client = new StockServiceClient("tcpIStockService");
            StockPrice sp = client.GetPrice("Id", "Stock") as StockPrice;
            Console.WriteLine(sp);
            Console.WriteLine(client.Endpoint.Address);
        }
    }
}
