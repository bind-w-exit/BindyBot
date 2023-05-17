using BindyBot.Api.Enums;

namespace BindyBot.Api.Models.Dtos;

public class UserDto
{
    public int Id { get; set; }
    public string? Username { get; set; }
    public Roles UserRole { get; set; }

    public UserDto()
    {
    }

    public UserDto(int id, string username, Roles userRole)
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