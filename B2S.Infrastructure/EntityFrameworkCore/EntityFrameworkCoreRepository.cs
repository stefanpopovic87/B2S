﻿using B2S.Infrastructure.Domain;
using Microsoft.EntityFrameworkCore;

namespace B2S.Infrastructure.EntityFrameworkCore
{
    public class EntityFrameworkCoreRepository<TDbContext, TEntity, TKey> : IRepository<TEntity, TKey>
        where TDbContext : DbContext
        where TEntity : EntityBase<TKey>
    {
        protected readonly TDbContext Context;
        protected readonly DbSet<TEntity> Set;

        public EntityFrameworkCoreRepository(TDbContext context)
        {
            Context = context;
            Set = Context.Set<TEntity>();
        }

        public virtual async Task<TEntity> GetByIdAsync(TKey id, bool includeDetails = true, CancellationToken cancellationToken = default)
        {
            return await GetQueryable(includeDetails)
                .FirstOrDefaultAsync(e => e.Id.Equals(id));
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(bool includeDetails = true, CancellationToken cancellationToken = default)
        {
            return await GetQueryable(includeDetails)
                .ToListAsync();
        }

        public virtual async Task InsertAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await Set.AddAsync(entity);
        }

        public virtual async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            Context.Attach(entity);

            Set.Update(entity);

            await Task.CompletedTask;
        }

        public virtual async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            Set.Remove(entity);

            await Task.CompletedTask;
        }

        protected IQueryable<TEntity> GetQueryable(bool includeDetails)
        {
            var query = Set.AsQueryable();

            if (!includeDetails)
            {
                return query;
            }

            var navigations = Context.Model.FindEntityType(typeof(TEntity))
                .GetDerivedTypesInclusive()
                .SelectMany(type => type.GetNavigations())
                .Distinct();

            foreach (var property in navigations)
            {
                query = query.Include(property.Name);
            }

            return query;
        }
    }

    public class EntityFrameworkCoreRepository<TDbContext, TEntity> : EntityFrameworkCoreRepository<TDbContext, TEntity, int>
        where TDbContext : DbContext
        where TEntity : EntityBase<int>
    {
        public EntityFrameworkCoreRepository(TDbContext context) : base(context)
        {
        }
    }
}