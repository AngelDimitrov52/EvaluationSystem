using EvaluationSystem.Application.Models.QuestionModels.Dtos;
using FluentValidation;

namespace EvaluationSystem.Application.Helpers.Validators
{
    public class QuestionCreateDtoValidator : AbstractValidator<QuestionCreateDto>
    {

        public QuestionCreateDtoValidator()
        {
            RuleFor(t => t.Name)
              .NotEmpty().WithMessage("{PropertyName} can't be empty!")
              .NotNull().WithMessage("{PropertyName} can't be null!");
            //.OnAnyFailure(x => throw new HttpException("Invalid Name", HttpStatusCode.BadRequest));
        }
    }
}
