using System.Security.Cryptography;
using System.Text;

namespace PriceMaster.Helper
{
    public class PasswordManager
    {
        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);
                string hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
                return hash;
            }
        }

        public static string DecryptPassword(string hashedPassword)
        {
            byte[] hashBytes = Enumerable.Range(0, hashedPassword.Length)
                .Where(x => x % 2 == 0)
                .Select(x => Convert.ToByte(hashedPassword.Substring(x, 2), 16))
                .ToArray();

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] decryptedBytes = sha256.ComputeHash(hashBytes);
                string decryptedPassword = Encoding.UTF8.GetString(decryptedBytes);
                return decryptedPassword;
            }
        }
    }
}
