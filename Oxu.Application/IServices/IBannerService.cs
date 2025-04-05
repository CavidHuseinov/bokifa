using Bokifa.Domain.DTOs.Banner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bokifa.Application.IServices
{
    public interface IBannerService
    {
        Task<ICollection<BannerDto>> GetAllAsync();
        Task<BannerDto> GetByIdAsync(Guid id);
        Task<BannerDto> CreateAsync(CreateBannerDto dto);
        Task UpdateAsync(UpdateBannerDto dto);
        Task DeleteAsync(Guid id);
    }
}
