using BindyBot.Api.Data.Contracts;
using BindyBot.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BindyBot.Api.Data;

public class TwitchUserCredentialsRepository : ITwitchUserCredentialsRepository
{
    private readonly BindyBotApiDbContext _dbContext;

    public TwitchUserCredentialsRepository(BindyBotApiDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<TwitchUserCredentials> CreateAsync(TwitchUserCredentials credentials)
    {
        await _dbContext.TwitchUsersCredentials.AddAsync(credentials);
        await _dbContext.SaveChangesAsync();

        return credentials;
    }

    public Task<TwitchUserCredentials?> GetByUserIdAsync(int userId)
    {
        return _dbContext.TwitchUsersCredentials
            .FirstOrDefaultAsync(credentials => credentials.UserId == userId);
    }

    public async Task<TwitchUserCredentials?> UpdateAsync(TwitchUserCredentials credentials)
    {
        var existingCredentials = await _dbContext.TwitchUsersCredentials.FindAsync(credentials.Id);

        if (existingCredentials is not null)
        {
            existingCredentials.UserId = credentials.UserId;
            existingCredentials.AccessToken = credentials.AccessToken;
            existingCredentials.RefreshToken = credentials.RefreshToken;
            existingCredentials.ExpiresIn = credentials.ExpiresIn;

            await _dbContext.SaveChangesAsync();
        }

        return existingCredentials;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var credentials = await _dbContext.TwitchUsersCredentials
            .FirstOrDefaultAsync(credentials => credentials.Id == id);

        if (credentials is not null)
        {
            _dbContext.TwitchUsersCredentials.Remove(credentials);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        return false;
    }
}