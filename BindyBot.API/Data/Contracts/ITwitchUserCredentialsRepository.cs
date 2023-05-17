using BindyBot.Api.Models;

namespace BindyBot.Api.Data.Contracts;

public interface ITwitchUserCredentialsRepository
{
    Task<TwitchUserCredentials> CreateAsync(TwitchUserCredentials credentials);

    Task<TwitchUserCredentials?> GetByUserIdAsync(int userId);

    Task<TwitchUserCredentials?> UpdateAsync(TwitchUserCredentials credentials);

    Task<bool> DeleteAsync(int id);
}