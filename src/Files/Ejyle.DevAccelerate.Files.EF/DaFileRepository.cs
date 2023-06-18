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
using System.Reflection.Metadata.Ecma335;

namespace Ejyle.DevAccelerate.Files.EF
{
    public class DaFileRepository : DaFileRepository<string, DaFile, DaFileCollection, DbContext>
    {
        public DaFileRepository(DbContext dbContext)
            : base(dbContext)
        { }
    }


    public class DaFileRepository<TKey, TFile, TFileCollection, TDbContext>
        : DaEntityRepositoryBase<TKey, TFile, TDbContext>, IDaFileRepository<TKey, TFile>
        where TKey : IEquatable<TKey>
        where TFileCollection : DaFileCollection<TKey, TFileCollection, TFile>
        where TFile : DaFile<TKey, TFileCollection>
        where TDbContext : DbContext
    {
        public DaFileRepository(TDbContext dbContext)
            : base(dbContext)
        { }

        private DbSet<TFile> FilesDbSet { get { return DbContext.Set<TFile>(); } }

        public IQueryable<TFile> Files => FilesDbSet.AsQueryable();

        public Task CreateAsync(TFile file)
        {
            FilesDbSet.Add(file);
            return SaveChangesAsync();
        }

        public Task DeleteAsync(TFile file)
        {
            FilesDbSet.Remove(file);
            return SaveChangesAsync();
        }

        public Task<TFile> FindByIdAsync(TKey id)
        {
            return FilesDbSet.Where(m => m.Id.Equals(id)).SingleOrDefaultAsync();
        }

        public Task<TFile> FindByGuidFileNameAsync(string guidFileName)
        {
            return FilesDbSet.Where(m => m.GuidFileName.Equals(guidFileName)).SingleOrDefaultAsync();
        }

        public async Task<DaPaginatedEntityList<TKey, TFile>> FindByFileCollectionIdAsync(TKey fileCollectionId, DaDataPaginationCriteria paginationCriteria)
        {
            var totalCount = await FilesDbSet.Where(m => m.FileCollectionId.Equals(fileCollectionId)).CountAsync();

            if (totalCount <= 0)
            {
                return null;
            }

            var query = FilesDbSet
                .Where(m => m.FileCollectionId.Equals(fileCollectionId))
                .Skip((paginationCriteria.PageIndex - 1) * paginationCriteria.PageSize)
                .Take(paginationCriteria.PageSize)
                .AsQueryable();

            var result = await query.ToListAsync();

            return new DaPaginatedEntityList<TKey, TFile>(result
                , new DaDataPaginationResult(paginationCriteria, totalCount));
        }

        public async Task<DaPaginatedEntityList<TKey, TFile>> FindByObjectInstanceIdAsync(TKey objectInstanceId, DaDataPaginationCriteria paginationCriteria)
        {
            var totalCount = await FilesDbSet.Where(m => m.ObjectIdentifier.Equals(objectInstanceId)).CountAsync();

            if (totalCount <= 0)
            {
                return null;
            }

            var query = FilesDbSet
                .Where(m => m.ObjectIdentifier.Equals(objectInstanceId))
                .Skip((paginationCriteria.PageIndex - 1) * paginationCriteria.PageSize)
                .Take(paginationCriteria.PageSize)
                .AsQueryable();

            var result = await query.ToListAsync();

            return new DaPaginatedEntityList<TKey, TFile>(result
                , new DaDataPaginationResult(paginationCriteria, totalCount));
        }

        public async Task RenameAsync(TKey id, string newName)
        {
            var file = await FilesDbSet.Where(m => m.Id.Equals(id)).SingleOrDefaultAsync();
            file.FileName = newName;

            DbContext.Entry<TFile>(file).State = EntityState.Modified;
            await SaveChangesAsync();
        }
    }
}
