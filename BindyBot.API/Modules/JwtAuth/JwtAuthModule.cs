using BindyBot.API.Modules.JwtAuth.Dtos;
using BindyBot.API.Modules.JwtAuth.Models;
using BindyBot.API.Modules.JwtAuth.Repositories;
using BindyBot.API.Modules.JwtAuth.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BindyBot.API.Modules.Authentication;

public static class JwtAuthModule
{
    // Who created and signed this token
    private static string _issuer;

    // Who or what the token is intended for
    private static string _audience;

    private static string _key;

    public static IServiceCollection AddJwtAuthModule<TUserRepository, TRevokedTokenRepository>
        (this IServiceCollection services, string issuer, string audience, string key)
        where TUserRepository : class, IUserRepository
        where TRevokedTokenRepository : class, IRevokedTokenRepository
    {
        _issuer = issuer;
        _audience = audience;
        _key = key;

        services.AddScoped<IUserRepository, TUserRepository>();
        services.AddScoped<IRevokedTokenRepository, TRevokedTokenRepository>();
        services.AddScoped<ITokenService, TokenService>();

        services.AddAuthorization(options =>
        {
            options.AddPolicy("RefreshToken", policy =>
                policy.RequireRole("RefreshToken"));
        });
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

        MapUserEndpoints(app);
        MapAuthEndpoints(app);

        return app;
    }

    private static void MapUserEndpoints(IEndpointRouteBuilder endpoints)
    {
        var userGroup = endpoints.MapGroup("/api/User").WithTags("User");

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
            CreatePasswordHash(user.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var newUser = new User(user.Username, passwordHash, passwordSalt, user.UserRole);

            var newUserWithIdFromDb = userRepository.Create(newUser);

            var response = new UserDto(newUserWithIdFromDb!);

            return Results.Created($"/user/{newUser.Id}", response);
        })
        .WithName("CreateUser")
        .WithOpenApi();

        userGroup.MapDelete("/{id}", (int id, IUserRepository userRepository) =>
        {
            return userRepository.Delete(id) ? Results.Ok() : Results.NotFound();
        })
        .WithName("DeleteUser")
        .WithOpenApi();
    }

    private static void MapAuthEndpoints(IEndpointRouteBuilder endpoints)
    {
        var authGroup = endpoints.MapGroup("/api/auth")
        .WithTags("Auth")
        .WithOpenApi();

        authGroup.MapPost("/login", (IUserRepository userRepository, ITokenService tokenService, UserForLoginDto userDto) =>
        {
            var user = userRepository.GetByLogin(userDto.Username);

            if (user == null)
                return Results.BadRequest("User not found.");

            if (!VerifyPasswordHash(userDto.Password, user.PasswordHash, user.PasswordSalt))
                return Results.BadRequest("Wrong password.");

            AuthenticatedResponse response = tokenService.GenerateAuthenticatedResponse(user);
            return Results.Ok(response);
        })
        .WithName("Login")
        .AllowAnonymous();

        authGroup.MapDelete("/logout", (IRevokedTokenRepository revokedTokenRepository, ClaimsPrincipal claimsPrincipal) =>
        {
            // Validation 1: Ensure that the JTI is valid
            var jtiString = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Jti)?.Value;
            if (jtiString == null)
            {
                return Results.BadRequest("Invalid JTI");
            }
            var jti = Guid.Parse(jtiString);

            // Validation 2: Check if the token is already in the blacklist
            var revokedToken = revokedTokenRepository.GetByJti(jti);
            if (revokedToken != null)
            {
                return Results.BadRequest("Token has already been revoked");
            }

            // Validation 3: Ensure that the token expiry time is valid
            var tokenExpiresString = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Exp)?.Value;
            if (tokenExpiresString == null || !long.TryParse(tokenExpiresString, out long tokenExpiresSeconds))
            {
                return Results.BadRequest("Invalid Exp");
            }
            var tokenExpires = DateTimeOffset.FromUnixTimeSeconds(tokenExpiresSeconds);
            if (tokenExpires <= DateTimeOffset.UtcNow)
            {
                return Results.BadRequest("Token has expired");
            }

            // Add tokens to the blacklist
            revokedTokenRepository.Create(new RevokedToken
            {
                Jti = jti,
                ExpiryDate = tokenExpires.UtcDateTime
            });

            return Results.Ok();
        })
        .WithName("Logout")
        .RequireAuthorization();

        authGroup.MapGet("/refresh", (
            IUserRepository userRepository,
            IRevokedTokenRepository revokedTokenRepository,
            ITokenService tokenService,
            ClaimsPrincipal claimsPrincipal) =>
        {
            // Validation 1: Ensure that the JTI is valid
            var jtiString = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Jti)?.Value;
            if (jtiString == null)
            {
                return Results.BadRequest("Invalid JTI");
            }
            var jti = Guid.Parse(jtiString);

            // TODO: Move to the AuthMiddleware
            // Validation 2: Ensure that the token is not in the blacklist
            var revokedToken = revokedTokenRepository.GetByJti(jti);
            if (revokedToken != null)
            {
                return Results.BadRequest("Token has been used");
            }

            // Validation 3: Ensure that the token expiry time is valid
            var tokenExpiresString = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Exp)?.Value;
            if (tokenExpiresString == null || !long.TryParse(tokenExpiresString, out long tokenExpiresSeconds))
            {
                return Results.BadRequest("Invalid Exp");
            }
            var tokenExpires = DateTimeOffset.FromUnixTimeSeconds(tokenExpiresSeconds);

            // Validation 4: Ensure that the user ID is valid
            var userId = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (userId == null || !int.TryParse(userId, out int userIdValue))
            {
                return Results.BadRequest("Invalid user ID");
            }

            var user = userRepository.GetById(userIdValue);
            if (user == null)
            {
                return Results.BadRequest("User not found");
            }

            // Add old tokens to the blacklist
            revokedTokenRepository.Create(new RevokedToken
            {
                Jti = jti,
                ExpiryDate = tokenExpires.UtcDateTime
            });

            AuthenticatedResponse response = tokenService.GenerateAuthenticatedResponse(user);
            return Results.Ok(response);
        })
        .WithName("Refresh")
        .RequireAuthorization("RefreshToken");
    }

    private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using var hmac = new HMACSHA512();
        passwordSalt = hmac.Key;
        passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
    }

    private static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using var hmac = new HMACSHA512(passwordSalt);
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        return computedHash.SequenceEqual(passwordHash);
    }
}