using System;

namespace spserver.Utilities
{
    static class BetterConsole
    {
        public static void WriteLog(string message)
        {
            Console.WriteLine($"[{DateTime.Now}] {message}");
        }
    }
}
