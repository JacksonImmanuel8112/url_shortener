using System.Security.Cryptography;
using System.Text;

namespace urlshortner.Helper
{
    public static class UrlHelper
    {
        public const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

        public static string Generate(int length = 6)
        {
            var data = new byte[length];

            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(data);

            var result = new StringBuilder(length);
            foreach (var b in data)
            {
                result.Append(chars[b % chars.Length]);
            }
            return result.ToString();
        }
    }
}
