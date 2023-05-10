using BindyBot.API.Data;
using BindyBot.API.Modules.JwtAuth.Dtos;
using BindyBot.API.Modules.JwtAuth.Models;
using BindyBot.API.Modules.JwtAuth.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace BindyBot.API.Repositories;

public class UserRepository : IUserRepository
{
    private readonly BindyBotApiDbContext _dbContext;

    public UserRepository(BindyBotApiDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public User? Create(UserForRegisterDto user)
    {
        var newUser = new User(user.Username, HashPassword(user.Password), UserRole.Admin);
        _dbContext.Users.Add(newUser);
        _dbContext.SaveChanges();

        return newUser;
    }

    public bool Delete(int id)
    {
        var affected = _dbContext.Users
            .Where(model => model.Id == id)
            .ExecuteDelete();

        return affected == 1;
    }

    public List<User>? GetAll()
    {
        return _dbContext.Users.ToList();
    }

    public User? GetById(int id)
    {
        return _dbContext.Users.AsNoTracking()
            .FirstOrDefault(model => model.Id == id);
    }

    public User? GetByLoginAndPass(string username, string password)
    {
        return _dbContext.Users.AsNoTracking()
            .FirstOrDefault(model => model.Username == username && model.PasswordHash == HashPassword(password));
    }

    public User Update(User user)
    {
        throw new NotImplementedException();
    }

    private static string HashPassword(string password)
    {
        byte[] hashedBytes = SHA512.HashData(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(hashedBytes);
    }
}