using Bokifa.Domain.DTOs.BookAndCategory;
using Bokifa.Domain.DTOs.BookAndTag;
using Bokifa.Domain.DTOs.BookAndVariant;
using Bokifa.Domain.DTOs.Review;
using Bokifa.Domain.DTOs.TVariant;
using Bokifa.Domain.ValueObjects;
using Bookifa.Domain.Abstractions;

namespace Bokifa.Domain.DTOs.Book
{
    public record BookDto:BaseDto
    {
        public string ImgUrl { get; set; }
        public string Title { get; set; }
        public bool InStock { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public FinalPriceVO? FinalPrice => new FinalPriceVO(Price, Discount);
        public string Description { get; set; }
        public ICollection<BookAndCategoryDto>? Categories { get; set; }
        public ICollection<BookAndTagDto>? BookAndTags { get; set; }
        public string PrimaryLanguageType { get; set; }
        public ICollection<ReviewDto>? Comments { get; set; }
        public ICollection<TVariantDto>? TVariants { get; set; }
        public ICollection<BookAndVariantDto>? BookAndVariants { get; set; }
    }
}
