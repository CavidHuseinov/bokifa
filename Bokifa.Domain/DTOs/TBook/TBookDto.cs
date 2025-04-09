using Bokifa.Domain.DTOs.Book;
using Bokifa.Domain.Enums;
using Bokifa.Domain.ValueObjects;
using Bookifa.Domain.Abstractions;

namespace Bokifa.Domain.DTOs.TBook
{
    public record TBookDto:BaseDto
    {
        public string LanguageType { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public BookDto Book { get; set; }
    }
}
