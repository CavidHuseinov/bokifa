namespace Bookifa.Domain.DTOs.Contact
{
    public record ContactFormDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
    }
}
