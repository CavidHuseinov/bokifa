using Bokifa.Domain.DTOs.THeadBanner;

namespace Bokifa.Application.IServices
{
    public interface ITHeadBannerService
    {
        Task<ICollection<THeadBannerDto>> GetAllAsync();
        Task<THeadBannerDto> GetByIdAsync(Guid id);
        Task<THeadBannerDto> CreateAsync(CreateTHeadBannerDto dto);
        Task UpdateAsync (UpdateTHeadBannerDto dto);
        Task DeleteAsync(Guid id);
    }
}
