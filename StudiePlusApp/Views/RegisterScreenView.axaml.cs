using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using StudiePlusApp.ViewModels;

namespace StudiePlusApp;

public partial class RegisterScreenView : UserControl
{
    public RegisterScreenView()
    {
        InitializeComponent();
        if (Design.IsDesignMode)
        {
            DataContext = new RegisterScreenViewModel();
        }
        else
        {
            DataContext = App.GetService<RegisterScreenViewModel>();
        }
    }
}