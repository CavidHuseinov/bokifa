using AutoMapper;
using Bokifa.Application.IServices;
using Bokifa.Domain.DTOs.Banner;
using Bokifa.Domain.DTOs.Banner;
using Bokifa.Domain.Entities;
using Bokifa.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Bookifa.Domain.IRepositories.Generics;
using Bookifa.Persistance.UnitOfWorks;

namespace Bokifa.Persistance.Services
{
    public class BannerService : IBannerService
    {
        private readonly IUnitOfWork _work;
        private readonly IMapper _mapper;
        private readonly IBannerRepo _command;
        private readonly IQueryRepository<Banner> _query;
        private readonly IMemoryCache _cache;
        private readonly string cacheKey = "banners";
        public BannerService(IUnitOfWork unitOfWork, IMapper mapper, IBannerRepo command, IQueryRepository<Banner> query, IMemoryCache cache)
        {
            _work = unitOfWork;
            _mapper = mapper;
            _command = command;
            _query = query;
            _cache = cache;
        }
        public async Task<ICollection<BannerDto>> GetAllAsync()
        {
            if (_cache.TryGetValue(cacheKey, out Dictionary<Guid, Banner>? cachedDict))
            {
                return _mapper.Map<ICollection<BannerDto>>(cachedDict.Values);
            }

            var banners = await _query.GetAllAsync();
            var bannerDict = banners.ToDictionary(b => b.Id);
            _cache.Set(cacheKey, bannerDict);
            return _mapper.Map<ICollection<BannerDto>>(banners);
        }

        public async Task<BannerDto> GetByIdAsync(Guid id)
        {
            var bannerId = await _query.GetByIdAsync(id);
            if (bannerId == null)
            {
                throw new Exception("Banner not found");
            }
            return _mapper.Map<BannerDto>(bannerId);
        }
        public async Task<BannerDto> CreateAsync(CreateBannerDto dto)
        {
            var banner = _mapper.Map<Banner>(dto);
            var newBanner = await _command.CreateAsync(banner);
            await _work.SaveChangeAsync();

            if (_cache.TryGetValue(cacheKey, out Dictionary<Guid, Banner> cachedDict))
            {
                var updatedCache = new Dictionary<Guid, Banner>(cachedDict)
                {
                    [newBanner.Id] = newBanner
                };
                _cache.Set(cacheKey, updatedCache);
            }
            else
            {
                var newCache = new Dictionary<Guid, Banner>
                {
                    [newBanner.Id] = newBanner
                };
                _cache.Set(cacheKey, newCache);
            }
            return _mapper.Map<BannerDto>(newBanner);
        }
        public async Task UpdateAsync(UpdateBannerDto dto)
        {
            var existingBanner = await _query.GetByIdAsync(dto.Id);
            if (existingBanner == null)
            {
                throw new KeyNotFoundException("Banner not found");
            }

            _mapper.Map(dto, existingBanner);
            await _command.UpdateAsync(existingBanner);
            await _work.SaveChangeAsync();

            if (_cache.TryGetValue(cacheKey, out Dictionary<Guid, Banner> cachedDict) && cachedDict.ContainsKey(dto.Id))
            {
                var updatedCache = new Dictionary<Guid, Banner>(cachedDict)
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
            if (_cache.TryGetValue(cacheKey, out Dictionary<Guid, Banner> cachedDict) && cachedDict.ContainsKey(id))
            {
                var updatedCache = new Dictionary<Guid, Banner>(cachedDict);
                updatedCache.Remove(id);
                _cache.Set(cacheKey, updatedCache);
            }
        }
    }
}
