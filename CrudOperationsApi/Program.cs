using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using CrudOperationsApi.Services;
using CrudOperationsApi.Models;
using CrudOperationsApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Register the DatabaseService with Dependency Injection (Singleton)
builder.Services.AddSingleton<DatabaseService>(provider =>
    new DatabaseService(builder.Configuration.GetConnectionString("DefaultConnection")));

// Swagger/OpenAPI configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Enable authorization middleware if needed for security (this can be skipped if not required)
app.UseAuthorization();

// Map controllers (like PersonController)
app.MapControllers();

app.Run();
