using System.ComponentModel.DataAnnotations;

namespace WebApplication_StudentAPI_115.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required(ErrorMessage = "Address cannot be empty")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Email cannot be empty")]

        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Subject cannot be emtpy")]
        public string Subject { get; set; }
    }
}
