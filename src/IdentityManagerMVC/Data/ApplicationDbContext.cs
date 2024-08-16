using IdentityManagerMVC.Models;

namespace IdentityManagerMVC.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):IdentityDbContext(options)
{
    public DbSet<ApplicationUser> ApplicationUser { get; set; }
}