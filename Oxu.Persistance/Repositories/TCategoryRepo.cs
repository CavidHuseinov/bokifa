using Bokifa.Domain.Entities;
using Bokifa.Domain.IRepositories;
using Oxu.Persistance.Context;
using Oxu.Persistance.Repositories.Generics;

namespace Bokifa.Persistance.Repositories
{
    public class TCategoryRepo : CommandRepository<TCategory>, ITCategoryRepo
    {
        public TCategoryRepo(OxuDbContext context) : base(context)
        {
        }
    }
}
