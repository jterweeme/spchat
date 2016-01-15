using System;

namespace spserver.Commands
{
    class PrivateMessageCommand : ICommand
    {
        public Action<Client, string[]> Action
        {
            get
            {
                return new Action<Client, string[]>(SendPrivateMessage);
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
                return "pm";
            }
        }

        private void SendPrivateMessage(Client client, string[] parameters)
        {
            throw new System.NotImplementedException();
        }
    }
}
