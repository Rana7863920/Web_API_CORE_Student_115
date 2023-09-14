using System.ComponentModel.DataAnnotations;
using Xunit.Sdk;

namespace WebApplication_StudentAPI_115.DTOs
{
    public class CompanyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int ProductId { get; set; }
    }
}
