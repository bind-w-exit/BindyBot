using BindyBot.API.Modules.JwtAuth.Models;

namespace BindyBot.API.Modules.JwtAuth.Repositories;

public interface IUserRepository
{
    User? Create(User user);

    List<User>? GetAll();

    User? GetById(int id);

    User? Update(User user);

    bool Delete(int id);

    User? GetByLogin(string username);
}