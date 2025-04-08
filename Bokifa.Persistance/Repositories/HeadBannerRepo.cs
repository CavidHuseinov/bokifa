using Bokifa.Domain.Entities;
using Bokifa.Domain.IRepositories;
using Bookifa.Domain.IRepositories.Generics;
using Bookifa.Persistance.Context;
using Bookifa.Persistance.Repositories.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bokifa.Persistance.Repositories
{
    public class HeadBannerRepo : CommandRepository<HeadBanner>, IHeadBannerRepo
    {
        public HeadBannerRepo(BookifaDbContext context) : base(context)
        {
        }
    }
}
