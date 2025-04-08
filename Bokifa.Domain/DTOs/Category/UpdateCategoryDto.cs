namespace Bokifa.Domain.DTOs.Category
{
    public record UpdateCategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
