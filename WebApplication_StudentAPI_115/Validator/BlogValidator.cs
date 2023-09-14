using FluentValidation;
using WebApplication_StudentAPI_115.DTOs;

namespace WebApplication_StudentAPI_115.Validator
{
    public class BlogValidator:AbstractValidator<BlogDTO>
    {
        public BlogValidator()
        {
            RuleFor(b => b.Title)
                .NotEmpty()
                .WithMessage("{PropertyName} cannot be empty!!");
        }
    }
}
