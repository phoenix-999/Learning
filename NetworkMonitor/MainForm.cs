﻿using System;
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
using System.Diagnostics;
using System.Text.RegularExpressions;
using Microsoft.Win32;

namespace NetworkMonitor
{
    public partial class MainForm : Form
    {
        private bool isAutoLoadApp;
        const string appName = "NetworkMonitor";
        string ExePath = System.Windows.Forms.Application.ExecutablePath;
        public static readonly int timeUpdate = 1000;
        private long lastReciveTraffic = 0;
        private long lastSentTraffic = 0;
        
        private Initializer init;
        public MainForm()
        {
            InitializeComponent();
            init = new Initializer();
            InitializeEvents();
            init.InitializeNetworkInterfaces();
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

        private void frmTest_MouseWheel(object sender, MouseEventArgs e)
        {
            if(e.Delta > 0)
            {
                if (this.Opacity < 1) this.Opacity += 0.1;
            }
            else
            {
                if (this.Opacity > 0.2) this.Opacity -= 0.1;
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

            long mbByteSent = (ipStat.BytesSent) * 8 / (long)Math.Pow(10, 6);
            long mbByteRecive = (ipStat.BytesReceived) * 8 / (long)Math.Pow(10, 6);

            
            long mbByteSentOnSec = mbByteSent - ( lastSentTraffic != 0 ? lastSentTraffic : mbByteSent);
            long mbByteReciveOnSec = mbByteRecive - (lastReciveTraffic != 0 ? lastReciveTraffic : mbByteRecive); ;
            lastSentTraffic = mbByteSent;
            lastReciveTraffic = mbByteRecive;

            lbSpeed.Text = string.Format("{0} Мбит/сек", Math.Round((nic.Speed / Math.Pow(10, 6)), 0).ToString());
            lbInterfaceType.Text = nic.NetworkInterfaceType.ToString();
            lbStatus.Text = nic.OperationalStatus.ToString();

            lbSentMb.Text = string.Format("{0} Мбит/сек", mbByteSentOnSec);
            lbReciveMb.Text = string.Format("{0} Мбит/сек", mbByteReciveOnSec);

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

            lbReciveAll.Text = string.Format("{0} МБайт", Math.Round(mbByteRecive*0.125, 0));

            lbSentAll.Text = string.Format("{0} МБайт", Math.Round(mbByteSent*0.125, 0));
        }


        

        private void GetContextMenu()
        {
            string item;
            RegistryKey reg;
            //Проверка HKEY_CURRENT_USER
            reg = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\");
            if(reg.GetValue(appName) != null)
            {
                item = "Удалить из автозагрузки";
                isAutoLoadApp = true;
            }
            else
            {
                item = "Добавить в автозагрузку";
                isAutoLoadApp = false;
            }

            contextMenuStrip1.Items.Find("toolStripMenuItem2", false)[0].Text = item;
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

            this.MouseWheel += frmTest_MouseWheel;
            //Отключение скроллинга выпадающего списка сетевых интерфейсов
            this.cmbInterfaces.MouseWheel += (object sender, MouseEventArgs e) =>
            {
                ((HandledMouseEventArgs)e).Handled = true;
                this.OnMouseWheel(e);
            };
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cmbInterfaces_SelectedIndexChanged(object sender, EventArgs e)
        {
            lastReciveTraffic = 0;
            lastSentTraffic = 0;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            RegistryKey reg;
            //Работает с HKEY_CURRENT_USER
            reg = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\");
            if (isAutoLoadApp)
            {
                reg.DeleteValue(appName);
                MessageBox.Show(string.Format("{0} удалена из автозагрузки. При следующем запуске системы программа НЕ будет запущена.", appName));
            }
            else
            {
                reg.SetValue(appName, ExePath);
                MessageBox.Show(string.Format("{0} добавлена в автозагрузку. При следующем запуске системы программа будет запущена.", appName));
            }
        }
    }
}
