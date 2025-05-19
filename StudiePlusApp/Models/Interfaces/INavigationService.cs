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
    UserControl NavigateTo<T>() where T : UserControl;
    void NavigateToViewModel<T>() where T : ViewModelBase;
}