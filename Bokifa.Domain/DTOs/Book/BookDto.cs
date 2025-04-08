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
    }
}
