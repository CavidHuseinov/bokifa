namespace Bokifa.Domain.DTOs.Author
{
    public record CreateAuthorDto
    {
        public string Name { get; set; }
        public string ImgUrl { get; set; }
    }
}
