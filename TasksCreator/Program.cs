using Microsoft.EntityFrameworkCore;
using TasksCreator.Data;
using TasksCreator.Repositories;
using TasksCreator.Services;

var builder = WebApplication.CreateBuilder(args);

// Configuration
var configuration = builder.Configuration;
var useMySQL = configuration.GetValue<bool>("UseMySQL");

if (useMySQL)
{
    var connectionString = configuration.GetConnectionString("DefaultConnection");
    var serverVersion = new MySqlServerVersion(new Version(8, 0, 32)); // Change this to match your MySQL version

    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseMySql(connectionString, serverVersion));

    builder.Services.AddScoped<ITaskRepository, TaskRepository>();
}
else
{
    builder.Services.AddSingleton<ITaskRepository, MockTaskRepository>();
}

builder.Services.AddScoped<TaskService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
