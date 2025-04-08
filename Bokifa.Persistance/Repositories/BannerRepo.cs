using Bokifa.Domain.Entities;
using Bokifa.Domain.IRepositories;
using Bookifa.Persistance.Context;
using Bookifa.Persistance.Repositories.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bokifa.Persistance.Repositories
{
    public class BannerRepo : CommandRepository<Banner>, IBannerRepo
    {
        public BannerRepo(BookifaDbContext context) : base(context)
        {
        }
    }
}
