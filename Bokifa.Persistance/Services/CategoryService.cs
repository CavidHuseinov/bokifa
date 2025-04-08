using AutoMapper;
using Bokifa.Application.IServices;
using Bokifa.Domain.DTOs.Category;
using Bokifa.Domain.DTOs.Category;
using Bokifa.Domain.Entities;
using Bokifa.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Bookifa.Domain.IRepositories.Generics;
using Bookifa.Persistance.UnitOfWorks;

namespace Bokifa.Persistance.Services
{
    public class CategoryService:ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private readonly ICategoryRepo _command;
        private readonly IQueryRepository<Category> _query;
        private readonly IUnitOfWork _work;
        private readonly string cacheKey = "categories";

        public CategoryService(IUnitOfWork unitOfWork, IQueryRepository<Category> query, ICategoryRepo command, IMemoryCache cache, IMapper mapper)
        {
            _work = unitOfWork;
            _query = query;
            _command = command;
            _cache = cache;
            _mapper = mapper;
        }
        public async Task<ICollection<CategoryDto>> GetAllAsync()
        {
            if (_cache.TryGetValue(cacheKey, out Dictionary<Guid, Category>? cachedDict))
            {
                return _mapper.Map<ICollection<CategoryDto>>(cachedDict.Values);
            }

            var categories = await _query.GetAllAsync();
            var categoryDict = categories.ToDictionary(b => b.Id);
            _cache.Set(cacheKey, categoryDict);
            return _mapper.Map<ICollection<CategoryDto>>(categories);
        }
        public async Task<CategoryDto> GetByIdAsync(Guid id)
        {
            var categoryId = await _query.GetByIdAsync(id);
            if (categoryId == null)
            {
                throw new Exception("Category not found");
            }
            return _mapper.Map<CategoryDto>(categoryId);
        }
        public async Task<CategoryDto> CreateAsync(CreateCategoryDto dto)
        {
            var category = _mapper.Map<Category>(dto);
            var newCategory = await _command.CreateAsync(category);
            await _work.SaveChangeAsync();

            if (_cache.TryGetValue(cacheKey, out Dictionary<Guid, Category> cachedDict))
            {
                var updatedCache = new Dictionary<Guid, Category>(cachedDict)
                {
                    [newCategory.Id] = newCategory
                };
                _cache.Set(cacheKey, updatedCache);
            }
            else
            {
                var newCache = new Dictionary<Guid, Category>
                {
                    [newCategory.Id] = newCategory
                };
                _cache.Set(cacheKey, newCache);
            }
            return _mapper.Map<CategoryDto>(newCategory);
        }
        public async Task UpdateAsync(UpdateCategoryDto dto)
        {
            var existingCategory = await _query.GetByIdAsync(dto.Id);
            if (existingCategory == null)
            {
                throw new KeyNotFoundException("Category not found");
            }

            _mapper.Map(dto, existingCategory);
            await _command.UpdateAsync(existingCategory);
            await _work.SaveChangeAsync();

            if (_cache.TryGetValue(cacheKey, out Dictionary<Guid, Category> cachedDict) && cachedDict.ContainsKey(dto.Id))
            {
                var updatedCache = new Dictionary<Guid, Category>(cachedDict)
                {
                    [dto.Id] = existingCategory
                };

                _cache.Set(cacheKey, updatedCache);
            }
        }
        public async Task DeleteAsync(Guid id)
        {
            var categoryId = await _query.GetByIdAsync(id);
            if (categoryId == null)
            {
                throw new KeyNotFoundException("Category not found");
            }
            await _command.DeleteAsync(categoryId);
            await _work.SaveChangeAsync();
            if (_cache.TryGetValue(cacheKey, out Dictionary<Guid, Category> cachedDict) && cachedDict.ContainsKey(id))
            {
                var updatedCache = new Dictionary<Guid, Category>(cachedDict);
                updatedCache.Remove(id);
                _cache.Set(cacheKey, updatedCache);
            }
        }
    }
}
