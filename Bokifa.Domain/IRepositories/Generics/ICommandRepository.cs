namespace Bookifa.Domain.IRepositories.Generics
{
    public interface ICommandRepository<TEntity> where TEntity : BaseEntity, new()
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
