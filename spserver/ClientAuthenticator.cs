using System.Linq;
using System.Security.Cryptography;
using System.Text;
using spserver.Models;

namespace spserver
{
    internal static class ClientAuthenticator
    {
        public static bool Authenticate(Client client, string username, string password)
        {
            var encodedPassword = new UTF8Encoding().GetBytes(password);
            var hashedPassword = MD5.Create().ComputeHash(encodedPassword);

            var matchedUser = Database.GetDatabase()
                .UserAccounts.FirstOrDefault(u => u.Username.Equals(username) && u.HashedPassword.SequenceEqual(hashedPassword));
            
            if (matchedUser == null)
                return false;

            client.User = matchedUser;
            client.Authenticated = true;

            return true;
        }

        public static bool Register(Client client, string username, string password)
        {
            var database = Database.GetDatabase();

            var encodedPassword = new UTF8Encoding().GetBytes(password);
            var hashedPassword = MD5.Create().ComputeHash(encodedPassword);

            if (database.UserAccounts.Any(u => u.Username == username))
            {
                return false;
            }

            var newUser = new UserAccount
            {
                Username = username,
                HashedPassword = hashedPassword
            };

            database.UserAccounts.Add(newUser);
            database.SaveDatabases();

            return true;
        }
    }
}