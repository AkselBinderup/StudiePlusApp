using ReactiveUI;

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
        public MainWindowViewModel()
        {
            if (Instance == null) Instance = this;
            SetViewModel(new LoginScreenViewModel()); 
        }
    }
}
