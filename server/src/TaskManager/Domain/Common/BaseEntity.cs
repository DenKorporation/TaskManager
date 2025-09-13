namespace TaskManager.Domain.Common;

public abstract class BaseEntity<TKey>
{
    /// <summary>
    /// Primary Key
    /// </summary>
    public TKey? Id { get; set; }
}
