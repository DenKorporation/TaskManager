namespace TaskManager.Domain.Common;

public interface ISoftDeletable
{
    public bool Deleted { get; set; }
}
