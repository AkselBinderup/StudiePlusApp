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
    private readonly INavigationService _nav;
    public ReactiveCommand<Unit, Unit> LoginCommand { get; }
    public ReactiveCommand<Unit, Unit> RegisterCommand { get; }


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

    public LoginScreenViewModel(INavigationService nav)
    {
        _nav = nav;
        //RegisterCommand = ReactiveCommand.Create(() => _homePage.ShowRegister());
        //register command to change page in homeview. i dont know if its needed here????
        LoginCommand = ReactiveCommand.Create(Login);
    }

    private void Login()
    {
        var store = new SecureUserStore();

        bool isValid = store.Login(Username,Password);
        if(isValid)
        {
            _nav.NavigateTo<CoursesPageView>();
            //If its a valid password i need it to switch page in homeviewmodel, like with the buttons i created in homeviewmodel
            //but have in my login axaml...
        }
    }
}
