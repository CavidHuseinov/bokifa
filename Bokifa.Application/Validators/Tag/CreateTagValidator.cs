using Bokifa.Domain.DTOs.Tag;

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
