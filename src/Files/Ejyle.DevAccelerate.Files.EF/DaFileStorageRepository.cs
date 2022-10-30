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
    public class DaFileStorageRepository : DaFileStorageRepository<int, DaFileStorage, DaFileStorageLocation, DaFileStorageAttribute, DbContext>
    {
        public DaFileStorageRepository(DbContext dbContext)
            : base(dbContext)
        { }
    }


    public class DaFileStorageRepository<TKey, TFileStorage, TFileStorageLocation, TFileStorageAttribute, TDbContext>
        : DaEntityRepositoryBase<TKey, TFileStorage, TDbContext>, IDaFileStorageRepository<TKey, TFileStorage>
        where TKey : IEquatable<TKey>
        where TFileStorage : DaFileStorage<TKey, TFileStorageLocation, TFileStorageAttribute>
        where TFileStorageLocation : DaFileStorageLocation<TKey, TFileStorage>
        where TFileStorageAttribute : DaFileStorageAttribute<TKey, TFileStorage>
        where TDbContext : DbContext
    {
        public DaFileStorageRepository(TDbContext dbContext)
            : base(dbContext)
        { }

        private DbSet<TFileStorage> FileStorages { get { return DbContext.Set<TFileStorage>(); } }

        public Task CreateAsync(TFileStorage fileStorage)
        {
            FileStorages.Add(fileStorage);
            return SaveChangesAsync();
        }

        public Task DeleteAsync(TFileStorage fileStorage)
        {
            FileStorages.Remove(fileStorage);
            return SaveChangesAsync();
        }

        public Task<TFileStorage> FindByIdAsync(TKey id)
        {
            return FileStorages.Where(m => m.Id.Equals(id)).SingleOrDefaultAsync();
        }

        public async Task UpdateAsync(TFileStorage fileStorage)
        {
            DbContext.Entry<TFileStorage>(fileStorage).State = EntityState.Modified;
            await SaveChangesAsync();
        }

        public Task<TFileStorage> FindByNameAsync(string name)
        {
            return FileStorages.Where(m => m.Name.Equals(name)).SingleOrDefaultAsync();
        }
    }
}
