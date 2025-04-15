using Bokifa.Domain.DTOs.Author;

namespace Bokifa.Application.IServices
{
    public interface IAuthorService
    {
        Task<ICollection<AuthorDto>> GetAllAsync();
        Task<AuthorDto> GetByIdAsync(Guid id);
        Task<AuthorDto> CreateAsync(CreateAuthorDto dto);
        Task UpdateAsync(UpdateAuthorDto dto);
        Task DeleteAsync(Guid id);
    }
}