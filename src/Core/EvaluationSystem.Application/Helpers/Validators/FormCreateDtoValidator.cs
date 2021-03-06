using EvaluationSystem.Application.Models.FormModels.Dtos;
using FluentValidation;

namespace EvaluationSystem.Application.Helpers.Validators
{
    public class FormCreateDtoValidator : AbstractValidator<FormCreateDto>
    {
        public FormCreateDtoValidator()
        {
            RuleFor(t => t.Name)
                 .NotEmpty().WithMessage("Form {PropertyName} can't be empty!")
                    .NotNull().WithMessage("Form {PropertyName} can't be null!")
                    .Length(1, 255);
        }
    }
}
