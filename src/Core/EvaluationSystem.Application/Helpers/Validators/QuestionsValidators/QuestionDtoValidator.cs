using EvaluationSystem.Application.Models.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationSystem.Application.Helpers.Validators
{
   public class QuestionDtoValidator : AbstractValidator<QuestionDto>
    {
        public QuestionDtoValidator()
        {
            RuleFor(t => t.Title)
                .NotEmpty().WithMessage("{PropertyName} can't be empty!");
        }
    }
}
