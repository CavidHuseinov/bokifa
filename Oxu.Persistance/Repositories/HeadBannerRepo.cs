using Bokifa.Domain.Entities;
using Bokifa.Domain.IRepositories;
using Oxu.Domain.IRepositories.Generics;
using Oxu.Persistance.Context;
using Oxu.Persistance.Repositories.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bokifa.Persistance.Repositories
{
    public class HeadBannerRepo : CommandRepository<HeadBanner>, IHeadBannerRepo
    {
        public HeadBannerRepo(OxuDbContext context) : base(context)
        {
        }
    }
}
