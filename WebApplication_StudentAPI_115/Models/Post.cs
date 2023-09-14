
using System.ComponentModel.DataAnnotations;

namespace WebApplication_StudentAPI_115.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
