using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Minimal_API;

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
app.Run();
