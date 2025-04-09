using Bokifa.Domain.Enums;
using Bokifa.Domain.ValueObjects;

namespace Bokifa.Domain.DTOs.TBook
{
    public record CreateTBookDto
    {
        public LanguageType LanguageType { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid BookId { get; set; }
    }
}
