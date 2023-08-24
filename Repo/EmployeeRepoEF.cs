using Sample.Data;
using Sample.Models;
using System.Reflection;

namespace Sample.Repo
{
    public class EmployeeRepoEF : IEmployeeRepo
    {
        private readonly ApplicationDbContext _db;

        public EmployeeRepoEF(ApplicationDbContext context)
        {
            _db = context;
        }
        public Employee Add(Employee employee)
        {
            _db.Employees.Add(employee);
            _db.SaveChanges();
            return employee;
        }

        public Employee Find(string id)
        {
            //return _db.Employees.FirstOrDefault(u => u.EmployeeId==id);
            return _db.Employees.FirstOrDefault(e => e.EmployeeId == id);
        }

        public object Find(object value)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAll()
        {
            return _db.Employees.ToList();
        }

        public void Remove(string id)
        {
            Employee employee = _db.Employees.FirstOrDefault(e => e.EmployeeId==id); 
            _db.Employees.Remove(employee);
            _db.SaveChanges();
            return;
        }

        public Employee Update(Employee employee)
        {
            _db.Employees.Update(employee);
            _db.SaveChanges();
            return employee;

        }
    }
}
