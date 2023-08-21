using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication_StudentAPI_115.Models.ViewModels
{
    public class UserVM
    {
        [Required(ErrorMessage = "UserName cannot be empty")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password cannot be empty")]
        public string Password { get; set; }
    }
}
