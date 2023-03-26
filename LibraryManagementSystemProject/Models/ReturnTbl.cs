using System;
using System.Collections.Generic;

namespace LibraryManagementSystemProject.Models;

public partial class ReturnTbl
{
    public int RetNum { get; set; }

    public int StdId { get; set; }

    public string StdName { get; set; } = null!;

    public string StdDept { get; set; } = null!;

    public string Stdphone { get; set; } = null!;

    public int Bookreturned { get; set; }

    public DateTime IssueDate { get; set; }

    public DateTime ReturnDate { get; set; }
}
