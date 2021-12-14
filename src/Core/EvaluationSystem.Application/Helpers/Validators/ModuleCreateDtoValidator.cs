using EvaluationSystem.Application.Models.ModuleModels.Dtos;
using FluentValidation;

namespace EvaluationSystem.Application.Helpers.Validators
{
    public class ModuleCreateDtoValidator : AbstractValidator<ModuleCreateDto>
    {
        public ModuleCreateDtoValidator()
        {
            RuleFor(t => t.Name)
             .NotEmpty().WithMessage("{PropertyName} can't be empty!")
             .NotNull().WithMessage("{PropertyName} can't be null!");
            // .OnAnyFailure(x => throw new HttpException("Invalid Name", HttpStatusCode.BadRequest));
        }
    }
}
