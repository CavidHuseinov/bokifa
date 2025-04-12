using Bokifa.Domain.DTOs.Tag;
using FluentValidation;

namespace Bokifa.Application.Validators.Tag
{
    public class CreateTagValidator:AbstractValidator<CreateTagDto>
    {
        public CreateTagValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
