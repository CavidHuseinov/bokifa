
using Bokifa.Domain.DTOs.ShippingInfo;

namespace Bokifa.Application.IServices
{
    public interface IShippingInfoService
    {
        Task<ShippingInfoDto> GetAsync();
        Task<ShippingInfoDto> CreateAsync(CreateShippingInfoDto dto);
        Task DeleteAsync(Guid id);
    }
}
