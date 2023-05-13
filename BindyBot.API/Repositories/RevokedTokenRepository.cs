using BindyBot.API.Data;
using BindyBot.API.Modules.JwtAuth.Models;
using BindyBot.API.Modules.JwtAuth.Repositories;

namespace BindyBot.API.Repositories;

public class RevokedTokenRepository : IRevokedTokenRepository
{
    private readonly BindyBotApiDbContext _dbContext;

    public RevokedTokenRepository(BindyBotApiDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public RevokedToken? Create(RevokedToken revokedToken)
    {
        _dbContext.RevokedTokens.Add(revokedToken);
        _dbContext.SaveChanges();

        return revokedToken;
    }

    public RevokedToken? GetByJti(Guid jti)
    {
        return _dbContext.RevokedTokens
            .FirstOrDefault(revokedToken => revokedToken.Jti == jti);
    }
}