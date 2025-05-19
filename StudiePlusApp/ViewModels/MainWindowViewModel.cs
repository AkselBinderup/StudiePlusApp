using Avalonia.Controls;
using ReactiveUI;
using StudiePlusApp.Models;
using StudiePlusApp.Models.Interfaces;
using StudiePlusApp.Views;
using System;

namespace StudiePlusApp.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {

        private ViewModelBase _contentViewModel;

        public ViewModelBase ContentViewModel
        {
            get => _contentViewModel;
            private set => this.RaiseAndSetIfChanged(ref _contentViewModel, value);
        }
        public void SetViewModel(ViewModelBase model)
        {
            ContentViewModel = model;
        }
        public static MainWindowViewModel? Instance { get; private set; }
        public MainWindowViewModel(INavigationService navigationService)
        {
            if (Instance == null) Instance = this;
            SetViewModel(new HomePageViewModel(navigationService)); 
        }
        public UserControl SelectedView { get; set; }
        private void UpdateView(UserControl ctrl)
        {
            if (SelectedView != ctrl)
            {
                SelectedView = ctrl;
            }
        }
    }
}
