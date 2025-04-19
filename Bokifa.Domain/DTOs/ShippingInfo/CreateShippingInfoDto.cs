
namespace Bokifa.Domain.DTOs.ShippingInfo
{
    public record CreateShippingInfoDto
    {
        public string? Country { get; set; }
        public string Address { get; set; }
        public string Apartment { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public bool SaveInformation { get; set; }
    }
}
