using FluentValidation;
using WebApplication_StudentAPI_115.Models.ViewModels;

namespace WebApplication_StudentAPI_115.Validator
{
    public class UserVMValidator:AbstractValidator<UserVM>
    {
        public UserVMValidator()
        {
            RuleFor(u => u.UserName)
                .NotEmpty()
                .WithMessage("{PropertyName} cannot be empty");

            RuleFor(u => u.Password)
                .NotEmpty()
                .WithMessage("{PropertyName} cannot be empty")
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$")
                .WithMessage("{PropertyName} must be 8-15 characters long and must contain a small and Capital letter along with a special character and a number");
        }
    }
}
