using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Entities;

using Task = TaskManager.Domain.Entities.Task;

namespace TaskManager.Infrastructure.Data;

public class TaskManagerDbContext(DbContextOptions<TaskManagerDbContext> options)
    : DbContext(options)
{
    public DbSet<Status> Statuses { get; set; }

    public DbSet<Task> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TaskManagerDbContext).Assembly);
    }
}
