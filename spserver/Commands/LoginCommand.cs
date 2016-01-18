using System;
using spserver.Utilities;

namespace spserver.Commands
{
    class LoginCommand : ICommand
    {
        public Action<Client, string[]> Action => Login;
        public bool ClientMustBeAuthenticated => false;
        public string Command => "login";
        public string Description => "Login with specified credentials.";

        private void Login(Client client, string[] parameters)
        {
            if (parameters.Length != 2)
            {
                client.DisplayString("Incorrect syntax. Use /login [username] [password]");
                return;
            }

            if (client.Authenticated == true)
            {
                client.DisplayString("You are already logged in.");
                return;
            }

            var username = parameters[0];
            var password = parameters[1];

            var isLoginSuccessful = ClientAuthenticator.Authenticate(client, username, password);

            if (!isLoginSuccessful)
            {
                client.DisplayString("Username and password do not match.");
                return;
            }

            client.DisplayString($"Logged in as {username}.");
            Server.GetServer().BroadcastMessage($"{username} has joined the chat.");

            BetterConsole.WriteLog($"{username} logged in.");
        }
    }
}
