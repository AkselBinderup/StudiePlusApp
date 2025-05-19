using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using StudiePlusApp.ViewModels;

namespace StudiePlusApp.Views;

public partial class FunctionLineView : UserControl
{
    public FunctionLineView()
    {
        InitializeComponent();
        if (Design.IsDesignMode)
        {
            DataContext = new FunctionLineViewModel();
        }
        else
        {
            DataContext = App.GetService<FunctionLineViewModel>();
        }
    }
}