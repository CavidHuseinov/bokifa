using Bokifa.Domain.Entities;
using Bokifa.Domain.IRepositories;
using Bookifa.Persistance.Context;
using Bookifa.Persistance.Repositories.Generics;

namespace Bokifa.Persistance.Repositories
{
    public class CategoryRepo : CommandRepository<Category>, ICategoryRepo
    {
        public CategoryRepo(BookifaDbContext context) : base(context)
        {
        }
    }
}
