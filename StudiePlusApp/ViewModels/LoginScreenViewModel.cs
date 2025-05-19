using Avalonia.Controls;
using ReactiveUI;
using StudiePlusApp.Helpers;
using StudiePlusApp.Models.Interfaces;
using StudiePlusApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace StudiePlusApp.ViewModels;

public class LoginScreenViewModel : ViewModelBase
{
    private string _username;
    private string _password;

    public string Username
    {
        get => _username;
        set => this.RaiseAndSetIfChanged(ref _username, value);
    }

    public string Password
    {
        get => _password;
        set => this.RaiseAndSetIfChanged(ref _password, value);
    }

    public ReactiveCommand<Unit, Unit> LoginCommand { get; }
    public ReactiveCommand<Unit, Unit> RegisterCommand { get; }
    public LoginScreenViewModel()
    {
        LoginCommand = ReactiveCommand.Create(Login);
    }

    private void Login()
    {
        var store = new SecureUserStore();

        bool isValid = store.Login(Username,Password);
        if(isValid)
        {
        }
    }
}
