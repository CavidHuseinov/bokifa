using FluentValidation;
using Bookifa.Domain.DTOs.User;

namespace Bookifa.Application.Validators.UserValidators
{
    public class ResetPassword : AbstractValidator<ResetPasswordDto>
    {
        public ResetPassword()
        {
            RuleFor(x=>x.NewPassword)
               .NotEmpty().WithMessage("Password field must be provided")
               .MinimumLength(6).WithMessage("Password must be at least 6 characters long")
               .Matches(@"[a-z]").WithMessage("Password must contain at least one lowercase letter")
               .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter")
               .Matches(@"[0-9]").WithMessage("Password must contain at least one number");

            RuleFor(x => x.ConfirmPassword)
               .NotEmpty().WithMessage("EmailConfirmed field must be provided")
               .Equal(x => x.NewPassword).WithMessage("Passwords do not match");
        }
    }
}
