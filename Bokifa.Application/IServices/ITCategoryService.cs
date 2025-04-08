using Bokifa.Domain.DTOs.TCategory;

namespace Bokifa.Application.IServices
{
    public interface ITCategoryService
    {
        Task<ICollection<TCategoryDto>> GetAllAsync();
        Task<TCategoryDto> GetByIdAsync(Guid id);
        Task<TCategoryDto> CreateAsync(CreateTCategoryDto dto);
        Task UpdateAsync(UpdateTCategoryDto dto);
        Task DeleteAsync(Guid id);
    }
}
