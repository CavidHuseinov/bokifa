
namespace Bokifa.Domain.DTOs.Currency
{
    public record CurrencyDto
    {
        public string? Code { get; set; }
        public string? Symbol { get; set; }
        public decimal RateToBase { get; set; }

    }
}
