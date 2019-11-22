using System;
using System.Security.Cryptography;
using System.Text;

internal class Helper
{
    public static string EncodePassword(string originalPassword)
    {
        SHA1 sha1 = new SHA1CryptoServiceProvider();
        SHA512CryptoServiceProvider sha512 = new SHA512CryptoServiceProvider();

        byte[] inputBytes = (new UnicodeEncoding()).GetBytes(originalPassword);
        byte[] hash = sha1.ComputeHash(inputBytes);
        byte[] rehash = sha512.ComputeHash(hash);

        return Convert.ToBase64String(rehash);
    }

    // Generate a random string with a given size
    public string RandomToken()
    {
        StringBuilder builder = new StringBuilder();
        Random random = new Random();
        char ch;
        for (int i = 0; i < 13; i++)
        {
            ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
            builder.Append(ch);
        }
        //if (lowerCase)
            //return builder.ToString().ToLower();
        return builder.ToString();
    }
}

