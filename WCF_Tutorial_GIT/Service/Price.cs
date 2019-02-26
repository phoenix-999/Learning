using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace EssentialWCF
{
    [DataContract]
    [KnownType(typeof(StockPrice))]
    [KnownType(typeof(MetalPrice))]
    public class Price
    {
        [DataMember]
        public double CurrentPrice { get; set; }
        [DataMember]
        public DateTime CurrentTime { get; set; }
        [DataMember]
        public string Currency { get; set; }
    }
}
