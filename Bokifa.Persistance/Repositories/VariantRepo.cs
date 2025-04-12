﻿using Bokifa.Domain.Entities;
using Bokifa.Domain.IRepositories;
using Bookifa.Persistance.Context;
using Bookifa.Persistance.Repositories.Generics;

namespace Bokifa.Persistance.Repositories
{
    public class VariantRepo : CommandRepository<Variant>, IVariantRepo
    {
        public VariantRepo(BookifaDbContext context) : base(context)
        {
        }
    }
}
