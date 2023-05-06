namespace BindyBot.API.Models;

public record User(string Name, string PasswordHash, UserRole UserRole) 
{
    public int Id { get; set; }
}
