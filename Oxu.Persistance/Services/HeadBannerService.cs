using AutoMapper;
using Bokifa.Application.IServices;
using Bokifa.Domain.DTOs.HeadBanner;
using Bokifa.Domain.Entities;
using Bokifa.Domain.IRepositories;
using Microsoft.Extensions.Caching.Memory;
using Oxu.Domain.IRepositories.Generics;
using Oxu.Persistance.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bokifa.Persistance.Services
{
    public class HeadBannerService : IHeadBannerService
    {
        private readonly IHeadBannerRepo _command;
        private readonly IQueryRepository<HeadBanner> _query;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private readonly IUnitOfWork _work;
        private readonly string cacheKey = "HeadBanners";
        public HeadBannerService(IHeadBannerRepo command,
                                 IQueryRepository<HeadBanner> query,
                                 IMapper mapper,
                                 IMemoryCache cache,
                                 IUnitOfWork work)
        {
            _command = command;
            _query = query;
            _mapper = mapper;
            _cache = cache;
            _work = work;
        }

        public async Task<ICollection<HeadBannerDto>> GetAllAsync()
        {
            if (_cache.TryGetValue(cacheKey, out ICollection<HeadBanner>? cachedBanners))
            {
                return _mapper.Map<ICollection<HeadBannerDto>>(cachedBanners);
            }
            var banners = await _query.GetAllAsync();
            _cache.Set(cacheKey, banners);
            return _mapper.Map<ICollection<HeadBannerDto>>(banners);
        }

        public async Task<HeadBannerDto> GetByIdAsync(Guid id)
        {
            var bannerId =await _query.GetByIdAsync(id);
            if (bannerId == null)
            {
                throw new Exception("Banner not found");
            }
            return _mapper.Map<HeadBannerDto>(bannerId);
        }
        public async Task<HeadBannerDto> CreateAsync(CreateHeadBannerDto dto)
        {
            var banner = _mapper.Map<HeadBanner>(dto);
            var newBanner = await _command.CreateAsync(banner);
            await _work.SaveChangeAsync();

            if(_cache.TryGetValue(cacheKey, out IReadOnlyCollection<HeadBannerDto> cachedBanners))
            {
                var newBannerDto = _mapper.Map<HeadBannerDto>(newBanner);
                var updatedBanners = cachedBanners.Append(newBannerDto).ToList().AsReadOnly();
                _cache.Set(cacheKey, updatedBanners);
            }
            return _mapper.Map<HeadBannerDto>(newBanner);
        }
        public async Task UpdateAsync(UpdateHeadBannerDto dto)
        {
            var existingBanner = await _query.GetByIdAsync(dto.Id);
            if (existingBanner == null)
            {
                throw new KeyNotFoundException("Banner not found");
            }

            _mapper.Map(dto, existingBanner);
            await _command.UpdateAsync(existingBanner);
            await _work.SaveChangeAsync();

            if (_cache.TryGetValue(cacheKey, out Dictionary<Guid, HeadBanner> cachedDict) && cachedDict.ContainsKey(dto.Id))
            {
                var updatedCache = new Dictionary<Guid, HeadBanner>(cachedDict)
                {
                    [dto.Id] = existingBanner
                };

                _cache.Set(cacheKey, updatedCache);
            }
        }
        public async Task DeleteAsync(Guid id)
        {
            var bannerId = await _query.GetByIdAsync(id);
            if (bannerId == null)
            {
                throw new KeyNotFoundException("Banner not found");
            }
            await _command.DeleteAsync(bannerId);
            await _work.SaveChangeAsync();
            if (_cache.TryGetValue(cacheKey, out Dictionary<Guid, HeadBanner> cachedDict) && cachedDict.ContainsKey(id))
            {
                var updatedCache = new Dictionary<Guid, HeadBanner>(cachedDict);
                updatedCache.Remove(id);
                _cache.Set(cacheKey, updatedCache);
            }
        }
    }
}
