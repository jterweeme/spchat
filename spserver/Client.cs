using System;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Threading;
using spserver.Models;
using spserver.Utilities;

namespace spserver
{
    class Client
    {
        private readonly TcpClient _clientSocket;

        public bool Authenticated { get; set; }
        public BinaryStream Stream { get; set; }
        public UserAccount User { get; set; }

        public Client(TcpClient clientSocket)
        {
            _clientSocket = clientSocket;

            var sslStream = new SslStream(clientSocket.GetStream(), false);
            sslStream.AuthenticateAsServer(Server.GetServer().Certificate, false, SslProtocols.Tls, true);
            Stream = new BinaryStream(sslStream);

            BetterConsole.WriteLog("Connection secured.");

            StartClientThread();
        }

        private void StartClientThread()
        {
            var thread = new Thread(ClientThread);
            thread.Start();
        }

        private void ClientThread()
        {
            while (_clientSocket.Connected)
            {
                var message = Stream.Reader.ReadString();

                if (message.StartsWith("/"))
                {
                    ProcessCommand(message);
                    continue;
                }

                if (!Authenticated)
                {
                    DisplayString("You are not authenticated to use the chat. Please login first using '/login [username] [password]'");
                    continue;
                }

                var chatMessage = new ChatMessage
                {
                    FromUser = User.Username,
                    ToUser = "Everyone",
                    Message = message,
                    Time = DateTime.Now
                };

                Server.GetServer().BroadcastChatMessage(chatMessage);
                Database.GetDatabase().ChatMessages.Add(chatMessage);

            }

            Server.GetServer().RemoveClient(this);
            Server.GetServer().BroadcastMessage($"{User.Username} has left the chat.");
        }

        private void ProcessCommand(string message)
        {
            var splitMessage = message.Trim('\0').Split(' ');

            var commandString = splitMessage[0].Replace("/", "");
            var parameters = new string[splitMessage.Length - 1];
            for (var i = 1; i < splitMessage.Length; i++)
            {
                parameters[i - 1] = splitMessage[i];
            }

            var command = CommandInterpreter.GetInterpreter().InterpretCommand(commandString);

            if (command == null)
            {
                DisplayString("Unknown command.");
                return;
            }

            if (command.ClientMustBeAuthenticated && !Authenticated)
            {
                DisplayString("You are not authenticated to use this command. Please login first using '/login [username] [password]'");
                return;
            }

            command.Action.Invoke(this, parameters);
        }

        public void DisplayString(string s)
        {
            Stream.Writer.Write(s);
            Stream.Writer.Flush();
        }
    }
}
