
using Bokifa.Domain.DTOs.Blog;

namespace Bokifa.Application.IServices
{
    public interface IBlogService
    {
        Task<ICollection<BlogDto>> GetAllAsync();
        Task<BlogDto> GetByIdAsync(Guid id);
        Task<BlogDto> CreateAsync(CreateBlogDto dto);
        Task UpdateAsync(UpdateBlogDto dto);
        Task DeleteAsync(Guid id);
    }
}
