using FluentValidation;
using WebApplication_StudentAPI_115.DTOs;
using WebApplication_StudentAPI_115.Models;

namespace WebApplication_StudentAPI_115.Validator
{
    public class PostValidator:AbstractValidator<PostDTO>
    {
        public PostValidator()
        {
            RuleFor(p => p.Title)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithMessage("{PropertyName} should not be empty!!")
                .Length(2, 20);
            RuleFor(p => p.Description)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithMessage("{PropertyName} should not be empty")
                .Length(10, 100);
        }
    }
}
