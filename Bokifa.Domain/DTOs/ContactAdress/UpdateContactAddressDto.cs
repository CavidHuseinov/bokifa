
namespace Bokifa.Domain.DTOs.ContactAdress
{
    public record UpdateContactAddressDto
    {
        public Guid Id { get; set; }
        public string NewPhoneNumber { get; set; }
    }
}
