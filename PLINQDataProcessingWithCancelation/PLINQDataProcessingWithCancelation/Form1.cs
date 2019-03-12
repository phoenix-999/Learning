using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
 

namespace PLINQDataProcessingWithCancelation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetTime();
            ShowTimeAsync();
        }
        async void ShowTimeAsync()
        {
            while (true)
            {
                this.Text = await Task<string>.Run(()=>
                {
                    Thread.Sleep(1000);
                    return DateTime.Now.ToLongTimeString();
                });
                if(cancelTime.IsCancellationRequested)
                {
                    break;
                }
            }
        }

        void SetTime()
        {
            //Timer не корректно работает по причине переключения(уничтожения) потоков пула средой CLR. Надо использовать либо Thread либо async/await
            //new System.Threading.Timer(
            //    (object state) =>
            //    {
            //        if (InvokeRequired)
            //        {
            //            BeginInvoke((Action)delegate { this.Text = DateTime.Now.ToLongTimeString(); });
            //        }
            //        else
            //        {
            //            this.Text = DateTime.Now.ToLongTimeString();
            //        }
            //    }, null, 0, 1000);

            //Thread t = new Thread(() =>
            //{
                //while (true)
                //{
                //    if (InvokeRequired)
                //    {
                //        this.Invoke((Action)delegate { this.Text = DateTime.Now.ToLongTimeString(); });
                //    }
                //    else
                //    {
                //        this.Text = DateTime.Now.ToLongTimeString();
                //    }
                //    Thread.Sleep(1000);
                //    if(cancelTime.IsCancellationRequested)
                //    {
                //        Thread.CurrentThread.Suspend();
                //    }
                //}
            //});
            //t.IsBackground = true;
            //t.Start();
        }
        private void btnExecute_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(ProcessIntData);
        }
        void ProcessIntData()
        {
            int[] source = Enumerable.Range(1, 100000000).ToArray<int>();
            int[] modThreeIsZero;
            try
            {
                modThreeIsZero = (from i in source.AsParallel().WithCancellation(cancelToken.Token) where i % 3 == 0 orderby i descending select i).ToArray<int>();
                MessageBox.Show(string.Format("Count of modThreeIsZero: {0}", modThreeIsZero.Count()));
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("Canceled");
                cancelToken = new CancellationTokenSource();
            }
            
        }
        CancellationTokenSource cancelToken = new CancellationTokenSource();

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cancelToken.Cancel();
        }
        CancellationTokenSource cancelTime = new CancellationTokenSource();
        private void btnStopTime_Click(object sender, EventArgs e)
        {
            cancelTime.Cancel();
        }
    }

}
