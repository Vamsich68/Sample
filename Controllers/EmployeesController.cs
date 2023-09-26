using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sample.Data;
using Sample.Models;
using Sample.Repo;


namespace Sample.Controllers
{
    [Authorize]
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
        public async Task<ActionResult> Index( string child)
        {
            if (string.IsNullOrWhiteSpace(child))
            {
                return View(_context.GetAll());
            }
            else
            {
                var searchitem = _context.GetAll().Where(s=>s.EmployeeId.Contains(child));
                return View(searchitem);
            }
            
        }
       
        public async Task<ActionResult> List( string child)
        {
            if (string.IsNullOrEmpty(child))
            {
                return View( _context.GetAll());
            }
            
            else
            {
                var searchitem =  _context.GetAll().Where(s => s.EmployeeId.Contains(child));
                return View(searchitem);
            }
        }

        public async Task<IActionResult> Details(string id)
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

       
        public ActionResult Create()
        {
            var employee = new Employee();
            employee.EmployeeDescription = "Vamsi";
            return View(employee);
        }
        
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
            

            
        }

        
    }
}
