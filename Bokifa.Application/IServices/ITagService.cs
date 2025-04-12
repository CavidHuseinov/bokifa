using Bokifa.Domain.DTOs.Tag;

namespace Bokifa.Application.IServices
{
    public interface ITagService
    {
        Task<ICollection<TagDto>> GetAllAsync();
        Task<TagDto> GetByIdAsync(Guid id);
        Task<TagDto> CreateAsync(CreateTagDto dto);
        Task UpdateAsync(UpdateTagDto dto);
        Task DeleteAsync(Guid id);
    }
}
