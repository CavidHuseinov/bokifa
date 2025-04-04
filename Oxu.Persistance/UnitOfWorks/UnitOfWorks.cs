using Oxu.Persistance.Context;

namespace Oxu.Persistance.UnitOfWorks;

public sealed class UnitOfWorks : IUnitOfWork
{
    private readonly OxuDbContext _context;
    public UnitOfWorks(OxuDbContext context)
    {
        _context = context;
    }
    public async Task<int> SaveChangeAsync(CancellationToken cancellation = default)
    {
        return await _context.SaveChangesAsync(cancellation);
    }
}
