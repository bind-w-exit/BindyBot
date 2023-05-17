using BindyBot.Api.Models;

namespace BindyBot.Api.Data.Contracts;

public interface IRevokedTokenRepository
{
    Task<RevokedToken> CreateAsync(RevokedToken revokedToken);

    Task<RevokedToken?> GetByJtiAsync(Guid jti);
}