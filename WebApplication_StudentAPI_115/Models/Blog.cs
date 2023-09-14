using System.ComponentModel.DataAnnotations;
using WebApplication_StudentAPI_115.DTOs;

namespace WebApplication_StudentAPI_115.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<Post> Posts { get; set; } = new List<Post>();
    }
}
