using EvaluationSystem.Application.Models.QuestionModels.Dtos;
using FluentValidation;

namespace EvaluationSystem.Application.Helpers.Validators
{
    public class QuestionCreateDtoValidator : AbstractValidator<QuestionCreateDto>
    {
        public QuestionCreateDtoValidator()
        {
            RuleFor(t => t.Name)
              .NotEmpty().WithMessage("Question {PropertyName} can't be empty!")
              .NotNull().WithMessage("Question {PropertyName} can't be null!")
              .Length(1, 255);
            //.OnAnyFailure(x => throw new HttpException("Invalid Name", HttpStatusCode.BadRequest));
            RuleFor(t => t.Position)
                    .GreaterThan(-1).WithMessage("Question {PropertyName} must be positive number!");
        }
    }
}
