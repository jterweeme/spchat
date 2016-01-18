using System;
using spserver.Utilities;

namespace spserver.Commands
{
    class PrivateMessageCommand : ICommand
    {
        public Action<Client, string[]> Action => new Action<Client, string[]>(SendPrivateMessage);

        public bool ClientMustBeAuthenticated => true;

        public string Command => "pm";

        private void SendPrivateMessage(Client client, string[] parameters)
        {
            if (parameters.Length != 2)
            {
                client.DisplayString("Incorrect syntax. Use /pm [username] [message]");
                return;
            }

            var username = parameters[0];
            var message = parameters[1];

            if (username == client.User.Username)
            {
                client.DisplayString("You can't send private messages to yourself.");
            }

            if (!Server.GetServer().IsUserOnline(username))
            {
                client.DisplayString($"The user '{username}' is not online. Can't deliver message.");
                return;
            }

            client.DisplayString($"To {username}: {message}");
            Server.GetServer().GetUser(username).DisplayString($"{client.User.Username} whispers: {message}");

            BetterConsole.WriteLog($"Private message sent: {client.User.Username} -> {username}");
        }
    }
}
