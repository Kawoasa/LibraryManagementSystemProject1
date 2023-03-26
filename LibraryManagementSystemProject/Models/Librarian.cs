using System;
using System.Collections.Generic;

namespace LibraryManagementSystemProject.Models;

public partial class Librarian
{
    public int LibId { get; set; }

    public string LibName { get; set; } = null!;

    public string LibPassword { get; set; } = null!;

    public string LibPhone { get; set; } = null!;

    public Librarian(int libId, string libName, string libPassword, string libPhone)
    {
        LibId = libId;
        LibName = libName;
        LibPassword = libPassword;
        LibPhone = libPhone;
    }
}
