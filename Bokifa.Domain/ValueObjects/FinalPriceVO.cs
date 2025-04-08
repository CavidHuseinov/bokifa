namespace Bokifa.Domain.ValueObjects
{
    public class FinalPriceVO
    {
        public decimal FinalPrice { get; }

        public FinalPriceVO(decimal price, decimal discount)
        {
            if (price < 0) throw new ArgumentException("Price cannot be negative.", nameof(price));
            if (discount < 0 || discount > 100) throw new ArgumentException("Discount must be between 0 and 100.", nameof(discount));

            FinalPrice = price - (price * discount / 100);
        }
    }

}
