using spserver.Commands;
using System.Collections.Generic;

namespace spserver
{
    class CommandInterpreter
    {
        private static CommandInterpreter _interpreter;

        private List<ICommand> _commandList;

        private CommandInterpreter()
        {
            _commandList = new List<ICommand>();
            _commandList.Add(new LoginCommand());
            _commandList.Add(new PrivateMessageCommand());
            _commandList.Add(new FartCommand());
        }

        public static CommandInterpreter GetInterpreter()
        {
            return _interpreter ?? (_interpreter = new CommandInterpreter());
        }

        public ICommand InterpretCommand(string chatCommand)
        {
            foreach (var command in _commandList)
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
