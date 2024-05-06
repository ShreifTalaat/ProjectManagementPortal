using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Project
{
    public int ProjectId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? OwnerId { get; set; }

    public int? ManagerId { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public virtual User? Manager { get; set; }

    public virtual User? Owner { get; set; }

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
