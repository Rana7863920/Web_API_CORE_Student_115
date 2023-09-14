using FluentValidation;
using WebApplication_StudentAPI_115.DTOs;

namespace WebApplication_StudentAPI_115.Validator
{
    public class DepartmentValidator:AbstractValidator<DepartmentDTO>
    {
        public DepartmentValidator()
        {
            RuleFor(d => d.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} must not be empty")
                .Length(2, 20)
                .Must(IsValidName).WithMessage("{PropertyName} should be all letters");
        }

        private bool IsValidName(string Name)
        {
            return Name.All(Char.IsLetter);
        }
    }
}
