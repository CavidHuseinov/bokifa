namespace Bokifa.Persistance.Repositories
{
    public class TVariantRepo:CommandRepository<TVariant>, ITVariantRepo
    {
        public TVariantRepo(BookifaDbContext context) : base(context)
        {
        }
    }
}
