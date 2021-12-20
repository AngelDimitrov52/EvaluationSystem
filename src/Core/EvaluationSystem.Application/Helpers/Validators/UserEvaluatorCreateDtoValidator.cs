using EvaluationSystem.Application.Models.AttestationAnswerModel.Dtos;
using FluentValidation;

namespace EvaluationSystem.Application.Helpers.Validators
{
    class UserEvaluatorCreateDtoValidator : AbstractValidator<BodyUserAnswerCreateDto>
    {
        public UserEvaluatorCreateDtoValidator()
        {
            RuleFor(t => t.AnswerText)
              .NotEmpty().WithMessage("{PropertyName} can't be empty!")
              .NotNull().WithMessage("{PropertyName} can't be null!")
              .Length(1, 512);
        }
    }
}
