using EvaluationSystem.Application.Models.AnswerModels.Dtos;
using FluentValidation;

namespace EvaluationSystem.Application.Validators
{
    public class AnswerDtoValidator : AbstractValidator<AnswerCreateDto>
    {
        public AnswerDtoValidator()
        {
            RuleFor(t => t.AnswerText)
                  .NotEmpty().WithMessage("Answer {PropertyName} can't be empty!")
                    .NotNull().WithMessage("Answer {PropertyName} can't be null!")
                    .Length(1, 255);
            RuleFor(t => t.Position)
                    .GreaterThan(-1).WithMessage("Answer {PropertyName} must be positive number!");
        }
    }
}
