using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sample.Migrations
{
    /// <inheritdoc />
    public partial class StoredProcedures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
				CREATE PROC usp_GetEmployee 
					@EmployeeId int
				AS
				BEGIN 
					SELECT *FROM Employees WHERE EmployeeId =@EmployeeId;
				END
				GO
				");

            migrationBuilder.Sql(@"
				CREATE PROC usp_GetAllEmployees
				AS
				BEGIN
					SELECT * from Employees;
				END
				GO
				");

            migrationBuilder.Sql(@"
				CREATE PROC usp_AddEmployee
					@EmployeeId varchar(10) OUTPUT, 
					@EmployeeName varchar(MAX), 
					@EmployeeAge int, 
					@EmployeeDesignation varchar(MAX), 
					@EmployeeDepartment varchar(MAX), 
					@EmployeeAddress varchar(MAX), 
					@EmployeeDescription varchar(MAX)
				AS
				BEGIN
					INSERT INTO Employees(EmployeeId, EmployeeName, EmployeeAge,EmployeeDesignation,EmployeeDepartment,EmployeeAddress,EmployeeDescription) VALUES (@EmployeeId, @EmployeeName, @EmployeeAge, @EmployeeDesignation, @EmployeeDepartment, @EmployeeAddress, @EmployeeDescription);
					select @EmployeeId = SCOPE_IDENTITY();
				END
				GO
				");

            migrationBuilder.Sql(@"
				CREATE PROC usp_UpdateEmployee

					@EmployeeId varchar(10) OUTPUT, 
					@EmployeeName varchar(MAX), 
					@EmployeeAge int, 
					@EmployeeDesignation varchar(MAX), 
					@EmployeeDepartment varchar(MAX), 
					@EmployeeAddress varchar(MAX), 
					@EmployeeDescription varchar(MAX)
			
				AS
				BEGIN
		
					UPDATE Employees 
					SET 
						EmployeeId = @EmployeeId, 
						EmployeeName=@EmployeeName, 
						EmployeeAge=@EmployeeAge,
						EmployeeDesignation=@EmployeeDesignation, 
						EmployeeAddress=@EmployeeAddress, 
						EmployeeDescription=@EmployeeDescription 
					WHERE EmployeeId=@EmployeeId;
			
					SELECT @EmployeeId=Scope_Identity();
				END
				GO
			");

            migrationBuilder.Sql(@"
				CREATE PROC usp_RemoveEmployee
					@EmployeeId int
				AS
				BEGIN
					DELETE FROM Employees WHERE EmployeeId=@EmployeeId;
				END
				GO
				");

				}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
