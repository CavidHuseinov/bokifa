using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Bookifa.Domain.IRepositories.Generics
{
    public interface IQueryRepository<TEntity> where TEntity : BaseEntity, new()
    {
        Task<TEntity> GetByIdAsync(Guid id);
        Task<IEnumerable<TEntity>>? GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null,
                                                Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
                                                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
                                                bool enableTracking = true);

        Task<IEnumerable<TEntity>> GetByPagingAsync(Expression<Func<TEntity, bool>>? predicate = null,
                                                    Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
                                                    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
                                                    bool enableTracking = true,
                                                    int pageIndex = 1,
                                                    int pageSize = 10);
    }
}
