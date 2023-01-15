using System.Security.Cryptography;
using System.Text;
using UserRegistration.Interface;

namespace UserRegistration.Service
{
    public class SecurePasswordGenerationAndValidation : ISecurePasswordGenerationAndValidation
    {
        public string GenerateSalt()
        {
            byte[] salt;
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(salt = new byte[16]);
            return Convert.ToBase64String(salt);
        }

        public byte[] GetHash(string password, string salt)
        {
            byte[] byteArray = Encoding.Unicode.GetBytes(String.Concat(salt,password));
            var sha256 = SHA256.Create();
            byte[] hashedBytes = sha256.ComputeHash(byteArray);
            return hashedBytes;
        }

        public bool PasswordValidation(string password, string hash, string salt)
        {
            string hashedPassword = Convert.ToBase64String(GetHash(password, salt));
            return hashedPassword.Equals(hash);
        }
    }
}
