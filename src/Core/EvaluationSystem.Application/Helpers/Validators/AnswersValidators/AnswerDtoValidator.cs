
using EvaluationSystem.Application.Models.AnswerModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Application.Validators
{
    public class AnswerDtoValidator : AbstractValidator<AnswerDto>
    {
        public AnswerDtoValidator()
        {
            RuleFor(t => t.Title)
                  .NotEmpty().WithMessage("{PropertyName} can't be empty!");
        }
    }
}
