using ReactiveUI;
using StudiePlusApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace StudiePlusApp.ViewModels;
public class MessagesPageViewModel : ViewModelBase
{
    private string _newMessage;
    public string NewMessage
    {
        get => _newMessage;
        set => this.RaiseAndSetIfChanged(ref _newMessage, value);
    }

    public ObservableCollection<string> Messages { get; } = new();
    public ReactiveCommand<Unit, Unit> AddMessageCommand { get; }

    public MessagesPageViewModel()
    {
        AddMessageCommand = ReactiveCommand.Create(AddMessage);
    }

    private void AddMessage()
    {
        if (!string.IsNullOrWhiteSpace(NewMessage))
        {
            Messages.Add($"{DateTime.Now:t}: {NewMessage}");
            NewMessage = string.Empty;
        }
    }
}