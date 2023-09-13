using Microsoft.AspNetCore.Mvc;
using System.Data;
using Sample.Repo;

namespace Sample.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly IEmployeeRepo _db;
        public MenuViewComponent(IEmployeeRepo db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var employees = _db.GetAll();
            var len = employees.Count;
            return View(employees);
        }

    }
}
