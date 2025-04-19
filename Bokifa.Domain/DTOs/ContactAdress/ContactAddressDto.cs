namespace Bokifa.Domain.DTOs.ContactAdress
{
    public record ContactAddressDto:BaseDto
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; } = default!;
        public bool IsConfirmed { get; set; }
        public DateTime? ConfirmedAt { get; set; }
        public string SendNotification { get; set; } = default!;
    }
}
