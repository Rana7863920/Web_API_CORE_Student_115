
using System.ComponentModel.DataAnnotations;

namespace WebApplication_StudentAPI_115.Models
{
    public class Post
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Title cannot be empty")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Description cannot be empty")]
        public string Description { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
