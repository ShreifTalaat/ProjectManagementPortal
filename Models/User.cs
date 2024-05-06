using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Role { get; set; }

    public virtual ICollection<Project> ProjectManagers { get; set; } = new List<Project>();

    public virtual ICollection<Project> ProjectOwners { get; set; } = new List<Project>();
}
