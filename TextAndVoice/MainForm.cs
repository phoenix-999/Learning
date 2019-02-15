using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TextAndVoice
{
    public partial class MainForm : Form
    {
        EnSpeecher speecher;
        [ThreadStatic]
        internal static MainForm Current;
        public MainForm()
        {
            InitializeComponent();
            Current = this;
            speecher = new EnSpeecher();
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            foreach(var i in tableLayoutPanel1.Controls)
            {
                var temp = i as Label;
                if (temp == null) continue;
                temp.Text = string.Empty;
            }
        }
    }
}
