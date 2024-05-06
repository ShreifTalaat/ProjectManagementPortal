using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

public partial class ProjectManagementDbContext : DbContext
{
    public ProjectManagementDbContext()
    {
    }

    public ProjectManagementDbContext(DbContextOptions<ProjectManagementDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder. UseSqlServer("Server=db4704.public.databaseasp.net; Database=db4704; User Id=db4704; Password=j-4B7H#pb!6C; Encrypt=False; MultipleActiveResultSets=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.ProjectId).HasName("PK__Projects__761ABEF0943FCB86");

            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.StartDate).HasColumnType("datetime");

            entity.HasOne(d => d.Manager).WithMany(p => p.ProjectManagers)
                .HasForeignKey(d => d.ManagerId)
                .HasConstraintName("FK__Projects__Manage__3E52440B");

            entity.HasOne(d => d.Owner).WithMany(p => p.ProjectOwners)
                .HasForeignKey(d => d.OwnerId)
                .HasConstraintName("FK__Projects__OwnerI__3D5E1FD2");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.TaskId).HasName("PK__Tasks__7C6949B19BB191E9");

            entity.Property(e => e.DueDate).HasColumnType("datetime");

            entity.HasOne(d => d.Project).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK__Tasks__ProjectId__412EB0B6");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4CCA10B8B2");

            entity.HasIndex(e => e.Username, "UQ__Users__536C85E4E7865BDE").IsUnique();

            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.Role).HasMaxLength(50);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
