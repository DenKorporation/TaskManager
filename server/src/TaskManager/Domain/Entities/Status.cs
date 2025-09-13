using TaskManager.Domain.Common;

namespace TaskManager.Domain.Entities;

public class Status : BaseEntity<int>
{
    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string Color { get; set; } = null!;

    public bool IsFinishStatus { get; set; }

    public IList<Task> Tasks { get; set; } = null!;
}
