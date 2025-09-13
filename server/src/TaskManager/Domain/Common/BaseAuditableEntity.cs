namespace TaskManager.Domain.Common;

public abstract class BaseAuditableEntity<TKey> : BaseEntity<TKey>, IAuditableEntity
{
    public DateTimeOffset Created { get; set; }

    public DateTimeOffset Updated { get; set; }
}
