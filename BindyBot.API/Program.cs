﻿using BindyBot.API.Data;
using BindyBot.API.Modules.Authentication;
using BindyBot.API.Modules.Swagger;
using BindyBot.API.Repositories;
using Microsoft.EntityFrameworkCore;

#region Builder
var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();

// Add services to the container.
builder.Services.AddCors();
builder.Services.AddSwaggerModule(true);

var host = builder.Configuration["DB_HOST"];
var database = builder.Configuration["DB_NAME"];
var username = builder.Configuration["DB_USER"];
var password = builder.Configuration["DB_PASS"];
var connectionString = $"Host={host};Database={database};Username={username};Password={password}";
builder.Services.AddDbContext<BindyBotApiDbContext>(options =>
        options.UseNpgsql(connectionString));

var issuer = builder.Configuration["JWT_ISSUER"];
var audience = builder.Configuration["JWT_AUDIENCE"];
var key = builder.Configuration["JWT_ACCESS_TOKEN_SECRET"];
builder.Services.AddJwtAuthModule<UserRepository, RevokedTokenRepository>(issuer, audience, key);
#endregion

#region App
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerModule();

    using var scope = app.Services.CreateScope();
    var apiContext = scope.ServiceProvider.GetRequiredService<BindyBotApiDbContext>();
    apiContext.Database.EnsureDeleted();
    apiContext.Database.EnsureCreated();
}

app.UseHttpsRedirection();

// Configure CORS for React app
app.UseCors(builder => builder
    .WithOrigins("http://localhost:3000")
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseJwtAuthModule();

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
#endregion