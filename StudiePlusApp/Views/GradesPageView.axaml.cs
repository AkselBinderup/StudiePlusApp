using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using StudiePlusApp.ViewModels;

namespace StudiePlusApp.Views;

public partial class GradesPageView : UserControl
{
    public GradesPageView()
    {
        InitializeComponent();
        if (Design.IsDesignMode)
        {
            DataContext = new GradesPageViewModel();
        }
        else
        {
            DataContext = App.GetService<GradesPageViewModel>();
        }
    }
}