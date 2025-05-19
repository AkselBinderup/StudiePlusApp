using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using StudiePlusApp.ViewModels;

namespace StudiePlusApp.Views;

public partial class HomePageView : UserControl
{
    public HomePageView()
    {
        InitializeComponent();
        DataContext = App.GetService<HomePageViewModel>();
    }
}