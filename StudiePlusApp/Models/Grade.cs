using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudiePlusApp.Models;
public class Grade
{
    public string CourseName { get; set; }
    public double Score { get; set; }
    public string LetterGrade => Score >= 90 ? "A" : (Score >= 80 ? "B" : (Score >= 70 ? "C" : "D"));
}
