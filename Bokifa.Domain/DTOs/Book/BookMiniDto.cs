using Bokifa.Domain.ValueObjects;
using Bookifa.Domain.Abstractions;

namespace Bokifa.Domain.DTOs.Book
{
    public record BookMiniDto:BaseDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public FinalPriceVO? FinalPrice => new FinalPriceVO(Price, Discount);
    }
}
