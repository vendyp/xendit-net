using System.Text;

namespace Xendit.Net
{
    public static class StringUtil
    {
        public static string GenerateBasicAuthentication(string username, string password)
        {
            if (username is null)
            {
                username = string.Empty;
            }

            if (password is null)
            {
                password = string.Empty;
            }

            string encoded = System.Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1")
                               .GetBytes(username + ":" + password));

            return encoded;
        }
    }
}
