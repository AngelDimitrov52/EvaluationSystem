using Application.ModelDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
   public class BookDtoValidator : AbstractValidator<BookDto>
    {
        public BookDtoValidator()
        {
            RuleFor(t => t.TitleDto)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} can't be empty!")
                .Length(2,12).WithMessage("The length of {PropertyName} must be baetlen 2 and 12 simbols!");

            RuleFor(t => t.AuthorNameDto)
                .NotNull()
                .NotEmpty().WithMessage("Author name can't be empty!");

            RuleFor(t => t.EmailDto)
                .EmailAddress().WithMessage("Invalid Email address .....................!");
        }
    }
}
