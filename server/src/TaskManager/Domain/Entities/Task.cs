using TaskManager.Domain.Common;

namespace TaskManager.Domain.Entities;

public class Task : BaseAuditableEntity<int>, ISoftDeletable
{
    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? Deadline { get; set; }

    public byte Readiness { get; set; }

    public bool Deleted { get; set; }

    public int StatusId { get; set; }

    public Status Status { get; set; } = null!;

    public int ParentId { get; set; }

    public Task Parent { get; set; } = null!;

    public IList<Task> Children { get; set; } = null!;
}
