using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudiePlusApp.ViewModels;
public class HomeWorkViewModel : ViewModelBase
{
    public ObservableCollection<HomeworkModel> Homeworks { get; } = new();

    public HomeWorkViewModel()
    {
        // Testdata – kan hentes fra en database senere
        Homeworks.Add(new HomeworkModel
        {
            Title = "Læs kapitel 4 i 'Et Dukkehjem'",
            Description = "Forbered analyse og noter til diskussion i timen.",
            DueDate = DateTime.Today.AddDays(1),
            Subject = "Dansk",
            IsCompleted = false
        });

        Homeworks.Add(new HomeworkModel
        {
            Title = "Aflever opgave 5",
            Description = "Opgave om sandsynlighedsregning. Upload som PDF.",
            DueDate = DateTime.Today.AddDays(3),
            Subject = "Matematik",
            IsCompleted = false
        });

        Homeworks.Add(new HomeworkModel
        {
            Title = "Essay om kolonialisme",
            Description = "Minimum 500 ord. Afleveres på Aula.",
            DueDate = DateTime.Today.AddDays(-1),
            Subject = "Historie",
            IsCompleted = true
        });
    }
}
public class HomeworkModel
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public string Subject { get; set; }
    public bool IsCompleted { get; set; }

    public string Status => IsCompleted ? "Afleveret" : (DueDate < DateTime.Today ? "For sent!" : "Afventer");

    public IBrush StatusColor =>
        IsCompleted ? Brushes.Green :
        (DueDate < DateTime.Today ? Brushes.Red : Brushes.Orange);
}