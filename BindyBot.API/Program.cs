using BindyBot.API.Data;
using BindyBot.API.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddDbContext<BindyBotApiContext>(options =>
        options.UseNpgsql($"Host={Environment.GetEnvironmentVariable("DB_HOST")};Database={Environment.GetEnvironmentVariable("DB_NAME")};Username={Environment.GetEnvironmentVariable("DB_USER")};Password={Environment.GetEnvironmentVariable("DB_PASS")}"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    // DB test
    using var scope = app.Services.CreateScope();
    var apiContext = scope.ServiceProvider.GetRequiredService<BindyBotApiContext>();
    apiContext.Database.EnsureCreated();
    if (!apiContext.Users.Any())
    {
        apiContext.Add(new User("admin", "passwordHash", UserRole.Admin));
        apiContext.SaveChanges();
    }
}

app.UseHttpsRedirection();

// Enable CORS for React app
app.UseCors(builder => builder
    .WithOrigins("http://localhost:3000")
    .AllowAnyMethod()
    .AllowAnyHeader());

app.MapGet("/api/test", () =>
{
    return "Hello, I'm Binty!";
})
.WithName("HelloWorld")
.WithOpenApi();

app.MapPost("/api/test", (string name) =>
{
    return $"Hello, I'm {name}!";
})
.WithName("HelloWorldWithCustomName")
.WithOpenApi();

app.MapPost("/api/users", (BindyBotApiContext apiContext) =>
{
    return Results.Ok(apiContext.Users);
})
.WithName("Users")
.WithOpenApi();

app.Run();