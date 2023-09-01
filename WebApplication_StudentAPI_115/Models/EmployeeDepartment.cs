namespace WebApplication_StudentAPI_115.Models
{
    public class EmployeeDepartment
    {
        public int EmployeeId { get; set; }
        public int DepartmentId { get; set; }
        public Employee Employee { get; set; }
        public Department Department { get; set; }
    }
}
