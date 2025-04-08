using FluentValidation;
using Bookifa.Domain.DTOs.User;

namespace Bookifa.Application.Validators.UserValidators
{
    public class ForgetPassword : AbstractValidator<ForgotPasswordDto>
    {
        public ForgetPassword()
        {
            RuleFor(x=>x.Email).EmailAddress().WithMessage("Invalid email format");
        }
    }
}
