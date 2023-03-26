using System;
using System.Collections.Generic;

namespace LibraryManagementSystemProject.Models;

public partial class BooksIssue
{
    public int IssuNumber { get; set; }

    public int StdId { get; set; }

    public string StdName { get; set; } = null!;

    public string StdDeparment { get; set; } = null!;

    public string StdPhone { get; set; } = null!;

    public int BookIssued { get; set; }

    public DateTime IssueDate { get; set; }

    public virtual Book BookIssuedNavigation { get; set; } = null!;

    public virtual Student Std { get; set; } = null!;
}
