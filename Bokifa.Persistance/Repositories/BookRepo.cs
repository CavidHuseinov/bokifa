using Bokifa.Domain.Entities;
using Bokifa.Domain.IRepositories;
using Bookifa.Persistance.Context;
using Bookifa.Persistance.Repositories.Generics;

namespace Bokifa.Persistance.Repositories
{
    public class BookRepo:CommandRepository<Book>, IBookRepo
    {
        public BookRepo(BookifaDbContext context) : base(context)
        {
        }
    }
}
