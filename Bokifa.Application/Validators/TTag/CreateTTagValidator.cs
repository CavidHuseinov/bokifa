using Bokifa.Domain.DTOs.TTag;

namespace Bokifa.Application.Validators.TTag
{
    public class CreateTTagValidator : AbstractValidator<CreateTTagDto>
    {
        public CreateTTagValidator()
        {
            RuleFor(x => x.Name).NotEmpty(); 
        }
    }
}
