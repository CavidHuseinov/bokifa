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
    }
}
