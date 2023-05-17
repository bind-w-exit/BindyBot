using BindyBot.Api.Data.Contracts;
using BindyBot.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BindyBot.Api.Data;

public class RevokedTokenRepository : IRevokedTokenRepository
{
    private readonly BindyBotApiDbContext _dbContext;

    public RevokedTokenRepository(BindyBotApiDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<RevokedToken> CreateAsync(RevokedToken revokedToken)
    {
        await _dbContext.RevokedTokens.AddAsync(revokedToken);
        await _dbContext.SaveChangesAsync();

        return revokedToken;
    }

    public Task<RevokedToken?> GetByJtiAsync(Guid jti)
    {
        return _dbContext.RevokedTokens
            .SingleOrDefaultAsync(revokedToken => revokedToken.Jti == jti);
    }
}