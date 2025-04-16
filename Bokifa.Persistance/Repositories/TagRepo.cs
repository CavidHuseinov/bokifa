namespace Bokifa.Persistance.Repositories
{
    public class TagRepo : CommandRepository<Tag>, ITagRepo
    {
        public TagRepo(BokifaDbContext context) : base(context)
        {
        }
    }
}
