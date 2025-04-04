using Bokifa.Domain.DTOs.HeadBanner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bokifa.Application.IServices
{
    public interface IHeadBannerService
    {
        Task<ICollection<HeadBannerDto>> GetAllAsync();
        Task<HeadBannerDto> GetByIdAsync(Guid id);
        Task<HeadBannerDto> CreateAsync(CreateHeadBannerDto dto);
        Task UpdateAsync(UpdateHeadBannerDto dto);
        Task DeleteAsync(Guid id);
    }
}
