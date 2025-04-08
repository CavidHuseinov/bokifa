using AutoMapper;
using Bokifa.Application.IServices;
using Bokifa.Domain.DTOs.THeadBanner;
using Bokifa.Domain.Entities;
using Bokifa.Domain.Enums;
using Bokifa.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Oxu.Domain.IRepositories.Generics;
using Oxu.Persistance.UnitOfWorks;

namespace Bokifa.Persistance.Services
{
    public class THeadBannerService : ITHeadBannerService
    {
        private readonly ITHeadBannerRepo _command;
        private readonly IQueryRepository<THeadBanner> _query;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _work;
        private readonly IMemoryCache _cache;
        private readonly string cacheKey = "THeadBanners";

        public THeadBannerService(ITHeadBannerRepo command, IQueryRepository<THeadBanner> query, IMapper mapper, IUnitOfWork unitOfWork, IMemoryCache cache)
        {
            _command = command;
            _query = query;
            _mapper = mapper;
            _work = unitOfWork;
            _cache = cache;
        }
        public async Task<ICollection<THeadBannerDto>> GetAllAsync()
        {
            if (_cache.TryGetValue(cacheKey, out Dictionary<Guid, THeadBanner>? cachedDict))
            {
                return _mapper.Map<ICollection<THeadBannerDto>>(cachedDict.Values);
            }

            var banners = await _query.GetAllAsync(include:q=>q.Include(x=>x.HeadBanner));
            var bannerDict = banners.ToDictionary(b => b.Id);
            _cache.Set(cacheKey, bannerDict);
            return _mapper.Map<ICollection<THeadBannerDto>>(banners);
        }

        public async Task<THeadBannerDto> GetByIdAsync(Guid id)
        {
            var bannerId = await _query.GetByIdAsync(id);
            if (bannerId == null)
            {
                throw new Exception("Banner not found");
            }
            return _mapper.Map<THeadBannerDto>(bannerId);
        }
        public async Task<THeadBannerDto> CreateAsync(CreateTHeadBannerDto dto)
        {
            var banner = _mapper.Map<THeadBanner>(dto);
            var newBanner = await _command.CreateAsync(banner);
            await _work.SaveChangeAsync();

            if (_cache.TryGetValue(cacheKey, out Dictionary<Guid, THeadBanner> cachedDict))
            {
                var updatedCache = new Dictionary<Guid, THeadBanner>(cachedDict)
                {
                    [newBanner.Id] = newBanner
                };
                _cache.Set(cacheKey, updatedCache);
            }
            else
            {
                var newCache = new Dictionary<Guid, THeadBanner>
                {
                    [newBanner.Id] = newBanner
                };
                _cache.Set(cacheKey, newCache);
            }
            return _mapper.Map<THeadBannerDto>(newBanner);
        }
        public async Task UpdateAsync(UpdateTHeadBannerDto dto)
        {
            var existingBanner = await _query.GetByIdAsync(dto.Id);
            if (existingBanner == null)
            {
                throw new KeyNotFoundException("Banner not found");
            }

            _mapper.Map(dto, existingBanner);
            await _command.UpdateAsync(existingBanner);
            await _work.SaveChangeAsync();

            if (_cache.TryGetValue(cacheKey, out Dictionary<Guid, THeadBanner> cachedDict) && cachedDict.ContainsKey(dto.Id))
            {
                var updatedCache = new Dictionary<Guid, THeadBanner>(cachedDict)
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
            if (_cache.TryGetValue(cacheKey, out Dictionary<Guid, THeadBanner> cachedDict) && cachedDict.ContainsKey(id))
            {
                var updatedCache = new Dictionary<Guid, THeadBanner>(cachedDict);
                updatedCache.Remove(id);
                _cache.Set(cacheKey, updatedCache);
            }
        }
    }
}
