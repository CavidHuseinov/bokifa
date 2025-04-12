using Bokifa.Domain.Enums;
using Bokifa.Domain.ValueObjects;
using Bookifa.Domain.Abstractions;

namespace Bokifa.Domain.Entities
{
    public class Book : BaseEntity
    {
        public string ImgUrl { get; set; }
        public string Title { get; set; }
        public bool InStock { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public FinalPriceVO? FinalPrice => new FinalPriceVO(Price, Discount);
        public string Description { get; set; }
        public int Quantity { get; set; } = 1;
        public ICollection<BookAndCategory>? BookAndCategories { get; set; }
        public ICollection<TBook>? TBooks { get; set; }
        public PrimaryLanguageType PrimaryLanguageType { get; set; } = PrimaryLanguageType.English;
        public ICollection<BookAndTag>? BookAndTags {  get; set; }
        public ICollection<Review>? Comments { get; set; }

    }
}
