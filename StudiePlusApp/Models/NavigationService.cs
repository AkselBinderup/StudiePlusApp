using Avalonia.Controls;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;
using StudiePlusApp.Models.Interfaces;
using StudiePlusApp.ViewModels;
using StudiePlusApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace StudiePlusApp.Models;
public class NavigationService : INavigationService
{
    private readonly IServiceProvider _provider;

    // Make it observable
    private readonly BehaviorSubject<object> _currentView = new(null);
    public IObservable<object> CurrentViewObservable => _currentView;

    public object CurrentView => _currentView.Value;

    public NavigationService(IServiceProvider provider)
    {
        _provider = provider;
    }

    public void NavigateTo<T>() where T : UserControl
    {
        var view = _provider.GetRequiredService<T>();
        _currentView.OnNext(view);
    }
}