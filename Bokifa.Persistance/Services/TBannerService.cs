using AutoMapper;
using Bokifa.Application.IServices;
using Bokifa.Domain.DTOs.TBanner;
using Bokifa.Domain.DTOs.TBanner;
using Bokifa.Domain.Entities;
using Bokifa.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Bookifa.Domain.IRepositories.Generics;
using Bookifa.Persistance.UnitOfWorks;

namespace Bokifa.Persistance.Services
{
    public class TBannerService : ITBannerService
    {
        private readonly IMapper _mapper;
        private readonly ITBannerRepo _command;
        private readonly IQueryRepository<TBanner> _query;
        private readonly IMemoryCache _cache;
        private readonly IUnitOfWork _work;
        private readonly string cacheKey = "TBanners";

        public TBannerService(IUnitOfWork work, IMemoryCache cache, IQueryRepository<TBanner> query, ITBannerRepo command, IMapper mapper)
        {
            _work = work;
            _cache = cache;
            _query = query;
            _command = command;
            _mapper = mapper;
        }
        public async Task<ICollection<TBannerDto>> GetAllAsync()
        {
            if (_cache.TryGetValue(cacheKey, out Dictionary<Guid, TBanner>? cachedDict))
            {
                return _mapper.Map<ICollection<TBannerDto>>(cachedDict.Values);
            }

            var banners = await _query.GetAllAsync(
                include:q=>q.Include(x=>x.Banner));
            var bannerDict = banners.ToDictionary(b => b.Id);
            _cache.Set(cacheKey, bannerDict);
            return _mapper.Map<ICollection<TBannerDto>>(banners);
        }

        public async Task<TBannerDto> GetByIdAsync(Guid id)
        {
            var bannerId = await _query.GetByIdAsync(id);
            if (bannerId == null)
            {
                throw new Exception("Banner not found");
            }
            return _mapper.Map<TBannerDto>(bannerId);
        }
        public async Task<TBannerDto> CreateAsync(CreateTBannerDto dto)
        {
            var banner = _mapper.Map<TBanner>(dto);
            var newBanner = await _command.CreateAsync(banner);
            await _work.SaveChangeAsync();
            if (_cache.TryGetValue(cacheKey, out Dictionary<Guid, TBanner> cachedDict))
            {
                var updatedCache = new Dictionary<Guid, TBanner>(cachedDict)
                {
                    [newBanner.Id] = newBanner
                };
                _cache.Set(cacheKey, updatedCache);
            }
            else
            {
                var newCache = new Dictionary<Guid, TBanner>
                {
                    [newBanner.Id] = newBanner
                };
                _cache.Set(cacheKey, newCache);
            }
            return _mapper.Map<TBannerDto>(newBanner);
        }
        public async Task UpdateAsync(UpdateTBannerDto dto)
        {
            var existingBanner = await _query.GetByIdAsync(dto.Id);
            if (existingBanner == null)
            {
                throw new KeyNotFoundException("Banner not found");
            }

            _mapper.Map(dto, existingBanner);
            await _command.UpdateAsync(existingBanner);
            await _work.SaveChangeAsync();

            if (_cache.TryGetValue(cacheKey, out Dictionary<Guid, TBanner> cachedDict) && cachedDict.ContainsKey(dto.Id))
            {
                var updatedCache = new Dictionary<Guid, TBanner>(cachedDict)
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
            if (_cache.TryGetValue(cacheKey, out Dictionary<Guid, TBanner> cachedDict) && cachedDict.ContainsKey(id))
            {
                var updatedCache = new Dictionary<Guid, TBanner>(cachedDict);
                updatedCache.Remove(id);
                _cache.Set(cacheKey, updatedCache);
            }
        }
    }
}
