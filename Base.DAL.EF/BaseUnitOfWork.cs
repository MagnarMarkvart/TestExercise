﻿using Base.Contracts.DAL;
using Microsoft.EntityFrameworkCore;

namespace Base.DAL.EF;

public abstract class BaseUnitOfWork<TAppDbContext> : IUnitOfWork
    where TAppDbContext : DbContext
{
    protected readonly TAppDbContext UowDbContext;

    protected BaseUnitOfWork(TAppDbContext uowDbContext)
    {
        UowDbContext = uowDbContext;
    }

    public async Task<int> SaveChangesAsync()
    {
        var res = await UowDbContext.SaveChangesAsync();
        
        return res;
    }
}