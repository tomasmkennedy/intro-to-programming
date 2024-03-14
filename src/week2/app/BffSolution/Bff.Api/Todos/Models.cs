using System.ComponentModel.DataAnnotations;

namespace Bff.Api.Todos;


/* {
    "description": "Buy Beer",
    "dueDate": "ISO8601 Date String",
    "priority": "High" | "Low" | undefined
} */

public record CreateTodoRequest
{
    [Required, MinLength(3), MaxLength(124)]
    public string Description { get; set; } = string.Empty;
    public DateTimeOffset? DueDate { get; set; }
    public TodoPriority? Priority { get; set; }


}

public enum TodoPriority { Low, High };


/*{
    "id": "38938938",
    "dueDate": "893893",
    "description": "Buy Beer",
    "priority": "Low"
} */

public record CreateTodoResponse
{
    public Guid Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTimeOffset? DueDate { get; set; }
    public TodoPriority? Priority { get; set; }
}