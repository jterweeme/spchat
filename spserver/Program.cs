using System;

namespace spserver
{
    class Program
    {
        private const int Port = 1234;

        static void Main(string[] args)
        {
            Console.WriteLine("Starting SpChat server...");
            var server = Server.GetServer();
            Console.WriteLine($"Initialized server socket on port {Port}");
            server.Start(Port);
        }
    }
}
