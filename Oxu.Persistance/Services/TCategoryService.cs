using AutoMapper;
using Bokifa.Application.IServices;
using Bokifa.Domain.DTOs.TCategory;
using Bokifa.Domain.Entities;
using Bokifa.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Oxu.Domain.IRepositories.Generics;
using Oxu.Persistance.UnitOfWorks;

namespace Bokifa.Persistance.Services
{
    public class TCategoryService:ITCategoryService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _work;
        private readonly IMemoryCache _cache;
        private readonly ITCategoryRepo _command;
        private readonly IQueryRepository<TCategory> _query;
        private readonly string cacheKey = "TCategories";

        public TCategoryService(IQueryRepository<TCategory> query, ITCategoryRepo command, IMemoryCache cache, IUnitOfWork work, IMapper mapper)
        {
            _query = query;
            _command = command;
            _cache = cache;
            _work = work;
            _mapper = mapper;
        }

        public async Task<ICollection<TCategoryDto>> GetAllAsync()
        {
            if (_cache.TryGetValue(cacheKey, out Dictionary<Guid, TCategory>? cachedDict))
            {
                return _mapper.Map<ICollection<TCategoryDto>>(cachedDict.Values);
            }

            var categories = await _query.GetAllAsync(include:q=>q.Include(x=>x.Category));
            var TcategoryDict = categories.ToDictionary(b => b.Id);
            _cache.Set(cacheKey, TcategoryDict);
            return _mapper.Map<ICollection<TCategoryDto>>(categories);
        }
        public async Task<TCategoryDto> GetByIdAsync(Guid id)
        {
            var TcategoryId = await _query.GetByIdAsync(id);
            if (TcategoryId == null)
            {
                throw new Exception("TCategory not found");
            }
            return _mapper.Map<TCategoryDto>(TcategoryId);
        }
        public async Task<TCategoryDto> CreateAsync(CreateTCategoryDto dto)
        {
            var Tcategory = _mapper.Map<TCategory>(dto);
            var newTCategory = await _command.CreateAsync(Tcategory);
            await _work.SaveChangeAsync();

            if (_cache.TryGetValue(cacheKey, out Dictionary<Guid, TCategory> cachedDict))
            {
                var updatedCache = new Dictionary<Guid, TCategory>(cachedDict)
                {
                    [newTCategory.Id] = newTCategory
                };
                _cache.Set(cacheKey, updatedCache);
            }
            else
            {
                var newCache = new Dictionary<Guid, TCategory>
                {
                    [newTCategory.Id] = newTCategory
                };
                _cache.Set(cacheKey, newCache);
            }
            return _mapper.Map<TCategoryDto>(newTCategory);
        }
        public async Task UpdateAsync(UpdateTCategoryDto dto)
        {
            var existingTCategory = await _query.GetByIdAsync(dto.Id);
            if (existingTCategory == null)
            {
                throw new KeyNotFoundException("TCategory not found");
            }

            _mapper.Map(dto, existingTCategory);
            await _command.UpdateAsync(existingTCategory);
            await _work.SaveChangeAsync();

            if (_cache.TryGetValue(cacheKey, out Dictionary<Guid, TCategory> cachedDict) && cachedDict.ContainsKey(dto.Id))
            {
                var updatedCache = new Dictionary<Guid, TCategory>(cachedDict)
                {
                    [dto.Id] = existingTCategory
                };

                _cache.Set(cacheKey, updatedCache);
            }
        }
        public async Task DeleteAsync(Guid id)
        {
            var TcategoryId = await _query.GetByIdAsync(id);
            if (TcategoryId == null)
            {
                throw new KeyNotFoundException("TCategory not found");
            }
            await _command.DeleteAsync(TcategoryId);
            await _work.SaveChangeAsync();
            if (_cache.TryGetValue(cacheKey, out Dictionary<Guid, TCategory> cachedDict) && cachedDict.ContainsKey(id))
            {
                var updatedCache = new Dictionary<Guid, TCategory>(cachedDict);
                updatedCache.Remove(id);
                _cache.Set(cacheKey, updatedCache);
            }
        }
    }
}
