namespace Bookifa.Persistance.UnitOfWorks;

public sealed class UnitOfWorks : IUnitOfWork
{
    private readonly BookifaDbContext _context;
    public UnitOfWorks(BookifaDbContext context)
    {
        _context = context;
    }
    public async Task<int> SaveChangeAsync(CancellationToken cancellation = default)
    {
        return await _context.SaveChangesAsync(cancellation);
    }
}
