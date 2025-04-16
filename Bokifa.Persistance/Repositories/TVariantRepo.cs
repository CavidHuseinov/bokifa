namespace Bokifa.Persistance.Repositories
{
    public class TVariantRepo:CommandRepository<TVariant>, ITVariantRepo
    {
        public TVariantRepo(BokifaDbContext context) : base(context)
        {
        }
    }
}
