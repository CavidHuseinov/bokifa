using Bokifa.Domain.Entities;
using Bokifa.Domain.IRepositories;
using Oxu.Persistance.Context;
using Oxu.Persistance.Repositories.Generics;

namespace Bokifa.Persistance.Repositories
{
    public class CategoryRepo : CommandRepository<Category>, ICategoryRepo
    {
        public CategoryRepo(OxuDbContext context) : base(context)
        {
        }
    }
}
