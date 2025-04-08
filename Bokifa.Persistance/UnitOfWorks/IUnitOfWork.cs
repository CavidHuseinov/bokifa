namespace Bookifa.Persistance.UnitOfWorks
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangeAsync(CancellationToken cancellation = default);
    }
}
