using System;

namespace spserver.Commands
{

    // Just a test command!
    class FartCommand : ICommand
    {
        public Action<Client, string[]> Action => Fart;

        public bool ClientMustBeAuthenticated => true;

        public string Command => "fart";

        private void Fart(Client client, string[] parameters)
        {
            Server.GetServer().BroadcastMessage($"{client.User.Username} farted.");
        }
    }
}
