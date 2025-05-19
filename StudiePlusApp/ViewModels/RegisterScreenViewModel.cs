using ReactiveUI;
using StudiePlusApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace StudiePlusApp.ViewModels;

public class RegisterScreenViewModel : ViewModelBase
{
    private string _username;
    private string _email;
    private string _password;
    private string _confirmPassword;

    public string Username
    {
        get => _username;
        set => this.RaiseAndSetIfChanged(ref _username, value);
    }

    public string Email
    {
        get => _email;
        set => this.RaiseAndSetIfChanged(ref _email, value);
    }

    public string Password
    {
        get => _password;
        set => this.RaiseAndSetIfChanged(ref _password, value);
    }

    public string ConfirmPassword
    {
        get => _confirmPassword;
        set => this.RaiseAndSetIfChanged(ref _confirmPassword, value);
    }

    public ReactiveCommand<Unit, Unit> RegisterCommand { get; }

    public RegisterScreenViewModel()
    {
        RegisterCommand = ReactiveCommand.Create(Register);
    }

    private void Register()
    {
        if (Password != ConfirmPassword)
        {
            Console.WriteLine("Passwords do not match!");
            return;
        }
        var store = new SecureUserStore();

        store.Register(Username, Password);
    }
}
