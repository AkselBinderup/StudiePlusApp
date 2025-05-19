using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using StudiePlusApp.ViewModels;

namespace StudiePlusApp.Views;

public partial class MessagePageView : UserControl
{
    public MessagePageView()
    {
        InitializeComponent();
        if (Design.IsDesignMode)
        {
            DataContext = new MessagesPageViewModel();
        }
        else
        {
            DataContext = App.GetService<MessagesPageViewModel>();
        }
    }
}