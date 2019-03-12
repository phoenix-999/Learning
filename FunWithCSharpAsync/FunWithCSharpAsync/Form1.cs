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

namespace FunWithCSharpAsync
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnCallMethod_Click(object sender, EventArgs e)
        {
            this.Text = await DoWork();
        }
        private Task<string> DoWork()
        {
            return Task.Run(() =>
            {
                Thread.Sleep(5000);
                return "Done this work";
            });
        }
    }
}
