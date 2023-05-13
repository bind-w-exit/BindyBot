using BindyBot.API.Modules.JwtAuth.Models;

namespace BindyBot.API.Modules.JwtAuth.Repositories;

public interface IRevokedTokenRepository
{
    RevokedToken? Create(RevokedToken user);

    RevokedToken? GetByJti(Guid jti);
}