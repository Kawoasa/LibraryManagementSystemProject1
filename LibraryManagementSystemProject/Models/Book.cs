using System;
using System.Collections.Generic;

namespace LibraryManagementSystemProject.Models;

public partial class Book
{
    public int BookId { get; set; }

    public string BookName { get; set; } = null!;

    public string Author { get; set; } = null!;

    public string Publisher { get; set; } = null!;

    public int Price { get; set; }

    public int Quantity { get; set; }

    public virtual ICollection<BooksIssue> BooksIssues { get; } = new List<BooksIssue>();
}
