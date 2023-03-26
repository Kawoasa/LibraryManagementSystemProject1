using System;
using System.Collections.Generic;

namespace LibraryManagementSystemProject.Models;

public partial class StudetnSemester
{
    public int StdSemesterId { get; set; }

    public string StdSemesterName { get; set; } = null!;

    public virtual ICollection<Student> Students { get; } = new List<Student>();
}
