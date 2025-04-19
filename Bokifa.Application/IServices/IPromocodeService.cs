
using Bokifa.Domain.DTOs.Promocode;

namespace Bokifa.Application.IServices
{
    public interface IPromocodeService
    {
        Task<ICollection<PromocodeDto>> GetAllAsync();
        Task<PromocodeDto> GetByIdAsync(Guid id);
        Task<PromocodeDto> CreateAsync(CreatePromocodeDto dto);
        Task UpdateAsync(UpdatePromocodeDto dto);
        Task DeleteAsync(Guid id);
        Task<bool> IsPromocodeValid(string code);
    }
}
