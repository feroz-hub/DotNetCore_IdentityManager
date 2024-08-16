namespace IdentityManagerMVC.Models;

public class ApplicationUser:IdentityUser
{
    [Required]
    public string Name { get; set; }
    
}