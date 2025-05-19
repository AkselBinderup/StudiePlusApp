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
public class AbsenceCausePageViewModel : ViewModelBase
{
    public ObservableCollection<string> AbsenceTypes { get; } = new()
    {
        "Syg",
        "Familie",
        "Læge",
        "Personlig årsag",
        "Andet"
    };

    private string _selectedAbsenceType;
    public string SelectedAbsenceType
    {
        get => _selectedAbsenceType;
        set => this.RaiseAndSetIfChanged(ref _selectedAbsenceType, value);
    }

    private string _description;
    public string Description
    {
        get => _description;
        set => this.RaiseAndSetIfChanged(ref _description, value);
    }

    private string _statusMessage;
    public string StatusMessage
    {
        get => _statusMessage;
        set => this.RaiseAndSetIfChanged(ref _statusMessage, value);
    }

    public ReactiveCommand<Unit, Unit> SubmitCommand { get; }

    public AbsenceCausePageViewModel()
    {
        SubmitCommand = ReactiveCommand.Create(SubmitAbsence, 
            this.WhenAnyValue(x => x.SelectedAbsenceType, x => !string.IsNullOrWhiteSpace(x)));

        StatusMessage = "";
    }

    private void SubmitAbsence()
    {
        StatusMessage = $"Fravær '{SelectedAbsenceType}' angivet: {DateTime.Now:HH:mm}.";
        Description = "";
        SelectedAbsenceType = null;
    }
}