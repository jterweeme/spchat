using System;

namespace spserver.Commands
{
    class LoginCommand : ICommand
    {
        public Action<Client, string[]> Action => new Action<Client, string[]>(Login);

        public bool ClientMustBeAuthenticated => false;

        public string Command => "login";

        private void Login(Client client, string[] parameters)
        {
            if (parameters.Length != 2)
            {
                client.DisplayString("Incorrect syntax. Use /login [username] [password]");
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
        }
    }
}
