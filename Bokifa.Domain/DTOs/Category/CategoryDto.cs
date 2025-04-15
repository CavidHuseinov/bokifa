namespace Bokifa.Domain.DTOs.Category
{
    public record CategoryDto : BaseDto
    {
        public string Name { get; set; }
        public string PrimaryLanguageType { get; set; }

    }
}
