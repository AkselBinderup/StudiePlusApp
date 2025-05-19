using StudiePlusApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudiePlusApp.ViewModels;
    public class ScheduleViewModel
    {
        public ObservableCollection<ScheduleEntry> Entries { get; }

        public ScheduleViewModel()
        {
            Entries = new ObservableCollection<ScheduleEntry>
            {
                new() { Subject = "Matematik, D", ClassCode = "ID2001AGBa2", Room = "i3f", StartTime = new(8, 0, 0), EndTime = new(8, 45, 0), Color = "#D8EFD3" },
                new() { Subject = "Matematik, D", ClassCode = "ID2001AGBa2", Room = "i3f", StartTime = new(8, 45, 0), EndTime = new(9, 30, 0), Color = "#C9E2FF" },
                new() { Subject = "Matematik, D", ClassCode = "ID2001AGBa2", Room = "i3f", StartTime = new(9, 45, 0), EndTime = new(10, 30, 0), Color = "#C9E2FF" },
            };
        }
}
