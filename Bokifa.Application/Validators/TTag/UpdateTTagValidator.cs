using Bokifa.Domain.DTOs.TTag;
using FluentValidation;

namespace Bokifa.Application.Validators.TTag
{
    public class UpdateTTagValidator : AbstractValidator<UpdateTTagDto>
    {
        public UpdateTTagValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
