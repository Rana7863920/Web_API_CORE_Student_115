using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication_StudentAPI_115.Models.ViewModels
{
    public class UserVM
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
