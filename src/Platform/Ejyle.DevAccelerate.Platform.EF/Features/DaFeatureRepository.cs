// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Ejyle.DevAccelerate.Core.EF;
using Microsoft.EntityFrameworkCore;
using Ejyle.DevAccelerate.Core.Data;
using Ejyle.DevAccelerate.Platform.Features;
using Ejyle.DevAccelerate.Platform.Apps;

namespace Ejyle.DevAccelerate.Platform.EF.Features
{
    public class DaFeatureRepository : DaFeatureRepository<string, DaFeature, DaFeatureAction, DaApp, DaAppAttribute, DaAppFeature, DbContext>
    {
        public DaFeatureRepository(DbContext dbContext)
            : base(dbContext)
        { }
    }


    public class DaFeatureRepository<TKey, TFeature, TFeatureAction, TApp, TAppAttribute, TAppFeature, TDbContext>
        : DaEntityRepositoryBase<TKey, TApp, TDbContext>, IDaFeatureRepository<TKey, TFeature>
        where TKey : IEquatable<TKey>
        where TApp : DaApp<TKey, TAppAttribute, TFeature, TAppFeature>
        where TAppAttribute : DaAppAttribute<TKey, TApp>
        where TAppFeature : DaAppFeature<TKey, TApp, TFeature>
        where TFeatureAction : DaFeatureAction<TKey, TFeature>
        where TFeature : DaFeature<TKey, TApp, TAppFeature, TFeatureAction>
        where TDbContext : DbContext
    {
        public DaFeatureRepository(TDbContext dbContext)
            : base(dbContext)
        { }

        private DbSet<TFeature> Features { get { return DbContext.Set<TFeature>(); } }

        public Task CreateAsync(TFeature feature)
        {
            Features.Add(feature);
            return SaveChangesAsync();
        }

        public Task DeleteAsync(TFeature feature)
        {
            Features.Remove(feature);
            return SaveChangesAsync();
        }

        public Task<List<TFeature>> FindByAppIdAsync(TKey appId)
        {
            return Features.Where(m => m.AppId.Equals(appId))
                .Include(m => m.FeatureActions)
                .ToListAsync();
        }

        public Task<TFeature> FindByIdAsync(TKey id)
        {
            return Features.Where(m => m.Id.Equals(id))
                .Include(m => m.FeatureActions)
                .SingleOrDefaultAsync();
        }

        public Task<TFeature> FindByKeyAsync(string key)
        {
            return Features.Where(m => m.Key == key)
                .Include(m => m.FeatureActions)
                .SingleOrDefaultAsync();
        }

        public Task UpdateAsync(TFeature feature)
        {
            DbContext.Entry(feature).State = EntityState.Modified;
            return SaveChangesAsync();
        }

        public async Task<DaPaginatedEntityList<TKey, TFeature>> FindAllAsync(DaDataPaginationCriteria paginationCriteria)
        {
            var totalCount = await Features.CountAsync();

            if (totalCount <= 0)
            {
                return null;
            }

            var query = Features
                .Skip((paginationCriteria.PageIndex - 1) * paginationCriteria.PageSize)
                .Take(paginationCriteria.PageSize)
                .Include(m => m.FeatureActions)
                .AsQueryable();

            var result = await query.ToListAsync();

            return new DaPaginatedEntityList<TKey, TFeature>(result
                , new DaDataPaginationResult(paginationCriteria, totalCount));
        }
    }
}
