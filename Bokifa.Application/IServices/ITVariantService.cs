using Bokifa.Domain.DTOs.TVariant;

namespace Bokifa.Application.IServices
{
    public interface ITVariantService
    {
        Task<ICollection<TVariantDto>> GetAllAsync();
        Task<TVariantDto> GetByIdAsync(Guid id);
        Task<TVariantDto> CreateAsync(CreateTVariantDto dto);
        Task UpdateAsync(UpdateTVariantDto dto);
        Task DeleteAsync(Guid id);
    }
}
