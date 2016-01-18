using System;
using System.Windows.Forms;
using static System.Int32;

namespace spclient
{
    public partial class ConnectForm : Form
    {
        private ConnectInformation _connectInformation;

        public ConnectForm(ConnectInformation connectInformation)
        {
            InitializeComponent();
            _connectInformation = connectInformation;
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ButtonConnect_Click(object sender, EventArgs e)
        {
            _connectInformation.ServerAddress = TextBoxServerAddress.Text;
            _connectInformation.Port = Parse(TextBoxServerPort.Text);

            DialogResult = DialogResult.OK;
            Close();
        }

        public class ConnectInformation
        {
            public string ServerAddress { get; set; }
            public int Port { get; set; }
        }
    }
}
