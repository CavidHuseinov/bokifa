
using Bokifa.Domain.DTOs.Blog;
using Bokifa.Domain.Entities;

namespace Bokifa.Persistance.Services
{
    public class BlogService:IBlogService
    {
        private readonly IUnitOfWork _work;
        private readonly IMapper _mapper;
        private readonly IBlogRepo _command;
        private readonly IQueryRepository<Blog> _query;
        public BlogService(IUnitOfWork work, IMapper mapper, IBlogRepo command, IQueryRepository<Blog> query)
        {
            _work = work;
            _mapper = mapper;
            _command = command;
            _query = query;
        }
        public async Task<ICollection<BlogDto>> GetAllAsync()
        {
            var blogs = await _query.GetAllAsync(
                include: q => q.Include(x => x.Author).Include(x => x.TBlogs)
                .Include(x => x.BlogAndTags).ThenInclude(x=>x.Tag));
            return _mapper.Map<ICollection<BlogDto>>(blogs);
        }

        public async Task<BlogDto> GetByIdAsync(Guid id)
        {
            var blogId = await _query.GetByIdAsync(id);
            if (blogId == null)
            {
                throw new Exception("Blog not found");
            }
            return _mapper.Map<BlogDto>(blogId);
        }
        public async Task<BlogDto> CreateAsync(CreateBlogDto dto)
        {
            var blog = _mapper.Map<Blog>(dto);
            if (dto.TagIds != null && dto.TagIds.Any())
            {
                blog.BlogAndTags = new List<BlogAndTag>();
                foreach (var tagId in dto.TagIds)
                {
                    blog.BlogAndTags.Add(new BlogAndTag
                    {
                        TagId = tagId
                    });
                }
            }
            var newBlog = await _command.CreateAsync(blog);
            await _work.SaveChangeAsync();
            return _mapper.Map<BlogDto>(newBlog);
        }
        public async Task UpdateAsync(UpdateBlogDto dto)
        {
            var existingBlog = await _query.GetByIdAsync(dto.Id);
            if (existingBlog == null)
            {
                throw new KeyNotFoundException("Blog not found");
            }

            _mapper.Map(dto, existingBlog);
            await _command.UpdateAsync(existingBlog);
            await _work.SaveChangeAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            var blogId = await _query.GetByIdAsync(id);
            if (blogId == null)
            {
                throw new KeyNotFoundException("Blog not found");
            }
            await _command.DeleteAsync(blogId);
            await _work.SaveChangeAsync();
        }
    }
}
