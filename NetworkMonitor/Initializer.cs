using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Threading;

namespace NetworkMonitor
{
    
    class Initializer
    {
        public List<NetworkInterface> nicArr;

        public Initializer()
        {

        }
        public void InitializeNetworkInterfaces()
        {
            this.nicArr = NetworkInterface.GetAllNetworkInterfaces().ToList(); ;
        }
    }
}
