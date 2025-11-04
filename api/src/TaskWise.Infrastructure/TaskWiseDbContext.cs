using Microsoft.EntityFrameworkCore;

namespace TaskWise.Infrastructure;

public class TaskWiseDbContext : DbContext
{
    public TaskWiseDbContext(DbContextOptions<TaskWiseDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TaskWiseDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
