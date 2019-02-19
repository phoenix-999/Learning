using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Remote_Assistant
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void tbRemoteAddress_TextChanged(object sender, EventArgs e)
        {
            tbRemoteAddress.CharacterCasing = CharacterCasing.Upper;
        }

        private void btnAscConnect_Click(object sender, EventArgs e)
        {
            RemoteConnect remoteConnect = new RemoteConnect();
            Boolean status;
            status = remoteConnect.StartRemoteAssistance(tbRemoteAddress.Text.ToString(), false, true);

            if (status == false)
            {
                System.Windows.Forms.MessageBox.Show("Unable to Establish Connection, Please try Again later.");
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            RemoteConnect remoteConnect = new RemoteConnect();
            Boolean status = remoteConnect.StartRemoteAssistance(tbRemoteAddress.Text.ToString(), true, false);
            if (status == false)
            {
                System.Windows.Forms.MessageBox.Show("Unable to Connect to the Remote Machine.Please try Again later.");
            }
        }
    }
}
