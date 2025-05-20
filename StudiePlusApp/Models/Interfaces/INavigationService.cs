using Avalonia.Controls;
using StudiePlusApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudiePlusApp.Models.Interfaces;

public interface INavigationService
{
    object CurrentView { get; }
    IObservable<object> CurrentViewObservable { get; }
    void NavigateTo<T>() where T : UserControl;
}