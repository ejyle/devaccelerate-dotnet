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
using Ejyle.DevAccelerate.Files;
using Microsoft.EntityFrameworkCore;
using Ejyle.DevAccelerate.Core.Data;
using System.Xml.Linq;

namespace Ejyle.DevAccelerate.Files.EF
{
    public class DaFileCollectionRepository : DaFileCollectionRepository<string, DaFileCollection, DaFile, DbContext>
    {
        public DaFileCollectionRepository(DbContext dbContext)
            : base(dbContext)
        { }
    }


    public class DaFileCollectionRepository<TKey, TFileCollection, TFile, TDbContext>
        : DaEntityRepositoryBase<TKey, TFileCollection, TDbContext>, IDaFileCollectionRepository<TKey, TFileCollection>
        where TKey : IEquatable<TKey>
        where TFileCollection : DaFileCollection<TKey, TFileCollection, TFile>
        where TFile : DaFile<TKey, TFileCollection>
        where TDbContext : DbContext
    {
        public DaFileCollectionRepository(TDbContext dbContext)
            : base(dbContext)
        { }

        private DbSet<TFileCollection> FileCollections { get { return DbContext.Set<TFileCollection>(); } }

        public Task CreateAsync(TFileCollection fileCollection)
        {
            FileCollections.Add(fileCollection);
            return SaveChangesAsync();
        }

        public Task DeleteAsync(TFileCollection fileCollection)
        {
            FileCollections.Remove(fileCollection);
            return SaveChangesAsync();
        }

        public Task<TFileCollection> FindByIdAsync(TKey id)
        {
            return FileCollections.Where(m => m.Id.Equals(id)).SingleOrDefaultAsync();
        }

        public async Task RenameAsync(TKey id, string newName)
        {
            var fileCollection = await FileCollections.Where(m => m.Id.Equals(id)).SingleOrDefaultAsync();
            fileCollection.Name = newName;

            DbContext.Entry<TFileCollection>(fileCollection).State = EntityState.Modified;
            await SaveChangesAsync();
        }

        public async Task<DaPaginatedEntityList<TKey, TFileCollection>> FindByParentIdAsync(TKey parentId, DaDataPaginationCriteria paginationCriteria)
        {
            var totalCount = await FileCollections.Where(m => m.ParentId.Equals(parentId)).CountAsync();

            if (totalCount <= 0)
            {
                return null;
            }

            var query = FileCollections
                .Where(m => m.ParentId.Equals(parentId))
                .Skip((paginationCriteria.PageIndex - 1) * paginationCriteria.PageSize)
                .Take(paginationCriteria.PageSize)
                .AsQueryable();

            var result = await query.ToListAsync();

            return new DaPaginatedEntityList<TKey, TFileCollection>(result
                , new DaDataPaginationResult(paginationCriteria, totalCount));
        }

        public async Task<DaPaginatedEntityList<TKey, TFileCollection>> FindByObjectInstanceIdAsync(TKey objectInstanceId, DaDataPaginationCriteria paginationCriteria)
        {
            var totalCount = await FileCollections.Where(m => m.ObjectInstanceId.Equals(objectInstanceId)).CountAsync();

            if (totalCount <= 0)
            {
                return null;
            }

            var query = FileCollections
                .Where(m => m.ObjectInstanceId.Equals(objectInstanceId))
                .Skip((paginationCriteria.PageIndex - 1) * paginationCriteria.PageSize)
                .Take(paginationCriteria.PageSize)
                .AsQueryable();

            var result = await query.ToListAsync();

            return new DaPaginatedEntityList<TKey, TFileCollection>(result
                , new DaDataPaginationResult(paginationCriteria, totalCount));
        }
    }
}
