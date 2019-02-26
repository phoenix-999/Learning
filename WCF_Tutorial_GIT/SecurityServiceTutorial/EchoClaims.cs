using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.IdentityModel.Claims;
using System.Security.Permissions;
using System.Data;
using System.ServiceModel.Description;
using System.Collections.ObjectModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Threading;

namespace SecurityServiceTutorial
{
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.PerCall)]
    public class EchoClaims : IEchoClaims, IServiceBehavior, IDisposable
    {
        public string Echo()
        {
            Console.WriteLine("Вызов Echo");
            string user = string.Empty;
            user = OperationContext.Current.ServiceSecurityContext.PrimaryIdentity.Name;
            Console.WriteLine(user);
            return user;
        }
        public void Test()
        {
            Console.WriteLine("Вызов Test");
            string user = string.Empty;
            //user = OperationContext.Current.ServiceSecurityContext.PrimaryIdentity.Name;
            Console.WriteLine(user);
            Thread.Sleep(5000);
            Console.WriteLine("Test закончил работу");
        }

        public DataSet SendDataSet()
        {
            Console.WriteLine("Вызов SendDataSet");
            DataSet ds = new DataSet("TestDataSet");
            DataTable table = new DataTable("TableTest1");
            table.Columns.Add("FirstName", typeof(string));
            table.Columns.Add("LastName", typeof(string));
            DataRow row = table.NewRow();
            row["FirstName"] = "YUrii";
            row["LastName"] = "Family";
            table.Rows.Add(row);
            ds.Tables.Add(table);
            return ds;
        }
        public void TestFault()
        {
            Console.WriteLine("Вызов TestFault, поток: {0}", Thread.CurrentThread.ManagedThreadId);
            ThrowException();
            throw new FaultException<DivideByZeroException>(new DivideByZeroException(), "Деления на нуль");
            //throw new FaultException("Деления на нуль");
        }
        private void ThrowException()
        {
            throw new Exception();
        }

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            
        }

        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
            
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            MyErrorHandler handler = new MyErrorHandler();
            foreach(ChannelDispatcher d in serviceHostBase.ChannelDispatchers)
            {
                d.ErrorHandlers.Add(handler);
            }
        }

        public void Dispose()
        {
            Console.WriteLine("Вызо в Dispose");
        }
    }
}
