using Bokifa.Domain.DTOs.Review;
using FluentValidation;

namespace Bokifa.Application.Validators.Review
{
    public class CreateReviewValidator : AbstractValidator<CreateReviewDto>
    {
        public CreateReviewValidator()
        {
            RuleFor(x => x.Rating)
                .InclusiveBetween(1, 5)
                .WithMessage("Rating must be between 1 and 5.");
        }
    }
}
