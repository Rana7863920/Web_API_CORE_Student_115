using System.ComponentModel.DataAnnotations;

namespace WebApplication_StudentAPI_115.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
    }
}
