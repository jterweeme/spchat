using spserver.Commands;
using System.Collections.Generic;

namespace spserver
{
    class CommandInterpreter
    {
        private static CommandInterpreter _interpreter;

        public List<ICommand> Commands { get; }

        private CommandInterpreter()
        {
            Commands = new List<ICommand>
            {
                new HelpCommand(),
                new ListUsersCommand(),
                new LoginCommand(),
                new PrivateMessageCommand(),
                new RegisterCommand()
            };
        }

        public static CommandInterpreter GetInterpreter()
        {
            return _interpreter ?? (_interpreter = new CommandInterpreter());
        }

        public ICommand InterpretCommand(string chatCommand)
        {
            foreach (var command in Commands)
            {
                if (command.Command.Equals(chatCommand.ToLower()))
                {
                    return command;
                }
            }

            return null;
        }

    }
}
