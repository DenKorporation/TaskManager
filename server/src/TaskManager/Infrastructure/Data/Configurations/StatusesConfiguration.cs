using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Domain.Entities;

namespace TaskManager.Infrastructure.Data.Configurations;

public class StatusesConfiguration : IEntityTypeConfiguration<Status>
{
    public void Configure(EntityTypeBuilder<Status> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
            .HasMaxLength(100);

        builder.HasIndex(x => x.Title)
            .IsUnique();

        builder.Property(x => x.Description)
            .HasMaxLength(255);

        builder.Property(x => x.Color)
            .HasMaxLength(7);

        builder.ToTable(x => x.HasCheckConstraint("CK_Status_Color_Format", "\"Color\" ~* '^#[a-f0-9]{6}$'"));
    }
}
