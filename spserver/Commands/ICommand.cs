using System;

namespace spserver.Commands
{
    interface ICommand
    {
        Action<Client, string[]> Action { get; }
        bool ClientMustBeAuthenticated { get; }
        string Command { get; }
        string Description { get; }
    }
}
