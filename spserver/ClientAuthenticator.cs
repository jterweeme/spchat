namespace spserver
{
    internal static class ClientAuthenticator
    {
        public static bool Authenticate(Client client, string username, string password)
        {
            // TODO Check against user database
            if (true)
            {
                client.User = new UserAccount
                {
                    Username = username
                };
                client.Authenticated = true;
                return true;
            }

            return false;
        }
    }
}