using System;
using System.Collections.Generic;

namespace LibraryManagementSystemProject.Models;

public partial class Student
{
    public int StdId { get; set; }

    public string StdName { get; set; } = null!;

    public int StdDeparment { get; set; }

    public int StdSemester { get; set; }

    public string StdPhone { get; set; } = null!;

    public virtual ICollection<BooksIssue> BooksIssues { get; } = new List<BooksIssue>();

    public virtual ICollection<ReturnBook> ReturnBooks { get; } = new List<ReturnBook>();

    public virtual StudentDepartment StdDeparmentNavigation { get; set; } = null!;

    public virtual StudetnSemester StdSemesterNavigation { get; set; } = null!;
}
