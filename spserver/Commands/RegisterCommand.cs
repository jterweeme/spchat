using System;

namespace spserver.Commands
{
    class RegisterCommand : ICommand
    {
        public Action<Client, string[]> Action => new Action<Client, string[]>(Register);

        public bool ClientMustBeAuthenticated => false;

        public string Command => "register";

        private void Register(Client client, string[] parameters)
        {
            throw new NotImplementedException();
        }
    }
}
