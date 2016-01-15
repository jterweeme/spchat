using System;

namespace spserver.Commands
{

    // Just a test command!
    class FartCommand : ICommand
    {
        public Action<Client, string[]> Action
        {
            get
            {
                return new Action<Client, string[]>(Fart);
            }
        }

        public bool ClientMustBeAuthenticated
        {
            get
            {
                return true;
            }
        }

        public string Command
        {
            get
            {
                return "fart";
            }
        }

        private void Fart(Client client, string[] parameters)
        {
            Server.GetServer().BroadcastMessage($"{client.Name} farted.");
        }
    }
}
