using System.ComponentModel.DataAnnotations;

namespace WebApplication_StudentAPI_115.Models.ViewModels
{
    public class UserVM2
    {
        [Required(ErrorMessage = "UserName cannot be empty")]
        public string UserName { get; set; }
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", ErrorMessage = "Password must be between 8 and 15 characters and contain one uppercase letter, one lowercase letter, one digit and one special character.")]
        [Required(ErrorMessage = "Password cannot be empty")]
        public string Password { get; set; }
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", ErrorMessage = "Password must be between 8 and 15 characters and contain one uppercase letter, one lowercase letter, one digit and one special character.")]
        [Required(ErrorMessage = "Confirm Password cannot be empty")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Role cannot be empty")]
        public string Role { get; set; }
    }
}
