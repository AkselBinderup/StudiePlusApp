using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using StudiePlusApp.ViewModels;

namespace StudiePlusApp.Views;

public partial class ScheduleView : UserControl
{
    public ScheduleView()
    {
        InitializeComponent();
        if (Design.IsDesignMode)
        {
            DataContext = new ScheduleViewModel();  
        }
        else
        {
            DataContext = App.GetService<ScheduleViewModel>();
        }
    }
}