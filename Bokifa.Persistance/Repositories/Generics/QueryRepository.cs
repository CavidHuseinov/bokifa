using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Bookifa.Domain.Abstractions;
using Bookifa.Domain.IRepositories.Generics;
using Bookifa.Persistance.Context;
using System.Linq.Expressions;

namespace Bookifa.Persistance.Repositories.Generics
{
    public class QueryRepository<TEntity>: IQueryRepository<TEntity> where TEntity : BaseEntity,new()
    {
        private readonly BookifaDbContext _context;
        public QueryRepository(BookifaDbContext context)
        {
            _context = context;
        }
        private DbSet<TEntity> Table => _context.Set<TEntity>();


        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await Table.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(
            Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            bool enableTracking = true)
        {
            IQueryable<TEntity> query = Table;

            if (!enableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetByPagingAsync(
            Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            bool enableTracking = true,
            int pageIndex = 1,
            int pageSize = 10)
        {
            IQueryable<TEntity> query = Table;

            if (!enableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return await query.Skip((pageIndex - 1) * pageSize)
                              .Take(pageSize)
                              .ToListAsync();

        }
    }
}
