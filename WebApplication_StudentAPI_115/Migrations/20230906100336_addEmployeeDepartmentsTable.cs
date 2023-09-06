using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication_StudentAPI_115.Migrations
{
    public partial class addEmployeeDepartmentsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDepartment_Departments_DepartmentId",
                table: "EmployeeDepartment");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDepartment_Employees_EmployeeId",
                table: "EmployeeDepartment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeDepartment",
                table: "EmployeeDepartment");

            migrationBuilder.RenameTable(
                name: "EmployeeDepartment",
                newName: "EmployeeDepartments");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeDepartment_DepartmentId",
                table: "EmployeeDepartments",
                newName: "IX_EmployeeDepartments_DepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeDepartments",
                table: "EmployeeDepartments",
                columns: new[] { "EmployeeId", "DepartmentId" });

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDepartments_Departments_DepartmentId",
                table: "EmployeeDepartments",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDepartments_Employees_EmployeeId",
                table: "EmployeeDepartments",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDepartments_Departments_DepartmentId",
                table: "EmployeeDepartments");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDepartments_Employees_EmployeeId",
                table: "EmployeeDepartments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeDepartments",
                table: "EmployeeDepartments");

            migrationBuilder.RenameTable(
                name: "EmployeeDepartments",
                newName: "EmployeeDepartment");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeDepartments_DepartmentId",
                table: "EmployeeDepartment",
                newName: "IX_EmployeeDepartment_DepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeDepartment",
                table: "EmployeeDepartment",
                columns: new[] { "EmployeeId", "DepartmentId" });

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDepartment_Departments_DepartmentId",
                table: "EmployeeDepartment",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDepartment_Employees_EmployeeId",
                table: "EmployeeDepartment",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
