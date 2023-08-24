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

namespace Ejyle.DevAccelerate.Platform.EF.Apps
{
    public class DaAppRepository : DaAppRepository<string, DaApp, DaAppAttribute, DaAppFeature, DaFeature, DaFeatureAction, DbContext>
    {
        public DaAppRepository(DbContext dbContext)
            : base(dbContext)
        { }
    }


    public class DaAppRepository<TKey, TApp, TAppAttribute, TAppFeature, TFeature, TFeatureAction, TDbContext>
        : DaEntityRepositoryBase<TKey, TApp, TDbContext>, IDaAppRepository<TKey, TApp>
        where TKey : IEquatable<TKey>
        where TApp : DaApp<TKey, TAppAttribute, TFeature, TAppFeature>
        where TAppAttribute : DaAppAttribute<TKey, TApp>
        where TAppFeature : DaAppFeature<TKey, TApp, TFeature>
        where TFeatureAction : DaFeatureAction<TKey, TFeature>
        where TFeature : DaFeature<TKey, TApp, TAppFeature, TFeatureAction>
        where TDbContext : DbContext
    {
        public DaAppRepository(TDbContext dbContext)
            : base(dbContext)
        { }

        private DbSet<TApp> Apps { get { return DbContext.Set<TApp>(); } }
        private DbSet<TAppFeature> AppFeatures { get { return DbContext.Set<TAppFeature>(); } }

        public Task CreateAsync(TApp app)
        {
            Apps.Add(app);
            return SaveChangesAsync();
        }

        public Task DeleteAsync(TApp app)
        {
            Apps.Remove(app);
            return SaveChangesAsync();
        }

        public Task<TApp> FindByIdAsync(TKey id)
        {
            return Apps.Where(m => m.Id.Equals(id))
                .Include(m => m.Attributes)
                .Include(m => m.Features)
                .Include(m => m.AppFeatures)
                .ThenInclude(m => m.Feature)
                .SingleOrDefaultAsync();
        }

        public Task<TApp> FindByKeyAsync(string key)
        {
            return Apps.Where(m => m.Key == key)
                .Include(m => m.Attributes)
                .Include(m => m.Features)
                .Include(m => m.AppFeatures)
                .ThenInclude(m => m.Feature)
                .SingleOrDefaultAsync();
        }

        public async Task RemoveAppFeatureByIdAsync(TKey appFeatureId)
        {
            var appFeature = await AppFeatures.Where(m => m.Id.Equals(appFeatureId))
                .SingleOrDefaultAsync();

            if (appFeature == null)
            {
                throw new InvalidOperationException("App feature doesn't exist.");
            }

            AppFeatures.Remove(appFeature);
            await SaveChangesAsync();
        }

        public Task UpdateAsync(TApp app)
        {
            DbContext.Entry(app).State = EntityState.Modified;
            return SaveChangesAsync();
        }

        public async Task<DaPaginatedEntityList<TKey, TApp>> FindAllAsync(DaDataPaginationCriteria paginationCriteria)
        {
            var totalCount = await Apps.CountAsync();

            if (totalCount <= 0)
            {
                return null;
            }

            var query = Apps
                .Skip((paginationCriteria.PageIndex - 1) * paginationCriteria.PageSize)
                .Take(paginationCriteria.PageSize)
                .Include(m => m.Attributes)
                .Include(m => m.Features)
                .Include(m => m.AppFeatures)
                .ThenInclude(m => m.Feature)
                .AsQueryable();

            var result = await query.ToListAsync();

            return new DaPaginatedEntityList<TKey, TApp>(result
                , new DaDataPaginationResult(paginationCriteria, totalCount));
        }
    }
}
