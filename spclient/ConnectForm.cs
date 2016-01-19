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
            try
            {
                _connectInformation.Port = Parse(TextBoxServerPort.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("The port number is not valid. Please try again.");
                return;
            }
            

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
