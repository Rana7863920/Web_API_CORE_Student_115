using System.ComponentModel.DataAnnotations;
using Xunit.Sdk;

namespace WebApplication_StudentAPI_115.DTOs
{
    public class ReviewerDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "First Name cannot be empty")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name cannot be empty")]
        public string LastName { get; set; }
    }
}
