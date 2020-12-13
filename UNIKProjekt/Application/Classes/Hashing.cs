using System.Text;
using System.Security.Cryptography;

namespace Application.Classes
{
    public static class Hashing
    {
        public static byte[] GetHash(string inputString)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        public static string Hash(string password)
        {
            if (!string.IsNullOrEmpty(password))
            {
                StringBuilder sb = new StringBuilder();
                foreach (byte b in GetHash(password))
                    sb.Append(b.ToString("X2"));

                return sb.ToString();
            }

            return null;
        }
    }
}
