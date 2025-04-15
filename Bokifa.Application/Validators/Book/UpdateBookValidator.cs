using Bokifa.Domain.DTOs.Book;

namespace Bokifa.Application.Validators.Book
{
    public class UpdateBookValidator : AbstractValidator<UpdateBookDto>
    {
        public UpdateBookValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required");
            RuleFor(x => x.ImgUrl).NotEmpty().WithMessage("Image URL is required");
            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Price is required")
                .GreaterThan(0).WithMessage("Price must be greater than 0");
            RuleFor(x => x.Discount)
                .NotEmpty().WithMessage("Discount is required")
                .GreaterThanOrEqualTo(0).WithMessage("Discount must be greater than or equal to 0")
                .LessThanOrEqualTo(100).WithMessage("Discount must be less than or equal to 100");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
        }
    }
}
