using Microsoft.EntityFrameworkCore;
namespace CheatChat.Models;
public class AppDbContext : DbContext
{
    public DbSet<RegisterModel> users { get; set; }
}
