namespace spserver.Models
{
    class UserAccount
    {
        public string Username { get; set; }
        public byte[] HashedPassword { get; set; }
    }
}
