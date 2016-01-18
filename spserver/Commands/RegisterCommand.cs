using System;
using spserver.Utilities;

namespace spserver.Commands
{
    class RegisterCommand : ICommand
    {
        public Action<Client, string[]> Action => Register;

        public bool ClientMustBeAuthenticated => false;

        public string Command => "register";

        private void Register(Client client, string[] parameters)
        {
            if (parameters.Length != 2)
            {
                client.DisplayString("Incorrect syntax. Use /register [username] [password]");
                return;
            }

            var username = parameters[0];
            var password = parameters[1];
            
            var isRegisterSuccessful = ClientAuthenticator.Register(client, username, password);

            if (!isRegisterSuccessful)
            {
                client.DisplayString($"Username '{username}' already exists. Please choose another one.");
                return;
            }

            ClientAuthenticator.Authenticate(client, username, password);

            client.DisplayString($"Registered new user '{username}'. You are now logged in.");
            Server.GetServer().BroadcastMessage($"{username} has joined the chat.");
            
            BetterConsole.WriteLog($"New user registered: {username}");
        }
    }
}
