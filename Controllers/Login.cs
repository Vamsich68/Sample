using Microsoft.AspNetCore.Mvc;

namespace Sample.Controllers
{
    public class Login : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult SignIn()
        { 
            return View(); 
        }
    }
}
