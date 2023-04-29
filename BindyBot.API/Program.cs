var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
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

app.Run();