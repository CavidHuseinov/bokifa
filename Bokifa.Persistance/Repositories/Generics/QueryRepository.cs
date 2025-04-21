using Bookifa.Domain.Abstractions;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Bookifa.Persistance.Repositories.Generics
{
    public class QueryRepository<TEntity> : IQueryRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly BokifaDbContext _context;
        public QueryRepository(BokifaDbContext context) => _context = context;
        private DbSet<TEntity> Table => _context.Set<TEntity>();

        public async Task<TEntity> GetByIdAsync(Guid id) =>
            await Table.FindAsync(id);

        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate) =>
            await Table.FirstOrDefaultAsync(predicate);

        public IQueryable<TEntity> GetAllAsync(
            Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            bool enableTracking = true)
        {
            IQueryable<TEntity> query = Table;
            if (!enableTracking)
                query = query.AsNoTracking();
            if (include != null)
                query = include(query);
            if (predicate != null)
                query = query.Where(predicate);
            if (orderBy != null)
                query = orderBy(query);
            return query;
        }

        public IQueryable<TEntity> GetByPagedAsync(
            Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            bool enableTracking = true,
            int pageIndex = 1,
            int pageSize = 10)
        {
            var query = GetAllAsync (predicate, include, orderBy, enableTracking);
            return query.Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize);
        }
    }
}
