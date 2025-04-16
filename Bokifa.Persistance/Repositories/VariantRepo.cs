namespace Bokifa.Persistance.Repositories
{
    public class VariantRepo : CommandRepository<Variant>, IVariantRepo
    {
        public VariantRepo(BokifaDbContext context) : base(context)
        {
        }
    }
}
