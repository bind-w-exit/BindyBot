using BindyBot.API.Data;
using BindyBot.API.Modules.JwtAuth.Models;
using BindyBot.API.Modules.JwtAuth.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BindyBot.API.Repositories;

public class UserRepository : IUserRepository
{
    private readonly BindyBotApiDbContext _dbContext;

    public UserRepository(BindyBotApiDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public User? Create(User user)
    {
        _dbContext.Users.Add(user);
        _dbContext.SaveChanges();

        return user;
    }

    public bool Delete(int id)
    {
        var affected = _dbContext.Users
            .Where(user => user.Id == id)
            .ExecuteDelete();

        return affected == 1;
    }

    public List<User>? GetAll()
    {
        return _dbContext.Users.ToList();
    }

    public User? GetById(int id)
    {
        return _dbContext.Users
            .FirstOrDefault(user => user.Id == id);
    }

    public User? GetByLogin(string username)
    {
        return _dbContext.Users
            .FirstOrDefault(user => user.Username == username);
    }

    public User Update(User user)
    {
        throw new NotImplementedException();
    }
}