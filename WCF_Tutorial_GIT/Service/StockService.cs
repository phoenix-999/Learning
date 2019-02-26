using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Threading;

namespace EssentialWCF
{
    class StockService:IStockService
    {
        public Price GetPrice(string id, string type)
        {
            Console.WriteLine("GetPrice Thread Id: {0}", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Request from: {0}", OperationContext.Current.IncomingMessageHeaders.From);
            if (type.ToLower().Contains("stock"))
            {
                StockPrice price = new StockPrice() { Ticker = id, DailyWolume = 450000, CurrentPrice = 97.02, CurrentTime = System.DateTime.Now, Currency = "USD" };
                return price;
            }
            else if(type.ToLower().Contains("metal"))
            {
                MetalPrice price = new MetalPrice() { Metal=id, Quality="0.999", CurrentPrice=785.00, CurrentTime=System.DateTime.Now, Currency="USD"};
                return price;
            }
            return new Price();
        }
    }
}
