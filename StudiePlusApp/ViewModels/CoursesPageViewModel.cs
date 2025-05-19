using StudiePlusApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudiePlusApp.ViewModels;

public class CoursesPageViewModel : ViewModelBase
{
    public List<Course> Courses { get; set; }

    public CoursesPageViewModel()
    {
        Courses = new List<Course>
        {
            new Course { Name = "Matematik", Code = "N214", Instructor = "Christian Suhr Bech" },
            new Course { Name = "Engelsk", Code = "N225", Instructor = "Julie Fredborg Jungersen" }
        };
    }
}
