using System.ComponentModel.DataAnnotations;
using Xunit.Sdk;

namespace WebApplication_StudentAPI_115.DTOs
{
    public class PostDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int BlogId { get; set; }
    }
}
