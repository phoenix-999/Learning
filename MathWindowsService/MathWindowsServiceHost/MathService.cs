using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using MathServiceLibrary;

namespace MathWindowsServiceHost
{
    public partial class MathService : ServiceBase
    {
        private ServiceHost host;
        public MathService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            if(host != null)
            {
                host.Close();
                host = null;
            }
            host = new ServiceHost(typeof(MathServiceLibrary.MathService));
            host.Open();
        }

        protected override void OnStop()
        {
            if(host != null)
            {
                host.Close();
            }
        }
    }
}
