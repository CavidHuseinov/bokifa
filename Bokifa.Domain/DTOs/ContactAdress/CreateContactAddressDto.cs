namespace Bokifa.Domain.DTOs.ContactAdress
{
    public record CreateContactAddressDto
    {
        public bool SendNotification { get; set; }
    }
}
