namespace Bokifa.Domain.ValueObjects
{
    public class FinalPriceVO
    {
        public decimal FinalPrice { get; }

        public FinalPriceVO(decimal price, decimal? discount)
        {
            if (price < 0) throw new ArgumentException("Price cannot be negative.", nameof(price));

            if (discount == null)
            {
                FinalPrice = price;
            }
            else
            {
                FinalPrice = price - (price * discount.Value / 100);
            }
        }
    }

}
