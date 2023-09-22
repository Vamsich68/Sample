using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Sample.Models;
using System.Security.Claims;

namespace Sample.Controllers
{
    public class AccountController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login( )
        {
            return View();
        }
        
        [HttpPost]
        public async Task<ActionResult> Login(Credential credential)
        {
            if (!ModelState.IsValid) return View();
            if (credential.UserName == "Admin" && credential.Password == "password")
            {
                var claims = new List<Claim> { new Claim(ClaimTypes.Name, "Admin"), new Claim(ClaimTypes.Email, "password") };
                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);
                return RedirectToAction( "Index","Home");
            }
            return View();
        }

       
        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync("MyCookieAuth");
            return RedirectToAction("Login","Account");

        }
    }
}
