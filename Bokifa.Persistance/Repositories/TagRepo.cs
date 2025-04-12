using Bokifa.Domain.Entities;
using Bokifa.Domain.IRepositories;
using Bookifa.Persistance.Context;
using Bookifa.Persistance.Repositories.Generics;

namespace Bokifa.Persistance.Repositories
{
    public class TagRepo : CommandRepository<Tag>, ITagRepo
    {
        public TagRepo(BookifaDbContext context) : base(context)
        {
        }
    }
}
