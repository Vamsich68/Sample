using Microsoft.AspNetCore.Mvc;

using Sample.Models;
using System.Diagnostics;
//using System.Web.Mvc;
namespace Sample.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index() { return View(); }
        [HttpGet]
        public ActionResult Edit()
        {
            Employee employee = new Employee();
            employee.EmployeeId = "59";
            employee.EmployeeName ="Name";
            employee.EmployeeDescription="Description";
            return View( employee);

        }
    }
}
