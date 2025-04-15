using Bokifa.Domain.DTOs.TBlog;

namespace Bokifa.Application.IServices
{
    public interface ITBlogService
    {
        Task<ICollection<TBlogDto>> GetAllAsync();
        Task<TBlogDto> GetByIdAsync(Guid id);
        Task<TBlogDto> CreateAsync(CreateTBlogDto dto);
        Task UpdateAsync(UpdateTBlogDto dto);
        Task DeleteAsync(Guid id);
    }
}
