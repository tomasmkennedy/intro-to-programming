using Bff.Api.Todos;
using Microsoft.EntityFrameworkCore;

namespace Bff.Api.Data;

public class TodosDataContext : DbContext
{
    public TodosDataContext(DbContextOptions<TodosDataContext> options) : base(options) { }

    public DbSet<TodoEntity> Todos { get; set; }
}


public class TodoEntity
{
    public Guid Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTimeOffset? DueDate { get; set; }
    public TodoPriority? Priority { get; set; }
    public DateTimeOffset? CreatedDate { get; set; }
}