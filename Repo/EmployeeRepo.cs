using Dapper;
using Microsoft.Data.SqlClient;
using Sample.Data;
using Sample.Models;
using System.Configuration;
using System.Data;
using System.Reflection;


namespace Sample.Repo
{
    public class EmployeeRepo : IEmployeeRepo
    {
        
        private IDbConnection db;

        public EmployeeRepo(IConfiguration configuration)
        {

            this.db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));

        }
        public Employee Add(Employee employee)
        {
      
            var sql = "INSERT INTO Employees(EmployeeId, EmployeeName, EmployeeAge,EmployeeDesignation,EmployeeDepartment,EmployeeAddress,EmployeeDescription) " +
                "VALUES (@EmployeeId, @EmployeeName, @EmployeeAge, @EmployeeDesignation,@EmployeeDepartment,@EmployeeAddress,@EmployeeDescription)";
            return db.Query<Employee>(sql, new {employee.EmployeeId, employee.EmployeeName, employee.EmployeeAge,employee.EmployeeDesignation,employee.EmployeeDepartment, employee.EmployeeAddress, employee.EmployeeDescription}).FirstOrDefault();
            //return db.Query<Employee>(sql, employee).Single();
        }



        public Employee Find(string id)
        {
            var sql = "SELECT *FROM Employees where EmployeeId =@EmployeeId";
            return db.Query<Employee>(sql, new { @EmployeeId = id}).Single();
        }



        public object Find(object value)
        {
            throw new NotImplementedException();
        }

        //public object Find(object value)
        //{

        //}

        public List<Employee> GetAll()
        {
            var sql = "SELECT *FROM Employees";
            return db.Query<Employee>(sql).ToList();
           
        }

        public void Remove(string id)
        {
            var sql = "DELETE FROM Employees WHERE EmployeeId=@id";
            db.Execute(sql, new {@id=id});
            
        }

        public Employee Update(Employee employee)
        {
            var sql = "UPDATE INTO Employees SET EmployeeId = @EmployeeId, EmployeeName=@EmployeeName, EmployeeAge=@EmployeeAge,EmployeeDesignation=@EmployeeDesignation, EmployeeAddress=@EmployeeAddress, EmployeeDescription=@EmployeeDescription WHERE EmployeeId=@EmployeeId";
               
            db.Execute(sql, employee);
            return employee;
        }
    }
}
