using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CW.SchoolServiceManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ServiceTools tool = null;

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnReStart.Enabled = true;
            btnStop.Enabled = true;
            btnStart.Enabled = false;
            tool.StartService();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {

        }

        private void btnReStart_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnReStart.Enabled = false;
            btnStop.Enabled = false;
            btnStart.Enabled = true;

            tool = new ServiceTools();
            tool.ServiceMsg += Tool_ServiceMsg;
        }

        private void Tool_ServiceMsg(string message)
        {
            this.Invoke(new Action(() =>
            {
                txtMsg.Text += ServiceTools.CurrentTime()+ "  "+  message + "\r\n";
            }));
        }
    }
}
