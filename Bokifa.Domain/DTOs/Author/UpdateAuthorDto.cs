namespace Bokifa.Domain.DTOs.Author
{
    public record UpdateAuthorDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ImgUrl { get; set; }
    }
}
