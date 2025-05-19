using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using StudiePlusApp.ViewModels;

namespace StudiePlusApp;

public partial class HomeWorkView : UserControl
{
    public HomeWorkView()
    {
        InitializeComponent();
        if (Design.IsDesignMode)
        {
            DataContext = new HomeWorkViewModel();
        }
        else
        {
            DataContext = App.GetService<HomeWorkViewModel>();
        }
    }
}