using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Minimal_API;
using Minimal_API.Models;
using System.Threading.Tasks;
using Task = Minimal_API.Models.Task;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<TasksContext> (p => p.UseInMemoryDatabase("TasksDB"));
builder.Services.AddSqlServer<TasksContext>(builder.Configuration.GetConnectionString("connectTasks"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/db", async ([FromServices] TasksContext dbContext) =>
    {
        dbContext.Database.EnsureCreated();
        return Results.Ok("base de datos en memoria: " + dbContext.Database.IsInMemory());
    });


app.MapGet("/api/tasks", async ([FromServices] TasksContext dbContext) =>
{
    return Results.Ok(dbContext.Tasks);
});

app.MapPost("/api/tasks", async ([FromServices] TasksContext dbContext, [FromBody] Task task) =>
{
    task.TaskId = Guid.NewGuid();
    task.DateTimeCreated = DateTime.UtcNow;
    await dbContext.AddAsync(task);
    await dbContext.SaveChangesAsync();
    return Results.Ok();
});

app.MapPut("/api/tasks/{id}", async ([FromServices] TasksContext dbContext, [FromBody] Task task, [FromRoute] Guid id) =>
{
    var currentTask = dbContext.Tasks.Find(id);
    if (currentTask != null)
    {
        currentTask.Title = task.Title;
        currentTask.Description = task.Description;
        currentTask.Points = task.Points;
        currentTask.Stars = task.Stars;

        await dbContext.SaveChangesAsync();
        return Results.Ok();
    }

   
    return Results.NotFound();
});

app.MapDelete("/api/tasks/{id}", async ([FromServices] TasksContext dbContext, [FromRoute] Guid id) =>
{
    var currentTask = dbContext.Tasks.Find(id);

    if (currentTask == null)
    {
        return Results.NotFound("Task not found.");
    }

    dbContext.Remove<Minimal_API.Models.Task>(currentTask);
    await dbContext.SaveChangesAsync();

    return Results.Ok("Removed!");
});

app.Run();
