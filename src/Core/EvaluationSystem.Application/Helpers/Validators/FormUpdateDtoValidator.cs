using EvaluationSystem.Application.Models.FormModels.Dtos;
using FluentValidation;

namespace EvaluationSystem.Application.Helpers.Validators
{
    public class FormUpdateDtoValidator : AbstractValidator<FormUpdateDto>
    {
        public FormUpdateDtoValidator()
        {
            RuleFor(t => t.Name)
                 .NotEmpty().WithMessage("Form {PropertyName} can't be empty!")
                    .NotNull().WithMessage("Form {PropertyName} can't be null!")
                    .Length(1, 255);
        }
    }
}
