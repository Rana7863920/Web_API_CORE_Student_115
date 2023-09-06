using System.ComponentModel.DataAnnotations;
using Xunit.Sdk;

namespace WebApplication_StudentAPI_115.DTOs
{
    public class BlogDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Title cannot be empty")]
        public string Title { get; set; }
    }
}
