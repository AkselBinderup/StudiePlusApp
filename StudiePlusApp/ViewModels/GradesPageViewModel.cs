using ReactiveUI;
using StudiePlusApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudiePlusApp.ViewModels;

public class GradesPageViewModel : ViewModelBase
{
    public ObservableCollection<GradeItem> Grades { get; }

    public GradesPageViewModel()
    {
        Grades = new ObservableCollection<GradeItem>
        {
            new GradeItem("Matematik", "12"),
            new GradeItem("Engelsk", "10"),
            new GradeItem("Fysik", "7"),
            new GradeItem("Biologi", "10"),
            new GradeItem("Historie", "12")
        };
    }
}
public class GradeItem
{
    public string Subject { get; }
    public string Grade { get; }

    public GradeItem(string subject, string grade)
    {
        Subject = subject;
        Grade = grade;
    }
}
