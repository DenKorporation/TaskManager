using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaskManager.Infrastructure.Data.Configurations;

public class TasksConfiguration : IEntityTypeConfiguration<TaskManager.Domain.Entities.Task>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Task> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasQueryFilter(x => x.Deleted);

        builder.Property(x => x.Title)
            .HasMaxLength(100);

        builder.Property(x => x.Description)
            .HasMaxLength(255);

        builder.ToTable(t =>
            t.HasCheckConstraint("CK_MyEntity_Value", "\"Readiness\" <= 100"));

        builder.HasOne(x => x.Status)
            .WithMany(x => x.Tasks)
            .HasForeignKey(x => x.StatusId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.Parent)
            .WithMany(x => x.Children)
            .HasForeignKey(x => x.ParentId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
