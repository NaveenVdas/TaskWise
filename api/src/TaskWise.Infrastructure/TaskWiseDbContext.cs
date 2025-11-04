using Microsoft.EntityFrameworkCore;
using TaskWise.Domain.DomainModels;

namespace TaskWise.Infrastructure;

public class TaskWiseDbContext : DbContext
{
    public TaskWiseDbContext(DbContextOptions<TaskWiseDbContext> options) : base(options)
    {
    }

    public virtual DbSet<Role> Roles { get; set; }
    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TaskWiseDbContext).Assembly);

        modelBuilder.Entity<Role>().HasQueryFilter(r => !r.Deleted);

        base.OnModelCreating(modelBuilder);
    }
}
