using BindyBot.Api.Data;
using BindyBot.Api.Data.Contracts;
using BindyBot.Api.Enums;
using BindyBot.Api.Services;
using BindyBot.Api.Services.Contracts;
using BindyBot.TwitchApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IHashService, HashService>();
builder.Services.AddSingleton<TwitchAuthService>();
builder.Services.AddSingleton<ITokenService, TokenService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRevokedTokenRepository, RevokedTokenRepository>();
builder.Services.AddScoped<ITwitchUserCredentialsRepository, TwitchUserCredentialsRepository>();
builder.Services.AddHttpClient();
builder.Services.AddControllers();

// Database
var connectionString = GetConnectionString(builder.Configuration);
builder.Services.AddDbContext<BindyBotApiDbContext>(options =>
    options.UseNpgsql(connectionString));

// Authentication
var issuer = builder.Configuration["JWT_ISSUER"]!;
var audience = builder.Configuration["JWT_AUDIENCE"]!;
var key = builder.Configuration["JWT_ACCESS_TOKEN_SECRET"]!;
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = issuer,
            ValidAudience = audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
        };
    });

// Authorization
AddAuthorizationPolicies(builder.Services);

// Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Bindy Bot API",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "GitHub",
            Url = new Uri("https://github.com/bind-w-exit/BindyBot")
        },
        License = new OpenApiLicense()
        {
            Name = "MIT",
            Url = new Uri("https://opensource.org/licenses/MIT")
        }
    });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JSON Web Token based security"
    });

    c.AddSecurityRequirement(
        new OpenApiSecurityRequirement()
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                Array.Empty<string>()
            }
        }
    );

    //c.OperationFilter<SecurityRequirementsOperationFilter>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

static string GetConnectionString(IConfiguration configuration)
{
    var host = configuration["DB_HOST"];
    var database = configuration["DB_NAME"];
    var username = configuration["DB_USER"];
    var password = configuration["DB_PASS"];
    return $"Host={host};Database={database};Username={username};Password={password}";
}

static void AddAuthorizationPolicies(IServiceCollection services)
{
    var roles = Enum.GetValues(typeof(Roles)).Cast<Roles>();
    foreach (var role in roles)
    {
        services.AddAuthorization(options =>
        {
            options.AddPolicy(role.ToString(), policy =>
                policy.RequireRole(role.ToString()));
        });
    }

    services.AddAuthorization(options =>
    {
        options.AddPolicy("RefreshToken", policy =>
                policy.RequireRole("RefreshToken"));
    });
}