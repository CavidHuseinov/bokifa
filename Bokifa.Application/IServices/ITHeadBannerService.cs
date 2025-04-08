using Bokifa.Domain.DTOs.THeadBanner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
