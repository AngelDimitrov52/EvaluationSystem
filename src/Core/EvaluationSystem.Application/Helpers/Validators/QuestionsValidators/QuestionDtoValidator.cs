using EvaluationSystem.Application.Models.QuestionModels.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Application.Helpers.Validators
{
    public class QuestionDtoValidator : AbstractValidator<QuestionCreateDto>
    {
        public QuestionDtoValidator()
        {
            RuleFor(t => t.Name)
                .NotEmpty().WithMessage("{PropertyName} can't be empty!")
                .NotNull().WithMessage("{PropertyName} can't be null!")
                .Length(2, 4).WithMessage("Length must be between 2 and 4");
        }
    }
}
