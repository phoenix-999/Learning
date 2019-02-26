using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace EssentialWCF
{
    [DataContract]
    public class StockPrice : Price
    {
        [DataMember]
        public string Ticker { get; set; }
        [DataMember]
        public long DailyWolume { get; set; }
        [DataMember]
        public double DailyChange { get; set; }
    }
}
