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
    public ReactiveCommand<Unit, Unit> GoToScheduleCommand { get; }
    public ReactiveCommand<Unit, Unit> GoToCoursesCommand { get; }
    public ReactiveCommand<Unit, Unit> GoToGradesCommand { get; }
    public ReactiveCommand<Unit, Unit> GoToMessagesCommand { get; }
    public ReactiveCommand<Unit, Unit> GoToAbsenceCausesCommand { get; }
    public ReactiveCommand<Unit, Unit> GoToLoginCommand { get; }
    public ReactiveCommand<Unit, Unit> GoToRegisterCommand { get; }
    


    public HomePageViewModel(INavigationService nav)
    {
        _nav = nav;
        _nav.CurrentViewObservable
            .Subscribe(view => ChosenView = (UserControl)view);

        _nav.NavigateTo<LoginScreenView>();
        
        GoToLoginCommand = ReactiveCommand.Create(() => _nav.NavigateTo<LoginScreenView>());
        GoToRegisterCommand = ReactiveCommand.Create(() => _nav.NavigateTo<RegisterScreenView>());
        GoToScheduleCommand = ReactiveCommand.Create(() => _nav.NavigateTo<ScheduleView>());
        GoToCoursesCommand = ReactiveCommand.Create(() => _nav.NavigateTo<CoursesPageView>());
        GoToGradesCommand = ReactiveCommand.Create(() =>  _nav.NavigateTo<GradesPageView>());
        GoToMessagesCommand = ReactiveCommand.Create(() =>  _nav.NavigateTo<MessagePageView>());
        GoToAbsenceCausesCommand = ReactiveCommand.Create(() =>  _nav.NavigateTo<AbsenceCausePageView>());

    }

}
