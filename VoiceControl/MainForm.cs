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

namespace VoiceControl
{
    public partial class MainForm : Form
    {
        public static SynchronizationContext MainFormSyncContext;
        Listener listener;
        public MainForm()
        {
            InitializeComponent();
            MainFormSyncContext = SynchronizationContext.Current;
            listener = new Listener();
        }
    }
}
