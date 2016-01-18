﻿using System;
using spserver.Models;
using spserver.Utilities;

namespace spserver.Commands
{
    class PrivateMessageCommand : ICommand
    {
        public Action<Client, string[]> Action => SendPrivateMessage;

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
                return;
            }

            if (!Server.GetServer().IsUserOnline(username))
            {
                client.DisplayString($"The user '{username}' is not online. Can't deliver message.");
                return;
            }

            var chatMessage = new ChatMessage
            {
                FromUser = client.User.Username,
                ToUser = username,
                Message = message,
                Time = DateTime.Now
            };

            client.DisplayString($"To {chatMessage.ToUser}: {chatMessage.Message}");
            Server.GetServer().GetUser(chatMessage.ToUser).DisplayString($"{chatMessage.FromUser} whispers: {chatMessage.Message}");
            Database.GetDatabase().ChatMessages.Add(chatMessage);

            BetterConsole.WriteLog($"Private message sent: {client.User.Username} -> {username}");
        }
    }
}
