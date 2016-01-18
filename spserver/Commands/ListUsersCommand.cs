using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spserver.Commands
{
    class ListUsersCommand : ICommand
    {
        public Action<Client, string[]> Action => ListUsers;
        public bool ClientMustBeAuthenticated => false;
        public string Command => "list";
        public string Description => "Shows all users that are online.";

        private void ListUsers(Client client, string[] parameters)
        {
            client.DisplayString("These users are online:");
            foreach (var c in Server.GetServer().Clients.Where(c => c.Authenticated == true))
            {
                client.DisplayString(c.User.Username);
            }
        }
    }
}
