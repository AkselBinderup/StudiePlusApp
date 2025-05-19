using Avalonia.Controls;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;
using StudiePlusApp.Models.Interfaces;
using StudiePlusApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudiePlusApp.Models;

public class NavigationService : INavigationService
{
    private readonly IServiceProvider _provider;

    public NavigationService(IServiceProvider provider)
    {
        _provider = provider;
    }

    public UserControl NavigateTo<T>() where T : UserControl
    {
        return _provider.GetRequiredService<T>();
    }

    public void NavigateToViewModel<T>() where T : ViewModelBase
    {
        var vm = _provider.GetRequiredService<T>();
        MainWindowViewModel.Instance?.SetViewModel(vm);
    }
}