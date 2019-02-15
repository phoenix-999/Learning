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
        public Dictionary<string, double> ReciveTraffic;
        public Dictionary<string, double> SentTraffic;
        public List<NetworkInterface> nicArr;

        public Initializer()
        {
            ReciveTraffic = new Dictionary<string, double>();
            SentTraffic = new Dictionary<string, double>();
        }
        public void InitializeNetworkInterfaces()
        {
            this.nicArr = NetworkInterface.GetAllNetworkInterfaces().ToList(); ;
            if (nicArr.Count > 0)
            {
                foreach (var nic in nicArr)
                {
                    ReciveTraffic.Add(nic.Name, 0);
                    SentTraffic.Add(nic.Name, 0);
                }
            }
        }

        private void ReciveMonitorAllinterfaces()
        {
            NetworkInterface nic;
            while (true)
            {
                foreach (var interfaceName in ReciveTraffic.Keys.ToList())
                {
                    nic = nicArr.Find(interf => interf.Name.Contains(interfaceName));
                    try
                    {
                        IPInterfaceStatistics ipStat = nic.GetIPStatistics();
                        lock (ReciveTraffic)
                        {
                            ReciveTraffic[nic.Name] += (double)ipStat.BytesReceived / 1024 / 1024;
                        }
                    }
                    catch { }
                }
                Thread.Sleep(1000);
            }
        }

        private void SentMonitorAllinterfaces()
        {
            NetworkInterface nic;
            while (true)
            {
                foreach (var interfaceName in SentTraffic.Keys.ToList())
                {
                    nic = nicArr.Find(interf => interf.Name.Contains(interfaceName));
                    try
                    {
                        IPInterfaceStatistics ipStat = nic.GetIPStatistics();
                        lock (SentTraffic)
                        {
                            SentTraffic[nic.Name] += (double)ipStat.BytesSent / 1024 / 1024;
                        }
                    }
                    catch { }
                }
                Thread.Sleep(1000);
            }
        }

        public void InitializeReciveMonitorAllInterfaces()
        {
            Thread th = new Thread(ReciveMonitorAllinterfaces);
            th.IsBackground = true;
            th.Start();
        }

        public void InitializeSentMonitorAllInterfaces()
        {
            Thread th = new Thread(SentMonitorAllinterfaces);
            th.IsBackground = true;
            th.Start();
        }
    }
}
