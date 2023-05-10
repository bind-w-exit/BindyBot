using BindyBot.API.Modules.JwtAuth.Models;
using Microsoft.EntityFrameworkCore;

namespace BindyBot.API.Data;

public class BindyBotApiDbContext : DbContext
{
    public BindyBotApiDbContext(DbContextOptions<BindyBotApiDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
}