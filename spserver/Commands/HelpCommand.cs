using System;

namespace spserver.Commands
{
    class HelpCommand : ICommand
    {
        public Action<Client, string[]> Action => ShowHelp;
        public bool ClientMustBeAuthenticated => false;
        public string Command => "help";
        public string Description => "Shows the help.";

        private void ShowHelp(Client client, string[] parameters)
        {
            client.DisplayString("These commands are available:");
            foreach (var command in CommandInterpreter.GetInterpreter().Commands)
            {
                client.DisplayString($"-> /{command.Command} - {command.Description}");
            }
        }
    }
}
