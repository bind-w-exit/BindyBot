using BindyBot.API.Modules.JwtAuth.Dtos;
using BindyBot.API.Modules.JwtAuth.Models;
using BindyBot.API.Modules.JwtAuth.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BindyBot.API.Modules.Authentication;

public static class JwtAuthModule
{
    // Who created and signed this token
    private static string _issuer;

    // Who or what the token is intended for
    private static string _audience;

    private static string _key;

    public static IServiceCollection AddJwtAuthModule<TUserRepository>(this IServiceCollection services, string issuer, string audience, string key) where TUserRepository : class, IUserRepository
    {
        _issuer = issuer;
        _audience = audience;
        _key = key;

        services.AddScoped<IUserRepository, TUserRepository>();

        services.AddAuthorization();
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = _issuer,
                    ValidAudience = _audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key))
                };
            });

        return services;
    }

    public static WebApplication UseJwtAuthModule(this WebApplication app)
    {
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapPost("/security/getToken", (IUserRepository userRepository, UserForLoginDto userDto) =>
        {
            var user = userRepository.GetByLoginAndPass(userDto.Username, userDto.Password);

            if (user != null)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var jwtTokenHandler = new JwtSecurityTokenHandler();

                var key = Encoding.ASCII.GetBytes(_key);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim("Id", user.Id.ToString()),
                        new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                        // The JTI is used for our refresh token
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                    }),
                    Expires = DateTime.UtcNow.AddHours(1),
                    Audience = _audience,
                    Issuer = _issuer,
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
                };

                var token = jwtTokenHandler.CreateToken(tokenDescriptor);
                var jwtToken = jwtTokenHandler.WriteToken(token);

                return Results.Ok(jwtToken);
            }
            else
            {
                return Results.Unauthorized();
            }
        })
        .WithName("GetToken")
        .WithOpenApi()
        .AllowAnonymous();

        app.MapUserEndpoints();

        return app;
    }

    private static void MapUserEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var userGroup = endpoints.MapGroup("/api/User").WithTags(nameof(User));

        userGroup.MapGet("/", (IUserRepository userRepository) =>
        {
            return userRepository.GetAll();
        })
        .WithName("GetAllUsers")
        .WithOpenApi();

        userGroup.MapGet("/{id}", (int id, IUserRepository userRepository) =>
        {
            var user = userRepository.GetById(id);
            if (user == null)
                return Results.NotFound();
            return Results.Ok(user);
        })
        .WithName("GetUserById")
        .WithOpenApi();

        userGroup.MapPost("/", (UserForRegisterDto user, IUserRepository userRepository) =>
        {
            var newUser = userRepository.Create(user);
            return Results.Created($"/user/{newUser.Id}", newUser);
        })
        .WithName("CreateUser")
        .WithOpenApi();

        userGroup.MapDelete("/{id}", (int id, IUserRepository userRepository) =>
        {
            return userRepository.Delete(id) ? Results.Ok() : Results.NotFound();
        })
        .WithName("DeleteUser")
        .WithOpenApi()
        .RequireAuthorization();
    }
}