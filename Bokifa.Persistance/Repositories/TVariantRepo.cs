using Bokifa.Domain.Entities;
using Bokifa.Domain.IRepositories;
using Bookifa.Persistance.Context;
using Bookifa.Persistance.Repositories.Generics;

namespace Bokifa.Persistance.Repositories
{
    public class TVariantRepo:CommandRepository<TVariant>, ITVariantRepo
    {
        public TVariantRepo(BookifaDbContext context) : base(context)
        {
        }
    }
}
