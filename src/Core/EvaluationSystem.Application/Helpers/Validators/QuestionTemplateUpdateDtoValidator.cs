using EvaluationSystem.Application.Models.QuestionModels.Dtos;
using FluentValidation;

namespace EvaluationSystem.Application.Helpers.Validators
{
    public class QuestionTemplateUpdateDtoValidator : AbstractValidator<QuestionTemplateUpdateDto>
    {
        public QuestionTemplateUpdateDtoValidator()
        {
            RuleFor(t => t.Name)
              .NotEmpty().WithMessage("QuestionTemplate {PropertyName} can't be empty!")
              .NotNull().WithMessage("QuestionTemplate {PropertyName} can't be null!")
              .Length(1, 255);
        }

    }
}
