namespace BindyBot.API.Modules.JwtAuth.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public UserRole UserRole { get; set; }

    public User(string username, string passwordHash, UserRole userRole)
    {
        Username = username;
        PasswordHash = passwordHash;
        UserRole = userRole;
    }
}