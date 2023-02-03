using Microsoft.AspNetCore.Mvc;
using MVC2.Models;
using System.Diagnostics;
using MVC2.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace MVC2.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;
        public HomeController(ILogger<HomeController> logger, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            _logger = logger;
            this.signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult userProfile()
        {
            var userName = User.Identity.Name.ToString();
            var name = User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.Name).ToString();
            var id = User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier).ToString();
            var email = User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.Email).ToString();
            List<string> info = new List<string>()
            {
                userName,
                name,
                id,
                email
            };

            return View(info);
        }
        
        public async Task<IActionResult> getLoginInfo(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(loginVM.email);
                if (user != null)
                {
                   var result = await userManager.CheckPasswordAsync(user, loginVM.password);
                    if(result)
                    {
                        await signInManager.SignInAsync(user, loginVM.rememberMe);
                        return RedirectToAction("userProfile");
                    }
                    ModelState.AddModelError("", "wrong email or password");
                }
            }
            return View(nameof(Index), loginVM);
        }
        public async Task<IActionResult> logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        

    }
}