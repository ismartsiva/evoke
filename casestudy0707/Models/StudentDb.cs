using System;
using System.Collections.Generic;

namespace casestudy0707.Models;

public partial class StudentDb
{
    public int Rno { get; set; }

    public string? Name { get; set; }

    public string? Grade { get; set; }

    public string? Section { get; set; }

    public string? ScienceMark { get; set; }

    public string? MathsMark { get; set; }

    public string? Total { get; set; }
}
