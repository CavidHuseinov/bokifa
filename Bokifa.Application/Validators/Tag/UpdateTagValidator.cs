using Bokifa.Domain.DTOs.Tag;

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
