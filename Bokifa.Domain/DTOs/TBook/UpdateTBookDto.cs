using Bokifa.Domain.Enums;
using Bokifa.Domain.ValueObjects;

namespace Bokifa.Domain.DTOs.TBook
{
    public record UpdateTBookDto
    {
        public Guid Id { get; set; }
        public LanguageType LanguageType { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid BookId { get; set; }
    }
}
