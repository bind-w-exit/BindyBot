using BindyBot.API.Modules.JwtAuth.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BindyBot.API.Modules.JwtAuth.Services;

public class TokenService : ITokenService
{
    private readonly string _audience;
    private readonly string _issuer;
    private readonly string _key;

    public TokenService(IConfiguration configuration)
    {
        _issuer = configuration["JWT_ISSUER"]!;
        _audience = configuration["JWT_AUDIENCE"]!;
        _key = configuration["JWT_ACCESS_TOKEN_SECRET"]!;
    }

    public AuthenticatedResponse GenerateAuthenticatedResponse(User user)
    {
        return GenerateAuthenticatedResponse(user, out _, out _, out _);
    }

    public AuthenticatedResponse GenerateAuthenticatedResponse(
        User user,
        out Guid pairJti,
        out DateTime accessTokenExpires,
        out DateTime refreshTokenExpires)
    {
        pairJti = Guid.NewGuid();
        accessTokenExpires = DateTime.UtcNow.AddMinutes(5);
        refreshTokenExpires = DateTime.UtcNow.AddDays(14);

        var accessTokenClaims = GenerateAccessTokenClaims(user, pairJti);
        var refreshTokenClaims = GenerateRefreshTokenClaims(user, pairJti);

        return new AuthenticatedResponse
        {
            AccessToken = GenerateToken(accessTokenClaims, accessTokenExpires),
            RefreshToken = GenerateToken(refreshTokenClaims, refreshTokenExpires)
        };
    }

    private static List<Claim> GenerateAccessTokenClaims(User user, Guid jti)
    {
        return new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, user.UserRole.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, jti.ToString())
            ,
        };
    }

    private static List<Claim> GenerateRefreshTokenClaims(User user, Guid jti)
    {
        return new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, "RefreshToken"),
            new Claim(JwtRegisteredClaimNames.Jti, jti.ToString())
        };
    }

    private string GenerateToken(IEnumerable<Claim> claims, DateTime expires)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var tokeOptions = new JwtSecurityToken(
            claims: claims,
            issuer: _issuer,
            audience: _audience,
            expires: expires,
            signingCredentials: credentials
        );

        var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
        return tokenString;
    }
}