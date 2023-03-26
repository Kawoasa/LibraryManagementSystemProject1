using System;
using System.Collections.Generic;

namespace LibraryManagementSystemProject.Models;

public partial class StudentDepartment
{
    public int StdDepartmentId { get; set; }

    public string StdDepartmentName { get; set; } = null!;

    public virtual ICollection<Student> Students { get; } = new List<Student>();
}
