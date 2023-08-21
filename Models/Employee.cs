using Microsoft.Data.SqlClient;

namespace Sample.Models
{
    
    public class Employee
    {

        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int EmployeeAge { get; set; } = 0;
        public string EmployeeDesignation { get; set; }
        public string EmployeeDepartment { get; set; }
        public string EmployeeAddress { get; set; }

        public string EmployeeDescription { get; set; }
    }
    //public List<Employee> EmployeesList(string connectionString)
    //{
    //    List<Employee> employeelist = new List<Employee>();
    //    SqlConnection con = new SqlConnection(connectionString);
    //    string SelectSQL = "select EmployeeId, EmployeeName, EmployeeAge, employeeDesignation, EmployeeDepartment, EmployeeAddress, EmployeeDescription";
    //    con.Open();
    //    SqlCommand cmd = new SqlCommand(SelectSQL, con);
    //    SqlDataReader dr = cmd.ExecuteReader();

    //}
}

