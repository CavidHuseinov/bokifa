using AutoMapper;
using Bokifa.Application.IServices;
using Bokifa.Domain.DTOs.Tag;
using Bokifa.Domain.Entities;
using Bokifa.Domain.IRepositories;
using Bookifa.Domain.IRepositories.Generics;
using Bookifa.Persistance.UnitOfWorks;
using Microsoft.Extensions.Caching.Memory;

namespace Bokifa.Persistance.Services
{
    public class TagService:ITagService
    {
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private readonly IUnitOfWork _work;
        private readonly ITagRepo _command;
        private readonly IQueryRepository<Tag> _query;
        private readonly string cacheKey = "Tags";

        public TagService(IQueryRepository<Tag> query, ITagRepo command, IUnitOfWork work, IMemoryCache cache, IMapper mapper)
        {
            _query = query;
            _command = command;
            _work = work;
            _cache = cache;
            _mapper = mapper;
        }
        public async Task<ICollection<TagDto>> GetAllAsync()
        {
            if (_cache.TryGetValue(cacheKey, out Dictionary<Guid, Tag>? cachedDict))
            {
                return _mapper.Map<ICollection<TagDto>>(cachedDict.Values);
            }

            var banners = await _query.GetAllAsync();
            var bannerDict = banners.ToDictionary(b => b.Id);
            _cache.Set(cacheKey, bannerDict);
            return _mapper.Map<ICollection<TagDto>>(banners);
        }

        public async Task<TagDto> GetByIdAsync(Guid id)
        {
            var bannerId = await _query.GetByIdAsync(id);
            if (bannerId == null)
            {
                throw new Exception("Banner not found");
            }
            return _mapper.Map<TagDto>(bannerId);
        }
        public async Task<TagDto> CreateAsync(CreateTagDto dto)
        {
            var banner = _mapper.Map<Tag>(dto);
            var newBanner = await _command.CreateAsync(banner);
            await _work.SaveChangeAsync();

            if (_cache.TryGetValue(cacheKey, out Dictionary<Guid, Tag> cachedDict))
            {
                var updatedCache = new Dictionary<Guid, Tag>(cachedDict)
                {
                    [newBanner.Id] = newBanner
                };
                _cache.Set(cacheKey, updatedCache);
            }
            else
            {
                var newCache = new Dictionary<Guid, Tag>
                {
                    [newBanner.Id] = newBanner
                };
                _cache.Set(cacheKey, newCache);
            }
            return _mapper.Map<TagDto>(newBanner);
        }
        public async Task UpdateAsync(UpdateTagDto dto)
        {
            var existingBanner = await _query.GetByIdAsync(dto.Id);
            if (existingBanner == null)
            {
                throw new KeyNotFoundException("Banner not found");
            }

            _mapper.Map(dto, existingBanner);
            await _command.UpdateAsync(existingBanner);
            await _work.SaveChangeAsync();

            if (_cache.TryGetValue(cacheKey, out Dictionary<Guid, Tag> cachedDict) && cachedDict.ContainsKey(dto.Id))
            {
                var updatedCache = new Dictionary<Guid, Tag>(cachedDict)
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
            if (_cache.TryGetValue(cacheKey, out Dictionary<Guid, Tag> cachedDict) && cachedDict.ContainsKey(id))
            {
                var updatedCache = new Dictionary<Guid, Tag>(cachedDict);
                updatedCache.Remove(id);
                _cache.Set(cacheKey, updatedCache);
            }
        }
    }
}
