using BindyBot.API.Modules.JwtAuth.Models;

namespace BindyBot.API.Modules.JwtAuth.Dtos;

public class UserDto
{
    public int Id { get; set; }
    public string? Username { get; set; }
    public UserRole UserRole { get; set; }

    public UserDto()
    {
    }

    public UserDto(int id, string username, UserRole userRole)
    {
        Id = id;
        Username = username;
        UserRole = userRole;
    }

    public UserDto(User user)
    {
        Id = user.Id;
        Username = user.Username;
        UserRole = user.UserRole;
    }
}