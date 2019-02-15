using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Threading;

namespace NetworkMonitor
{
    public partial class MainForm : Form
    {
        public static readonly int timeUpdate = 1000;
       
        
        private Initializer init;
        public MainForm()
        {
            InitializeComponent();
            init = new Initializer();
            InitializeEvents();
            init.InitializeNetworkInterfaces();
            init.InitializeReciveMonitorAllInterfaces();
            init.InitializeSentMonitorAllInterfaces();
            InitializeTimer();
            SetComboBoxInterfacesData();
        }

        //-----------------------------------
        private Point mouseOffset;
        private bool isMouseDown = false;

        private void frmTest_MouseDown(object sender, MouseEventArgs e)
        {
            
            int xOffset;
            int yOffset;

            if (e.Button == MouseButtons.Left)
            {
                xOffset = -e.X - SystemInformation.FrameBorderSize.Width;
                yOffset = -e.Y - SystemInformation.CaptionHeight -
                    SystemInformation.FrameBorderSize.Height;
                mouseOffset = new Point(xOffset, yOffset);
                isMouseDown = true;
            } else if(e.Button == MouseButtons.Right)
            {
                GetContextMenu();
            }
        }

        private void frmTest_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouseOffset.X, mouseOffset.Y);
                Location = mousePos;
            }
        }

        private void frmTest_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = false;
            }
        }
        //---------------------------


        private void SetComboBoxInterfacesData()
        {
            if (init.nicArr.Count > 0)
            {
                foreach (var nic in init.nicArr)
                {
                    cmbInterfaces.Items.Add(nic.Name);
                }
                cmbInterfaces.SelectedIndex = 0;
            }
        }

        public void InitializeTimer()
        {
            System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
            t.Interval = timeUpdate;
            t.Tick += (sender, e) => { this.UpdateDisplayData(); };
            t.Start();
        }


        private void UpdateDisplayData()
        {
            NetworkInterface nic = init.nicArr[cmbInterfaces.SelectedIndex];
            IPInterfaceStatistics ipStat = nic.GetIPStatistics();

            double mbByteSent = ((double)ipStat.BytesSent) / 1000 / 1000;
            double mbByteRecive = ((double)ipStat.BytesReceived) / 1000 / 1000;

            //ReciveTraffic[nic.Name] += (double)ipStat.BytesReceived / 1024 / 1024;
            //SentTraffic[nic.Name] += (double)ipStat.BytesSent / 1024 / 1024;


            lbSpeed.Text = string.Format("{0} Мбит/сек", (nic.Speed / 1000 / 1000).ToString());
            lbInterfaceType.Text = nic.NetworkInterfaceType.ToString();
            lbStatus.Text = nic.OperationalStatus.ToString();

            lbSentMb.Text = string.Format("{0} Мбит/сек", Math.Round(mbByteSent, 2));
            lbReciveMb.Text = string.Format("{0} Мбит/сек", Math.Round(mbByteRecive, 2));

            lbHasMulticast.Text = nic.SupportsMulticast ? "Поддерживает" : "Не поддерживает";

            lbIncomingPacketDiscarded.Text = ipStat.IncomingPacketsDiscarded.ToString();

            lbIncomingPacketsError.Text = ipStat.IncomingPacketsWithErrors.ToString();

            lbIncomingUnknownProtocolPackets.Text = ipStat.IncomingUnknownProtocolPackets.ToString();

            lbNonUnicastPacketsReceived.Text = ipStat.NonUnicastPacketsReceived.ToString();

            lbNonUnicastPacketsSent.Text = ipStat.NonUnicastPacketsSent.ToString();

            lbOutgoingPacketsDiscarded.Text = ipStat.OutgoingPacketsDiscarded.ToString();

            lbOutgoingPacketsWithErrors.Text = ipStat.OutgoingPacketsWithErrors.ToString();

            lbOutputQueueLength.Text = ipStat.OutputQueueLength.ToString();

            lbUnicastPacketsReceived.Text = ipStat.UnicastPacketsReceived.ToString();

            lbUnicastPacketsSent.Text = ipStat.UnicastPacketsSent.ToString();

            lbReciveAll.Text = string.Format("{0} Мбайт", Math.Round(init.ReciveTraffic[nic.Name], 2));

            lbSentAll.Text = string.Format("{0} Мбайт", Math.Round(init.SentTraffic[nic.Name], 2));
        }


        

        private void GetContextMenu()
        {
             tableLayoutPanel1.ContextMenuStrip = contextMenuStrip1;
             contextMenuStrip1.Show();
        }

        private void InitializeEvents()
        {
            foreach(Control c in tableLayoutPanel1.Controls)
            {
                c.MouseDown += frmTest_MouseDown;
                c.MouseUp += frmTest_MouseUp;
                c.MouseMove += frmTest_MouseMove;
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
