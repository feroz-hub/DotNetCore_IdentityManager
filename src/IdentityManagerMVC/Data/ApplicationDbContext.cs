namespace IdentityManagerMVC.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):IdentityDbContext(options)
{
    
}