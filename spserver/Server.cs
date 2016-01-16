using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace spserver
{
    class Server
    {
        private static Server _server;

        private TcpListener _serverSocket;
        private List<Client> _clientList;

        private Server()
        {
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

            ListenForIncomingConnections();
        }

        private void ListenForIncomingConnections()
        {
            while (true)
            {
                var clientSocket = _serverSocket.AcceptTcpClient();
                var unauthenticatedClient = new Client
                {
                    ClientSocket = clientSocket,
                    Name = "Unauthenticated client",
                    Authenticated = false
                };

                _clientList.Add(unauthenticatedClient);
                unauthenticatedClient.StartClientThread();
            }
        }

        public void BroadcastMessage(string message)
        {
            foreach (var client in _clientList)
            {
                client.DisplayString(message);
            }
        }

        public Client GetUser(string username)
        {
            foreach (var client in _clientList)
            {
                if (client.Name == username)
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
