using Bokifa.Domain.Entities;
using Bokifa.Domain.IRepositories;
using Bookifa.Persistance.Context;
using Bookifa.Persistance.Repositories.Generics;

namespace Bokifa.Persistance.Repositories
{
    public class TTagRepo:CommandRepository<TTag>, ITTagRepo
    {
        public TTagRepo(BookifaDbContext context) : base(context)
        {
        }
    }
}
