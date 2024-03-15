using Bff.Api.Todos;

namespace Bff.Api.Data;

public class TodoEntity
{
    public Guid Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTimeOffset? DueDate { get; set; }
    public TodoPriority? Priority { get; set; }
    public DateTimeOffset? CreatedDate { get; set; }

    public bool Completed { get; set; } = false;
}