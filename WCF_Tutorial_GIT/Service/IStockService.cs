using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace EssentialWCF
{
    [ServiceContract(Namespace = "EssentialWCF")]
    interface IStockService
    {
        [OperationContract]
        Price GetPrice(string id ,string type);
    }
}
