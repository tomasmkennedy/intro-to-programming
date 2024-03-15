using Microsoft.EntityFrameworkCore;

namespace Bff.Api.Data;

public class TodosDataContext : DbContext
{
    public TodosDataContext(DbContextOptions<TodosDataContext> options) : base(options) { }

    public DbSet<TodoEntity> Todos { get; set; }
}