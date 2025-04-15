namespace Bokifa.Domain.DTOs.Author
{
    public record AuthorDto : BaseDto
    {
        public string Name { get; set; }
        public string ImgUrl { get; set; }
    }
}
