using Domain.Entities.User;
using Microsoft.EntityFrameworkCore;

public class UserAccountDBContext(DbContextOptions<UserAccountDBContext> options) : DbContext(options)
{
    public DbSet<UserAccount> userAccounts { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}

