using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace spclient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cf = new ConnectForm();
            cf.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ab1 = new AboutBox1();
            ab1.Show();
        }
    }
}
