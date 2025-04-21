using Bokifa.Domain.DTOs.Book;

namespace Bokifa.Application.IServices
{
    public interface IBookService
    {
        Task<ICollection<BookDto>> GetAllAsync();
        Task<BookDto> GetByIdAsync(Guid id);
        Task<BookDto> CreateAsync(CreateBookDto dto);
        Task UpdateAsync(UpdateBookDto dto);
        Task DeleteAsync(Guid id);
        Task<Dictionary<string, int>> GetBookCountsByAvailabilityAsync();
        Task<Dictionary<string, int>> GetBookCountsByFormatAsync();
        Task<Dictionary<string, int>> GetSpecialCategoriesCountAsync();
        Task<Dictionary<string, int>> GetBookCountsByRatingAsync();
        Task<Dictionary<string, Dictionary<string, int>>> GetAllFilterCountsAsync();
    }
}
