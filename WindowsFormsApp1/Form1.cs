﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();            
        }


        private void tmr_CurrentTime_Tick(object sender, EventArgs e)
        {
            tssl_Time.Text = DateTime.Now.ToLongTimeString(); //Выполняется в первичном потоке
        }
    }
}
