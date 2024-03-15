using Bff.Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bff.Api.Todos;

[ApiController]
public class TodosController(TodosDataContext _context) : ControllerBase
{

    [HttpPost("/completed-todos")]
    public async Task<ActionResult> MarkTodoComplete([FromBody] CreateTodoResponse request)
    {

        // see if we have it, if not, return a bad request
        var todo = await _context.Todos.SingleOrDefaultAsync(x => x.Id == request.Id);
        if (todo is null)
        {
            return BadRequest("No Todo To Mark Complete");
        }
        todo.Completed = true;
        await _context.SaveChangesAsync();
        return NoContent();
        // if we do, mark it complete, save it, and then return ok
    }

    [HttpGet("/todos")]
    public async Task<ActionResult<GetTodoListResponse>> GetAllTodosAsync(CancellationToken token)
    {

        await Task.Delay(3000, token); // Don't do this.
        var list = await _context.Todos
            .OrderBy(t => t.CreatedDate)
            .Select(t => new CreateTodoResponse
            {
                Id = t.Id,
                Description = t.Description,
                DueDate = t.DueDate,
                Priority = t.Priority,
                Completed = t.Completed
            }).ToListAsync(token);
        var response = new GetTodoListResponse { List = list };
        return Ok(response);
    }

    [HttpPost("/todos")]
    public async Task<ActionResult<CreateTodoResponse>> AddATodoAsync([FromBody] CreateTodoRequest request)
    {

        await Task.Delay(3000); // Don't do this.
        // validate it - description is required, min length 3, maximum length 150
        //               dueDate >= Today's Date
        // If it's not valid, return a 400. 
        // if it is valid -
        // Write something to the database (we are stateless here)
        var todoToAdd = new TodoEntity
        {
            Description = request.Description,
            CreatedDate = DateTime.Now.ToUniversalTime(),
            DueDate = request.DueDate,
            Priority = request.Priority,
        };
        _context.Todos.Add(todoToAdd);
        await _context.SaveChangesAsync();
        // send them back 
        var response = new CreateTodoResponse
        {
            Id = todoToAdd.Id,
            Description = todoToAdd.Description,
            DueDate = todoToAdd.DueDate,
            Priority = todoToAdd.Priority
        };
        return Ok(response);
    }
}