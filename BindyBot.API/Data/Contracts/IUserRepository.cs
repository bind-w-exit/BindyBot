using BindyBot.Api.Models;

namespace BindyBot.Api.Data.Contracts;

public interface IUserRepository
{
    Task<User> CreateAsync(User user);

    Task<List<User>> GetAllAsync();

    Task<User?> GetByIdAsync(int id);

    Task<User?> GetByLoginAsync(string username);

    Task<User?> UpdateAsync(User user);

    Task<bool> DeleteAsync(int id);
}