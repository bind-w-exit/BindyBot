using BindyBot.Api.Data.Contracts;
using BindyBot.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BindyBot.Api.Data;

public class UserRepository : IUserRepository
{
    private readonly BindyBotApiDbContext _dbContext;

    public UserRepository(BindyBotApiDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User> CreateAsync(User user)
    {
        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();

        return user;
    }

    public Task<List<User>> GetAllAsync()
    {
        return _dbContext.Users.ToListAsync();
    }

    public Task<User?> GetByIdAsync(int id)
    {
        return _dbContext.Users
            .SingleOrDefaultAsync(user => user.Id == id);
    }

    public Task<User?> GetByLoginAsync(string username)
    {
        return _dbContext.Users
            .SingleOrDefaultAsync(user => user.Username == username);
    }

    public async Task<User?> UpdateAsync(User user)
    {
        var existingUser = await _dbContext.Users.FindAsync(user.Id);

        if (existingUser is not null)
        {
            existingUser.Username = user.Username;
            existingUser.PasswordHash = user.PasswordHash;
            existingUser.PasswordSalt = user.PasswordSalt;
            existingUser.UserRole = user.UserRole;

            await _dbContext.SaveChangesAsync();
        }

        return existingUser;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var user = await _dbContext.Users
            .SingleOrDefaultAsync(user => user.Id == id);

        if (user is not null)
        {
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        return false;
    }
}