using Bokifa.Domain.DTOs.Tag;
using FluentValidation;

namespace Bokifa.Application.Validators.Tag
{
    public class UpdateTagValidator : AbstractValidator<UpdateTagDto>
    {
        public UpdateTagValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
