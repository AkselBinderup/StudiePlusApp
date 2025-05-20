using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using StudiePlusApp.ViewModels;

namespace StudiePlusApp.Views;

public partial class AbsenceCausePageView : UserControl
{
    public AbsenceCausePageView()
    {
        InitializeComponent();
        DataContext = App.GetService<AbsenceCausePageViewModel>();
    }
}