namespace Bokifa.Persistance.Repositories
{
    public class TagRepo : CommandRepository<Tag>, ITagRepo
    {
        public TagRepo(BookifaDbContext context) : base(context)
        {
        }
    }
}
