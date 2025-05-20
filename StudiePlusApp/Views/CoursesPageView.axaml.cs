using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using StudiePlusApp.ViewModels;

namespace StudiePlusApp.Views;

public partial class CoursesPageView : UserControl
{
    public CoursesPageView()
    {
        InitializeComponent();
        DataContext = App.GetService<CoursesPageViewModel>();
    }
}