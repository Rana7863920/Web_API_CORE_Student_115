using FluentValidation;
using FluentValidation.Validators;
using WebApplication_StudentAPI_115.Models;

namespace WebApplication_StudentAPI_115.Validator
{
    public class StudentValidator:AbstractValidator<Student>
    {
        public StudentValidator()
        {
            RuleFor(s => s.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} cannot be empty")
                .Length(2, 20)
                .Must(IsValidName).WithMessage("{PropertyName} must contain all letters");

            RuleFor(s => s.Address)
                .NotEmpty()
                .WithMessage("{PropertyName} cannot be empty");

            RuleFor(s => s.Email)
                .EmailAddress(EmailValidationMode.Net4xRegex);

            RuleFor(s => s.Subject)
                .NotEmpty()
                .WithMessage("{PropertyName} cannot be empty");

        }

        private bool IsValidName(string Name)
        {
            return Name.All(Char.IsLetter);
        }
    }
}
