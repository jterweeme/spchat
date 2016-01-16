namespace spserver
{
    internal static class ClientAuthenticator
    {
        public static bool Authenticate(Client client, string username, string password)
        {
            // TODO Check against user database
            if (true)
            {
                client.Name = username;
                client.Authenticated = true;
                return true;
            }

            return false;
        }
    }
}