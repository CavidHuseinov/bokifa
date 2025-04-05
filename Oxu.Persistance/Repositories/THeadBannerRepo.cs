using Bokifa.Domain.Entities;
using Bokifa.Domain.IRepositories;
using Oxu.Persistance.Context;
using Oxu.Persistance.Repositories.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bokifa.Persistance.Repositories
{
    public class THeadBannerRepo : CommandRepository<THeadBanner>, ITHeadBannerRepo
    {
        public THeadBannerRepo(OxuDbContext context) : base(context)
        {
        }
    }
}
