using FluentValidation;
using WebApplication_StudentAPI_115.DTOs;

namespace WebApplication_StudentAPI_115.Validator
{
    public class CompanyValidator:AbstractValidator<CompanyDTO>
    {
        public CompanyValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} cannot be empty")
                .Length(2, 20)
                .Must(IsValidName).WithMessage("{PropertyName} must contain all letters");

            RuleFor(c => c.Address)
                .NotEmpty()
                .WithMessage("{PropertyName} cannot be empty");

            RuleFor(c => c.ProductId)
                .NotEmpty()
                .WithMessage("{PropertyName} cannot be emtpy");
        }

        private bool IsValidName(string name)
        {
            return name.All(Char.IsLetter);
        }
    }
}
