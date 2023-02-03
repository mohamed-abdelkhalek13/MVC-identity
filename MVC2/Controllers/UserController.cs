
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC2.ViewModels;
namespace MVC2.Controllers
{
    public class UserController : Controller
    {
        private UserManager<IdentityUser> userManager { get; set; }
        public UserController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> getRegisteredInfo(identityuserVM IU)
        {
            if(ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser()
                {
                    UserName = IU.UserName,
                    Email = IU.Email,
                    PhoneNumber = IU.PhoneNumber,
                };
                var result = await userManager.CreateAsync(user, IU.Password);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View("Index", IU);
        }
    }
}
