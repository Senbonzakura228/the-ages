using BCrypt.Net;

namespace Application.Authentication
{
    public class PasswordHasher
    {
        public string Generate(string password)
        {
            return BCrypt.Net.BCrypt.EnhancedHashPassword(password);
        }

        public bool Verify(string password, string hash)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(hash)) return false;
            return BCrypt.Net.BCrypt.EnhancedVerify(password, hash);
        }
    }
}