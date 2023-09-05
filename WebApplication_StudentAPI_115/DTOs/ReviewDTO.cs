using System.ComponentModel.DataAnnotations;
using Xunit.Sdk;

namespace WebApplication_StudentAPI_115.DTOs
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Title cannot be empty")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Description cannot be empty")]
        public string Description { get; set; }
        public int ReviewerId { get; set; }
    }
}
