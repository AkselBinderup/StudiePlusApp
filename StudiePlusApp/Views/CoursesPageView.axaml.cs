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

        if (Design.IsDesignMode)
        {
            DataContext = new CoursesPageViewModel();
        }
        else
        {
            DataContext = App.GetService<CoursesPageViewModel>();
        }
     
    }
}