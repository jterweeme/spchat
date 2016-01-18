using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using spserver.Utilities;

namespace spserver
{
    class Server
    {
        private static Server _server;

        private TcpListener _serverSocket;
        private readonly List<Client> _clientList;

        public X509Certificate2 Certificate { get; }

        private Server()
        {
            Certificate = new X509Certificate2("certificate.pfx", "SuperSecretPassword");

            _clientList = new List<Client>();
        }

        public static Server GetServer()
        {
            return _server ?? (_server = new Server());
        }

        public void Start(int port)
        {
            _serverSocket = new TcpListener(IPAddress.Any, port);
            _serverSocket.Start();

            BetterConsole.WriteLog($"Initialized server socket on port {port}");

            ListenForIncomingConnections();
        }

        private void ListenForIncomingConnections()
        {
            while (true)
            {
                var clientSocket = _serverSocket.AcceptTcpClient();
                BetterConsole.WriteLog($"New client connected.");
                var unauthenticatedClient = new Client(clientSocket);

                _clientList.Add(unauthenticatedClient);
            }
        }

        public void BroadcastMessage(string message)
        {
            foreach (var client in _clientList)
            {
                client.DisplayString(message);
            }

            BetterConsole.WriteLog($"Public chat: {message}");
        }

        public void BroadcastChatMessage(Client from, string message)
        {
            BroadcastMessage($"{from.User.Username} says: {message}");
        }

        public Client GetUser(string username)
        {
            foreach (var client in _clientList)
            {
                if (client.User.Username == username)
                {
                    return client;
                }
            }

            return null;
        }

        public bool IsUserOnline(string username)
        {
            return GetUser(username) != null;
        }

        public void RemoveClient(Client client)
        {
            _clientList.Remove(client);
        }
    }
}
