using System;

namespace spserver.Commands
{
    class LoginCommand : ICommand
    {
        public Action<Client, string[]> Action
        {
            get
            {
                return new Action<Client, string[]>(Login);
            }
        }

        public bool ClientMustBeAuthenticated
        {
            get
            {
                return false;
            }
        }

        public string Command
        {
            get
            {
                return "login";
            }
        }

        private void Login(Client client, string[] parameters)
        {
            if (parameters.Length != 2)
            {
                // TODO Error
                throw new System.NotImplementedException();
            }

            var username = parameters[0];
            var password = parameters[1];

            var isLoginSuccessful = ClientAuthenticator.Authenticate(client, username, password);

            if (isLoginSuccessful)
            {
                client.DisplayString($"Logged in as {username}.");
                Server.GetServer().BroadcastMessage($"{username} joined the chat.");
            }
            else
            {
                client.DisplayString("Username and password do not match.");
            }
        }
    }
}
