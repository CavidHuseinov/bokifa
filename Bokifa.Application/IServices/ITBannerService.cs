using Bokifa.Domain.DTOs.TBanner;

namespace Bokifa.Application.IServices
{
    public interface ITBannerService
    {
        Task<ICollection<TBannerDto>> GetAllAsync();
        Task<TBannerDto> GetByIdAsync(Guid id);
        Task<TBannerDto> CreateAsync(CreateTBannerDto dto);
        Task UpdateAsync(UpdateTBannerDto dto);
        Task DeleteAsync(Guid id);
    }
}
