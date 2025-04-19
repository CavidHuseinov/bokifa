
using Bokifa.Domain.DTOs.NotificationModel;

namespace Bokifa.Application.Validators.NotificationModel
{
    public class CreateNotificationModelValidator : AbstractValidator<CreateNotificationModelDto>
    {
        public CreateNotificationModelValidator()
        {
            RuleFor(x => x.Email).EmailAddress()
                .WithMessage("Invalid email format")
                .NotEmpty()
                .WithMessage("Email is required");
        }
    }
}
