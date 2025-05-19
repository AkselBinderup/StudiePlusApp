using Avalonia.Controls;
using StudiePlusApp.ViewModels;

namespace StudiePlusApp.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Width = 393;
            Height = 600;
            DataContext = App.GetService<MainWindowViewModel>();
        }
    }
}