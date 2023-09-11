using Dapper;
using Microsoft.Data.SqlClient;
using Sample.Data;
using Sample.Models;
using System.Configuration;
using System.Data;
using System.Reflection;


namespace Sample.Repo
{
    public class EmployeeRepoSP : IEmployeeRepo
    {
        
        private IDbConnection db;

        public EmployeeRepoSP(IConfiguration configuration)
        {

            this.db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));

        }
        public Employee Add(Employee employee)
        {
            return db.Query<Employee>("usp_AddEmployee", new { employee.EmployeeId, employee.EmployeeName, employee.EmployeeAge, employee.EmployeeDesignation, employee.EmployeeDepartment, employee.EmployeeAddress, employee.EmployeeDescription }, commandType: CommandType.StoredProcedure).FirstOrDefault();

            //var sql = "INSERT INTO Employees(EmployeeId, EmployeeName, EmployeeAge,EmployeeDesignation,EmployeeDepartment,EmployeeAddress,EmployeeDescription) " +
            //    "VALUES (@EmployeeId, @EmployeeName, @EmployeeAge, @EmployeeDesignation,@EmployeeDepartment,@EmployeeAddress,@EmployeeDescription)";
            //return db.Query<Employee>(sql, new {employee.EmployeeId, employee.EmployeeName, employee.EmployeeAge,employee.EmployeeDesignation,employee.EmployeeDepartment, employee.EmployeeAddress, employee.EmployeeDescription}).FirstOrDefault();
            ////return db.Query<Employee>(sql, employee).Single();
        }



        public Employee Find(string id)
        {
            return db.Query<Employee>("usp_GetEmployee", new { @EmployeeId = id }, commandType: CommandType.StoredProcedure).Single();
            // var sql = "SELECT *FROM Employees where EmployeeId =@EmployeeId";
            //return db.Query<Employee>(sql, new { @EmployeeId = id}).Single();
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
            //var sql = "SELECT *FROM Employees";
            return db.Query<Employee>("usp_GetAllEmployees", commandType: CommandType.StoredProcedure).ToList();
           
        }

        public void Remove(string id)
        {
            //var sql = "DELETE FROM Employees WHERE EmployeeId=@id";
            //db.Execute(sql, new {@id=id});
            db.Execute("usp_RemoveEmployee", new {@EmployeeId=id}, commandType: CommandType.StoredProcedure);
        }

        public Employee Update(Employee employee)
        {
            //var sql = "UPDATE Employees SET EmployeeId = @EmployeeId, EmployeeName=@EmployeeName, EmployeeAge=@EmployeeAge,EmployeeDesignation=@EmployeeDesignation, EmployeeAddress=@EmployeeAddress, EmployeeDescription=@EmployeeDescription WHERE EmployeeId=@EmployeeId";
            db.Execute("usp_UpdateEmployee", employee);
            //db.Execute(sql, employee);
            return employee;
        }
    }
}


