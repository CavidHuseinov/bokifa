﻿using Bokifa.Domain.Entities;
using Bookifa.Domain.IRepositories.Generics;

namespace Bokifa.Domain.IRepositories
{
    public interface ITBookRepo:ICommandRepository<TBook>
    {
    }
}
