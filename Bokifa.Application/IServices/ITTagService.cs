using Bokifa.Domain.DTOs.TTag;

namespace Bokifa.Application.IServices
{
    public interface ITTagService
    {
        Task<ICollection<TTagDto>> GetAllAsync();
        Task<TTagDto> GetByIdAsync(Guid id);
        Task<TTagDto> CreateAsync(CreateTTagDto dto);
        Task UpdateAsync(UpdateTTagDto dto);
        Task DeleteAsync(Guid id);
    }
}
