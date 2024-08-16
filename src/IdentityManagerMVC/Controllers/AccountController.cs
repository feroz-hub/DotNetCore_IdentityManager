using IdentityManagerMVC.Models;

namespace IdentityManagerMVC.Controllers;

public class AccountController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager) : Controller
{
    // GET
    public IActionResult Register()
    {
        var registerViewModel = new RegisterViewModel();
        return View(registerViewModel);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterViewModel register)
    {
        if (ModelState.IsValid)
        {
            var user = new ApplicationUser{
                UserName = register.Email,
                Email = register.Email,
                Name = register.Name
            };
            var result = await userManager.CreateAsync(user, register.Password);
            if(result.Succeeded){
                return RedirectToAction("Login", "Account");
            }
            
            foreach(var error in result.Errors){
                ModelState.AddModelError("", error.Description);
            }
        }
        var registerViewModel = new RegisterViewModel();
        return View(registerViewModel);
    }


    public IActionResult Login()
    {
        return View();
    }
    
   
}