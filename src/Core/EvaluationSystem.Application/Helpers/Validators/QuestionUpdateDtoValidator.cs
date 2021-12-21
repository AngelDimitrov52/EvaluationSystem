using EvaluationSystem.Application.Models.QuestionModels.Dtos;
using FluentValidation;

namespace EvaluationSystem.Application.Helpers.Validators
{
    public class QuestionUpdateDtoValidator : AbstractValidator<QuestionUpdateDto>
    {
        public QuestionUpdateDtoValidator()
        {
            RuleFor(t => t.Name)
              .NotEmpty().WithMessage("Question {PropertyName} can't be empty!")
              .NotNull().WithMessage("Question {PropertyName} can't be null!")
              .Length(1, 255);
            RuleFor(t => t.Position)
                   .GreaterThan(-1).WithMessage("Question {PropertyName} must be positive number!");
        }

    }
}
