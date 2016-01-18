using spserver.Utilities;

namespace spserver
{
    class Program
    {
        private const int Port = 1234;

        static void Main(string[] args)
        {
            BetterConsole.WriteLog("Starting SpChat server...");
            var server = Server.GetServer();
            server.Start(Port);
        }
    }
}
