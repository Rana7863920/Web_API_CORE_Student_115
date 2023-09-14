using FluentValidation;
using WebApplication_StudentAPI_115.Models;
using WebApplication_StudentAPI_115.Models.ViewModels;

namespace WebApplication_StudentAPI_115.Validator
{
    public class UserValidator:AbstractValidator<UserVM2>
    {
        public UserValidator()
        {
            RuleFor(u => u.UserName)
                .NotEmpty()
                .WithMessage("{PropertyName} cannot be empty");

            RuleFor(u => u.Password)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithMessage("{PropertyName} cannot be empty")
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$")
                .WithMessage("{PropertyName} must be 8-15 characters long and must contain a small and Capital letter along with a special character and a number");

            RuleFor(u => u.ConfirmPassword)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithMessage("{PropertyName} cannot be empty")
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$")
                .WithMessage("{PropertyName} must be 8-15 characters long and must contain a small and Capital letter along with a special character and a number")
                .Equal(u => u.Password)
                .WithMessage("{PropertyName} must be equals to Password");

            RuleFor(u => u.Role)
                .NotEmpty()
                .WithMessage("{PropertyName} cannot be empty");
        }
    }
}
