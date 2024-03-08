using Marten;
using Microsoft.AspNetCore.Mvc;
using TodosApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IFormatDisplayInformation, AdvancedFormatters>();

var connectionString = builder.Configuration.GetConnectionString("todos") ??
    throw new Exception("Can't start, need a connection string");

builder.Services.AddMarten(options =>
{
    options.Connection(connectionString);
}).UseLightweightSessions();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// GET /status
app.MapGet("/status", ([FromServices] IFormatDisplayInformation utils) =>
{
    var response = new StatusResponse
    {
        CheckedAt = DateTimeOffset.Now,
        MessageProcessingHandler = "Looks Good",
        SupportTech = utils.FormatName("Bob", "Smith")
    };
    return Results.Ok(response);
});

app.MapPost("/todos", async ([FromBody] TodoCreateRequest request,
    [FromServices] IDocumentSession session) =>
{
    var response = new TodoCreateResponse
    {
        Id = Guid.NewGuid(),
        Description = request.Description,
        Status = TodoStatus.Incomplete
    };
    session.Store(response);
    await session.SaveChangesAsync(); // this actually writes it
    return Results.Ok(response);
});

app.MapGet("/todos", async ([FromServices] IDocumentSession session) =>
{
    var todoList = await session.Query<TodoCreateResponse>().ToListAsync();
    return Results.Ok(todoList);
});

app.Run();

public partial class Program { }