using EvaluationSystem.Application.Models.QuestionModels.Dtos;
using FluentValidation;

namespace EvaluationSystem.Application.Helpers.Validators
{
    public class QuestionTemplateCreateDtoValidator : AbstractValidator<QuestionTemplateCreateDto>
    {
        public QuestionTemplateCreateDtoValidator()
        {
            RuleFor(t => t.Name)
              .NotEmpty().WithMessage("QuestionTemplate {PropertyName} can't be empty!")
              .NotNull().WithMessage("QuestionTemplate {PropertyName} can't be null!")
              .Length(1, 255);
        }
    }
}
