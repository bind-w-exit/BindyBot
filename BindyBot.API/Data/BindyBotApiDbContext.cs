using BindyBot.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BindyBot.Api.Data;

public class BindyBotApiDbContext : DbContext
{
    public BindyBotApiDbContext(DbContextOptions<BindyBotApiDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<RevokedToken> RevokedTokens { get; set; }
    public DbSet<TwitchUserCredentials> TwitchUsersCredentials { get; set; }
}