using LibrarySystemAPI.Application.Extensions;
using LibrarySystemAPI.Data.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDataServices();
builder.Services.AddApplicationServices();

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/", () => Results.Ok(new
{
    message = "Welcome to Library System API",
    version = "1.0.0",
    documentation = "/swagger",
    endpoints = new[] {
        "/api/auth/login",
        "/api/auth/signup",
        "/api/books",
        "/api/members",
        "/api/borrowing/borrow",
        "/api/borrowing/return"
    }
}));

app.Run();
