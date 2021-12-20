using EvaluationSystem.Application.Models.AnswerModels.Dtos;
using FluentValidation;

namespace EvaluationSystem.Application.Validators
{
    public class AnswerDtoValidator : AbstractValidator<AnswerCreateDto>
    {
        public AnswerDtoValidator()
        {
            RuleFor(t => t.AnswerText)
                  .NotEmpty().WithMessage("{PropertyName} can't be empty!")
                    .NotNull().WithMessage("{PropertyName} can't be null!")
                    .Length(1, 255);
        }
    }
}
