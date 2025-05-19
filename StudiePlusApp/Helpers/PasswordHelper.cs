using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace StudiePlusApp.Helpers;

public static class PasswordHelper
{
    public static string GenerateSalt() => Convert.ToBase64String(RandomNumberGenerator.GetBytes(16));

    public static string HashPassword(string password, string salt)
    {
        var saltBytes = Convert.FromBase64String(salt);
        var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, 100_000, HashAlgorithmName.SHA256);
        return Convert.ToBase64String(pbkdf2.GetBytes(32)); 
    }

    public static bool Verify(string password, string salt, string hash) =>
        HashPassword(password, salt) == hash;
}