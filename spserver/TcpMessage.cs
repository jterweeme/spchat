using System.Net.Sockets;

namespace spserver
{
    static class TcpMessage
    {
        public static string GetString(TcpClient clientSocket)
        {
            var bytesFrom = new byte[clientSocket.ReceiveBufferSize];
            var networkStream = clientSocket.GetStream();
            networkStream.Read(bytesFrom, 0, clientSocket.ReceiveBufferSize);
            var dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);

            return dataFromClient;
        }
    }
}
