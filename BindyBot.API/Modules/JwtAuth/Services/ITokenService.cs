using BindyBot.API.Modules.JwtAuth.Models;

namespace BindyBot.API.Modules.JwtAuth.Services;

public interface ITokenService
{
    AuthenticatedResponse GenerateAuthenticatedResponse(User user);

    AuthenticatedResponse GenerateAuthenticatedResponse(User user,
        out Guid pairJti,
        out DateTime accessTokenExpires,
        out DateTime refreshTokenExpires);
}