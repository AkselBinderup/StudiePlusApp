using Avalonia.Controls;
using ReactiveUI;
using StudiePlusApp.Models.Interfaces;
using StudiePlusApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace StudiePlusApp.ViewModels;

public class HomePageViewModel : ViewModelBase
{
    private readonly INavigationService _nav;
    private UserControl _chosenView;
    public UserControl ChosenView
    {
        get => _chosenView;
        set => this.RaiseAndSetIfChanged(ref _chosenView, value);
    }
    public ReactiveCommand<Unit, UserControl> GoToScheduleCommand { get; }
    public ReactiveCommand<Unit, UserControl> GoToCoursesCommand { get; }
    public ReactiveCommand<Unit, UserControl> GoToGradesCommand { get; }
    public ReactiveCommand<Unit, UserControl> GoToMessagesCommand { get; }
    public ReactiveCommand<Unit, UserControl> GoToAbsenceCausesCommand { get; }
    public ReactiveCommand<Unit, UserControl> GoToLoginCommand { get; }
    public ReactiveCommand<Unit, UserControl> GoToRegisterCommand { get; }
    


    public HomePageViewModel(INavigationService nav)
    {
        _nav = nav;
        ChosenView = _nav.NavigateTo<LoginScreenView>();

        GoToLoginCommand = ReactiveCommand.Create(() =>
            ChosenView = _nav.NavigateTo<LoginScreenView>());

        GoToRegisterCommand = ReactiveCommand.Create(() =>
            ChosenView = _nav.NavigateTo<RegisterScreenView>());



        GoToScheduleCommand = ReactiveCommand.Create(() => ChosenView = _nav.NavigateTo<ScheduleView>());
        GoToCoursesCommand = ReactiveCommand.Create(() => ChosenView = _nav.NavigateTo<CoursesPageView>());
        GoToGradesCommand = ReactiveCommand.Create(() => ChosenView = _nav.NavigateTo<GradesPageView>());
        GoToMessagesCommand = ReactiveCommand.Create(() => ChosenView = _nav.NavigateTo<MessagePageView>());
        GoToAbsenceCausesCommand = ReactiveCommand.Create(() => ChosenView = _nav.NavigateTo<AbsenceCausePageView>());
    }

    public void goToFirstPage()
    {
        _nav.NavigateTo<ScheduleView>();
    }

}
