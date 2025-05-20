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
    public ObservableCollection<GradeModel> Grades { get; } = new();

    public string AverageGrade => BeregnGennemsnit();

    public GradesPageViewModel()
    {
        // Midlertidige testdata
        Grades.Add(new GradeModel { Subject = "Dansk", Grade = 12, Teacher = "Hr. Mortensen" });
        Grades.Add(new GradeModel { Subject = "Engelsk", Grade = 10, Teacher = "Frk. Jensen" });
        Grades.Add(new GradeModel { Subject = "Matematik", Grade = 7, Teacher = "Hr. Holm" });
        Grades.Add(new GradeModel { Subject = "Samfundsfag", Grade = 12, Teacher = "Frk. Rahbek" });
        Grades.Add(new GradeModel { Subject = "Biologi", Grade = 4, Teacher = "Hr. Nyborg" });

        this.WhenAnyValue(x => x.Grades.Count)
            .Subscribe(_ => this.RaisePropertyChanged(nameof(AverageGrade)));
    }

    private string BeregnGennemsnit()
    {
        if (Grades.Count == 0) return "-";
        var gennemsnit = Grades.Average(g => g.Grade);
        return gennemsnit.ToString("0.0");
    }
}
