using Bokifa.Domain.DTOs.Book;

namespace Bokifa.Domain.DTOs.TBook
{
    public record TBookDto : BaseDto
    {
        public string LanguageType { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public BookDto Book { get; set; }
    }
}
