using System;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Windows.Forms;
using spclient.Utilities;
using static System.String;

namespace spclient
{
    public partial class Form1 : Form
    {
        private readonly TcpClient _clientSocket;
        private BinaryStream _binaryStream;

        public Form1()
        {
            InitializeComponent();
            _clientSocket = new TcpClient();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var connectInformation = new ConnectForm.ConnectInformation();
            var connectForm = new ConnectForm(connectInformation);
            var dialogResult = connectForm.ShowDialog();

            if (dialogResult == DialogResult.Cancel)
                return;

            ConnectToServer(connectInformation.ServerAddress, connectInformation.Port);
        }

        private void ConnectToServer(string serverAddress, int port)
        {
            _clientSocket.Connect(serverAddress, port);
            var sslStream = new SslStream(_clientSocket.GetStream(), false, new RemoteCertificateValidationCallback(ValidateCertificate));
            sslStream.AuthenticateAsClient("ChatServer");

            _binaryStream = new BinaryStream(sslStream);

            if (!_clientSocket.Connected)
                return;

            new Thread(GetMessageThread).Start();
        }

        public static bool ValidateCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            // Uncomment this lines to disallow untrusted certificates.
            //if (sslPolicyErrors == SslPolicyErrors.None)
            //    return true;
            //else
            //    return false;

            return true; // Allow untrusted certificates.
        }

        private void GetMessageThread()
        {
            while (_clientSocket.Connected)
            {
                var message = _binaryStream.Reader.ReadString();
                DisplayMessage(message);

                Thread.Sleep(5);
            }
        }

        private void DisplayMessage(string message)
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(() => DisplayMessage(message)));
            else
                TextBoxChat.Text = Concat(TextBoxChat.Text, Environment.NewLine, message);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ab1 = new AboutBox1();
            ab1.ShowDialog();
        }

        private void ButtonSend_Click(object sender, EventArgs e)
        {
            SendMessage(TextBoxUserInput.Text);
            TextBoxUserInput.Text = string.Empty;
        }

        private void SendMessage(string message)
        {
            _binaryStream.Writer.Write(message);
            _binaryStream.Writer.Flush();
        }
    }
}
