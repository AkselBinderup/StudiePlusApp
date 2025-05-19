using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudiePlusApp.Models;
public class ScheduleEntry
{
    public string Subject { get; set; }
    public string ClassCode { get; set; }
    public string Room { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public string Color { get; set; } 
}