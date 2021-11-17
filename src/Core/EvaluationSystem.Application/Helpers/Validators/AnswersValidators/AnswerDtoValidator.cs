using EvaluationSystem.Application.Models.AnswerModels.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Application.Validators
{
    public class AnswerDtoValidator : AbstractValidator<AnswerCreateDto>
    {
        public AnswerDtoValidator()
        {
            RuleFor(t => t.AnswerText)
                  .NotEmpty().WithMessage("{PropertyName} can't be empty!")
                    .NotNull().WithMessage("{PropertyName} can't be null!")
                .Length(2, 4).WithMessage("Length must be between 2 and 4");
        }
    }
}
