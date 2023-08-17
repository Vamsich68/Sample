using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;


namespace Sample.Controllers
{

    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
        
    }
}
