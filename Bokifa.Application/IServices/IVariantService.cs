using Bokifa.Domain.DTOs.Variant;

namespace Bokifa.Application.IServices
{
    public interface IVariantService
    {
        Task<ICollection<VariantDto>> GetAllAsync();
        Task<VariantDto> GetByIdAsync(Guid id);
        Task<VariantDto> CreateAsync(CreateVariantDto dto);
        Task UpdateAsync(UpdateVariantDto dto);
        Task DeleteAsync(Guid id);
    }
}
