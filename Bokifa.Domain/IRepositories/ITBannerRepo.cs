using Bokifa.Domain.Entities;
using Bookifa.Domain.IRepositories.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bokifa.Domain.IRepositories
{
    public interface ITBannerRepo:ICommandRepository<TBanner>
    {
    }
}
