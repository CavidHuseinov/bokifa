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

    }
}
