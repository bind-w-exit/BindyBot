using BindyBot.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BindyBot.API.Data;

public class BindyBotApiContext : DbContext
{
    public BindyBotApiContext(DbContextOptions<BindyBotApiContext> options)
        : base(options) 
    {
    }

    public DbSet<User> Users { get; set; }
}