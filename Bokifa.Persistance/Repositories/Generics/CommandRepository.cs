using Microsoft.EntityFrameworkCore;
using Bookifa.Domain.Abstractions;
using Bookifa.Domain.IRepositories.Generics;
using Bookifa.Persistance.Context;

namespace Bookifa.Persistance.Repositories.Generics
{
    public class CommandRepository<TEntity> : ICommandRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly BokifaDbContext _context;


        public CommandRepository(BokifaDbContext context)
        {
            _context = context;
        }
        private DbSet<TEntity> Table => _context.Set<TEntity>();

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await Table.AddAsync(entity);
            return entity;
        }

        public async Task DeleteAsync(TEntity entity)
        {
            Table.Remove(entity);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            Table.Update(entity);
        }
    }
}
