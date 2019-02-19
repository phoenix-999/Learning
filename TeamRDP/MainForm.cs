using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AxMSTSCLib;
using MSTSCLib;

namespace TeamRDP
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

 

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                rdp.Server = tbServerName.Text;
                rdp.UserName = tbUserName.Text;
                IMsTscNonScriptable security = (IMsTscNonScriptable)rdp.GetOcx();
                security.ClearTextPassword = tbPassword.Text;
                
                rdp.Connect();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error Connecting", "Error connecting to remote desktop " + tbServerName.Text + " Error:  " + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                if(rdp.Connected.ToString() == "1")
                {
                    rdp.Disconnect();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error Disconnecting", "Error disconnecting from remote desktop " + tbServerName.Text + " Error:  " + Ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
    }
}
