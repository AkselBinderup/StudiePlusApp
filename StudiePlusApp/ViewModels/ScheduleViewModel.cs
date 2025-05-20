using Avalonia.Media;
using StudiePlusApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudiePlusApp.ViewModels;
public class ScheduleViewModel : ViewModelBase
{
    public string DayTitle => "Torsdag d. 22. Maj";

    public ObservableCollection<ScheduleBlock> DaySchedule { get; } = new();

    public ScheduleViewModel()
    {
        DaySchedule.Add(new ScheduleBlock("Matematik", 8, 9, Colors.SkyBlue));
        DaySchedule.Add(new ScheduleBlock("Engelsk", 9, 10, Colors.LightGreen));
        DaySchedule.Add(new ScheduleBlock("Fysik", 11, 12, Colors.Orange));
        DaySchedule.Add(new ScheduleBlock("Historie", 13, 14, Colors.MediumPurple));
    }
}

public class ScheduleBlock
{
    public string CourseTitle { get; }
    public int StartHour { get; }
    public int EndHour { get; }
    public SolidColorBrush Color { get; }

    public string TimeRange => $"{StartHour:00}:00 - {EndHour:00}:00";

    public ScheduleBlock(string courseTitle, int startHour, int endHour, Color color)
    {
        CourseTitle = courseTitle;
        StartHour = startHour;
        EndHour = endHour;
        Color = new SolidColorBrush(color);
    }
}