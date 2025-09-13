namespace TaskManager.Domain.Common;

public interface IAuditableEntity
{
    public DateTimeOffset Created { get; set; }

    public DateTimeOffset Updated { get; set; }
}
