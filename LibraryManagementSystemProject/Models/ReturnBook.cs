using System;
using System.Collections.Generic;

namespace LibraryManagementSystemProject.Models;

public partial class ReturnBook
{
    public int ReturnNum { get; set; }

    public int StdId { get; set; }

    public string StdName { get; set; } = null!;

    public string StdDepartment { get; set; } = null!;

    public string StdPhone { get; set; } = null!;

    public int Bookreturned { get; set; }

    public DateTime IssueDate { get; set; }

    public DateTime ReturnDate { get; set; }

    public virtual Student Std { get; set; } = null!;
}
