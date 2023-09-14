using System.ComponentModel.DataAnnotations;

namespace WebApplication_StudentAPI_115.Models.ViewModels
{
    public class UserVM2
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Role { get; set; }
    }
}
