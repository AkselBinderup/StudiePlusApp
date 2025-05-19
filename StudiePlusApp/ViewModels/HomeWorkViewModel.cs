using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudiePlusApp.ViewModels;
public class HomeWorkViewModel : ViewModelBase
{
    public ObservableCollection<HomeworkItem> HomeworkItems { get; }

    public HomeWorkViewModel()
    {
        HomeworkItems = new ObservableCollection<HomeworkItem>
        {
            new HomeworkItem("Matematik", "Klar opgave 431-435", DateTime.Now.AddDays(1)),
            new HomeworkItem("Engelsk", "Skriv en bograpport om bogen 'Romeo and Juliet'", DateTime.Now.AddDays(3)),
            new HomeworkItem("Fysik", "Lav opgave 5.3.1 i Orbit B", DateTime.Now.AddDays(2))
        };
    }
}
public class HomeworkItem
{
    public string Subject { get; }
    public string Description { get; }
    public DateTime DueDate { get; }

    public HomeworkItem(string subject, string description, DateTime dueDate)
    {
        Subject = subject;
        Description = description;
        DueDate = dueDate;
    }
}
