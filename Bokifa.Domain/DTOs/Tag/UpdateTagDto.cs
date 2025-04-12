namespace Bokifa.Domain.DTOs.Tag
{
    public record UpdateTagDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
