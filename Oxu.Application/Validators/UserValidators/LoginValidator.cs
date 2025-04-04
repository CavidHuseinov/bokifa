using FluentValidation;
using Oxu.Domain.DTOs.User;

namespace Oxu.Application.Validators.UserValidators
{
    public class LoginValidator : AbstractValidator<LoginDto>
    {
        public LoginValidator()
        {
            RuleFor(x => x.UsernameOrEmail).NotEmpty().WithMessage("Username or email field must be provided");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password field must be provided");
        }
    }
}
