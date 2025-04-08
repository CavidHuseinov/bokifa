using Bokifa.Domain.Entities;
using Bokifa.Domain.IRepositories;
using Bookifa.Persistance.Context;
using Bookifa.Persistance.Repositories.Generics;

namespace Bokifa.Persistance.Repositories
{
    public class TCategoryRepo : CommandRepository<TCategory>, ITCategoryRepo
    {
        public TCategoryRepo(BookifaDbContext context) : base(context)
        {
        }
    }
}
