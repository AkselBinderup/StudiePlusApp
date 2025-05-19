using StudiePlusApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace StudiePlusApp.Helpers;

public class SecureUserStore
{
    private const string FilePath = "users.secure";
    private List<User> _users = new();

    public SecureUserStore()
    {
        Load();
    }

    public bool Register(string username, string password)
    {
        if (_users.Any(u => u.Username == username)) return false;

        var salt = PasswordHelper.GenerateSalt();
        var hash = PasswordHelper.HashPassword(password, salt);

        _users.Add(new User { Username = username, Salt = salt, PasswordHash = hash });
        Save();
        return true;
    }

    public bool Login(string username, string password)
    {
        var user = _users.FirstOrDefault(u => u.Username == username);
        return user != null && PasswordHelper.Verify(password, user.Salt, user.PasswordHash);
    }

    private void Save()
    {
        var json = JsonSerializer.Serialize(_users);
        var encrypted = EncryptionHelper.Encrypt(json);
        File.WriteAllText(FilePath, encrypted);
    }

    private void Load()
    {
        if (!File.Exists(FilePath)) return;

        var encrypted = File.ReadAllText(FilePath);
        var json = EncryptionHelper.Decrypt(encrypted);
        _users = JsonSerializer.Deserialize<List<User>>(json) ?? new();
    }
}