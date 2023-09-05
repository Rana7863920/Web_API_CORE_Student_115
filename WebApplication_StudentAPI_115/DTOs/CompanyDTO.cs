using System.ComponentModel.DataAnnotations;
using Xunit.Sdk;

namespace WebApplication_StudentAPI_115.DTOs
{
    public class CompanyDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name cannot be empty")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Address cannot be empty")]
        public string Address { get; set; }
        [Required(ErrorMessage = "ProductId cannot be empty")]
        public int ProductId { get; set; }
    }
}
