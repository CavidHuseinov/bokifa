using Bokifa.Domain.DTOs.Author;

namespace Bokifa.Application.Validators.Author
{
    public class CreateAuthorValidator:AbstractValidator<CreateAuthorDto>
    {
        public CreateAuthorValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required");

            RuleFor(x => x.ImgUrl)
                .NotEmpty()
                .WithMessage("Image is required");
        }
    }
}
