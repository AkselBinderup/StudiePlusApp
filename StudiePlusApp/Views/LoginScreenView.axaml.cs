using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using StudiePlusApp.ViewModels;

namespace StudiePlusApp.Views;

public partial class LoginScreenView : UserControl
{
    public LoginScreenView()
    {
        InitializeComponent();
        DataContext = App.GetService<LoginScreenViewModel>();
    }
}