using ReactiveUI;
using StudiePlusApp.Models;
using StudiePlusApp.Models.Interfaces;
using StudiePlusApp.Views;
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
    private readonly INavigationService _nav;

    public AbsenceCausePageViewModel(INavigationService nav)
    {
        _nav = nav;

        var canSubmit = this.WhenAnyValue(
            x => x.Reason,
            x => x.StartDate,
            x => x.EndDate,
            (r, s, e) =>
                !string.IsNullOrWhiteSpace(r) &&
                s != null && e != null &&
                e >= s);

        CanSubmit = canSubmit;

        SubmitCommand = ReactiveCommand.Create(Submit, canSubmit);
    }

    private string _reason;
    private string _notes;
    private DateTimeOffset? _startDate = DateTimeOffset.Now;
    private DateTimeOffset? _endDate = DateTimeOffset.Now;
    private string _error;

    public string Reason
    {
        get => _reason;
        set => this.RaiseAndSetIfChanged(ref _reason, value);
    }

    public string Notes
    {
        get => _notes;
        set => this.RaiseAndSetIfChanged(ref _notes, value);
    }

    public DateTimeOffset? StartDate
    {
        get => _startDate;
        set => this.RaiseAndSetIfChanged(ref _startDate, value);
    }

    public DateTimeOffset? EndDate
    {
        get => _endDate;
        set => this.RaiseAndSetIfChanged(ref _endDate, value);
    }

    public string Error
    {
        get => _error;
        set => this.RaiseAndSetIfChanged(ref _error, value);
    }

    public IObservable<bool> CanSubmit { get; }

    public ReactiveCommand<Unit, Unit> SubmitCommand { get; }

    private void Submit()
    {
        // Normally you'd send this to a server or save it
        if (StartDate > EndDate)
        {
            Error = "Slutdato skal være efter startdato.";
            return;
        }

        Error = string.Empty;

        Console.WriteLine($"Fravær indskrevet: {Reason} fra {StartDate} til {EndDate}.");
        _nav.NavigateTo<AbsenceCausePageView>();  
    }
}