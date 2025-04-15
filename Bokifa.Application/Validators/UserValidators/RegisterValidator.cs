using Bookifa.Domain.DTOs.User;

namespace Bookifa.Application.Validators.UserValidators
{
    public sealed class RegisterValidator : AbstractValidator<RegisterDto>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Name)
               .NotEmpty().WithMessage("Name field must be provided")
               .Matches(@"^[a-zA-Z]+$").WithMessage("Name can only contain letters")
               .MinimumLength(2).WithMessage("Your name must be at least 2 characters long")
               .MaximumLength(20).WithMessage("Your name must not exceed 20 characters");
            RuleFor(x => x.Surname)
               .NotEmpty().WithMessage("Surname field must be provided")
               .Matches(@"^[a-zA-Z]+$").WithMessage("Surname can only contain letters")
               .MinimumLength(2).WithMessage("Your surname must be at least 2 characters long")
               .MaximumLength(30).WithMessage("Your name must not exceed 30 characters");
            RuleFor(x => x.Username)
               .NotEmpty().WithMessage("Username field must be provided")
               .MinimumLength(3).WithMessage("Your username must be at least 3 characters long")
               .MaximumLength(30).WithMessage("Your username must not exceed 30 characters")
               .Matches(@"^[a-zA-Z0-9_\-\.]+$").WithMessage("Username can only contain letters, digits, '-', '_', and '.'");
            RuleFor(x => x.Email)
               .NotEmpty().WithMessage("Email field must be provided")
               .EmailAddress().WithMessage("Invalid email format");
            RuleFor(x => x.Password)
               .NotEmpty().WithMessage("Password field must be provided")
               .MinimumLength(8).WithMessage("Password must be at least 8 characters long")
               .Matches(@"[a-z]").WithMessage("Password must contain at least one lowercase letter")
               .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter")
               .Matches(@"[0-9]").WithMessage("Password must contain at least one number");
            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage("EmailConfirmed field must be provided")
               .Equal(x => x.Password).WithMessage("EmailConfirmed field must be provided");
        }
    }
}
