using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace spserver
{
    class Client
    {
        public bool Authenticated { get; set; }
        public TcpClient ClientSocket { get; set; }
        public string Name { get; set; }

        public void StartClientThread()
        {
            var thread = new Thread(ClientThread);
            thread.Start();
        }

        private void ClientThread()
        {
            // TODO Check if client disconnected
            while (true)
            {
                if (ClientSocket.Available <= 0)
                {
                    Thread.Sleep(1);
                    continue;
                }

                var message = TcpMessage.GetString(ClientSocket);

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

                Server.GetServer().BroadcastMessage(Name + " says: " + message);
            }
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
            var stream = ClientSocket.GetStream();
            var bytes = Encoding.ASCII.GetBytes(s);
            stream.Write(bytes, 0, bytes.Length);
            stream.Flush();
        }
    }
}
