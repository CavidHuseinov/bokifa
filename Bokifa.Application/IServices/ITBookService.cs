using Bokifa.Domain.DTOs.TBook;

namespace Bokifa.Application.IServices
{
    public interface ITBookService
    {
        Task<ICollection<TBookDto>> GetAllAsync();
        Task<TBookDto> GetByIdAsync(Guid id);
        Task<TBookDto> CreateAsync(CreateTBookDto dto);
        Task UpdateAsync(UpdateTBookDto dto);
        Task DeleteAsync(Guid id);
    }
}
