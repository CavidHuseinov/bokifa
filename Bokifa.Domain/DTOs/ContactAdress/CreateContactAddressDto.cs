namespace Bokifa.Domain.DTOs.ContactAdress
{
    public record CreateContactAddressDto
    {
        public string PhoneNumber { get; set; }
        public bool SendNotification { get; set; }
    }
}
