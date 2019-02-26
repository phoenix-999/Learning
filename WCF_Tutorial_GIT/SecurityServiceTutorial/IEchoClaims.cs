using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Data;


namespace SecurityServiceTutorial
{
    [ServiceContract]
    interface IEchoClaims
    {
        [OperationContract]
        string Echo();
        [OperationContract]
        void Test();
        [OperationContract]
        DataSet SendDataSet();
        [OperationContract]
        [FaultContract(typeof(DivideByZeroException))]
        void TestFault();
    }
}
