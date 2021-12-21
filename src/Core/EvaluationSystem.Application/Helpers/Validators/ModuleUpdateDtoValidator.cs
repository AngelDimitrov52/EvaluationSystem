using EvaluationSystem.Application.Models.ModuleModels.Dtos;
using FluentValidation;

namespace EvaluationSystem.Application.Helpers.Validators
{
    public class ModuleUpdateDtoValidator : AbstractValidator<ModuleUpdateDto>
    {
        public ModuleUpdateDtoValidator()
        {
            RuleFor(t => t.Name)
             .NotEmpty().WithMessage("Module {PropertyName} can't be empty!")
             .NotNull().WithMessage("Module {PropertyName} can't be null!")
             .Length(1, 255);

            RuleFor(t => t.Position)
                    .GreaterThan(-1).WithMessage("Module {PropertyName} must be positive number!");
        }
    }
}
