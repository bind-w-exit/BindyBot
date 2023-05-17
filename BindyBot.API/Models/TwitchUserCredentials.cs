namespace BindyBot.Api.Models;

public class TwitchUserCredentials
{
    public int Id { get; set; }
    public int UserId { get; set; } //TODO: Add a one-to-one relationship to User.Id
    public string? AccessToken { get; set; }
    public string? RefreshToken { get; set; }
    public int ExpiresIn { get; set; }
}