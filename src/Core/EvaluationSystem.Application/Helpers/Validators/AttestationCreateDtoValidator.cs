using EvaluationSystem.Application.Models.AttestationModels.Dtos;
using FluentValidation;

namespace EvaluationSystem.Application.Helpers.Validators
{
    public class AttestationCreateDtoValidator : AbstractValidator<AttestationCreateDto>
    {
        public AttestationCreateDtoValidator()
        {
            RuleFor(t => t.User.Email)
              .NotEmpty().WithMessage("{PropertyName} can't be empty!")
              .NotNull().WithMessage("{PropertyName} can't be null!");
            RuleFor(t => t.User.Name)
           .NotEmpty().WithMessage("{PropertyName} can't be empty!")
           .NotNull().WithMessage("{PropertyName} can't be null!");
        }
    }
}
