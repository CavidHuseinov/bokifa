using FluentValidation;
using Oxu.Domain.DTOs.User;

namespace Oxu.Application.Validators.UserValidators
{
    public class ForgetPassword : AbstractValidator<ForgotPasswordDto>
    {
        public ForgetPassword()
        {
            RuleFor(x=>x.Email).EmailAddress().WithMessage("Invalid email format");
        }
    }
}
