using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sample.Data;
using Sample.Models;
using Sample.Repo;


namespace Sample.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepo _context;

        public EmployeesController(IEmployeeRepo _db)
        {
            _context = _db;
        }
        public ActionResult Register()
        {
            return View();
        }
        // GET: Employees1
        public async Task<IActionResult> Index()
        {
            //return _context.Employees != null ?
            //            View(await _context.Employees.ToListAsync()) :
            //            Problem("Entity set 'ApplicationDbContext.Employees'  is null.");
            return View(_context.GetAll());
        }

        // GET: Employees1/Details/5
        public async Task<IActionResult> Details(string id)
        {
            //if (id == null || _context.Employees == null)
            if (id == null)
            {
                return NotFound();
            }
            // _context.Find(id.GetValueOrDefault())

            var employee = _context.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }
        //public ActionResult Edit()
        //{
        //    Employee employee = new Employee();
        //    employee.EmployeeId = "Id";
        //    employee.EmployeeDepartment = "department";
        //    employee.EmployeeName = "Name";
        //    employee.EmployeeDescription = "Description";
        //    employee.EmployeeDesignation = "Designation";
        //    employee.EmployeeAddress = "address";
        //    return View(employee);
        //}
        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,EmployeeName,EmployeeAge,EmployeeDesignation,EmployeeDepartment,EmployeeAddress,EmployeeDescription")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees1/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = _context.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employees1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("EmployeeId,EmployeeName,EmployeeAge,EmployeeDesignation,EmployeeDepartment,EmployeeAddress,EmployeeDescription")] Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                //try
                //{
                //    _context.Update(employee);
                //    await _context.SaveChangesAsync();
                //}
                //catch (DbUpdateConcurrencyException)
                //{
                //    if (!EmployeeExists(employee.EmployeeId))
                //    {
                //        return NotFound();
                //    }
                //    else
                //    {
                //        throw;
                //    }
                //}
                _context.Update(employee);
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees1/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            _context.Remove(id);
            return RedirectToAction(nameof(Index));
            

            //return View(employee);
        }

        // POST: Employees1/Delete/5
        //[HttpPost]
        //[ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(string id)
        //{
        //    if (_context.Employees == null)
        //    {
        //        return Problem("Entity set 'ApplicationDbContext.Employees'  is null.");
        //    }
        //    var employee = await _context.Employees.FindAsync(id);
        //    if (employee != null)
        //    {
        //        _context.Employees.Remove(employee);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool EmployeeExists(string id)
        //{
        //    return (_context.Employees?.Any(e => e.EmployeeId == id)).GetValueOrDefault();
        //}
    }
}
