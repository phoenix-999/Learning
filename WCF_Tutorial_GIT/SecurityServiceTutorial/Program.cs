using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Threading;

namespace SecurityServiceTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "SERVER";
            ServiceHost host = new ServiceHost(typeof(EchoClaims));

            using (host as IDisposable)
            {
                host.Open();
                foreach (var a in host.BaseAddresses)
                {
                    Console.WriteLine(a.AbsoluteUri);
                }
                Console.WriteLine("SERVER Thread Id: {0}", Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine("Server is running...");
                Console.ReadKey();
            }
        }
    }
}
