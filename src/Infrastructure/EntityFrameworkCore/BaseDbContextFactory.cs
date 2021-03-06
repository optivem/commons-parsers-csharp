﻿using Microsoft.EntityFrameworkCore;
using Atomiv.Core.Common;

namespace Atomiv.Infrastructure.EntityFrameworkCore
{
    public abstract class BaseDbContextFactory<TContext> : IFactory<TContext>
        where TContext : DbContext
    {
        public BaseDbContextFactory(DbContextOptions<TContext> contextOptions)
        {
            ContextOptions = contextOptions;
        }

        public DbContextOptions<TContext> ContextOptions { get; }

        public TContext Create()
        {
            return Create(ContextOptions);
        }

        protected abstract TContext Create(DbContextOptions<TContext> options);
    }
}