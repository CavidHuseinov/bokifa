using Bokifa.Domain.DTOs.Category;

namespace Bokifa.Application.IServices
{
    public interface ICategoryService
    {
        Task<ICollection<CategoryDto>> GetAllAsync();
        Task<CategoryDto> GetByIdAsync(Guid id);
        Task<CategoryDto> CreateAsync(CreateCategoryDto dto);
        Task UpdateAsync(UpdateCategoryDto dto);
        Task DeleteAsync(Guid id);
    }
}
