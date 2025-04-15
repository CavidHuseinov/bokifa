
using Bokifa.Domain.DTOs.TBlog;

namespace Bokifa.Persistance.Services
{
    public class TBlogService : ITBlogService
    {
        private readonly IUnitOfWork _work;
        private readonly IMapper _mapper;
        private readonly ITBlogRepo _command;
        private readonly IQueryRepository<TBlog> _query;
        public TBlogService(IUnitOfWork work, IMapper mapper, ITBlogRepo command, IQueryRepository<TBlog> query)
        {
            _work = work;
            _mapper = mapper;
            _command = command;
            _query = query;
        }
        public async Task<ICollection<TBlogDto>> GetAllAsync()
        {
            var tblogs = await _query.GetAllAsync();
            return _mapper.Map<ICollection<TBlogDto>>(tblogs);
        }

        public async Task<TBlogDto> GetByIdAsync(Guid id)
        {
            var tblogId = await _query.GetByIdAsync(id);
            if (tblogId == null)
            {
                throw new Exception("TBlog not found");
            }
            return _mapper.Map<TBlogDto>(tblogId);
        }
        public async Task<TBlogDto> CreateAsync(CreateTBlogDto dto)
        {
            var tblog = _mapper.Map<TBlog>(dto);
            var newTBlog = await _command.CreateAsync(tblog);
            await _work.SaveChangeAsync();
            return _mapper.Map<TBlogDto>(newTBlog);
        }
        public async Task UpdateAsync(UpdateTBlogDto dto)
        {
            var existingTBlog = await _query.GetByIdAsync(dto.Id);
            if (existingTBlog == null)
            {
                throw new KeyNotFoundException("TBlog not found");
            }

            _mapper.Map(dto, existingTBlog);
            await _command.UpdateAsync(existingTBlog);
            await _work.SaveChangeAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            var tblogId = await _query.GetByIdAsync(id);
            if (tblogId == null)
            {
                throw new KeyNotFoundException("TBlog not found");
            }
            await _command.DeleteAsync(tblogId);
            await _work.SaveChangeAsync();
        }
    }
}
