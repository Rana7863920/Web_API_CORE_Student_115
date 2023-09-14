

using System.ComponentModel.DataAnnotations;

namespace WebApplication_StudentAPI_115.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
