using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Task
{
    public int TaskId { get; set; }

    public int? ProjectId { get; set; }

    public string? Description { get; set; }

    public bool? IsComplete { get; set; }

    public DateTime? DueDate { get; set; }

    public virtual Project? Project { get; set; }
}
