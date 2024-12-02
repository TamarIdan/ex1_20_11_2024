using System;
using System.Collections.Generic;

namespace users.Models;

public partial class Change
{
    public int Id { get; set; }

    public string? Discription { get; set; }

    public DateOnly? Date { get; set; }
}
