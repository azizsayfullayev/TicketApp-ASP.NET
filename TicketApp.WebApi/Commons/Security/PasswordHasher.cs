namespace TicketApp.WebApi.Commons.Security
{
    public class PasswordHasher
    {
        private const string _key = "fed9e0da-9169-41f2-9745-84790ddfabd9";
        public static (string Hash, string Salt) Hash(string password)
        {
            string salt = GenerateSalt();
            string hash = BCrypt.Net.BCrypt.HashPassword(salt + password + _key);
            return (Hash: hash, Salt: salt);
        }

        public static bool Verify(string password, string salt, string hash)
        {
            string oldhash = BCrypt.Net.BCrypt.HashPassword(salt + password + _key);
            return oldhash == hash;
        }

        private static string GenerateSalt()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
