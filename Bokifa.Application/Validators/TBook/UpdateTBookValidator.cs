using Bokifa.Domain.DTOs.TBook;
using FluentValidation;

namespace Bokifa.Application.Validators.TBook
{
    public class UpdateTBookValidator : AbstractValidator<UpdateTBookDto>
    {
        public UpdateTBookValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
        }
    }
}
