namespace Bokifa.Persistance.Repositories
{
    public class VariantRepo : CommandRepository<Variant>, IVariantRepo
    {
        public VariantRepo(BookifaDbContext context) : base(context)
        {
        }
    }
}
