using EvaluationSystem.Application.Models.FormModels.Dtos;
using FluentValidation;

namespace EvaluationSystem.Application.Helpers.Validators
{
    public class FormCreateDtoValidator : AbstractValidator<FormCreateDto>
    {
        public FormCreateDtoValidator()
        {
            RuleFor(t => t.Name)
                 .NotEmpty().WithMessage("{PropertyName} can't be empty!")
                    .NotNull().WithMessage("{PropertyName} can't be null!");
        }
    }
}
