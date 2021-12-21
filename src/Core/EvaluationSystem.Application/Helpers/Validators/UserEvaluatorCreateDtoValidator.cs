using EvaluationSystem.Application.Models.AttestationAnswerModel.Dtos;
using FluentValidation;

namespace EvaluationSystem.Application.Helpers.Validators
{
    public class UserEvaluatorCreateDtoValidator : AbstractValidator<BodyUserAnswerCreateDto>
    {
        public UserEvaluatorCreateDtoValidator()
        {
            RuleFor(t => t.AnswerText)
              .NotEmpty().WithMessage("Body {PropertyName} can't be empty!")
              .NotNull().WithMessage("Body {PropertyName} can't be null!")
              .Length(1, 512);
            RuleFor(t => t.ModuleId)
                   .GreaterThan(0).WithMessage("Question {PropertyName} must be positive number!");
            RuleFor(t => t.QuestionId)
                  .GreaterThan(0).WithMessage("Question {PropertyName} must be positive number!");
        }
    }
}
